using ISC.Global.Common.Enumeration;
using ISC.Model.Working;
using System.Collections.Generic;

namespace ISC.Global.Common
{
    public static partial class General
    {
        public static WorkingMode WorkingMode { get; set; }

        public static List<SensorGroup> SensorGroups { get; set; } = new List<SensorGroup>();

    }
}
