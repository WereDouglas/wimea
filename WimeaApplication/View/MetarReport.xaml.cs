using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
    /// Interaction logic for MetarReport.xaml
    /// </summary>
    public partial class MetarReport : Page
    {
       
        private Metar u;
        private ObservableCollection<Station> _StationsList = null;
        private List<Metar> metList = new List<Metar>();
        public MetarReport()
        {
            InitializeComponent();
            RefreshUserList();
        }
        private void RefreshUserList()
        {

           
            _StationsList = new ObservableCollection<Station>(App.WimeaApp.Stations);           
            stationTxtCbx.ItemsSource = null;
            stationTxtCbx.ItemsSource = _StationsList.Select(c => c.Name);
            for (int p = 1; p < 32; p++)
            {
                dayTxtCbx.Items.Add(p);
            }
            for (int p = 1; p < 13; p++)
            {
                monthTxtCbx.Items.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(p));
            }
            


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
        private void stationTxtCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            stationNumber.Content = _StationsList.Where(c => c.Name == stationTxtCbx.SelectedItem.ToString()).Select(p => p.Code).SingleOrDefault().ToString();
           

        }
        private void loadings(string station)
        {
            metList = new List<Metar>();
            try
            {
                string total = "";
                string[] lines = System.IO.File.ReadAllLines(@"D:\" + station + "-" + "metar" + ".json");
                foreach (string line in lines)
                {
                  
                    total += line;
                }

                List<MetarOnline> model = JsonConvert.DeserializeObject<List<MetarOnline>>(total);
               
                for (int d = 0; d < model.Count; d++)
                {
                    u = new Metar(null);
                    u.Station = model.ElementAt(d).Station;
                    u.Types = model.ElementAt(d).Type;
                    u.Datetimes = model.ElementAt(d).Datetime;
                    u.Timezones = model.ElementAt(d).Timezone;
                    u.Direction = model.ElementAt(d).Wind_direction;
                    u.Speed = model.ElementAt(d).Wind_speed;
                    u.Unit = model.ElementAt(d).Unit;
                    u.Visibility = model.ElementAt(d).Visibility;
                    u.Weather = model.ElementAt(d).Present_weather;
                    u.Cloud = model.ElementAt(d).Cloud;
                    u.Temperature = model.ElementAt(d).Air_temperature;
                    u.Humidity = model.ElementAt(d).Humidity;
                    u.Dew = model.ElementAt(d).Dew_temperature;
                    u.Wet = model.ElementAt(d).Wet_bulb;
                    u.Stationhpa = model.ElementAt(d).Station_pressure_hpa;
                    u.Seahpa = model.ElementAt(d).Sea_pressure_hpa;
                    u.Recent = model.ElementAt(d).Recent_weather;
                    u.Users = model.ElementAt(d).User;
                    u.Days = model.ElementAt(d).Day;
                    metList.Add(u);
                }


                List<Metar> metLists = new List<Metar>(metList.Where(c => Convert.ToDateTime(c.Days).Month.ToString() == (monthTxtCbx.SelectedIndex+1).ToString() &&  Convert.ToDateTime(c.Days).Day.ToString() == dayTxtCbx.Text  &&  Convert.ToDateTime(c.Days).Year.ToString() == yearTxtBx.Text ));
         
                MetarGrid.ItemsSource = null;
                MetarGrid.ItemsSource = metLists;

                   

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
                return;

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loadings(stationTxtCbx.Text);
            
        }
    }
}
