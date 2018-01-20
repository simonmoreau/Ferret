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

            Console.Write(DateTime.Now.ToString() + ";" + clientURL);

            return recherche.pageMax ?? 1;
        }

        private async void RetriveFromURLAsync(string clientURL)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            Stream response = await client.GetStreamAsync(clientURL);

            XmlSerializer serializer = new XmlSerializer(typeof(recherche));
            //recherche recherche = (recherche)serializer.Deserialize(response);

            Console.Write(DateTime.Now.ToString() + ";" + clientURL);
        }

        private HousingUnit MapToHousingUnit(recherche recherche)
        {
            HousingUnit unit = new HousingUnit();

            return unit;
        }
    }
}
