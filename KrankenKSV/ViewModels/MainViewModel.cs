using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrankenKSV.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }

        
        public MainViewModel(){
            CurrentViewModel = new HomeViewModel();
        }
    }
}
