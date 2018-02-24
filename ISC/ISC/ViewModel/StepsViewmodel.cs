using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using ISC.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ISC.ViewModel
{
    public class StepsViewmodel:Base.ViewModel
    {
        public RelayCommand GetConnected => new RelayCommand(() =>
        {
            General.RaiseEventHandler(this, EventName.GetConnected, null);
        });

        public RelayCommand StackPanelSizeChanged => new RelayCommand((o)=> 
        {
            var StackPanel = (StackPanel)o;
        });
    }
}
