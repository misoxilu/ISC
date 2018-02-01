using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ISC.Model.Working
{
    public class SensorItem : Base.Notify
    {
        public string Name { get; set; }

        public BitmapImage Image { get; set; }

        public string Path { get; set; }

        public List<File> Files { get; set; }


    }
}
