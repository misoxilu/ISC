using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using ISC.ViewModel.Base;

namespace ISC.ViewModel.Menus
{
    public class SsmViewmodel : Base.ViewModel
    {
        public RelayCommand SwitchEasybuilder => new RelayCommand(() =>
        {
            General.RaiseEventHandler(this, EventName.SwitchEasybuilder, null);
        });

        public RelayCommand Login => new RelayCommand(() =>
        {
            General.PopupView("LoginView");
        });
    }
}
