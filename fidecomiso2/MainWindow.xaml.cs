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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Cliente Client_Page = new Cliente();
        UbicacionGeografica UG_Page = new UbicacionGeografica();
        ProductoServicio PS_Page = new ProductoServicio();
        CanalVinculacion CV_Page = new CanalVinculacion();
        RiesgoTransacional RTrans_Page = new RiesgoTransacional();
        RiskChart Chart_Page = new RiskChart();

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = Client_Page;
        }   

        private void Salir(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void New_Client(object sender, RoutedEventArgs e)
        {
            (App.Current as App).Analysis = new RiskAnalysis();
            Client_Page = new Cliente();
            UG_Page = new UbicacionGeografica();
            PS_Page = new ProductoServicio();
            CV_Page = new CanalVinculacion();
            RTrans_Page = new RiesgoTransacional();
            Chart_Page = new RiskChart();
            MainFrame.Content = Client_Page;
        }

        private void ToggelMenu_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonOpenMenu.Visibility == Visibility.Visible)
                ButtonOpenMenu.Visibility = Visibility.Collapsed;
            else
                ButtonOpenMenu.Visibility = Visibility.Visible;


            if (ButtonCloseMenu.Visibility == Visibility.Visible)
                ButtonCloseMenu.Visibility = Visibility.Collapsed;
            else
                ButtonCloseMenu.Visibility = Visibility.Visible;

        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;

        }
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListViewItem item = (ListViewItem)sender;
            if (item.Name == "cliente") MainFrame.Content = Client_Page;
            else if (item.Name == "ubicacion") MainFrame.Content = UG_Page;
            else if (item.Name == "productoServicio") MainFrame.Content = PS_Page;
            else if (item.Name == "viculacion") MainFrame.Content = CV_Page;
            else if (item.Name == "transacional") MainFrame.Content = RTrans_Page;
            else if (item.Name == "Chart") MainFrame.Content = Chart_Page;
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ButtonOpenMenu.Visibility == Visibility.Visible)
                ButtonOpenMenu.Visibility = Visibility.Collapsed;
            else
                ButtonOpenMenu.Visibility = Visibility.Visible;


            if (ButtonCloseMenu.Visibility == Visibility.Visible)
                ButtonCloseMenu.Visibility = Visibility.Collapsed;
            else
                ButtonCloseMenu.Visibility = Visibility.Visible;


        }
    }
}
