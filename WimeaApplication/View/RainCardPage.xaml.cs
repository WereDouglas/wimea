using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
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

namespace WimeaApplication.View
{
    /// <summary>
    /// Interaction logic for RainCardPage.xaml
    /// </summary>
    public partial class RainCardPage : Page
    {
        private Daily u;
        private ObservableCollection<Station> _StationsList = null;
        private List<Daily> metList = new List<Daily>();
        public RainCardPage()
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
            metList = new List<Daily>();
            metLists = new List<Daily>();
            //try
            //{
            string total = "";
            string[] lines = System.IO.File.ReadAllLines(@"D:\" + station + "-" + "daily" + ".json");
            foreach (string line in lines)
            {

                total += line;
            }

            List<DailyOnline> model = JsonConvert.DeserializeObject<List<DailyOnline>>(total);

            for (int d = 0; d < model.Count; d++)
            {
                u = new Daily(null);
                u.Station = model.ElementAt(d).Station;
                u.Id = model.ElementAt(d).Id;
                u.Maxs = model.ElementAt(d).Max;
                u.Mins = model.ElementAt(d).Min;
                u.Actual = model.ElementAt(d).Actual;
                u.Anemometer = model.ElementAt(d).Anemometer;
                u.Wind = model.ElementAt(d).Wind;
                u.Maxi = model.ElementAt(d).Maxi;
                u.Rain = model.ElementAt(d).Rain;
                u.Thunder = model.ElementAt(d).Thunder;
                u.Fog = model.ElementAt(d).Fog;
                u.Haze = model.ElementAt(d).Haze;
                u.Storm = model.ElementAt(d).Storm;
                u.Quake = model.ElementAt(d).Quake;
                u.Height = model.ElementAt(d).Height;
                u.Duration = model.ElementAt(d).Duration;
                u.Sunshine = model.ElementAt(d).Sunshine;
                u.Radiationtype = model.ElementAt(d).Radiationtype;
                u.Radiation = model.ElementAt(d).Radiation;
                u.Evaptype1 = model.ElementAt(d).Evaptype1;
                u.Evap1 = model.ElementAt(d).Evap1;
                u.Evaptype2 = model.ElementAt(d).Evaptype2;
                u.Evap2 = model.ElementAt(d).Evap2;
                u.Users = model.ElementAt(d).User;
                u.Dates = model.ElementAt(d).Date;
                metList.Add(u);
            }


            metLists = new List<Daily>(metList.Where(c => Convert.ToDateTime(c.Dates).Month.ToString() == (monthTxtCbx.SelectedIndex + 1).ToString() && Convert.ToDateTime(c.Dates).Year.ToString() == yearTxtBx.Text));
            double totals = 0;
            foreach (var val in metLists)
            {
                totals += Convert.ToDouble(val.Actual);

            }



            totalsTxtBx.Text = totals.ToString();
            
            twentyeightTxtBx.Text = filltext("21");



            threeTxtBx.Text = filltext("3");
            twoTxtBx.Text = filltext("2");
            seventTxtBx.Text=filltext("17");
            sevenTxtBx.Text = filltext("7");
            eightTxtBx.Text = filltext("8");
            eighteenTxtBx.Text = filltext("18");
            tenTxtBx.Text = filltext("10");
            elevenTxtBx.Text = filltext("11");
            thirtTxtBx.Text = filltext("13");
            fiftTxtBx.Text = filltext("15");
            sixtTxtBx.Text = filltext("16");
            twentyTxtBx.Text = filltext("20");
            twentyoneTxtBx.Text = filltext("21");
            twentytwoTxtBx.Text = filltext("22");
            twentythreeTxtBx.Text = filltext("23");
            twentyFourTxtBx.Text = filltext("24");
            twentyfiveTxtBx.Text = filltext("25");
            twentysixTxtBx.Text = filltext("26");
            twentysevenTxtBx.Text = filltext("27");
            twentyeightTxtBx.Text = filltext("28");
            twentynineTxtBx.Text = filltext("29");
            thirtyTxtBx.Text = filltext("30");
            thirtyoneTxtBx.Text = filltext("31");                
            fourTxtBx.Text = filltext("4");
            fiveTxtBx.Text = filltext("5");
            nineTxtBx.Text = filltext("9");
            sixTxtBx.Text = filltext("6");
            ninetTxtBx.Text = filltext("19");
            tweleveTxtBx.Text = filltext("12");
            twentyoneTxtBx.Text = filltext("21");
            twentythreeTxtBx.Text = filltext("23");
            fourtTxtBx.Text = filltext("14");
            thirtyoneTxtBx.Text = filltext("31");        
          

            // }
            //catch (Exception ex)
            //{

            //     MessageBox.Show(ex.Message.ToString());
            //    return;

            //}

        }
        private string filltext(string value) { 
          try
            {
            return    metLists.Where(c => Convert.ToDateTime(c.Dates).Day.ToString() == value).Select(p => p.Actual).SingleOrDefault().ToString();

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
    }
}