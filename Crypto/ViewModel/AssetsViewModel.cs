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
        public NavigationViewModel? NavigationViewModel { get; set; }
        private readonly IAssetService assetService;
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

        public AssetsViewModel(IAssetService assetService)
        {
            this.assetService = assetService;

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
