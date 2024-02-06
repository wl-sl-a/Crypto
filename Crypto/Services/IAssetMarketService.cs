using Crypto.Model;

namespace Crypto.Services
{
    public interface IAssetMarketService
    {
        Task<List<AssetMarket>?> GetAssetMarketsAsync(string assetId);
    }
}
