using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.ViewModel
{
    public class FileViewmodel:Base.ViewModel
    {
        public List<Model.File> Files { get;private set; }
        public FileViewmodel()
        {

            DirectoryInfo folder = new DirectoryInfo(string.Format(Properties.Resources.FilePath, Environment.CurrentDirectory));
            var files = folder.GetFiles();
            this.Files = new List<Model.File>(files.Length);
            foreach (var file in files) this.Files.Add(new Model.File(file));
            this.RaisePropertyChanged(nameof(this.Files));
        }
        //        

        //foreach (FileInfo file in folder.GetFiles("*.txt"))
        //{
        //    Console.WriteLine(file.FullName);
        //}
    }
}
