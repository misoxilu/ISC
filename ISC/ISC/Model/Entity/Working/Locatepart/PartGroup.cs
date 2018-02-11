using ISC.Model.Entity.WorkingLocatepart;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace ISC.Model.Entity.Working.Locatepart
{
    public class PartGroup :Item
    {
        public List<PartItem> PartItems { get; set; }
    }
}
