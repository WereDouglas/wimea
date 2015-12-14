using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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
    /// Interaction logic for InstrumentPage.xaml
    /// </summary>
    public partial class InstrumentPage : Page
    {
        private static ObservableCollection<Instrument> _instrumentList = new ObservableCollection<Instrument>();
        private Instrument u;
        private ObservableCollection<Station> _StationsList = new ObservableCollection<Station>();

        private BackgroundWorker bw = new BackgroundWorker();
        public InstrumentPage()
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
           
            _instrumentList = new ObservableCollection<Instrument>(App.WimeaApp.Instruments);
            MetarGrid.ItemsSource = null;
            MetarGrid.ItemsSource = _instrumentList;
            tbProgress.Content = _instrumentList.Count(c => c.Sync == "F" || c.Sync == " ").ToString();

           

        }
        private void deleteClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as System.Windows.Controls.Button;
            Instrument instrument = button.DataContext as Instrument;

            if (MessageBox.Show("Are you sure you want to delete this instrument ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                instrument.Delete(instrument.Id.ToString());
                RefreshUserList();
            }
            else
            {

                return;
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("confirm this information ?" + name.Text + " " + stationTxtCbx.Text + " ", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    u = App.WimeaApp.Instruments.Add();
                    u.Station = stationTxtCbx.Text;
                    u.Name = name.Text;
                    u.Element = element.Text;
                    u.DateRegister = datesRegister.Text;
                    u.DateExpire = dateExpire.Text;
                    u.Code = code.Text;
                    u.Manufacturer = manufacturer.Text;
                    u.Description = description.Text;
                    u.Submitted = DateTime.Now.ToString();                            
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


          code.Text="";
           manufacturer.Text="";
           description.Text="";
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
            int counter = _instrumentList.Count(c => c.Sync == "F" || c.Sync == "");

            List<Instrument> sendies = new List<Instrument>();
            sendies = _instrumentList.Where(c => c.Sync == "F" || c.Sync == "").ToList();
            string URL = Sending.genUrl + "api/tasks";
            foreach (Instrument row in sendies)            {

                NameValueCollection formData = new NameValueCollection();
                formData["name"] = row.Name;
                formData["element"] = row.Element;
                formData["station"] = row.Station;
                formData["dateRegister"] = row.DateRegister;
                formData["dateExpire"] = row.DateExpire;
                formData["code"] = row.Code;
                formData["manufacturer"] = row.Manufacturer;
                formData["description"] = row.Description;
                formData["submitted"] = row.Submitted;
                

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
                foreach (Instrument u in MetarGrid.SelectedItems)
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

    }
}
