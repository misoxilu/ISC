using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using ISC.ViewModel.Base;

namespace ISC.ViewModel.Menus
{
    public class SensorstatusMenuViewmodel : Base.ViewModel
    {
        public RelayCommand SwitchEasybuilder => new RelayCommand(() => General.RaiseEventHandler(this, EventName.SwitchEasybuilder, null));

        public RelayCommand Popup_LogOnOffView => new RelayCommand(() => General.PopupView(Properties.Resources.LogOnOffView));
    }
}
