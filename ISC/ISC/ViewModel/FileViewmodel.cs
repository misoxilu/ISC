using System.Collections.Generic;
using ISC.Model.Entity.Working;
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

        public ContextMenu FileItemContextMenu { get; set; }

        public ContextMenu FileBlankContextMenu { get; set; }

        public FileViewmodel() { }

        public void ChangeDataLayout(Item item)
        {
            switch (item.Rank)
            {
                case DirectoryRank.Sensor:
                {
                    this.Files = ((SensorItem)item).Files;
                    this.FileItemContextMenu = General.FindResource<ContextMenu>("FileItem");
                    this.FileBlankContextMenu = General.FindResource<ContextMenu>("FileBlank");
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
            this.RaisePropertyChanged(nameof(this.FileItemContextMenu));
            this.RaisePropertyChanged(nameof(this.FileBlankContextMenu));
        }

        private void ChangeControlTemplate(LayoutType layoutType)
        {
            switch (layoutType)
            {
                case LayoutType.Thumbnail:
                case LayoutType.Tile: { this.FileListboxControlTemplate = General.FindResource<ControlTemplate>(Properties.Resources.FileControlTemplate_Tile); break; }
                default: { this.FileListboxControlTemplate = General.FindResource<ControlTemplate>(Properties.Resources.FileControlTemplate_List); break; }
            }
            this.RaisePropertyChanged(nameof(this.FileListboxControlTemplate));
        }

        private void ChangeDataTemplate(LayoutType layoutType)
        {
            switch (layoutType)
            {
                case LayoutType.Thumbnail:
                {
                    this.FileListboxDataTemplate = General.FindResource<DataTemplate>(Properties.Resources.FileDataTemplate_Thumbnail);
                    break;
                }
                case LayoutType.Tile:
                {
                    this.FileListboxDataTemplate = General.FindResource<DataTemplate>(Properties.Resources.FileDataTemplate_Tile);
                    break;
                }
                case LayoutType.List:
                {
                    this.FileListboxDataTemplate = General.FindResource<DataTemplate>(Properties.Resources.FileDataTemplate_List);
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
            this.FileItemContextMenu = General.FindResource<ContextMenu>("SensorItem");
            this.FileBlankContextMenu = General.FindResource<ContextMenu>("SensorBlank");
            this.RaisePropertyChanged(nameof(this.FileBlankContextMenu));
            this.RaisePropertyChanged(nameof(this.Files));
            this.ChangeTemplate(LayoutType.List);
        });

        public RelayCommand Open => new RelayCommand(() => { this.ChangeDataLayout(this.SelectedItem); });

        public RelayCommand ChangeLayout => new RelayCommand((o) => this.ChangeTemplate(General.GetEnumItem<LayoutType>(o.ToString())));
    }
}
