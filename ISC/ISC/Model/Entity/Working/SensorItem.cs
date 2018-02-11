using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ISC.Model.Entity.Working
{
    public class SensorItem : File
    {
        public string Path { get; set; }

        public List<Item> Files { get; set; }

        public SensorItem(string name, string path)
        {
            this.Name = name;

            this.Icon = General.FindIconResource(Properties.Resources.I_Open);

            this.Path = path;

            var files = new System.IO.DirectoryInfo(path).GetFiles();

            this.Files = new List<Item>(files.Length);

            foreach (var item in files) this.Files.Add(new File(item));

            this.Rank = DirectoryRank.Sensor;
        }
    }
}
