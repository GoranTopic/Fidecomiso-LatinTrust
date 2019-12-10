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

        RiskField ActividadRisk;
        public RiskField XamlActividadRisk { get { return ActividadRisk; } }

        RiskField AgeRisk;
        public RiskField XamlAgeRisk { get { return AgeRisk; } }

        RiskField PatrimonyRisk;
        public RiskField XamlPatrimonyRisk { get { return PatrimonyRisk; } }

        RiskField IncomeRisk;
        public RiskField XamlIncomeRisk { get { return IncomeRisk; } }

        RiskField FlowRisk;
        public RiskField XamlFlowRisk { get { return FlowRisk; } }

        public Cliente()
        {
            PV = new PageVars();
            PepRisk = new RiskField("PEP", 0.3m);
            ActividadRisk = new RiskField("Activity", 0.1m);
            AgeRisk = new RiskField("Age", 0.15m);
            PatrimonyRisk = new RiskField("Patrimony", 0.1m);
            IncomeRisk = new RiskField("Income", 0.2m);
            FlowRisk = new RiskField("Flow", 0.15m);

            (App.Current as App).Analysis.ClientRisks.Add(PepRisk);
            (App.Current as App).Analysis.ClientRisks.Add(ActividadRisk);
            (App.Current as App).Analysis.ClientRisks.Add(AgeRisk);
            (App.Current as App).Analysis.ClientRisks.Add(PatrimonyRisk);
            (App.Current as App).Analysis.ClientRisks.Add(IncomeRisk);
            (App.Current as App).Analysis.ClientRisks.Add(FlowRisk);
        
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
                PV.IsJudicial = false;
                (App.Current as App).Analysis.IsJudicial = PV.IsJudicial;
                Render_Age();
                Render_Patrimony();
                Render_Income();
                Render_Flow();
            }
            else if ((bool)IsJudicial.IsChecked)
            {
                PV.IsJudicial = true;
                (App.Current as App).Analysis.IsJudicial = PV.IsJudicial;
                Render_Age();
                Render_Patrimony();
                Render_Income();
                Render_Flow();
            }
            else PV.IsTypeSet = false;
        }
        private void Render_Age()
        {
            if (PV.IsJudicial)
            {
                if (PV.Age < 0) AgeRisk.SetRisk(0);
                else if (PV.Age >= 0 || PV.Age <= 3) AgeRisk.SetRisk(1);
                else if (PV.Age > 3 && PV.Age <= 5) AgeRisk.SetRisk(2);
                else if (PV.Age < 5) AgeRisk.SetRisk(3);
            }
            else
            {
                if (PV.Age < 18) AgeRisk.SetRisk(0);
                else if (PV.Age <= 25 || PV.Age >= 65) AgeRisk.SetRisk(3);
                else if (PV.Age >= 26 && PV.Age <= 40) AgeRisk.SetRisk(2);
                else if (PV.Age > 40 || PV.Age < 65) AgeRisk.SetRisk(1);
            }
            AgeRisk.Vault = PV.Age;
        }
        private void Age_TextChanged(object sender, TextChangedEventArgs e)
        {
            Render_Age();
        }

        private void Render_Patrimony()
        {
            if (PV.IsJudicial)
            {
                if (PV.Patrimony == 0) PatrimonyRisk.SetRisk(0);
                else if (PV.Patrimony <= 150000) PatrimonyRisk.SetRisk(1);
                else if (PV.Patrimony > 250000 && PV.Patrimony <= 500000) PatrimonyRisk.SetRisk(2);
                else if (PV.Patrimony > 500000 || PV.Patrimony > 1000000) PatrimonyRisk.SetRisk(3);
            }
            else
            {
                if (PV.Patrimony == 0) PatrimonyRisk.SetRisk(0);
                else if (PV.Patrimony <= 10000) PatrimonyRisk.SetRisk(1);
                else if (PV.Patrimony > 50000 && PV.Patrimony <= 150000) PatrimonyRisk.SetRisk(2);
                else if (PV.Patrimony > 150000 || PV.Patrimony > 250000) PatrimonyRisk.SetRisk(3);
            }
            PatrimonyRisk.Vault = PV.Patrimony;
        }

        private void Patrimony_TextChanged(object sender, TextChangedEventArgs e)
        {
            Render_Patrimony();
        }

        private void Render_Income()
        {
            if (PV.IsJudicial)
            {
                if (PV.Income == 0) IncomeRisk.SetRisk(0);
                else if (PV.Income <= 100000) IncomeRisk.SetRisk(1);
                else if (PV.Income > 100000 && PV.Income <= 250000) IncomeRisk.SetRisk(2);
                else if (PV.Income > 500000 || PV.Income > 250000) IncomeRisk.SetRisk(3);
            }
            else
            {
                if (PV.Income == 0) IncomeRisk.SetRisk(0);
                else if (PV.Income <= 5000) IncomeRisk.SetRisk(1);
                else if (PV.Income > 5000 && PV.Income <= 15000) IncomeRisk.SetRisk(2);
                else if (PV.Income > 30000 || PV.Income > 15000) IncomeRisk.SetRisk(3);
            }
            IncomeRisk.Vault = PV.Income;
        }
        private void Income_TextChanged(object sender, TextChangedEventArgs e)
        {
            Render_Income();
        }
        private void Render_Flow()
        {
            if (PV.IsJudicial)
            {
                if (PV.Flow == 0) FlowRisk.SetRisk(0);
                else if (PV.Flow <= 50000) FlowRisk.SetRisk(1);
                else if (PV.Flow > 50000 && PV.Flow <= 250000) FlowRisk.SetRisk(2);
                else if (PV.Flow > 250000) FlowRisk.SetRisk(3);
            }
            else
            {
                if (PV.Flow == 0) FlowRisk.SetRisk(0);
                else if (PV.Flow <= 5000) FlowRisk.SetRisk(1);
                else if (PV.Flow > 5000 && PV.Flow <= 10000) FlowRisk.SetRisk(2);
                else if (PV.Flow > 10000) FlowRisk.SetRisk(3);
            }
            FlowRisk.Vault = PV.Flow;
        }
        private void Flow_TextChanged(object sender, TextChangedEventArgs e)
        {
            Render_Flow(); 
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
            fidecomiso2.MainWindow mw = (fidecomiso2.MainWindow)App.Current.MainWindow;
            mw.MainFrame.Content = mw.UG_Page;
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

        private bool _IsJudicial;
        public bool IsJudicial
        {
            get { return _IsJudicial; }
            set
            {
                _IsJudicial = value;
                OnPropertyChanged("IsJudicial");
            }
        }
        private int _Age;
        public int Age
        {
            get { return _Age; }
            set
            {
                _Age = value;
                OnPropertyChanged("Age");
            }
        }
        private int _Patrimony;
        public int Patrimony
        {
            get { return _Patrimony; }
            set
            {
                _Patrimony = value;
                OnPropertyChanged("Patrimony");
            }
        }

        private int _Income;
        public int Income
        {
            get { return _Income; }
            set
            {
                _Income = value;
                OnPropertyChanged("Income");
            }
        }

        private int _Flow;
        public int Flow
        {
            get { return _Flow; }
            set
            {
                _Flow = value;
                OnPropertyChanged("Flow");
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


