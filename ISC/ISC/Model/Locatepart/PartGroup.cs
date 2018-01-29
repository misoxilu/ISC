using ISC.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ISC.Model.Locatepart
{
    public class PartGroup 
    {
        public string Name { get; set; }

        public BitmapImage BitmapImage { get; set; }

        public List<PartItem> PartItems { get; set; }
    }
}
