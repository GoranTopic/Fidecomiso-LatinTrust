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
using System.Diagnostics;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.IO;

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
        Password pswd_page = new Password();
        RiskChart Chart_Page = (App.Current as App).Analysis.Chart_Page;
        GraphWindow GrapWin;
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = pswd_page;
        }

        private void Salir(object sender, RoutedEventArgs e)
        {
            if (Helpers.IsWindowOpen<GraphWindow>()) GrapWin.Close();
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
            else if (item.Name == "Chart")
            {
                if (Helpers.IsWindowOpen<GraphWindow>()) GrapWin.Close();
                MainFrame.Content = Chart_Page;
            }
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

        private void OpenWindowGraph(object sender, RoutedEventArgs e)
        {

            if (Helpers.IsWindowOpen<GraphWindow>())
            {
                GrapWin.Close();
            }
            else
            {
                GrapWin = new GraphWindow();
                GrapWin.GraphFrame.Content = Chart_Page;
                GrapWin.Show();
            }

        }

        private void SaveAnalysis(object sender, RoutedEventArgs e)
        {
            //BuildPngOnClick("charty");
           // Stream file = File.Create("Chart");
           // var result = Helpers.GetImage((App.Current as App).Analysis.Chart_Page.ChartsGrid);
           
            //Helpers.SaveAsPng(result, file);

            RiskChart control = (App.Current as App).Analysis.Chart_Page;
            double width = control.ActualWidth;
            double height = control.ActualHeight;

            control.Measure(new Size(width, height));
            control.Arrange(new Rect(new Size(width, height)));

            RenderTargetBitmap bmp = new RenderTargetBitmap((int)width, (int)height, 100, 100, PixelFormats.Pbgra32);

            bmp.Render(control);

            var encoder = new PngBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create(bmp));

            using (Stream stm = File.Create("test.png"))
                encoder.Save(stm);

        }
        
    }
    
    public static class Helpers
    {
        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<T>().Any()
               : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

    }
}
