using ISC.Global.Common;
using System.Windows;

namespace ISC.View
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            General.ShowWorkingview(this.ContentControl);

        }
    }
}
