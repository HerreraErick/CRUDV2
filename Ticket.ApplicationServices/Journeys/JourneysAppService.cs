using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.ApplicationServices.Journeys
{
    public class JourneysAppService : IJourneysAppService
    {
        private readonly IHttpClientFactory _clientFactory;
       
        public JourneysAppService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
 
        public async Task<ticket.Core.Journeys.Journey> GetJourney(int id)
        {
            HttpClient client = _clientFactory.CreateClient("journey");

            HttpResponseMessage response;
            string url = "journeys";

            response = await client.GetAsync($"{url}/{id}");

            ticket.Core.Journeys.Journey journey;

            if (response.IsSuccessStatusCode)
            {
                journey = Newtonsoft.Json.JsonConvert.DeserializeObject<ticket.Core.Journeys.Journey>(await response.Content.ReadAsStringAsync());
                return journey;
            }
            else
            {
                return null;
            }
        }
    }
}
