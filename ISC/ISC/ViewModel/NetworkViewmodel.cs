using ISC.Global.Common;
using ISC.Model.Network;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ISC.ViewModel
{
    public class NetworkViewmodel : Base.ViewModel
    {
        public BitmapImage Network { get; private set; } = General.FindIcon(nameof(Network));

        public BitmapImage Network2 { get; private set; } = General.FindIcon(nameof(Network2));

        public List<SensorGroup> SensorGroups { get; set; }= General.SensorGroups;

        public NetworkViewmodel()
        {
            this.RaisePropertyChanged(nameof(Network));
            this.RaisePropertyChanged(nameof(Network2));
            //var sensorItems = new List<SensorItem> { new SensorItem { Name = "传感器A" }, new SensorItem { Name = "传感器B" } };
            //this.SensorGroups = new List<SensorGroup> { new SensorGroup { Name = "In-Sight 传感器", SensorItems = sensorItems } };
            //this.RaisePropertyChanged(nameof(this.SensorGroups));
            
            var sensorItems = new ObservableCollection<SensorItem> { new SensorItem { Name = "传感器A" }, new SensorItem { Name = "传感器B" } };
            this.SensorGroups.Add(new SensorGroup { Name = "In-Sight 传感器", SensorItems = sensorItems });
            this.RaisePropertyChanged(nameof(this.SensorGroups));
        }
    }
}