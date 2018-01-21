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
    public class SeLogerRetriever : IRetriver
    {
        private readonly FerretContext _context;
        private TransactionType _transactionType;

        public SeLogerRetriever(FerretContext context)
        {
            _context = context;
        }

        public void Retrive()
        {
            string[] inseeCodes = { "750101", "750102", "750103", "750104", "750105", "750106" };

            foreach (string inseeCode in inseeCodes)
            {
                RetriveFromLocationAsync(inseeCode);
            }
        }

        private async void RetriveFromLocationAsync(string localisation)
        {
            _transactionType = TransactionType.rent;

            string clientURL = $"http://ws.seloger.com/search.xml?ci={localisation}&idtt=1";

            int pageNumber = await RetrivePageFromURLAsync(clientURL);

            //If the result is paginated
            if (pageNumber > 1)
            {
                for (int i = 2; i <= pageNumber; i++)
                {
                    string paginatedClientUrl = clientURL + $"&SEARCHpg={i.ToString()}";
                    RetriveFromURLAsync(paginatedClientUrl);
                }
            }
        }

        private async Task<int> RetrivePageFromURLAsync(string clientURL)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            Stream response = await client.GetStreamAsync(clientURL);

            XmlSerializer serializer = new XmlSerializer(typeof(recherche));
            recherche recherche = (recherche)serializer.Deserialize(response);
            UpdateDb(recherche);
            
            Log(clientURL);

            return recherche.pageMax ?? 1;
        }

        private async void RetriveFromURLAsync(string clientURL)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            Stream response = await client.GetStreamAsync(clientURL);

            XmlSerializer serializer = new XmlSerializer(typeof(recherche));
            recherche recherche = (recherche)serializer.Deserialize(response);
            UpdateDb(recherche);

            Log(clientURL);
        }

        private void UpdateDb(recherche recherche)
        {
            foreach (rechercheAnnonce rechercheAnnonce in recherche.annonces)
            {
                HousingUnit existingHousingUnit = _context.HousingUnits.FirstOrDefault(t => t.Id == rechercheAnnonce.idAgence);
                if (existingHousingUnit == null)
                {
                    //Create an new HousingUnit
                    HousingUnit unit = MapToHousingUnit(rechercheAnnonce);
                    _context.HousingUnits.Add(unit);
                    _context.SaveChanges();
                }
                else
                {
                    //Update the date
                    existingHousingUnit.RefreshDate = DateTime.Now;
                    _context.HousingUnits.Update(existingHousingUnit);
                    _context.SaveChanges();
                }
            }
        }
        private HousingUnit MapToHousingUnit(rechercheAnnonce annonce )
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
                Coordinates = new Coordinates(annonce.latitude ?? 0, annonce.longitude ?? 0),
                ConstructionYear = annonce.anneeconstruct ?? 0,
                RoomNumber = annonce.nbPiece ?? 0,
                BedroomNumber = annonce.nbChambre ?? 0,
                WCNumber = annonce.nbtoilettes ?? 0,
                BathroomNumber = (annonce.nbsallesdebain ?? 0) + (annonce.nbsalleseau ?? 0),
                ParkingNumber = annonce.nbparkings ?? 0,
                BoxNumber = annonce.nbboxes ?? 0,
                BalconiesNumber = annonce.nbterrasses ?? 0,
                SwimmingPool = annonce.sipiscine ?? false
            };

            return unit;
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
