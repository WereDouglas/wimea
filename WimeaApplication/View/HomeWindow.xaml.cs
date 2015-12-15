using AutoUpdaterDotNET;
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
using WimeaLibrary;

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
            username.Content = Sending.currentusername;
            station.Content = Sending.currentstation;
           
            if(Sending.currentinstance.Contains("center")){
                metar.Visibility = Visibility.Hidden;
                daily.Visibility = Visibility.Hidden;
                Dekadal.Visibility = Visibility.Hidden;
                synoptic.Visibility = Visibility.Hidden;
                view.Visibility = Visibility.Hidden;
            
            }
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
            Login w = new Login();
            w.Owner = Window.GetWindow(this);
            w.Show();
            w.Visibility = Visibility.Visible;          
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
            _mainFrame.NavigationService.Navigate(new Uri("view/SynopticReport.xaml", UriKind.Relative));
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

        private void Button_Click_view(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/SynopticsPage.xaml", UriKind.Relative));
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/DekadalPage.xaml", UriKind.Relative));
        }

        private void Button_Click_dekadals(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/DekadalPage.xaml", UriKind.Relative));
        }

        private void Button_Click_report(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/RainReport.xaml", UriKind.Relative));
        }

        private void Button_Click_monthly(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/MonthlyReport.xaml", UriKind.Relative));
        }

        private void Button_Click_clim(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/ClimReport.xaml", UriKind.Relative));
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            AutoUpdater.OpenDownloadPage = true;         
            AutoUpdater.Start(Sending.fileUrl + "wimea.xml");
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/ElementPage.xaml", UriKind.Relative));
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            _mainFrame.NavigationService.Navigate(new Uri("view/InstrumentPage.xaml", UriKind.Relative));
        }

       

       
    }
}
