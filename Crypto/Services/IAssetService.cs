using Crypto.Model;

namespace Crypto.Services
{
    public interface IAssetService
    {
        Task<List<Asset>?> GetAssetsAsync();
        Task<Asset>? GetAssetByIdAsync(string id);
    }
}
