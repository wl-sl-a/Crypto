using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crypto.Util;

namespace Crypto.ViewModel
{
    public class SearchViewModel : ViewModelBase
    {
        public NavigationViewModel? NavigationViewModel { get; set; }


        public SearchViewModel()
        {
            NavigationViewModel = NavigationViewModel.Instance;
        }
    }
}
