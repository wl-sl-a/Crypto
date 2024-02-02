using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crypto.Util;

namespace Crypto.ViewModel
{
    public class AssetsViewModel : ViewModelBase
    {
        public NavigationViewModel? NavigationViewModel { get; set; }
        

        public AssetsViewModel()
        {
            NavigationViewModel = NavigationViewModel.Instance;
        }
    }
}
