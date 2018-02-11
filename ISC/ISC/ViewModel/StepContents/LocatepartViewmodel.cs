using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using ISC.Model.Entity.Working.Locatepart;
using ISC.Model.Entity.WorkingLocatepart;
using ISC.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace ISC.ViewModel.StepContents
{
    public class LocatepartViewmodel : Base.ViewModel
    {
        public int FlowIndex { get; set; }

        public RelayCommand LeftClick => new RelayCommand((o) =>
        {
            var a = o;
            this.FlowIndex = 2;
            this.RaisePropertyChanged(nameof(this.FlowIndex));
            
        });

        public RelayCommand LeftDoubleClick => new RelayCommand(()=> 
        {

            this.FlowIndex = 1;
            this.RaisePropertyChanged(nameof(this.FlowIndex));
        });

        public List<PartGroup> PartGroups { get; set; }

        public LocatepartViewmodel()
        {
            var parts = Enum.GetNames(typeof(PartType));
            this.PartGroups = new List<PartGroup> { new PartGroup { PartItems = new List<PartItem>() } };
            for (int i = 0; i < parts.Length; i++)  this.PartGroups[0].PartItems.Add(new PartItem { Name = General.FindStringResource($"L_{ parts[i]}"), Icon = General.FindResource<BitmapImage>($"I_{parts[i]}") });
            this.RaisePropertyChanged(nameof(this.PartGroups));
        }
    }
}
