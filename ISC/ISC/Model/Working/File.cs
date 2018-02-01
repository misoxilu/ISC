using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using System.IO;
using System.Windows.Media.Imaging;

namespace ISC.Model.Working
{
    public class File:Item
    {
        public BitmapImage Thumbnail { get; set; }
        public string TypeName { get; set; }

        public File() : base() { }
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
            this.Icon= General.FindIcon(image);
            this.Rank = DirectoryRank.Child;
        }
    }
}
