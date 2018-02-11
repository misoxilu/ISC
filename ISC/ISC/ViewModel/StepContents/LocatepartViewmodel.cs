using ISC.Global.Common;
using ISC.Global.Common.Enumeration;
using ISC.Model.Entity.Working.Locatepart;
using ISC.Model.Entity.WorkingLocatepart;
using ISC.ViewModel.Base;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ISC.ViewModel.StepContents
{
    public class LocatepartViewmodel : Base.ViewModel
    {
        public string Discription { get; private set; }

        public string Direction { get; private set; }

        public SeriesCollection SeriesCollection { get; set; } = new SeriesCollection();

        public Func<double, string> XFormatter { get; set; }

        private int flowIndex;
        public int FlowIndex
        {
            get { return this.flowIndex; }
            set { this.flowIndex = value; this.RaisePropertyChanged(nameof(this.FlowIndex)); }
        }

        public RelayCommand LeftClick => new RelayCommand((o) =>
        {
            var item = o as PartItem;
            this.Discription = General.FindStringResource($"L_{General.GetEnumName<PartType>(item.PartType)}Discription");
            this.RaisePropertyChanged(nameof(this.Discription));
            this.FlowIndex = 0;
        });

        public RelayCommand LeftDoubleClick => new RelayCommand(() => this.FlowIndex = 1);

        public RelayCommand ClickOk => new RelayCommand((o) =>
        {
           
            this.FlowIndex = 2;
        });

        public List<PartGroup> PartGroups { get; set; }

        public LocatepartViewmodel()
        {
            var parts = Enum.GetNames(typeof(PartType));
            this.PartGroups = new List<PartGroup> { new PartGroup { PartItems = new List<PartItem>() } };
            for (int i = 0; i < parts.Length; i++)
            {
                this.PartGroups[0].PartItems.Add(new PartItem
                {
                    Name = General.FindStringResource($"L_{ parts[i]}"),
                    Icon = General.FindResource<BitmapImage>($"I_{parts[i]}"),
                    PartType = General.GetEnumItem<PartType>(parts[i])
                });
            }
            this.RaisePropertyChanged(nameof(this.PartGroups));
            this.LoadData();
        }

        private void LoadData()
        {
            this.XFormatter = (value) => $"{((int)value / 60).ToString("00")}:{ ((int)value % 60).ToString("00")}";

            var chart1Series = new ChartValues<ObservablePoint>
            {
                new ObservablePoint(1d, 5d),
                new ObservablePoint(12d, 90d),
                new ObservablePoint(31d, 26d),
                new ObservablePoint(100d, 79),
                new ObservablePoint(123d, 50d)
            };
            this.SeriesCollection.Add(new LineSeries
            {
                //StrokeDashArray = new DoubleCollection() { 1, 4 },
                Values = chart1Series,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Green,
                Title = "曲线",
                PointGeometrySize = 0
            });
            this.RaisePropertyChanged(nameof(this.SeriesCollection));
        }
    }
}
