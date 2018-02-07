using ISC.Global.Common.Enumeration;
using ISC.Model.Working;
using System.Collections.Generic;
using System.Windows.Media.Effects;

namespace ISC.Global.Common
{
    public static partial class General
    {
        public static Effect GrayEffect { get; set; } = General.FindResource("GrayEffect") as Effect;

        public static WorkingMode WorkingMode { get; set; }

        public static List<SensorGroup> SensorGroups { get; set; } = new List<SensorGroup> { new SensorGroup { Name = "传感器网络", SensorItems = new List<Item>() } };

    }
}
