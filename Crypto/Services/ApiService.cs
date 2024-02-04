using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Crypto.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient? _httpClient;
        private readonly string baseUrl;
        public ApiService()
        {
            baseUrl = "https://api.coincap.io/v2/";
            _httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage?> GetResponse(string url)
        {
            var response = await _httpClient.GetAsync(baseUrl+url);
            return response;
        }
    }
}
