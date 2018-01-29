using ISC.Global.Common.Enumeration;
using ISC.Model.Network;
using ISC.View;
using ISC.View.Selections;
using ISC.ViewModel;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Xceed.Wpf.AvalonDock.Layout;

namespace ISC.Global.Common
{
    static class General
    {
        public static WorkingMode WorkingMode { get; set; }

        public static List<SensorGroup> SensorGroups { get; set; } = new List<SensorGroup>();

        private static WorkingView workingView = new WorkingView();

        private static LayoutAnchorable FindPane(string paneName)
        {
            var dockView = (UserControl)FindName(workingView, Properties.Resources.DockView);
            return ((LayoutAnchorable)dockView?.FindName(paneName));
        }

        public static Grid FindGrid()
        {
            return (Grid)General.FindName(workingView, "Grid");
        }

        public static void SwitchPane(string paneName, PaneState paneState)
        {
            var pane = General.FindPane(paneName);
            switch (paneState)
            {
                case PaneState.Show: { pane?.Show(); break; }
                case PaneState.Hide: { pane?.Hide(); break; }
                default: break;
            }
        }

        private static ResourceDictionary currentLanguageResource;

        private static Window FindView(string viewName, string viewNameSpace)
        {
            var result = default(Window);
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if (type.Namespace == viewNameSpace && type.Name == viewName)
                {
                    result = assembly.CreateInstance(type.FullName) as Window;
                }
            }
            return result;
        }

        public static void PopupView(string viewName)
        {
            General.FindView(viewName, "ISC.View.Popups").ShowDialog();
        }

        public static void ShowWorkingview(ContentControl contentControl)
        {
            contentControl.Content = workingView;
        }

        public static void ChangeLanguage(string languageName)
        {
            if (General.currentLanguageResource != null) App.Current.Resources.MergedDictionaries.Remove(General.currentLanguageResource);
            var languageFilePath = string.Format(Properties.Resources.LanguageFilePath, languageName);
            General.currentLanguageResource = Application.LoadComponent(new Uri(languageFilePath, UriKind.Relative)) as ResourceDictionary;
            if (General.currentLanguageResource != null) App.Current.Resources.MergedDictionaries.Add(General.currentLanguageResource);
        }

        public static string FindStringResource(string resourceKey)
        {
            return General.FindResource(resourceKey).ToString();
        }

        public static object FindResource(string resourceKey)
        {
            return App.Current.FindResource(resourceKey);
        }

        public static BitmapImage FindIcon(string iconName)
        {
            return new BitmapImage(new Uri(string.Format(Properties.Resources.IconPath, Environment.CurrentDirectory, iconName), UriKind.RelativeOrAbsolute));
        }

        public static object FindName(ContentControl view, string name)
        {
            return view.FindName(name);
        }

        public static event EventHandler<EventHandlerArgs> EventHandler;

        public static void OnEventHandler(ViewModel.Base.ViewModel viewModel, EventHandlerArgs args)
        {
            General.EventHandler?.Invoke(viewModel, args);
        }

        public static void RaiseEventHandler(ViewModel.Base.ViewModel viewModel, EventName eventName, object value)
        {
            General.OnEventHandler(viewModel, new EventHandlerArgs(eventName, value));
        }
    }
}
