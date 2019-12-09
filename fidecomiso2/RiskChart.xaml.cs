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

namespace fidecomiso2
{
    /// <summary>
    /// Interaction logic for MaterialCards.xaml
    /// </summary>
    /// 
    public partial class RiskChart : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public ChartValues<HeatPoint> HeatValues { get; set; }
        public ChartValues<ObservablePoint> PointValue { get; set; }
        public ObservablePoint RiskPoint { get; set; }


        public double[] RiskAxis { get; set; }
        
        //chart page object 
        public RiskChart()
        {

            RiskAxis = new double[90];
            double x = 0.0;
            for (int i = 0; i < 90; i++)
            {
                RiskAxis[i] = x+=0.1;
            }
            var r = new Random();
            RiskPoint = new ObservablePoint(0, 0);
            PointValue = new ChartValues<ObservablePoint>();
            HeatValues = new ChartValues<HeatPoint>
            {

                new HeatPoint(0, 0, r.Next(0, 10)),
                new HeatPoint(0, 1, r.Next(0, 10)),
                new HeatPoint(0, 2, r.Next(0, 10)),
                new HeatPoint(0, 3, r.Next(0, 10)),
                new HeatPoint(0, 4, r.Next(0, 10)),
                new HeatPoint(0, 5, r.Next(0, 10)),
                new HeatPoint(0, 6, r.Next(0, 10)),
 
                //"Lorena Hoffman"
                new HeatPoint(1, 0, r.Next(0, 10)),
                new HeatPoint(1, 1, r.Next(0, 10)),
                new HeatPoint(1, 2, r.Next(0, 10)),
                new HeatPoint(1, 3, r.Next(0, 10)),
                new HeatPoint(1, 4, r.Next(0, 10)),
                new HeatPoint(1, 5, r.Next(0, 10)),
                new HeatPoint(1, 6, r.Next(0, 10)),

            };


            PointValue.Add(RiskPoint);

            this.DataContext = this;
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {

                new HeatSeries
                {
                    Title = "MyHeat",
                    Values = HeatValues,
                },
                /*
                new ScatterSeries
                {
                    Title = "MyRiskPoint",
                    Values = PointValue,
                    PointGeometry = DefaultGeometries.Circle
                },
                */

            };

        }




    }


}



