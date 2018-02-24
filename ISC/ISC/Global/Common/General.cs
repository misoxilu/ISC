using ISC.Global.Common.Enumeration;
using ISC.View;
using System;
using System.Runtime.Serialization.Json;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Xceed.Wpf.AvalonDock.Layout;
using System.IO;
using ISC.Model.Entity.Working;
using ISC.Model.Entity.Working.Initializations;

namespace ISC.Global.Common
{
    public static partial class General
    {
        private static WorkingView workingView = new WorkingView();

        public static LayoutAnchorable FindPane(string paneName)
        {
            var dockView = FindWorkingViewControl(Properties.Resources.DockView);
            return ((LayoutAnchorable)dockView?.FindName(paneName));
        }

        public static FrameworkElement FindWorkingViewControl(string controlName)
        {
            return (FrameworkElement)General.workingView.FindName(controlName);
        }

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
            General.UserControl = General.FindView(viewName, Properties.Resources.PopupWindowPath);
            General.UserControl.ShowDialog();
        }

        public static void CloseView()
        {
            General.SaveInitialization();
            General.UserControl.Close();
        }

        public static void ChangeLanguage(string languageName)
        {
            if (General.currentLanguageResource != null) App.Current.Resources.MergedDictionaries.Remove(General.currentLanguageResource);
            var languageFilePath = string.Format(Properties.Resources.LanguageFilePath, languageName);
            General.currentLanguageResource = Application.LoadComponent(new Uri(languageFilePath, UriKind.Relative)) as ResourceDictionary;
            if (General.currentLanguageResource != null) App.Current.Resources.MergedDictionaries.Add(General.currentLanguageResource);
        }

        public static void ShowWorkingview(ContentControl contentControl)
        {
            contentControl.Content = workingView;
        }

        public static T FindResource<T>(string resourceKey)
        {
            return (T)App.Current.FindResource(resourceKey);
        }

        public static string FindStringResource(string resourceKey)
        {
            return General.FindResource<string>(resourceKey);
        }

        public static BitmapImage FindIconResource(string iconName)
        {
            return General.FindResource<BitmapImage>(iconName);
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

        public static string JsonSerialize<T>(T entity)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(entity.GetType());
            string result = string.Empty;
            using (MemoryStream stream = new MemoryStream())
            {
                jsonSerializer.WriteObject(stream, entity);
                result = System.Text.Encoding.UTF8.GetString(stream.ToArray()).Trim();
            }
            return result;
        }

        public static T JsonDeserialize<T>(string _string)
        {
            T result = default(T);
            using (MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(_string)))
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
                result = (T)jsonSerializer.ReadObject(ms);
            }
            return result;
        }

        public static void ReadInitialization()
        {
            General.Initialization = General.JsonDeserialize<Initialization>(System.IO.File.ReadAllText(General.initializationFilePath, System.Text.Encoding.Default));
        }

        public static void SaveInitialization()
        {
            System.IO.File.WriteAllText(General.initializationFilePath, General.JsonSerialize(General.Initialization), System.Text.Encoding.Default);
        }

        public static string GetEnumName<T>(T t)
        {
            return Enum.GetName(t.GetType(), t);
        }

        public static T GetEnumItem<T>(string enumName)
        {
            return (T)Enum.Parse(typeof(T), enumName);
        }
    }
}
