using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using LiveCharts;
using LiveCharts.Wpf;
using System.Diagnostics;
using LiveCharts.Defaults;
using System.IO;

namespace fidecomiso2
{
    /// <summary>
    /// Interaction logic for MaterialCards.xaml
    /// </summary>
    /// 
    public partial class RiskChart : UserControl , ICloneable 
    {
        public SeriesCollection SeriesCollection { get; set; }
        public ChartValues<HeatPoint> HeatValues { get; set; }
        public ChartValues<ObservablePoint> ScatterValues { get; set; }
        //public ObservablePoint RiskPoint { get; set; }

        public double[] RiskAxis { get; set; }

        //chart page object 
        public RiskChart()
        {


            var r = new Random();
            ObservablePoint RiskPoint = new ObservablePoint(2, 2);

            ScatterValues = new ChartValues<ObservablePoint>();

            ScatterValues.Add(RiskPoint);

            foreach (ObservablePoint point in ScatterValues)
            {
                //Debug.WriteLine("x:{0}, y:{1}", point.X, point.Y);
            }

            HeatValues = new ChartValues<HeatPoint>();

            for (double X = 1; X <= 3; X += 1)
            {
                for (double Y = 1; Y <= 3; Y += 1)
                {
                    if ((int)X == (int)RiskPoint.X && (int)Y == (int)RiskPoint.Y)
                        HeatValues.Add(new HeatPoint(X, Y, 2));
                    HeatValues.Add(new HeatPoint(X, Y, X * Y));
                }
            }



            this.DataContext = this;
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new HeatSeries
                {
                    Title = "MyHeat",
                    Values = HeatValues,
                },

            };

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void UpdatePoint(double x, double y)
        {
            ScatterValues[0].X = x;
            ScatterValues[0].Y = y;

        }




    }
}


