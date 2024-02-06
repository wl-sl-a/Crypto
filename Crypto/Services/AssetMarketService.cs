using Crypto.Model;
using Crypto.Services.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Services
{
    public class AssetMarketService : IAssetMarketService
    {
        private readonly IApiService apiService;

        public AssetMarketService(IApiService apiService)
        {
            this.apiService = apiService;
        }
        public async Task<List<AssetMarket>?> GetAssetMarketsAsync(string assetId)
        {
            string? apiUrl = $"markets?baseId={assetId}";
            var response = await apiService.GetResponse(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                var assets = JsonConvert.DeserializeObject<AssetMarketsResponse>(responseBody);

                if (assets != null)
                {
                    return assets.Data;
                }
            }
            return null;
        }
    }
}
