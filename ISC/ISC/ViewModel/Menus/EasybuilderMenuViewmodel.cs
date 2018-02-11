using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using ISC.Model.Entity.Working;
using ISC.ViewModel.Base;
using System.Collections.Generic;
using System.Windows.Media.Effects;

namespace ISC.ViewModel.Menus
{
    public class EasybuilderMenuViewmodel : Base.ViewModel
    {
        private bool testGray = false;

        private Effect openEffect = null;
        public Effect OpenEffect
        {
            get { return openEffect; }
            set
            {
                openEffect = value;
                this.RaisePropertyChanged(nameof(OpenEffect));
            }
        }

        private bool isShowNetworkPane = true;
        private bool isShowFilePane = true;

        public List<SensorGroup> SensorGroups { get; set; } = General.SensorGroups;

        public RelayCommand SwitchNetworkPane => new RelayCommand(() =>
         {
             this.isShowNetworkPane = !this.isShowNetworkPane;
             if (this.isShowNetworkPane) General.FindPane(Properties.Resources.NetworkView).Show();
             else General.FindPane(Properties.Resources.NetworkView).Hide();
         });

        public RelayCommand SwitchFilePane => new RelayCommand(() =>
        {
            this.isShowFilePane = !this.isShowFilePane;
            if (this.isShowFilePane) General.FindPane(Properties.Resources.FileView).Show();
            else General.FindPane(Properties.Resources.FileView).Hide();
        });

        public RelayCommand SwitchSensorstatus => new RelayCommand(() =>
        {
            General.RaiseEventHandler(this, EventName.SwitchSensorstatus, null);
        });

        public RelayCommand OpenFile => new RelayCommand(() =>
        {
            this.testGray = !this.testGray;
            if (this.testGray) this.OpenEffect = General.GrayEffect;
            else this.OpenEffect = null;
        });

        public RelayCommand Popup_RecordPlaybackOptionsView =>
            new RelayCommand(() => General.RaiseEventHandler(this, EventName.PopupWindow, Properties.Resources.RecordPlaybackOptionsView));
    }
}
