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
using System.Windows.Shapes;

namespace WimeaApplication
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/DailyPage.xaml", UriKind.Relative));
 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/MetarPage.xaml", UriKind.Relative));
 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/station/StationPage.xaml", UriKind.Relative));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/ArchivePage.xaml", UriKind.Relative));
        }

       
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
        
            _mainFrame.NavigationService.Navigate(new Uri("view/user/UserPage.xaml", UriKind.Relative));
        }

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/RainCardPage.xaml", UriKind.Relative));
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/SettingPage.xaml", UriKind.Relative));
        }

        private void reportS_Click(object sender, RoutedEventArgs e)
        {

        }

        private void reportD_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/DailyReport.xaml", UriKind.Relative));
        }

        private void reportM_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/MetarReport.xaml", UriKind.Relative));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/SynopticPage.xaml", UriKind.Relative));
        }
    }
}
