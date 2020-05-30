using CustomerBooking.Service.ExternalClients.Payment.Requests;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OrchestrationDemo.Handlers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBooking.Service.ExternalClients.Payment
{
    public class PaymentClient : IPaymentClient
    {
        private readonly HttpClient _httpClient;

        public PaymentClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri(configuration.GetSection("ExternalUris")["PaymentApiUri"]);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HandlerResponse> ChargeCustomer(ChargeRequest request)
        {
            var apiRequest = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"api/transaction", apiRequest);

            return new HandlerResponse()
            {
                StatusCode = response.StatusCode,
                Success = response.IsSuccessStatusCode,
                ErrorResponse = response.IsSuccessStatusCode ? null : new ErrorResponse { ErrorMessage = new List<string> { await response.Content.ReadAsStringAsync() } }
            };
        }
    }
}
