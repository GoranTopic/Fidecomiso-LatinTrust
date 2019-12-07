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

    public partial class Cliente : Page
    {
        PageVars PV;
        public PageVars XamlPV { get { return PV; } }
        
        RiskField PepRisk;
        public RiskField XamlPepRisk { get { return PepRisk; } }

        RiskField IncomeRisk;
        public RiskField XamlIncomeRisk { get { return PepRisk; } }
        
        RiskField AgeRisk;

        public RiskField XamlAgeRisk { get { return PepRisk; } }
        
        RiskField ActividadRisk;
        public RiskField XamlActividadRisk { get { return ActividadRisk; } }
        public Cliente()
        {
            PV = new PageVars();
            PepRisk = new RiskField(0.3m);
            ActividadRisk = new RiskField(0.1m);
            AgeRisk = new RiskField(0.15m);
            IncomeRisk = new RiskField(0.2m);

            (App.Current as App).Analysis.ClienteRisks.Add("PEP", PepRisk);
            (App.Current as App).Analysis.ClienteRisks.Add("Activity", ActividadRisk);
            this.DataContext = this;
            InitializeComponent();       
        }

        private void radio_checked(object sender, RoutedEventArgs e)
        {
            if ((bool)radio1.IsChecked) PepRisk.SetRisk(3);
            else if ((bool)radio2.IsChecked) PepRisk.SetRisk(2);
            else if ((bool)radio3.IsChecked) PepRisk.SetRisk(1);
        }
        private void CheckBoxes_checked(object sender, RoutedEventArgs e)
        {
            int count = 0;
            foreach (CheckBox cb in FindVisualChildren<CheckBox>(Actividades_economicas)) 
                if ((bool)cb.IsChecked) count++;
            if (count > 0 && count < 4) ActividadRisk.SetRisk(count);
        }
        private void RadioType_checked(object sender, RoutedEventArgs e)
        {
            //we have to change this so that it is the greater client Class which get the value of IsJudicial
            PV.IsTypeSet = true;
            if ((bool)IsNatural.IsChecked)
            {
                PepRisk.IsJudicial = false;
                (App.Current as App).Analysis.IsJudicial = PepRisk.IsJudicial;
            }
            else if ((bool)IsJudicial.IsChecked)
            {
                PepRisk.IsJudicial = true;
                (App.Current as App).Analysis.IsJudicial = PepRisk.IsJudicial;
            }
            else PV.IsTypeSet = false;
        }
        private void Age_checked(object sender, RoutedEventArgs e)
        {
            //we have to change this so that it is the greater client Class which get the value of IsJudicial
            PV.IsTypeSet = true;
            if ((bool)IsNatural.IsChecked)
            {
                PepRisk.IsJudicial = false;
                (App.Current as App).Analysis.IsJudicial = PepRisk.IsJudicial;
            }
            else if ((bool)IsJudicial.IsChecked)
            {
                PepRisk.IsJudicial = true;
                (App.Current as App).Analysis.IsJudicial = PepRisk.IsJudicial;
            }
            else PV.IsTypeSet = false;
        }
        private void Income_checked(object sender, RoutedEventArgs e)
        {
            
             //we have to change this so that it is the greater client Class which get the value of IsJudicial
             PV.IsTypeSet = true;
            if ((bool)IsNatural.IsChecked)
            {
                PepRisk.IsJudicial = false;
                (App.Current as App).Analysis.IsJudicial = PepRisk.IsJudicial;
            }
            else if ((bool)IsJudicial.IsChecked)
            {
                PepRisk.IsJudicial = true;
                (App.Current as App).Analysis.IsJudicial = PepRisk.IsJudicial;
            }
            else PV.IsTypeSet = false;
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
    }

    public class PageVars : INotifyPropertyChanged
    {
        private bool _IsTypSet = false;
        public bool IsTypeSet
        {
            get { return _IsTypSet; }
            set
            {
                _IsTypSet = value;
                OnPropertyChanged("IsTypeSet");
            }
        }

        private bool _Income = false;
        public bool Income
        {
            get { return _Income; }
            set
            {
                _Income = value;
                OnPropertyChanged("Income");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


