using Crypto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Crypto.Util;
using Crypto.Services.Responses;

namespace Crypto.Services
{
    public class AssetService : IAssetService
    {
        private readonly IApiService apiService;

        public AssetService(IApiService apiService)
        {
            this.apiService = apiService;
        }
        public async Task<List<Asset>?> GetAssetsAsync()
        {
            string? apiUrl = "assets?limit=10";
            var response = await apiService.GetResponse(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                var assets = JsonConvert.DeserializeObject<AssetsResponse>(responseBody);

                if (assets != null)
                {
                    return assets.Data;
                }
            }
            return null;
        }
        public async Task<Asset>? GetAssetByIdAsync(string id)
        {
            string? apiUrl = $"assets/{id}";
            var response = await apiService.GetResponse(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                var asset = JsonConvert.DeserializeObject<AssetResponse>(responseBody);

                if (asset != null)
                {
                    return asset.Data;
                }
            }
            return null;
        }
        public async Task<List<Asset>?> SearchAssetsAsync(string param)
        {
            string? apiUrl = $"assets?search={param}";
            var response = await apiService.GetResponse(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                var assets = JsonConvert.DeserializeObject<AssetsResponse>(responseBody);

                if (assets != null)
                {
                    return assets.Data;
                }
            }
            return null;
        }
    }
}
