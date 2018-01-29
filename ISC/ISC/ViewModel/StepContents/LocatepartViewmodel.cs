using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using ISC.Model.Locatepart;
using ISC.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ISC.ViewModel.StepContents
{
    public class LocatepartViewmodel : Base.ViewModel
    {
        public RelayCommand Click => new RelayCommand((o)=> 
        {
            MessageBox.Show(o.ToString());
        });

        public List<PartGroup> PartGroups { get; set; }

        public LocatepartViewmodel()
        {
            var parts = Enum.GetNames(typeof(PartType));
            this.PartGroups = new List<PartGroup> { new PartGroup { PartItems = new List<PartItem>() } };
            for (int i = 0; i < parts.Length; i++)
            {
                var name = General.FindStringResource("L_" + parts[i]);
                var image = General.FindResource("I_" + parts[i]) as BitmapImage;
                this.PartGroups[0].PartItems.Add(new PartItem { Name = name, Image = image });
            }
            this.RaisePropertyChanged(nameof(this.PartGroups));
        }
    }
}
