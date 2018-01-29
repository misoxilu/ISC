using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using ISC.Model.Network;
using ISC.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ISC.ViewModel.Menus
{
    public class EbmViewmodel : Base.ViewModel
    {
        private bool isShowNetworkPane = true;

        public List<SensorGroup> SensorGroups { get; set; } = General.SensorGroups;

        public RelayCommand SwitchNetworkPane => new RelayCommand(() =>
         {
             //SensorGroups[0].SensorItems[0].Name = "changed";
             this.isShowNetworkPane = !this.isShowNetworkPane;
             General.SwitchPane(Properties.Resources.NetworkPane, this.isShowNetworkPane ? PaneState.Show : PaneState.Hide);
         });

        public RelayCommand SwitchSensorstatus => new RelayCommand(() =>
        {
            General.RaiseEventHandler(this, EventName.SwitchSensorstatus, null);
        });

        public RelayCommand OpenFile => new RelayCommand(()=> 
        {
           
        });
    }
}
