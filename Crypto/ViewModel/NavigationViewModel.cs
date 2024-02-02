using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;
using Crypto.Model;
using Crypto.Util;

namespace Crypto.ViewModel
{
    public class NavigationViewModel : ViewModelBase
    {
        private object? _currentView;

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
        public RelayCommand AssetsViewCommand { get; set; }
        public RelayCommand SearchViewCommand { get; set; }

        public NavigationViewModel()
        {
            AssetsViewModel = new AssetsViewModel();
            SearchViewModel = new SearchViewModel();
            CurrentView = AssetsViewModel;
            AssetsViewCommand = new RelayCommand(_ =>
            {
                CurrentView = AssetsViewModel;
            }, _ =>
            {
                return true;
            });
            SearchViewCommand = new RelayCommand(_ =>
            {
                CurrentView = SearchViewModel;
            }, _ =>
            {
                return true;
            });
            Instance = this;
        }
    }
}
