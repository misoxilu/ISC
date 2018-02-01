using System.Collections.Generic;
using ISC.Model.Working;
using ISC.ViewModel.Base;
using ISC.Global.Common;
using System.Windows.Controls;
using ISC.Global.Common.Enumeration;
using System.Windows;
using System;


namespace ISC.ViewModel
{
    public class FileViewmodel : Base.ViewModel
    {
        public List<File> Files { get; set; }

        public ControlTemplate FileListboxControlTemplate { get; set; }

        public DataTemplate FileListboxDataTemplate { get; set; }

        public ContextMenu FileListboxItemContextMenu { get; set; }
        //public List<Model.Working.File> Files { get;private set; }
        public FileViewmodel()
        {

            //System.IO.DirectoryInfo folder = new System.IO.DirectoryInfo(string.Format(Properties.Resources.FilePath, Environment.CurrentDirectory));
            //var files = folder.GetFiles();

            //foreach (var file in files)
            //{
            //    var aaa = file;
            //}


        }

        public void ChangeDataLayout(int option)
        {
            switch (option)
            {
                case -1:
                {
                    var sensors = General.SensorGroups[0].SensorItems;
                    this.Files = new List<File>(sensors.Count);
                    for (int i = 0; i < sensors.Count; i++) this.Files.Add(new File { Name = sensors[i].Name, Image = General.FindIconResource("I_Open") });
                    this.FileListboxItemContextMenu = General.FindResource("SensorItem") as ContextMenu;
                    break;
                }
                default:
                {
                    var files = General.SensorGroups[0].SensorItems[option].Files;
                    this.Files = new List<File>(files.Count);
                    for (int i = 0; i < files.Count; i++)
                    {
                        this.Files.Add(new File { Name = files[i].Name, Image = files[i].Image });
                    }
                    this.FileListboxItemContextMenu = General.FindResource("FileItem") as ContextMenu;
                    break;
                }
            }
            this.RaisePropertyChanged(nameof(this.Files));
            this.RaisePropertyChanged(nameof(this.FileListboxItemContextMenu));
        }

        private void ChangeControlTemplate(LayoutType layoutType)
        {
            switch (layoutType)
            {
                case LayoutType.Thumbnail:
                case LayoutType.Tile: { this.FileListboxControlTemplate = General.FindResource(Properties.Resources.FileControlTemplate_Tile) as ControlTemplate; break; }
                default: { this.FileListboxControlTemplate = General.FindResource(Properties.Resources.FileControlTemplate_List) as ControlTemplate; break; }
            }
            this.RaisePropertyChanged(nameof(this.FileListboxControlTemplate));
        }

        private void ChangeDataTemplate(LayoutType layoutType)
        {
            switch (layoutType)
            {
                case LayoutType.Thumbnail:
                {
                    this.FileListboxDataTemplate = General.FindResource(Properties.Resources.FileDataTemplate_Thumbnail) as DataTemplate;
                    break;
                }
                case LayoutType.Tile:
                {
                    this.FileListboxDataTemplate = General.FindResource(Properties.Resources.FileDataTemplate_Tile) as DataTemplate;
                    break;
                }
                case LayoutType.List:
                {
                    this.FileListboxDataTemplate = General.FindResource(Properties.Resources.FileDataTemplate_List) as DataTemplate;
                    break;
                }
                default:
                {

                    break;
                }
            }
            this.RaisePropertyChanged(nameof(this.FileListboxDataTemplate));
        }

        public void ChangeTemplate(LayoutType layoutType)
        {
            this.ChangeControlTemplate(layoutType);
            this.ChangeDataTemplate(layoutType);
        }

        public RelayCommand Loaded => new RelayCommand(() =>
        {
            this.ChangeDataLayout(-1);
            this.ChangeTemplate(LayoutType.List);
        });


        public RelayCommand Open => new RelayCommand((o) => { this.ChangeDataLayout(Convert.ToInt32(o)); });
    }
}
