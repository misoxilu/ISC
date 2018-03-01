using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using ISC.Model.Entity.Working;
using ISC.ViewModel.Base;
using ISC.ViewModel.Menus;
using ISC.ViewModel.StepContents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ISC.ViewModel
{
    public class WorkingViewmodel : Base.ViewModel
    {
        public List<SensorGroup> SensorGroups { get; set; } = General.SensorGroups;

        private Grid grid;

        public int WorkingmodeSelectedIndex { get; set; }

        public GridLength FirstRowHeight { get; set; }
        public int SecondRowHeight { get; set; }
        public int ThirdRowMinHeight { get; set; }
        public Visibility SecondRowVisibility { get; set; } = Visibility.Collapsed;

        private int stepsIndex;
        public int StepsIndex
        {
            get { return stepsIndex; }
            set { stepsIndex = value; this.RaisePropertyChanged(nameof(this.StepsIndex)); }
        }

        public SensorstatusMenuViewmodel SsmViewmodel { get; private set; } = new SensorstatusMenuViewmodel();
        public EasybuilderMenuViewmodel EbmViewmodel { get; private set; } = new EasybuilderMenuViewmodel();
        public DockViewmodel DockViewmodel { get; private set; } = new DockViewmodel();
        public StepsViewmodel StepsViewmodel { get; private set; } = new StepsViewmodel();
        public LocatepartViewmodel LocatepartViewmodel { get; private set; } = new LocatepartViewmodel();

        public RelayCommand Loaded => new RelayCommand(() =>
        {
            General.ReadInitialization();
            this.grid = General.FindWorkingViewControl("Grid") as Grid;
            this.SwitchSensorstatus();
        });

        public WorkingViewmodel()
        {
            this.TestSensorGroup();

            this.SubscribeEvent();
        }

        private void TestSensorGroup()
        {

            this.SensorGroups[0].SensorItems.Add(new SensorItem("SensorA", $"{ Environment.CurrentDirectory }\\Global\\File\\SensorA") { TypeName = "7400" });

            this.SensorGroups[0].SensorItems.Add(new SensorItem("SensorB", $"{ Environment.CurrentDirectory }\\Global\\File\\SensorB") { TypeName = "7400" });

            this.RaisePropertyChanged(nameof(this.SensorGroups));
        }

        private void SubscribeEvent()
        {
            General.EventHandler += (s, e) =>
            {
                switch (e.Name)
                {
                    case EventName.SwitchEasybuilder: { this.SwitchWorkingView(WorkingMode.Easybuilder); break; }
                    case EventName.SwitchSensorstatus: { this.SwitchWorkingView(WorkingMode.Sensorstatus); break; }
                    case EventName.SwitchStep: { this.StepsIndex = Convert.ToInt32(e.Value); break; }
                    case EventName.PopupWindow: { General.PopupView(e.Value.ToString()); break; }
                    case EventName.CloseWindow: { General.CloseView(); break; }
                    case EventName.ChangeFileDataLayout: { this.ChangeFileDataLayout((Item)e.Value); break; }
                    default: break;
                }
            };
        }

        private void ChangeFileDataLayout(Item item)
        {
            if(item.Rank.Equals(DirectoryRank.Group))
            {
                this.DockViewmodel.FileViewmodel.ChangeDataLayout();
            }
            else
            {
                this.DockViewmodel.FileViewmodel.ChangeDataLayout(item);
            }
        }

        private void SwitchWorkingView(WorkingMode workingMode)
        {
            switch (workingMode)
            {
                case WorkingMode.Sensorstatus: { this.SwitchSensorstatus(); break; }
                case WorkingMode.Easybuilder: { this.SwitchEasybuilder(); break; }
                default: break;
            }
            this.RaisePropertiesChanged();
            General.WorkingMode = workingMode;
        }

        private void SwitchSensorstatus()
        {
            this.WorkingmodeSelectedIndex = 0;
            this.DockViewmodel.WorkingmodeSelectedIndex = 0;
            this.grid.RowDefinitions[0].Height = new GridLength(100, GridUnitType.Star);
            this.grid.RowDefinitions[1].Height = new GridLength(0, GridUnitType.Pixel);
            this.grid.RowDefinitions[2].Height = new GridLength(0, GridUnitType.Pixel);
            this.SecondRowVisibility = Visibility.Hidden;
            this.RaisePropertiesChanged();
            General.FindPane(Properties.Resources.SelectionView).Hide();
            General.FindPane("StepView").Hide();
        }

        private void SwitchEasybuilder()
        {
            this.WorkingmodeSelectedIndex = 1;
            this.DockViewmodel.WorkingmodeSelectedIndex = 1;
            this.grid.RowDefinitions[0].Height = new GridLength(0, GridUnitType.Auto);
            this.grid.RowDefinitions[1].Height = new GridLength(3, GridUnitType.Pixel);
            this.grid.RowDefinitions[2].Height = new GridLength(200, GridUnitType.Star);
            this.SecondRowVisibility = Visibility.Visible;
            this.RaisePropertiesChanged();
            General.FindPane(Properties.Resources.SelectionView).Show();
            General.FindPane("StepView").Show();
        }

        private void RaisePropertiesChanged()
        {
            this.RaisePropertyChanged(nameof(this.WorkingmodeSelectedIndex));
            this.RaisePropertyChanged(nameof(this.FirstRowHeight));
            this.RaisePropertyChanged(nameof(this.SecondRowHeight));
            this.RaisePropertyChanged(nameof(this.SecondRowVisibility));
            this.RaisePropertyChanged(nameof(this.ThirdRowMinHeight));
        }
    }
}
