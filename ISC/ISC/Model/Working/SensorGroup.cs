using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ISC.Model.Working
{
   public class SensorGroup:Item
    {
        public List<Item> SensorItems { get; set; }
    }
}
