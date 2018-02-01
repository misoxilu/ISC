using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ISC.Model.Working
{
   public class SensorGroup
    {
        public string Name { get; set; }

        public BitmapImage Image { get; set; }

        public List<SensorItem> SensorItems { get; set; }
    }
}
