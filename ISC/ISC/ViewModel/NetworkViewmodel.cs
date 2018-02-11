using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using ISC.Model.Entity.Working;
using ISC.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
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
            this.BlankMenu = General.FindResource<ContextMenu>(General.GetEnumName(((Item)o).Rank));
            this.RaisePropertyChanged(nameof(this.BlankMenu));
        });

        public RelayCommand RightClick => new RelayCommand((o) =>
        {
            var a = o;
            //General.RaiseEventHandler(this, EventName.RightClickCollectionItem, "TreeView_Network");
        });

        public NetworkViewmodel()
        {
            this.RaisePropertyChanged(nameof(Network));
            this.RaisePropertyChanged(nameof(Network2));
        }
    }
}