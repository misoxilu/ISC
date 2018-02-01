using ISC.Global.Common;
using System.IO;
using System.Windows.Media.Imaging;

namespace ISC.Model.Working
{
    public class File
    {
        public BitmapImage Image { get; set; }

        public BitmapImage Thumbnail { get; set; }

        public string Name { get; set; }

        public string TypeName { get; set; }

        public File()
        {

        }
        public File(FileInfo fileInfo)
        {
            this.Name = fileInfo.Name;
            var image = string.Empty;
            switch (fileInfo.Extension)
            {
                case ".bmp":
                {
                    image ="Image";
                    //this.Thumbnail = new BitmapImage(new Uri(fileInfo.FullName));
                    TypeName = "BMP 文件";
                    break;
                }
                case ".txt":
                {
                    image = "Document";
                    TypeName = "文本文档";
                    break;
                }
                case ".jpg":
                default:
                {
                    image ="Image";
                    TypeName = "JPG 文件";
                    break;
                }
            }

            this.Image= General.FindIcon(image);
            
        }
    }
}
