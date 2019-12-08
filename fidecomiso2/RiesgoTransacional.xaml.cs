using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.ComponentModel;
using System.Diagnostics;

namespace fidecomiso2
{
    /// <summary>
    /// Interaction logic for Cliente.xaml
    /// </summary>
    /// 

    public partial class RiesgoTransacional : Page
    {
       
        RiskField VSPromedioRisk;
        public RiskField XamlVSPromedioRisk { get { return VSPromedioRisk; } }

        RiskField VSIngresosRisk;
        public RiskField XamlVSIngresosRisk { get { return VSIngresosRisk; } }

        RiskField LugarTransRisk;
        public RiskField XamlLugarTransRisk { get { return LugarTransRisk; } }

        RiskField FrecueciaRisk;
        public RiskField XamlFrecueciaRisk { get { return FrecueciaRisk; } }

        RiskField CambiosRisk;
        public RiskField XamlCambiosRisk { get { return CambiosRisk; } }

        RiskField HistInusualRisk;
        public RiskField XamlHistInusualRisk { get { return HistInusualRisk;  } }
        RiskField StatulJudicialRisk;
        public RiskField XamlStatulJudicialRisk { get { return StatulJudicialRisk; } }

        public RiesgoTransacional()
        {
            VSPromedioRisk = new RiskField(0.2m);
            VSIngresosRisk = new RiskField(0.2m);
            LugarTransRisk = new RiskField(0.1m);
            FrecueciaRisk = new RiskField(0.1m);
            CambiosRisk = new RiskField(0.15m);
            HistInusualRisk = new RiskField(0.1m);
            StatulJudicialRisk = new RiskField(0.15m);
            this.DataContext = this;
            InitializeComponent();
        }

        private void radio_checked(object sender, RoutedEventArgs e)
        {
            if ((bool)radio1.IsChecked) VSIngresosRisk.SetRisk(3);
            else if ((bool)radio2.IsChecked) VSIngresosRisk.SetRisk(2);
            else if ((bool)radio3.IsChecked) VSIngresosRisk.SetRisk(1);
        }
       
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T) yield return (T)child;
                    foreach (T childOfChild in FindVisualChildren<T>(child)) yield return childOfChild;
                }
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("UbicacionGeografica.xaml", UriKind.Relative));
        }
    }
}
