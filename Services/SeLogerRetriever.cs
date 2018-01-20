using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Ferret.Models;

namespace Ferret.Services
{
    public class SeLogerRetriever : IRetriver
    {
        public SeLogerRetriever()
        {
        }
        public async Task Retrive(string localisation)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            string clientURL = $"http://ws.seloger.com/search.xml?ci={localisation}&idtt=1";

            Task<HttpResponseMessage> response = client.GetAsync(clientURL);

            string msg = await response.Result.Content.ReadAsStringAsync();

            Console.Write(msg);
        }
    }
}
