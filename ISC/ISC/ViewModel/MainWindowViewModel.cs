using ISC.Global.Common;
using ISC.ViewModel.Base;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ISC.ViewModel
{
    public class MainWindowViewModel : Base.ViewModel
    {
        public MainWindowViewModel()
        {
           
        }

        public RelayCommand Loaded => new RelayCommand(()=> 
        {

        });
    }
}
