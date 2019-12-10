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
    /// Interaction logic for Password.xaml
    /// </summary>
    /// 
    public partial class Password : Page
    {

        private BitmapImage _ImageData;
        public BitmapImage ImageData
        {
            get { return this._ImageData; }
            set { this._ImageData = value; }
        }

        ImageSource imgSource = new BitmapImage(new Uri("C:\\Users\\gusta\\Source\\Repos\\Fidecomiso\\fidecomiso2\\bin\\Debug\\LatinTrustLogo.png"));


        public Password()
        {

            InitializeComponent();
            image1.Source = imgSource;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (pswdBox.Password.ToString() == "latintrust2020")
                this.NavigationService.Navigate(new Uri("Cliente.xaml", UriKind.Relative));
            else
                statusText.Content = "Wrong Password";
        }
           }
}
