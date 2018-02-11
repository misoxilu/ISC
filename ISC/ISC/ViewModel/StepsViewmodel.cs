using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using ISC.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.ViewModel
{
    public class StepsViewmodel:Base.ViewModel
    {
        public RelayCommand GetConnected => new RelayCommand(() =>
        {
            General.RaiseEventHandler(this, EventName.GetConnected, null);
        });
    }
}
