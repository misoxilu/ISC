using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using ISC.Model.Entity.Working;
using ISC.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ISC.ViewModel
{
    public class NetworkViewmodel : Base.ViewModel
    {
        public ContextMenu BlankMenu { get; private set; } = General.FindResource<ContextMenu>(General.GetEnumName(DirectoryRank.Group));

        public BitmapImage Network { get; private set; } = General.FindIconResource(Properties.Resources.I_NetworkRoot);

        public BitmapImage Network2 { get; private set; } = General.FindIconResource(Properties.Resources.I_NetworkChild);

        public List<SensorGroup> SensorGroups { get; set; } = General.SensorGroups;

        public RelayCommand SelectedItemChanged => new RelayCommand((o) =>
        {
            this.BlankMenu = General.FindResource<ContextMenu>(General.GetEnumName((o as Item).Rank));
            this.RaisePropertyChanged(nameof(this.BlankMenu));
        });

        public void LeftClick(Item item)
        {
              General.RaiseEventHandler(this, EventName.ChangeFileDataLayout, item);
         }


        public NetworkViewmodel()
        {
            this.RaisePropertyChanged(nameof(Network));
            this.RaisePropertyChanged(nameof(Network2));
        }
    }
}