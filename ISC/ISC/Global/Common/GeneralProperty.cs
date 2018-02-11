using ISC.Global.Common.Enumeration;
using ISC.Model.Entity.Working.Initializations;
using ISC.Model.Entity.Working;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Effects;

namespace ISC.Global.Common
{
    public static partial class General
    {
        private static string initializationFilePath = $"{Environment.CurrentDirectory}{Properties.Resources.InitializationFilePath}";

        private static ResourceDictionary currentLanguageResource;

        private static Window UserControl { get; set; }

        public static Initialization Initialization { get; set; }

        public static Effect GrayEffect { get; set; } = General.FindResource<Effect>(Properties.Resources.GrayEffect);

        public static WorkingMode WorkingMode { get; set; }

        public static List<SensorGroup> SensorGroups { get; set; } = new List<SensorGroup> { new SensorGroup { Name = "传感器网络", SensorItems = new List<Item>() } };

    }
}
