using CustomerBooking.Service.ExternalClients.DriverApp.Requests;
using CustomerBooking.Service.ExternalClients.DriverApp.Responses;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RequestHandlers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBooking.Service.ExternalClients.DriverApp
{
    public class DriverAppClient : IDriverAppClient
    {
        private readonly HttpClient _httpClient;

        public DriverAppClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            
            _httpClient.BaseAddress = new Uri(configuration.GetSection("ExternalUris")["DriverAppApiUri"]);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HandlerResponse<AddJobResponse>> AddJob(AddJobRequest request)
        {
            var apiRequest = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"api/job", apiRequest);

            return new HandlerResponse<AddJobResponse>()
            {
                StatusCode = response.StatusCode,
                Success = response.IsSuccessStatusCode,
                ErrorResponse = response.IsSuccessStatusCode ? null : new ErrorResponse { ErrorMessage = new List<string> { await response.Content.ReadAsStringAsync() } },
                SuccessResponse = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<AddJobResponse>(await response.Content.ReadAsStringAsync()) : null
            };
        }

        public async Task<HandlerResponse> CancelJob(CancelJobRequest request)
        {
            var response = await _httpClient.DeleteAsync($"api/job{request.JobId}");

            return new HandlerResponse()
            {
                StatusCode = response.StatusCode,
                Success = response.IsSuccessStatusCode,
                ErrorResponse = response.IsSuccessStatusCode ? null : new ErrorResponse { ErrorMessage = new List<string> { await response.Content.ReadAsStringAsync() } }
            };
        }
    }
}
