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


namespace fidecomiso2
{
    /// <summary>
    /// Interaction logic for UbicacionGeografica.xaml
    /// </summary>
    public partial class UbicacionGeografica : Page
    {
        RiskField UbcGeo;
        public RiskField XamlUbcGeo { get { return UbcGeo; } }

        RiskField LugarEco;
        public RiskField XamlLugarEco { get { return LugarEco; } }
        public UbicacionGeografica()
        {
            UbcGeo = new RiskField("GeoLocation", 0.4m);
            LugarEco = new RiskField("EconomicActivityLocation", 0.6m);


            (App.Current as App).Analysis.GeoLocRisks.Add(UbcGeo);
            (App.Current as App).Analysis.GeoLocRisks.Add(LugarEco);
            this.DataContext = this;
            InitializeComponent();
        }


        private void CheckBoxes_checked(object sender, RoutedEventArgs e)
        {
            
            int count = 0;
            foreach (CheckBox cb in RiskField.FindVisualChildren<CheckBox>(UbicacionCB))
                if ((bool)cb.IsChecked) count++;

            if (count > 0) UbcGeo.SetRisk(3);
            else UbcGeo.SetRisk(1);

            count = 0;
            foreach (CheckBox cb in RiskField.FindVisualChildren<CheckBox>(LugarActEcoCB))
                if ((bool)cb.IsChecked) count++;

            if (count > 0 && count < 4) LugarEco.SetRisk(count);

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            fidecomiso2.MainWindow mw = (fidecomiso2.MainWindow)App.Current.MainWindow;
            mw.MainFrame.Content = mw.PS_Page;
        }

    }

}
