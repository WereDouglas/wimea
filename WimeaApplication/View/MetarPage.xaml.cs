using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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
    /// Interaction logic for MetarPage.xaml
    /// </summary>
    public partial class MetarPage : Page
    {

        private ObservableCollection<Metar> _metarList = null;
        private Metar u;
        private ObservableCollection<Station> _StationsList = null;
        private BackgroundWorker bw = new BackgroundWorker();
        public MetarPage()
        {
            InitializeComponent();
            RefreshUserList();


            if (Sending.IsInternetAvailable())
            {
                internet.Content = "internet connection available";
                bw.RunWorkerAsync();
                bw.WorkerReportsProgress = true;
                //  bw.WorkerSupportsCancellation = true;
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            }
            else
            {

                internet.Content = "no internet connection";

            }

        }
        private void RefreshUserList()
        {

            _metarList = new ObservableCollection<Metar>(App.WimeaApp.Metars);
            _StationsList = new ObservableCollection<Station>(App.WimeaApp.Stations);
           // List<Metar> metLists = new List<Metar>(metList.Where(c => Convert.ToDateTime(c.Days).Month.ToString() == (monthTxtCbx.SelectedIndex + 1).ToString() && Convert.ToDateTime(c.Days).Day.ToString() == dayTxtCbx.Text && Convert.ToDateTime(c.Days).Year.ToString() == yearTxtBx.Text));

            for (int p = 1; p < 32; p++)
            {
                dayTxtCbx.Items.Add(p);
            }
            for (int p = 1; p < 13; p++)
            {
                monthTxtCbx.Items.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(p));
            }

            yearTxtBx.Text = DateTime.Now.Year.ToString();
            stationTxtCbx.Text = Sending.currentstation;

            MetarGrid.ItemsSource = null;
            MetarGrid.ItemsSource = _metarList.Where(c => Convert.ToDateTime(c.Days).Month.ToString() == (DateTime.Now.Month).ToString() && Convert.ToDateTime(c.Days).Day == DateTime.Now.Day && Convert.ToDateTime(c.Days).Year == DateTime.Now.Year);

            stationNumber.Content = _StationsList.Where(c => c.Name == stationTxtCbx.Text.ToString()).Select(p => p.Number).SingleOrDefault().ToString();
            codeTxtBx.Text = _StationsList.Where(c => c.Name == stationTxtCbx.Text.ToString()).Select(c => c.Code).SingleOrDefault().ToString();
            DatetimeTxtBx.Text = DateTime.Now.Date.Day.ToString() + DateTime.Now.Hour.ToString() + "00Z";

        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                this.tbProgress.Content = "Canceled!";
            }

            else if (!(e.Error == null))
            {
                this.tbProgress.Content = ("Error: " + e.Error.Message);
            }

            else
            {
                this.tbProgress.Content = "synchronised information!";
            }
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.tbProgress.Content = (e.ProgressPercentage.ToString() + "Count");
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int counter = _metarList.Count(c => c.Sync == "F" || c.Sync == "");

            List<Metar> sendies = new List<Metar>();
            sendies = _metarList.Where(c => c.Sync == "F" || c.Sync == "").ToList();

            string URL = Sending.genUrl + "apimetar/metar";


            foreach (Metar row in sendies)
            {               

                NameValueCollection formData = new NameValueCollection();
                formData["type"] = row.Types;
                formData["code"] = row.Station;
                formData["datetime"] = row.Station;
                formData["wind"] = row.Direction +" "+row.Speed +" "+row.Unit;
                formData["visibility"] = row.Visibility;
                formData["present"] = row.Weather;
                formData["cloud"] = row.Cloud;
                formData["stationhpa"] = row.Stationhpa;
                formData["seahpa"] = row.Seahpa;
                formData["recent"] = row.Recent;
                formData["temperatue"] = row.Temperature;
                formData["humidity"] = row.Humidity;
                formData["dew"] = row.Dew;
                formData["wet"] = row.Wet;
                formData["datenow"] = row.Datetimes;               
                formData["user"] = row.Users;

                String results = Sending.send(URL, formData);              
                row.Update(row.Id, results);
               
                worker.ReportProgress(((counter--)));


            }


            System.Threading.Thread.Sleep(500);

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


            stationNumber.Content = _StationsList.Where(c => c.Name == stationTxtCbx.Text.ToString()).Select(p => p.Number).SingleOrDefault().ToString();
            codeTxtBx.Text = _StationsList.Where(c => c.Name == stationTxtCbx.Text.ToString()).Select(c => c.Code).SingleOrDefault().ToString();
            DatetimeTxtBx.Text = DateTime.Now.Date.Day.ToString() + DateTime.Now.Hour.ToString() + "00Z";


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
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
                    u.Wet = WetTxtBx.Text;
                    u.Stationhpa = StationHpaTxtBx.Text;
                    u.Seahpa = SeaHpaTxtBx.Text;
                    u.Recent = RecentTxtBx.Text;
                    u.Users = "test";
                    u.Days = DateTime.Now.Date.ToString();
                    u.Sync = "F";

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


            DatetimeTxtBx.Text = "";
            WindDirectionTxtBx.Text = "";
            VisibilityTxtBx.Text = "";
            weatherTxtBx.Text = "";
            CloudTxtBx.Text = "";
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
            catch
            {

                MessageBox.Show("please use numbers/integers for these values !");

            }

        }

        private void StationHpaTxtBx_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                StationHpaInTxtBx.Text = (0.02952998751 * Convert.ToDouble(StationHpaTxtBx.Text)).ToString();
            }
            catch
            {

                MessageBox.Show("please use numbers/integers for these values !");

            }
        }

        private void SeaHpaTxtBx_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                SeaHpaInTxtBx.Text = (0.02952998751 * Convert.ToDouble(SeaHpaTxtBx.Text)).ToString();
            }
            catch
            {

                MessageBox.Show("please use numbers/integers for these values !");

            }
        }

        private void btnDeleteAll_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete all this information?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Metar u in MetarGrid.SelectedItems)
                {
                    u.Delete(u.Id.ToString());
                }
                RefreshUserList();
                
            }
            else
            {
                return;
            } 
           
        }
        private void chkSelectAll_Click(object sender, RoutedEventArgs e)
        {
            if (chkSelectAll.IsChecked.Value == true)
            {
                MetarGrid.SelectAll();
            }
            else
            {
                MetarGrid.UnselectAll();
            }
        }

        private void Button_Click_generate(object sender, RoutedEventArgs e)
        {
            MetarGrid.ItemsSource = null;
            MetarGrid.ItemsSource =  _metarList.Where(c => Convert.ToDateTime(c.Days).Month.ToString() == (monthTxtCbx.SelectedIndex + 1).ToString() && Convert.ToDateTime(c.Days).Day.ToString() == dayTxtCbx.Text && Convert.ToDateTime(c.Days).Year.ToString() == yearTxtBx.Text);

        }
        private void ExportToExcel()
        {
            MetarGrid.SelectAllCells();
            MetarGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, MetarGrid);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            MetarGrid.UnselectAllCells();
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Wimea\dekadal.xls");
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
