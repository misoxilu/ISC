using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ISC.Model.Working
{
    public class File
    {
        public BitmapImage Image { get; set; }

        public string Name { get; set; }

        public File()
        {

        }
        public File(FileInfo fileInfo)
        {
            this.Name = fileInfo.Name;
            var image = string.Empty;
            switch (fileInfo.Extension)
            {
                case ".bmp": { image ="Image"; break; }
                case ".txt": { image = "Document"; break; }
                default: { image ="Application"; break; }
            }

            this.Image= General.FindIcon(image);
        }
    }
}
