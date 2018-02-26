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

        private Visibility _state;
        public Visibility State
        {
            get { return _state; }
            set
            {
                _state = value;
                this.RaisePropertyChanged(nameof(State));
            }
        }

        public DirectoryRank Rank { get; set; }

        public Item()
        {
        }
    }
}
