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
            VSPromedioRisk = new RiskField("VersusAverage", 0.2m);
            VSIngresosRisk = new RiskField("VersusIncome", 0.2m);
            LugarTransRisk = new RiskField("TransactionPlace", 0.1m);
            FrecueciaRisk = new RiskField("Frequency", 0.1m);
            CambiosRisk = new RiskField("Changes", 0.15m);
            HistInusualRisk = new RiskField("UnusualHIstory", 0.1m);
            StatulJudicialRisk = new RiskField("JudicialStatus", 0.15m);

            (App.Current as App).Analysis.AddRiskFact2(VSPromedioRisk);
            (App.Current as App).Analysis.AddRiskFact2(VSIngresosRisk);
            (App.Current as App).Analysis.AddRiskFact2(LugarTransRisk);
            (App.Current as App).Analysis.AddRiskFact2(CambiosRisk);
            (App.Current as App).Analysis.AddRiskFact2(HistInusualRisk);
            (App.Current as App).Analysis.AddRiskFact2(StatulJudicialRisk);

            this.DataContext = this;
            InitializeComponent();
        }




        private void radio_checked(object sender, RoutedEventArgs e)
        {
            int count;
            
            count = 3;
            foreach (RadioButton cb in RiskField.FindVisualChildren<RadioButton>(vspromedio))
            {
                if ((bool)cb.IsChecked) VSPromedioRisk.SetRisk(count);
                count--;
                
            }
            
            count = 3;
            foreach (RadioButton cb in RiskField.FindVisualChildren<RadioButton>(vsingresos))
            {
                if ((bool)cb.IsChecked) VSIngresosRisk.SetRisk(count);
                count--;
            }

            count = 2;
            foreach (RadioButton cb in RiskField.FindVisualChildren<RadioButton>(lugar_transacion))
            {
                if ((bool)cb.IsChecked)
                {
                    if (count == 2) LugarTransRisk.SetRisk(3);
                    else LugarTransRisk.SetRisk(count);
                }
                count--;
            }

            count = 2;
            foreach (RadioButton cb in RiskField.FindVisualChildren<RadioButton>(frecuencia))
            {
                if ((bool)cb.IsChecked)
                {
                    if (count == 2) FrecueciaRisk.SetRisk(3);
                    else FrecueciaRisk.SetRisk(count);
                }
                count--;
            }

            count = 3;
            foreach (RadioButton cb in RiskField.FindVisualChildren<RadioButton>(condiciones))
            {
                if ((bool)cb.IsChecked) CambiosRisk.SetRisk(count);
                count--;
            }

            count = 3;
            foreach (RadioButton cb in RiskField.FindVisualChildren<RadioButton>(inusuales))
            {
                if ((bool)cb.IsChecked) HistInusualRisk.SetRisk(count);
                count--;
            }

            count = 3;
            foreach (RadioButton cb in RiskField.FindVisualChildren<RadioButton>(judicial))
            {
                if ((bool)cb.IsChecked) StatulJudicialRisk.SetRisk(count);
                count--;
            }


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
