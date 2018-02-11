using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace ISC.Model.Entity.Working
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
                    this.Thumbnail = new BitmapImage(new Uri(fileInfo.FullName));
                    TypeName = "BMP 文件";
                    this.State = System.Windows.Visibility.Collapsed;
                    break;
                }
                case ".txt":
                {
                    image = "Document";
                    this.Thumbnail = General.FindIconResource($"I_{image}");
                    TypeName = "文本文档";
                    break;
                }
                case ".jpg":
                default:
                {
                    image ="Image";
                    this.Thumbnail = new BitmapImage(new Uri(fileInfo.FullName));
                    TypeName = "JPG 文件";
                    this.State = System.Windows.Visibility.Collapsed;
                    break;
                }
            }
            this.Icon= General.FindIconResource($"I_{image}");
            this.Rank = DirectoryRank.File;
        }
    }
}
