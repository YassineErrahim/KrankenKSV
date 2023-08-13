using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrankenKSV.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        //to tell the ui what bindings to update
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            //tel ui whenever the property value has changed so that the views can regrabe the value and update the ui
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
