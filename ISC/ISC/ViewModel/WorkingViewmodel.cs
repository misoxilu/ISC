using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using ISC.Model.Working;
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


        public SsmViewmodel SsmViewmodel { get; private set; } = new SsmViewmodel();
        public EbmViewmodel EbmViewmodel { get; private set; } = new EbmViewmodel();
        public DockViewmodel DockViewmodel { get; private set; } = new DockViewmodel();
        public StepsViewmodel StepsViewmodel { get; private set; } = new StepsViewmodel();
        public LocatepartViewmodel LocatepartViewmodel { get; private set; } = new LocatepartViewmodel();

        public RelayCommand Loaded => new RelayCommand(() =>
        {
            this.grid = General.FindGrid();
            this.SwitchSensorstatus();
        });

        public WorkingViewmodel()
        {
            this.TestSensorGroup();

            this.SubscribeEvent();
        }

        private void TestSensorGroup()
        {
           
            this.SensorGroups[0].SensorItems.Add(new SensorItem ("SensorA", $"{ Environment.CurrentDirectory }\\Global\\File\\SensorA"));

            this.SensorGroups[0].SensorItems.Add(new SensorItem("SensorB", $"{ Environment.CurrentDirectory }\\Global\\File\\SensorB"));

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
                    case EventName.GetConnected:
                    {
                        this.StepsIndex = 2;
                        break;
                    }
                }
            };
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
            General.SwitchPane(Properties.Resources.SelectionPane, PaneState.Hide);
        }

        private void SwitchEasybuilder()
        {
            this.WorkingmodeSelectedIndex = 1;
            this.DockViewmodel.WorkingmodeSelectedIndex = 1;
            this.grid.RowDefinitions[0].Height = new GridLength(0, GridUnitType.Auto);
            this.grid.RowDefinitions[1].Height = new GridLength(3, GridUnitType.Pixel);
            this.grid.RowDefinitions[2].Height = new GridLength(200, GridUnitType.Pixel);
            this.SecondRowVisibility = Visibility.Visible;


            this.RaisePropertiesChanged();
            General.SwitchPane(Properties.Resources.SelectionPane, PaneState.Show);
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
