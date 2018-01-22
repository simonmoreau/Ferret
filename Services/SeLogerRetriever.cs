using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Ferret.Models;
using System.Xml.Serialization;

namespace Ferret.Services
{
    class Page
    {
        public Page(int pageMax, List<HousingUnit> housingUnits)
        {
            this.PageMax = pageMax;
            this.HousingUnits = HousingUnits;
        }
        public int PageMax { get; set; }
        public List<HousingUnit> HousingUnits { get; set; }
    }

    public class SeLogerRetriever : IRetriver
    {
        private readonly FerretContext _context;
        private TransactionType _transactionType;

        public SeLogerRetriever(FerretContext context)
        {
            this._context = context;
        }

        public async void Retrive()
        {
            string[] inseeCodes = { "750101", "750102", "750103", "750104", "750105", "750106" };

            List<Task<List<HousingUnit>>> tasks = new List<Task<List<HousingUnit>>>();
            List<HousingUnit> housingUnits = new List<HousingUnit>();

            foreach (string inseeCode in inseeCodes)
            {
                List<HousingUnit> units = await RetriveFromLocationAsync(inseeCode);
                Log(inseeCode);

                //Add it to the total
                housingUnits.AddRange(units);
            }

            Log("End of main loop");

        }

        private async Task<List<HousingUnit>> RetriveFromLocationAsync(string localisation)
        {
            _transactionType = TransactionType.rent;
            List<HousingUnit> housingUnits = new List<HousingUnit>();

            string clientURL = $"http://ws.seloger.com/search.xml?ci={localisation}&idtt=1";

            Page firstPage = await RetrivePageFromURLAsync(clientURL);
            if (firstPage != null)
            {
                if (firstPage.HousingUnits != null)
                {
                    if (firstPage.HousingUnits.Count != 0)
                    {
                        housingUnits.AddRange(firstPage.HousingUnits);
                    }
                }
                else
                {
                    Log("firstPage.HousingUnits is null;" + clientURL);
                }

            }
            else
            {
                Log("First page is null;" + clientURL);
            }

            int pageNumber = firstPage.PageMax;

            //If the result is paginated
            if (pageNumber > 1)
            {
                List<Task<Page>> tasks = new List<Task<Page>>();

                for (int i = 2; i <= pageNumber; i++)
                {
                    string paginatedClientUrl = clientURL + $"&SEARCHpg={i.ToString()}";
                    //tasks.Add(RetrivePageFromURLAsync(paginatedClientUrl));
                }

                foreach (Task<Page> task in tasks)
                {
                    Page page = await task;
                    housingUnits.AddRange(page.HousingUnits);
                }
            }

            return housingUnits;

        }

        private async Task<Page> RetrivePageFromURLAsync(string clientURL)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            using (Stream response = await client.GetStreamAsync(clientURL))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(recherche));
                recherche recherche = (recherche)serializer.Deserialize(response);

                List<HousingUnit> housingUnits = RetriveHousingUnits(recherche);

                Log("RetrivePageFromURLAsync;" + clientURL + ";" + housingUnits.Count().ToString());

                return new Page(recherche.pageMax ?? 1, housingUnits);
            }
        }

        private List<HousingUnit> RetriveHousingUnits(recherche recherche)
        {
            List<HousingUnit> units = new List<HousingUnit>();
            foreach (rechercheAnnonce rechercheAnnonce in recherche.annonces)
            {
                units.Add(MapToHousingUnit(rechercheAnnonce));
            }

            return units;
        }
        private HousingUnit MapToHousingUnit(rechercheAnnonce annonce)
        {
            HousingUnit unit = new HousingUnit
            {
                Id = annonce.idAnnonce,
                TransactionType = _transactionType,
                HousingType = SelectHousingType(annonce.idTypeBien),
                CreationDate = annonce.dtCreation,
                RefreshDate = annonce.dtCreation,
                Description = annonce.descriptif,
                Price = annonce.prix ?? 0,
                Area = annonce.surface ?? 0,
                Latitude = annonce.latitude ?? 0,
                Longitude = annonce.longitude ?? 0,
                ConstructionYear = ConvertIntFromString(annonce.anneeconstruct),
                RoomNumber = ConvertIntFromString(annonce.nbPiece),
                BedroomNumber = ConvertIntFromString(annonce.nbChambre),
                WCNumber = ConvertIntFromString(annonce.nbtoilettes),
                BathroomNumber = ConvertIntFromString(annonce.nbsallesdebain) + ConvertIntFromString(annonce.nbsalleseau),
                ParkingNumber = ConvertIntFromString(annonce.nbparkings),
                BoxNumber = ConvertIntFromString(annonce.nbboxes),
                BalconiesNumber = ConvertIntFromString(annonce.nbterrasses),
                SwimmingPool = ConvertBoolFromString(annonce.sipiscine)
            };

            return unit;
        }

        private async void UpdateDb(rechercheAnnonce rechercheAnnonce)
        {
            HousingUnit existingHousingUnit = (HousingUnit)await _context.FindAsync(typeof(HousingUnit), (long)rechercheAnnonce.idAnnonce);
            if (existingHousingUnit == null)
            {
                //Create an new HousingUnit
                HousingUnit unit = MapToHousingUnit(rechercheAnnonce);
                await _context.HousingUnits.AddAsync(unit);
                await _context.SaveChangesAsync();
            }
            else
            {
                //Update the date
                existingHousingUnit.RefreshDate = DateTime.Now;
                _context.HousingUnits.Update(existingHousingUnit);
                await _context.SaveChangesAsync();
            }
        }
        private int ConvertIntFromString(string input)
        {
            int value = 0;
            int.TryParse(input, out value);
            return value;
        }

        private bool ConvertBoolFromString(string input)
        {
            bool value = false;
            bool.TryParse(input, out value);
            return value;
        }
        private HousingType SelectHousingType(int? idTypeBien)
        {
            switch (idTypeBien)
            {
                case 1:
                    return HousingType.appartment;
                case 2:
                    return HousingType.house;
                default:
                    return HousingType.undefined;
            }
        }
        private void Log(string value)
        {
            string path = @"/Users/smoreau/Documents/Github/Ferret/Logs/logs";
            List<string> logs = new List<string>();
            logs.Add(DateTime.Now + ";" + value);
            File.AppendAllLines(path, logs);
        }
    }


}
