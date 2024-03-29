﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;
using Crypto.Model;
using Crypto.Services;
using Crypto.Util;

namespace Crypto.ViewModel
{
    public class NavigationViewModel : ViewModelBase
    {
        private object? _currentView;
        private readonly IAssetService assetService;
        private readonly IAssetMarketService assetMarketService;
        public object? CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public static NavigationViewModel? Instance { get; set; }
        public AssetsViewModel AssetsViewModel { get; set; }
        public SearchViewModel SearchViewModel { get; set; }
        public AssetDetailsViewModel AssetDetailsViewModel { get; set; }

        public ICommand AssetsViewCommand { get; set; }
        public ICommand SearchViewCommand { get; set; }
        public ICommand AssetDetailsViewCommand { get; set; }
        public ICommand ExitCommand { get; set; }


        private void Assets(object obj) => CurrentView = new AssetsViewModel(this.assetService, this, this.assetMarketService);
        private void Search(object obj) => CurrentView = new SearchViewModel(this.assetService, this, this.assetMarketService);
        private void AssetDetails(object obj) => CurrentView = new AssetDetailsViewModel(this.assetService, this.assetMarketService);


        public NavigationViewModel(IAssetService assetService, IAssetMarketService assetMarketService)
        {
            this.assetService = assetService;
            this.assetMarketService = assetMarketService;
            AssetsViewCommand = new RelayCommand(Assets);
            SearchViewCommand = new RelayCommand(Search);
            AssetDetailsViewCommand = new RelayCommand(AssetDetails);

            ExitCommand = new RelayCommand(_ =>
            {
                App.Current.MainWindow.Close();
            }, _ =>
            {
                return true;
            });

            CurrentView = new AssetsViewModel(this.assetService, this, this.assetMarketService);
        }

        
    }
}
