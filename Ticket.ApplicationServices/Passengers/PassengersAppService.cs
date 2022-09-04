using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticket.Core.Passengers;

namespace Ticket.ApplicationServices.Passengers
{
    public class PassengersAppService : IPassengersAppService
    {
        private readonly IHttpClientFactory _clientFactory;

        public PassengersAppService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Passenger> GetPassenger(int id)
        {
            HttpClient client = _clientFactory.CreateClient("passenger");

            HttpResponseMessage response;
            string url = "passengers";

            response = await client.GetAsync($"{url}/{id}");

            Passenger passenger;

            if (response.IsSuccessStatusCode)
            {
                passenger = Newtonsoft.Json.JsonConvert.DeserializeObject<Passenger>(await response.Content.ReadAsStringAsync());
                return passenger;
            }
            else
            {
                return null;
            }
        }
    }
}
