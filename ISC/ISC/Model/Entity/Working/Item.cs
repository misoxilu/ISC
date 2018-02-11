using ISC.Global.Common.Enumeration;
using ISC.Model.Entity.Base;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ISC.Model.Entity.Working
{
    public abstract class Item : Notify
    {
        public string Name { get; set; }

        public BitmapImage Icon { get; set; }

        public Item(string name, BitmapImage cion)
        {
            this.Name = name;
            this.Icon = Icon;
        }

        public Visibility State { get; set; }

        public DirectoryRank Rank { get; set; }

        public Item()
        {
        }
    }
}
