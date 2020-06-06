using CustomerBooking.Service.ExternalClients.CostCalculation.Requests;
using CustomerBooking.Service.ExternalClients.CostCalculation.Responses;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RequestHandlers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBooking.Service.ExternalClients.CostCalculation
{
    public class CostCalculationClient : ICostCalculationClient
    {
        private readonly HttpClient _httpClient;

        public CostCalculationClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration.GetSection("ExternalUris")["CostCalculationApiUri"]);
        }

        public async Task<HandlerResponse<GetJourneyCostResponse>> GetJourneyCost(GetJourneyCostRequest request)
        {
            var response = await _httpClient.GetAsync($"api/journey/cost/from/{request.PickupPostcode}/to/{request.DestinationPostcode}");
            var content = await response.Content.ReadAsStringAsync();

            return new HandlerResponse<GetJourneyCostResponse>()
            {
                StatusCode = response.StatusCode,
                Success = response.IsSuccessStatusCode,
                ErrorResponse = response.IsSuccessStatusCode ? null : new ErrorResponse { ErrorMessage = new List<string> { content } },
                SuccessResponse = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<GetJourneyCostResponse>(content) : null
            };
        }
    }
}
