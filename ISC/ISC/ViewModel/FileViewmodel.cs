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
        public Item SelectedItem { get; set; }

        public List<Item> Files { get; set; }

        public ControlTemplate FileListboxControlTemplate { get; set; }

        public DataTemplate FileListboxDataTemplate { get; set; }

        public ContextMenu FileListboxItemContextMenu { get; set; }

        public FileViewmodel() { }

        public void ChangeDataLayout(Item item)
        {
            switch (item.Rank)
            {
                case DirectoryRank.Root:
                {
                    this.Files = ((SensorItem)item).Files;// General.SensorGroups[0].SensorItems;
                    this.FileListboxItemContextMenu = General.FindResource("FileItem") as ContextMenu;
                    break;
                }
                //case DirectoryRank.Child:
                //{
                //    this.Files = ((SensorItem)item).Files;
                //    this.FileListboxItemContextMenu = General.FindResource("FileItem") as ContextMenu;
                //    break;
                //}
                default:
                {

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
            this.Files = General.SensorGroups[0].SensorItems;
            this.FileListboxItemContextMenu = General.FindResource("SensorItem") as ContextMenu;
            this.RaisePropertyChanged(nameof(this.Files));
            this.ChangeTemplate(LayoutType.List);
        });

        public RelayCommand Open => new RelayCommand((o) => { this.ChangeDataLayout(this.SelectedItem); });
    }
}
