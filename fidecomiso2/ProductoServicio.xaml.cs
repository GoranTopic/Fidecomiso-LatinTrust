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
    /// Interaction logic for ProductoServicio.xaml
    /// </summary>
    /// 

    public partial class ProductoServicio : Page
    {
        RiskField ProdServ;
        public RiskField XamlProdServ { get { return ProdServ; } }
        public ProductoServicio()
        {
            ProdServ = new RiskField(1);
            this.DataContext = this;
            InitializeComponent();
        }


        private void CheckBoxes_checked(object sender, RoutedEventArgs e)
        {

            int count = 0;
            foreach (CheckBox cb in RiskField.FindVisualChildren<CheckBox>(ProdServCB))
                if ((bool)cb.IsChecked) count++;

            if (count > 0 && count < 4) ProdServ.SetRisk(count);
        }

    }

}
