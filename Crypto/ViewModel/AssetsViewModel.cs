using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crypto.Util;
using Crypto.Services;
using Crypto.Model;

namespace Crypto.ViewModel
{
    public class AssetsViewModel : ViewModelBase
    {
        public static NavigationViewModel? NavigationViewModel { get; set; }
        public AssetDetailsViewModel? AssetDetailsViewModel { get; set; }
        public RelayCommand AssetDetailsCommand { get; set; }
        private readonly IAssetService assetService;
        private readonly IAssetMarketService assetMarketService;
        private List<Asset>? assets;

        public List<Asset>? Assets
        {
            get { return assets; }
            set
            {
                assets = value;
                OnPropertyChanged();
            }
        }

        public AssetsViewModel(IAssetService assetService, NavigationViewModel navigationViewModel, IAssetMarketService assetMarketService)
        {
            NavigationViewModel = navigationViewModel;
            this.assetService = assetService;
            this.assetMarketService = assetMarketService;
            AssetDetailsCommand = new RelayCommand(obj =>
            {
                var assetId = obj as string;

                if (assetId == null)
                {
                    return;
                }
                AssetDetailsViewModel = AssetDetailsViewModel.GetViewModel(assetId, this.assetService, this.assetMarketService);
                NavigationViewModel!.CurrentView = AssetDetailsViewModel;
            }, _ =>
            {
                return true;
            });

            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    Assets = await this.assetService.GetAssetsAsync();
                    await Task.Delay(10000);
                }
            });
        }
    }
}
