using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WimeaLibrary;

namespace WimeaApplication
{
    /// <summary>
    /// Interaction logic for DailyPage.xaml
    /// </summary>
    public partial class DailyPage : Page
    {
        private ObservableCollection<Daily> _dailyList = null;
        private Daily u;
        private ObservableCollection<Station> _StationsList = null;
        public DailyPage()
        {
            InitializeComponent();
            _StationsList = new ObservableCollection<Station>(App.WimeaApp.Stations);
            stationTxtCbx.ItemsSource = null;
            stationTxtCbx.ItemsSource = _StationsList.Select(c => c.Name);
            RefreshUserList();
        }
        private void RefreshUserList()
        {

            _dailyList = new ObservableCollection<Daily>(App.WimeaApp.Dailys);
            MetarGrid.ItemsSource = null;
            MetarGrid.ItemsSource = _dailyList;


        }
        private void deleteClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as System.Windows.Controls.Button;
            Daily daily = button.DataContext as Daily;

            if (MessageBox.Show("Are you sure you want to delete this information ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                daily.Delete(daily.Id.ToString());
                RefreshUserList();
            }
            else
            {

                return;
            }



        }
      

        private void dataGridEvaluation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("confirm this information ?" + dates.Text + " " + stationTxtCbx.Text + " ", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    u = App.WimeaApp.Dailys.Add();
                    u.Station = stationTxtCbx.Text;
                    u.Maxs = maxTemp.Text;
                    u.Mins = minTemp.Text;
                    u.Actual = Rainfall.Text;
                    u.Anemometer = AnemometerHeight.Text;
                    u.Wind = WindRun.Text;
                    u.Maxi = maxTemp.Text;

                    if (RainfallChk.IsChecked == true)
                        u.Rain = "true";
                    else u.Rain = "false";

                    if(ThunderstormChk.IsChecked==true)
                        u.Thunder = "true";
                    else u.Thunder = "false";
                    if (FogChk.IsChecked == true)
                        u.Fog = "true";
                    else u.Fog = "false";

                    if (HazeChk.IsChecked == true)
                        u.Haze = "true";
                    else u.Haze = "false";

                    if (ThunderstormChk.IsChecked == true)
                        u.Thunder = "true";
                    else u.Thunder = "false";

                    if (HailChk.IsChecked == true)
                        u.Storm = "true";
                    else u.Storm = "false";
                    if (QuakeChk.IsChecked == true)
                        u.Quake = "true";
                    else u.Quake = "false"; 
                 
                    u.Height = AnemometerHeight.Text;
                    u.Duration = RainDuration.Text;
                    u.Sunshine = Sunshine.Text;
                    u.Radiationtype = Radtype.Text;
                    u.Radiation = Radiation.Text;
                    u.Evaptype1 = EvapType.Text;
                    u.Evap1 = Evap.Text;
                    u.Evaptype2 = Evaptype2.Text;
                    u.Evap2 = Evap2.Text;
                    u.Users = "user";
                    u.Dates = dates.Text;

                    u.Save();
                    RefreshUserList();
                    clear();

                }
                else
                {

                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
                return;

            }
        }
        private void clear()
        {


            stationTxtCbx.Text="";
            maxTemp.Text = "";
            minTemp.Text = "";
            maxTemp.Text = "";
            AnemometerHeight.Text = "";
            WindRun.Text = "";
            maxTemp.Text = "";
            Rainfall.Text = "";
           ThunderstormChk.IsChecked = false;             
           FogChk.IsChecked = false;
           HazeChk.IsChecked = false; 
           ThunderstormChk.IsChecked = false;
            HailChk.IsChecked = false;
            QuakeChk.IsChecked = false;             
           
            AnemometerHeight.Text = "";
            RainDuration.Text = "";
            Sunshine.Text = "";
            Radtype.Text = "";
            Radiation.Text = "";
            EvapType.Text = "";
            Evap.Text = "";
            Evaptype2.Text = "";
            Evap2.Text = "";         
         


        }

        private void stationTxtCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
   
}
