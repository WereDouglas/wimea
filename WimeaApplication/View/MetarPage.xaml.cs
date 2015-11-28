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
    /// Interaction logic for MetarPage.xaml
    /// </summary>
    public partial class MetarPage : Page
    {

        private ObservableCollection<Metar> _metarList = null;
        private Metar u;
        private ObservableCollection<Station> _StationsList = null;
        public MetarPage()
        {
            InitializeComponent();
            _StationsList = new ObservableCollection<Station>(App.WimeaApp.Stations);
            stationTxtCbx.ItemsSource = null;
            stationTxtCbx.ItemsSource = _StationsList.Select(c => c.Name);
            RefreshUserList();
        }
        private void RefreshUserList()
        {

            _metarList = new ObservableCollection<Metar>(App.WimeaApp.Metars);
            MetarGrid.ItemsSource = null;
            MetarGrid.ItemsSource = _metarList;
            

        }
        private void deleteClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as System.Windows.Controls.Button;
            Metar metar = button.DataContext as Metar;

            if (MessageBox.Show("Are you sure you want to delete this metar ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                metar.Delete(metar.Id.ToString());
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

        private void stationTxtCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            stationNumber.Content = _StationsList.Where(c => c.Name == stationTxtCbx.SelectedItem.ToString()).Select(p => p.Number).SingleOrDefault().ToString();
            codeTxtBx.Text = _StationsList.Where(c => c.Name == stationTxtCbx.SelectedItem.ToString()).Select(c => c.Code).SingleOrDefault().ToString();
            DatetimeTxtBx.Text = DateTime.Now.Date.Day.ToString() + DateTime.Now.Hour.ToString()+"00Z";
        
        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           try {
               if (MessageBox.Show("confirm this information ?" + typeTxtBx.Text + " " + DatetimeTxtBx.Text + " " + VisibilityTxtBx.Text, "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
               {

            u = App.WimeaApp.Metars.Add();

            u.Station = stationTxtCbx.Text;
            u.Types = typeTxtBx.Text;
            u.Datetimes = DatetimeTxtBx.Text;
            u.Timezones = "GMT";
            u.Direction = WindDirectionTxtBx.Text;
            u.Speed = "13";
            u.Unit = "KT";
            u.Visibility = VisibilityTxtBx.Text;
            u.Weather = weatherTxtBx.Text;
            u.Cloud = CloudTxtBx.Text;
            u.Temperature = AirTempTxtBx.Text;
            u.Humidity = HumidityTxtBx.Text;
            u.Dew = DewTxtBx.Text;
            u.Wet =WetTxtBx.Text;
            u.Stationhpa = StationHpaTxtBx.Text;
            u.Seahpa = SeaHpaTxtBx.Text;
            u.Recent = RecentTxtBx.Text;
            u.Users = "test";
            u.Days = DateTime.Now.Date.ToString();

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
        private void clear() {

       
           DatetimeTxtBx.Text="";
         
         WindDirectionTxtBx.Text="";
        
        VisibilityTxtBx.Text="";
          weatherTxtBx.Text="";
            CloudTxtBx.Text="";
            AirTempTxtBx.Text = "";
            HumidityTxtBx.Text = "";
            DewTxtBx.Text = "";
            WetTxtBx.Text = "";
            StationHpaTxtBx.Text = "";
            SeaHpaTxtBx.Text = "";
            RecentTxtBx.Text = "";
         
        
        }

        private void HumidityTxtBx_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                double dew = ((Convert.ToDouble(HumidityTxtBx.Text) * Convert.ToDouble(AirTempTxtBx.Text)) / 100);
                double wet = (dew * 2) + Convert.ToDouble(AirTempTxtBx.Text) / 3;

                DewTxtBx.Text = ((Convert.ToDouble(HumidityTxtBx.Text) * Convert.ToDouble(AirTempTxtBx.Text)) / 100).ToString();
                WetTxtBx.Text = wet.ToString();
                TtTxtBx.Text = AirTempTxtBx.Text;
                TdTxtBx.Text = dew.ToString();
            }
            catch {

                MessageBox.Show("please use numbers/integers for these values !");
            
            }
        
        }

        private void StationHpaTxtBx_LostFocus(object sender, RoutedEventArgs e)
        {
            try { 
            StationHpaInTxtBx.Text = (0.02952998751 * Convert.ToDouble(StationHpaTxtBx.Text)).ToString();
            }
            catch
            {

                MessageBox.Show("please use numbers/integers for these values !");

            }
        }

        private void SeaHpaTxtBx_LostFocus(object sender, RoutedEventArgs e)
        {
            try { 
            SeaHpaInTxtBx.Text = (0.02952998751 * Convert.ToDouble(SeaHpaTxtBx.Text)).ToString();
            }
            catch
            {

                MessageBox.Show("please use numbers/integers for these values !");

            }
        }
    }
    
}
