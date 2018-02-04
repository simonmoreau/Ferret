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
            this.HousingUnits = housingUnits;
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

        public bool Retrive()
        {
            string[] inseeCodes = { "750101", "750102", "750103", "750104", "750105", "750106" };
            string[] cp = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "‍2A", "‍2B", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "971", "972", "973", "974", "976" };

            //List<Task<List<HousingUnit>>> tasks = new List<Task<List<HousingUnit>>>();
            //List<HousingUnit> housingUnits = new List<HousingUnit>();

            foreach (string localisation in cp)
            {
                List<HousingUnit> currentHousingUnits = RetriveFromLocationAsync("cp=" + localisation).Result;
                //housingUnits.AddRange();
                if (currentHousingUnits.Count != 0)
                {
                    try
                    {
                        _context.HousingUnits.AddRange(currentHousingUnits);
                        _context.SaveChanges();
                        Log(localisation + $";Adding {currentHousingUnits.Count} Housing Units to the DB");
                    }
                    catch (Exception e)
                    {
                        Log(localisation + $";Error Adding {currentHousingUnits.Count} Housing Units to the DB : " + e.Message);
                    }

                }
            }

            return true;

            // foreach (Task<List<HousingUnit>> unitsTask in tasks)
            // {
            //     List<HousingUnit> housingUnitsFromTask = await unitsTask;
            //     //Add it to the total
            //     housingUnits.AddRange(housingUnitsFromTask);
            //     Log("Units added to the main list;" + "taskId = " + unitsTask.Id.ToString());
            // }



            // foreach (HousingUnit housingUnit in housingUnits)
            // {
            //     HousingUnit existingHousingUnit = (HousingUnit)_context.HousingUnits.FirstOrDefault(h => h.sourceId == housingUnit.sourceId);

            //     if (existingHousingUnit == null)
            //     {
            //         //Create a new reccord
            //         _context.HousingUnits.Add(housingUnit);
            //         _context.SaveChanges();
            //     }
            // }

        }

        private async Task<List<HousingUnit>> RetriveFromLocationAsync(string localisation)
        {
            _transactionType = TransactionType.rent;
            List<HousingUnit> housingUnits = new List<HousingUnit>();

            string clientURL = $"http://ws.seloger.com/search.xml?{localisation}&idtt=1";

            Page firstPage = await RetrivePageFromURLAsync(clientURL);
            if (firstPage.HousingUnits != null)
            {
                housingUnits.AddRange(firstPage.HousingUnits);
            }

            int pageNumber = firstPage.PageMax;


            //If the result is paginated
            if (pageNumber > 1)
            {
                int[] pageNumbers = Enumerable.Range(2, pageNumber).ToArray();

                Parallel.ForEach(pageNumbers, (currentPage) =>
                                {
                                    string paginatedClientUrl = clientURL + $"&SEARCHpg={currentPage.ToString()}";

                                    Page page = RetrivePageFromURLAsync(paginatedClientUrl).Result;
                                    if (page.HousingUnits != null)
                                    {
                                        housingUnits.AddRange(page.HousingUnits);
                                    }
                                    else
                                    {
                                        Log("Null housing Unist;" + paginatedClientUrl);
                                    }
                                });

                // List<Task<Page>> tasks = new List<Task<Page>>();

                // for (int i = 2; i <= pageNumber; i++)
                // {
                //     Parallel.ForEach()


                //     if (i % 10 == 0)
                //     {
                //         foreach (Task<Page> task in tasks)
                //         {

                //         }
                //         tasks.Clear();
                //     }
                // }
            }

            return housingUnits;

        }

        private async Task<Page> RetrivePageFromURLAsync(string clientURL)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            HttpResponseMessage response = await client.GetAsync(clientURL);
            if (response.IsSuccessStatusCode)
            {
                using (Stream stream = await response.Content.ReadAsStreamAsync())
                {

                    XmlSerializer serializer = new XmlSerializer(typeof(recherche));
                    recherche recherche = (recherche)serializer.Deserialize(stream);

                    if (recherche.annonces != null)
                    {
                        List<HousingUnit> housingUnits = RetriveHousingUnits(recherche);

                        Log("RetrivePageFromURLAsync;" + clientURL + ";" + housingUnits.Count().ToString());

                        int? pageNum = Convert.ToInt32(recherche.pageMax);

                        return new Page(pageNum ?? 1, housingUnits);
                    }
                    else
                    {
                        return new Page(1, null);
                    }
                }
            }
            else
            {
                return new Page(1, null);
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
                sourceId = annonce.idAnnonce,
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
