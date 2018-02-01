using ISC.Global.Common.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ISC.Model.Working
{
    public abstract class Item : Base.Notify
    {
        public string Name { get; set; }

        public BitmapImage Icon { get; set; }

        public Item(string name, BitmapImage cion)
        {
            this.Name = name;
            this.Icon = Icon;
        }

        public DirectoryRank Rank { get; set; }

        public Item()
        {
        }
    }
}
