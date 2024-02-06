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
    public class SearchViewModel : ViewModelBase
    {
        public static NavigationViewModel? NavigationViewModel { get; set; }
        public AssetDetailsViewModel? AssetDetailsViewModel { get; set; }
        public RelayCommand AssetDetailsCommand { get; set; }
        private readonly IAssetService assetService;
        private List<Asset>? assets;
        private string? searchParam;
        public RelayCommand SearchCommand { get; set; }
        public List<Asset>? Assets
        {
            get { return assets; }
            set
            {
                assets = value;
                OnPropertyChanged();
            }
        }
        public string? SearchParam
        {
            get { return searchParam; }
            set
            {
                searchParam = value;
                OnPropertyChanged();
            }
        }

        public SearchViewModel(IAssetService assetService, NavigationViewModel navigationViewModel)
        {
            NavigationViewModel = navigationViewModel;
            this.assetService = assetService;
            SearchCommand = new RelayCommand(async _ =>
            {
                Assets = await this.assetService.SearchAssetsAsync(SearchParam);
            }, _ =>
            {
                return true;
            });

            AssetDetailsCommand = new RelayCommand(obj =>
            {
                var assetId = obj as string;

                if (assetId == null)
                {
                    return;
                }
                AssetDetailsViewModel = AssetDetailsViewModel.GetViewModel(assetId, this.assetService);
                NavigationViewModel!.CurrentView = AssetDetailsViewModel;
            }, _ =>
            {
                return true;
            });
        }
    }
}
