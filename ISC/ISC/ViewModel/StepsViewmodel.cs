using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using ISC.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ISC.ViewModel
{
    public class StepsViewmodel : Base.ViewModel
    {
        public Thickness Margin { get; set; }
        public HorizontalAlignment HorizontalAlignment { get; set; } = HorizontalAlignment.Left;
        public Visibility Visibility { get; set; } = Visibility.Visible;
        public RelayCommand GetConnected => new RelayCommand(() =>
        {
            General.RaiseEventHandler(this, EventName.GetConnected, null);
        });

        public RelayCommand StackPanelSizeChanged => new RelayCommand((o) =>
        {
            var StackPanel = (StackPanel)o;
            if (StackPanel.ActualWidth <= 90)
            {
                this.HorizontalAlignment = HorizontalAlignment.Center;
                this.Visibility = Visibility.Collapsed;
                this.Margin = new Thickness(0);
            }
            else
            {
                this.HorizontalAlignment = HorizontalAlignment.Left;
                this.Visibility = Visibility.Visible;
                this.Margin = new Thickness(5);
            }
            this.RaisePropertyChanged(nameof(this.HorizontalAlignment));
            this.RaisePropertyChanged(nameof(this.Visibility));
            this.RaisePropertyChanged(nameof(this.Margin));
        });
    }
}
