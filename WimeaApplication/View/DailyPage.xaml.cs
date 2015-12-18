using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
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

namespace WimeaApplication
{
    /// <summary>
    /// Interaction logic for DailyPage.xaml
    /// </summary>
    public partial class DailyPage : Page
    {
        private static ObservableCollection<Daily> _dailyList = new ObservableCollection<Daily>();
        private Daily u;
        private ObservableCollection<Station> _StationsList = new ObservableCollection<Station>();

        private BackgroundWorker bw = new BackgroundWorker();

        public DailyPage()
        {
            InitializeComponent();
            _StationsList = new ObservableCollection<Station>(App.WimeaApp.Stations);

            stationTxtCbx.Text = Sending.currentstation;
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
            dates.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            _dailyList = new ObservableCollection<Daily>(App.WimeaApp.Dailys);
            MetarGrid.ItemsSource = null;
            MetarGrid.ItemsSource = _dailyList.Where(w => Convert.ToDateTime(w.Dates).Month == DateTime.Now.Month && Convert.ToDateTime(w.Dates).Year == DateTime.Now.Year).OrderBy(w => w.Dates);
            tbProgress.Content = _dailyList.Count(c => c.Sync == "F" || c.Sync == " ").ToString();

            for (int p = 1; p < 13; p++)
            {
                monthTxtCbx.Items.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(p));
            }
            yearTxtBx.Text = DateTime.Now.Year.ToString();

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

                    if (ThunderstormChk.IsChecked == true)
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
                    u.Dates = (Convert.ToDateTime(dates.Text).ToString("yyyy-MM-dd"));
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


            stationTxtCbx.Text = "";
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

        private void monthTxtCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _dailyList = new ObservableCollection<Daily>(App.WimeaApp.Dailys);
            MetarGrid.ItemsSource = null;
            MetarGrid.ItemsSource = _dailyList.Where(w => Convert.ToDateTime(w.Dates).Month.ToString() == (monthTxtCbx.SelectedIndex + 1).ToString() && Convert.ToDateTime(w.Dates).Year.ToString() == yearTxtBx.Text).OrderBy(w => w.Dates); ;

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
            int counter = _dailyList.Count(c => c.Sync == "F" || c.Sync == "");

            List<Daily> sendies = new List<Daily>();
            sendies = _dailyList.Where(c => c.Sync == "F" || c.Sync == "").ToList();

            string URL = Sending.genUrl + "api/tasks";


            foreach (Daily row in sendies)
            {

                NameValueCollection formData = new NameValueCollection();
                formData["actual"] = row.Actual;
                formData["date"] = row.Dates;
                formData["station"] = row.Station;
                formData["max"] = row.Maxs;
                formData["min"] = row.Mins;
                formData["anemometer"] = row.Anemometer;
                formData["wind"] = row.Wind;
                formData["rain"] = row.Rain;
                formData["thunder"] = row.Thunder;
                formData["fog"] = row.Fog;
                formData["haze"] = row.Haze;
                formData["storm"] = row.Storm;
                formData["quake"] = row.Quake;
                formData["height"] = row.Height;
                formData["duration"] = row.Duration;
                formData["sunshine"] = row.Sunshine;
                formData["type"] = row.Radiationtype;
                formData["radiation"] = row.Radiation;
                formData["evaptype1"] = row.Evaptype1;
                formData["evap1"] = row.Evap1;
                formData["evaptype2"] = row.Evaptype2;
                formData["evap2"] = row.Evap2;
                formData["user"] = row.Users;

                String results = Sending.send(URL, formData);

                // row.Update(row.Id, "F");
                row.Update(row.Id, results);
                Console.WriteLine(results);
                worker.ReportProgress(((counter--)));


            }


            System.Threading.Thread.Sleep(500);

        }
        private void btnDeleteAll_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete all this information?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Daily u in MetarGrid.SelectedItems)
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

        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {

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
