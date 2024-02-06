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
        private Asset? asset;
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

        public string AssetId
        {
            get { return assetId; }
        }

        public AssetDetailsViewModel(IAssetService assetService)
        {
            this.assetService = assetService;
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    Asset = await this.assetService.GetAssetByIdAsync(assetId);
                    await Task.Delay(10000);
                }
            });
        }

        public static AssetDetailsViewModel GetViewModel(string id, IAssetService assetService)
        {
            assetId = id;
            return new AssetDetailsViewModel(assetService);
        }
    }
}
