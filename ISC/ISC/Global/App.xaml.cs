using System;
using System.Windows;

namespace ISC.Global
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.StartupUri = new Uri("/ISC;component/View/MainWindow.xaml", UriKind.Relative);
        }
    }
}
