using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Model.Network
{
    public class SensorItem : Base.Notify
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; this.RaisePropertyChanged(nameof(Name)); }
        }

    }
}
