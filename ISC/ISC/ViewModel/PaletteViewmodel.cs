using ISC.Model.Entity.Base;
using ISC.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ISC.ViewModel
{
    public class PaletteViewmodel:Notify
    {
        public double PaletteWidth { get; set; }
        public double PaetteHeight { get; set; }

        public RelayCommand Row0SizeChanged => new RelayCommand((o)=> 
        {
            var grid = o as Grid;
          
        });
    }
}
