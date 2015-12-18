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
    /// Interaction logic for DailyReport.xaml
    /// </summary>
    public partial class DailyReport : Page
    {
        private Daily u;
        private ObservableCollection<Station> _StationsList = null;
        private List<Daily> metList = new List<Daily>();
        public DailyReport()
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
        private void loadings(string station)
        {
            metList = new List<Daily>();
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
                    u = new Daily(null);
                    u.Station = model.ElementAt(d).Station;
                    u.Id =  model.ElementAt(d).Id;                  
                    u.Maxs =  model.ElementAt(d).Max;
                    u.Mins =  model.ElementAt(d).Min;
                    u.Actual = model.ElementAt(d).Actual;
                    u.Anemometer =  model.ElementAt(d).Anemometer;
                    u.Wind =  model.ElementAt(d).Wind;
                    u.Maxi =  model.ElementAt(d).Maxi;
                    u.Rain =  model.ElementAt(d).Rain;
                    u.Thunder =  model.ElementAt(d).Thunder;
                    u.Fog =  model.ElementAt(d).Fog;
                    u.Haze =  model.ElementAt(d).Haze;
                    u.Storm =  model.ElementAt(d).Storm;
                    u.Quake =  model.ElementAt(d).Quake;
                    u.Height =  model.ElementAt(d).Height;
                    u.Duration =  model.ElementAt(d).Duration;
                    u.Sunshine =  model.ElementAt(d).Sunshine;
                    u.Radiationtype =  model.ElementAt(d).Radiationtype;
                    u.Radiation =  model.ElementAt(d).Radiation;
                    u.Evaptype1 =  model.ElementAt(d).Evaptype1;
                    u.Evap1 =  model.ElementAt(d).Evap1;
                    u.Evaptype2 =  model.ElementAt(d).Evaptype2;
                    u.Evap2 =  model.ElementAt(d).Evap2;
                    u.Users =  model.ElementAt(d).User;                    
                    u.Dates = model.ElementAt(d).Date;
                    metList.Add(u);
                }


                List<Daily> metLists = new List<Daily>(metList.Where(c => Convert.ToDateTime(c.Dates).Month.ToString() == (monthTxtCbx.SelectedIndex + 1).ToString()  && Convert.ToDateTime(c.Dates).Year.ToString() == yearTxtBx.Text).OrderBy(c=>c.Dates));

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
        private void Button_Click_export(object sender, RoutedEventArgs e)
        {
            ExportToExcel();
        }
        private void ExportToExcel()
        {
            MetarGrid.SelectAllCells();
            MetarGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, MetarGrid);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            MetarGrid.UnselectAllCells();
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Wimea\daily.xls");
            file.WriteLine(result.Replace(',', ' '));
            file.Close();

            MessageBox.Show(" Exporting DataGrid data to Excel file created");
        }
    }
}
