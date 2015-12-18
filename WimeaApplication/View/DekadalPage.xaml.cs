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
    /// Interaction logic for DekadalPage.xaml
    /// </summary>
    public partial class DekadalPage : Page
    {
        private Dekadal u;
        private ObservableCollection<Station> _StationsList = null;
       
        private List<Dekadal> dekadalList = new List<Dekadal>();
        public DekadalPage()
        {
            InitializeComponent();
            RefreshUserList();
        }
        private void RefreshUserList()
        {


            _StationsList = new ObservableCollection<Station>(App.WimeaApp.Stations);
            stationTxtCbx.ItemsSource = null;
            stationTxtCbx.ItemsSource = _StationsList.Select(c => c.Name);
            

            for (int p = 1; p < 13; p++)
            {
                monthTxtCbx.Items.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(p));
            }
            yearTxtBx.Text = DateTime.Now.Year.ToString();



        }
        private void stationTxtCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            stationNumber.Content = _StationsList.Where(c => c.Name == stationTxtCbx.SelectedItem.ToString()).Select(p => p.Code).SingleOrDefault().ToString();


        }

        List<Daily> metLists = new List<Daily>();
        private void loadings(string station)
        {
            dekadalList.Clear();   
            string datetime9 = "0900Z";
             string datetime3 = "1500Z";
         
            try
           {
            string total = "";
            string[] lines = System.IO.File.ReadAllLines(Sending.directoryUrl + station + "-" + "daily" + ".json");
            foreach (string line in lines)
            {

                total += line;
            }

            List<DailyOnline> model = JsonConvert.DeserializeObject<List<DailyOnline>>(total);

            for (int d = 0; d < model.Count; d++)
            {
                u = new Dekadal();
                u.Station = model.ElementAt(d).Station;
                u.Date = Convert.ToDateTime(model.ElementAt(d).Date).Day.ToString();
                u.Dam = model.ElementAt(d).Date;
                u.Min = model.ElementAt(d).Min;
                u.Max = model.ElementAt(d).Max;
                u.Rain = model.ElementAt(d).Actual;
                ///////////////
                 string total2 = "";
                 string[] line2 = System.IO.File.ReadAllLines(Sending.directoryUrl + station + "-" + "metar" + ".json");
            foreach (string line in line2)
            {

                total2 += line;
            }

            List<MetarOnline> model2 = JsonConvert.DeserializeObject<List<MetarOnline>>(total2);

            for (int d2 = 0; d2 < model2.Count; d2++)
            {
                //System.Diagnostics.Debug.WriteLine(model2.ElementAt(d2).Datetime.Contains(datetime9));
               System.Diagnostics.Debug.WriteLine( Convert.ToDateTime(model2.ElementAt(d2).Day).Date.Day.ToString());


                if(model2.ElementAt(d2).Datetime.Contains(datetime9) && model2.ElementAt(d2).Day==u.Dam){

                    u.Db9 = model2.ElementAt(d2).Air_temperature;
                    u.Wb9 = model2.ElementAt(d2).Wet_bulb;
                    u.Dp9 = model2.ElementAt(d2).Dew_temperature;
                    u.Rh9 = model2.ElementAt(d2).Humidity;
                    u.Windd9 = model2.ElementAt(d2).Wind_direction;
                    u.Windc9 = DegreesToCardinalDetailed(Convert.ToDouble(model2.ElementAt(d2).Wind_direction)).ToString();
                    u.Speedk9 = model2.ElementAt(d2).Wind_speed;
                    u.Speedm9 = KtToMs(Convert.ToDouble(model2.ElementAt(d2).Wind_speed)).ToString();
                    u.Time9 = model2.ElementAt(d2).Datetime;
                }
                if (model2.ElementAt(d2).Datetime.Contains(datetime3) && model2.ElementAt(d2).Day == u.Dam)
                {

                    u.Db3 = model2.ElementAt(d2).Air_temperature;
                    u.Wb3 = model2.ElementAt(d2).Wet_bulb;
                    u.Dp3 = model2.ElementAt(d2).Dew_temperature;
                    u.Rh3 = model2.ElementAt(d2).Humidity;
                    u.Windd3 = model2.ElementAt(d2).Wind_direction;
                    u.Windc3 = DegreesToCardinalDetailed(Convert.ToDouble(model2.ElementAt(d2).Wind_direction)).ToString();
                    u.Speedk3 = model2.ElementAt(d2).Wind_speed;
                    u.Speedm3 = KtToMs(Convert.ToDouble(model2.ElementAt(d2).Wind_speed)).ToString();
                    u.Rain3 = "";
                    u.Time3 = model2.ElementAt(d2).Datetime;
                }


                     

            }
                /////////////////////

            dekadalList.Add(u); 
            }

            DekadalGrid.ItemsSource = null;

             DekadalGrid.ItemsSource = (dekadalList.Where(c => Convert.ToDateTime(c.Dam).Month.ToString() == (monthTxtCbx.SelectedIndex + 1).ToString() && Convert.ToDateTime(c.Dam).Year.ToString() == yearTxtBx.Text).OrderBy(c=>c.Dam));

           }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
                return;

            }

        }
        public static double KtToMs(double speed)
        {
            return (speed * 0.514444);
        }
        public static string DegreesToCardinalDetailed(double degrees)
        {
            degrees *= 10;

            string[] caridnals = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "N" };
            return caridnals[(int)Math.Round(((double)degrees % 3600) / 225)];
        }
        private string filltext(string value)
        {
            try
            {
                return metLists.Where(c => Convert.ToDateTime(c.Dates).Day.ToString() == value).Select(p => p.Actual).SingleOrDefault().ToString();

            }
            catch
            {
                return null;


            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loadings(stationTxtCbx.Text);

        }
        private void ExportToExcel()
        {
            DekadalGrid.SelectAllCells();
            DekadalGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, DekadalGrid);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            DekadalGrid.UnselectAllCells();
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Wimea\dekadals.xls");
            file.WriteLine(result.Replace(',', ' '));
            file.Close();

            MessageBox.Show(" Exporting DataGrid data to Excel file created");
        }

        private void Button_Click_export(object sender, RoutedEventArgs e)
        {
            ExportToExcel();
        }
    }
}
