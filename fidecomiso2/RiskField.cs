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

using System.ComponentModel;

namespace fidecomiso2
{
    public class RiskField : INotifyPropertyChanged
    /* Objec for setting the risk in a field and in the end to the client */
    {
        private int _Risk = 0;
        public int Risk
        {
            get { return _Risk; }
            set { _Risk = value; }
        }

        private string _PrecentageLabel;
        public string PercentageLabel
        {
            get { return _PrecentageLabel; }
            set
            {
                _PrecentageLabel = value;
                OnPropertyChanged("Percentage");
            }
        }

        private decimal _Precentage;
        public decimal Percentage
        {
            get { return _Precentage; }
            set
            {
                _Precentage = value;
                OnPropertyChanged("Percentage");
            }
        }

        private Brush _LabelColor = Brushes.Gray;
        public Brush LabelColor
        {
            get { return _LabelColor; }
            set
            {
                _LabelColor = value;
                OnPropertyChanged("LabelColor");
            }
        }

        private string _RiskLabel = "N/A";
        public string RiskLabel
        {
            get { return this._RiskLabel; }
            set
            {
                if (this._RiskLabel == value)
                    return;
                this._RiskLabel = value;
                this.OnPropertyChanged("RiskLabel");
            }
        }

        private decimal _RiskVar = 0.0m;
        public decimal RiskVar
        {
            get { return this._RiskVar; }
            set
            {
                if (this._RiskVar == value)
                    return;

                this._RiskVar = decimal.Round(value, 1);
                this.OnPropertyChanged("RiskVar");
            }
        }

        public RiskField(decimal Percentage)
        {
            this.Percentage = Percentage;
            PercentageLabel = decimal.Round((_Precentage * 100), 0).ToString() + "%";
            RiskVar = 1 * _Precentage;
        }

        public void SetRisk(int risk)
        {
            Risk = risk;
            UpdateRiskFields();
        }

        public void UpdateRiskFields()
        {

            if (_Risk == 1)
            {
                RiskLabel = "Bajo";
                LabelColor = LabelColor = Brushes.ForestGreen;
                RiskVar = _Risk * _Precentage;
            }
            else if (_Risk == 2)
            {
                RiskLabel = "Medio";
                LabelColor = LabelColor = Brushes.Goldenrod;
                RiskVar = _Risk * _Precentage;
            }
            else if (_Risk == 3)
            {
                RiskLabel = "Alto";
                LabelColor = LabelColor = Brushes.IndianRed;
                RiskVar = _Risk * _Precentage;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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


}
