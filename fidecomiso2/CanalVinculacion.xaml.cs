﻿using System;
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

namespace fidecomiso2
{
    /// <summary>
    /// Interaction logic for CanalVinculacion.xaml
    /// </summary>
    public partial class CanalVinculacion : Page
    {

        RiskField CanalVinc;
        public RiskField XamlCanalVinc { get { return CanalVinc; } }
        public CanalVinculacion()
        {
            CanalVinc = new RiskField(1);
            this.DataContext = this;
            InitializeComponent();
        }

        private void CheckBoxes_checked(object sender, RoutedEventArgs e)
        {
            int risk = 0;
            if ((bool)Matriz.IsChecked) { if (risk < 3) risk = 3; }
            else if ((bool)RefCliente.IsChecked) { if (risk < 2) risk = 2; }
            else if ((bool)RefGerencias.IsChecked) { if (risk < 2) risk = 2; }
            else if ((bool)Campanas.IsChecked) { if (risk < 2) risk = 2; }
            else if ((bool)Cajeros.IsChecked) { if (risk < 1) risk = 1; }
            else if ((bool)Redes.IsChecked) { if (risk < 1) risk = 1; }
            else if ((bool)Online.IsChecked) { if (risk < 1) risk = 1; }
            else { risk = 1; }
            CanalVinc.SetRisk(risk);
        }
    }
}