using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crypto.Model;
using Crypto.Services;
using Crypto.Util;

namespace Crypto.ViewModel
{
    public class AssetDetailsViewModel : ViewModelBase
    {
        public NavigationViewModel? NavigationViewModel { get; set; }

        private readonly IAssetService assetService;
        private readonly IAssetMarketService assetMarketService;

        private Asset? asset;
        private List<AssetMarket> assetMarkets;
        private static string? assetId;

        public Asset? Asset
        {
            get { return asset; }
            set
            {
                asset = value;
                OnPropertyChanged();
            }
        }
        public List<AssetMarket>? AssetMarkets
        {
            get { return assetMarkets; }
            set
            {
                assetMarkets = value;
                OnPropertyChanged();
            }
        }

        public string AssetId
        {
            get { return assetId; }
        }

        public AssetDetailsViewModel(IAssetService assetService, IAssetMarketService assetMarketService)
        {
            this.assetService = assetService;
            this.assetMarketService = assetMarketService;
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    Asset = await this.assetService.GetAssetByIdAsync(assetId);
                    await Task.Delay(10000);
                }
            });

            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    AssetMarkets = await this.assetMarketService.GetAssetMarketsAsync(assetId);
                    await Task.Delay(10000);
                }
            });
            this.assetMarketService = assetMarketService;
        }

        public static AssetDetailsViewModel GetViewModel(string id, IAssetService assetService, IAssetMarketService assetMarketService)
        {
            assetId = id;
            return new AssetDetailsViewModel(assetService, assetMarketService);
        }
    }
}
