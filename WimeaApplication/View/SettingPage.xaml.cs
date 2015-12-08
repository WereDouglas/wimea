using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SettingPage.xaml
    /// </summary>
    public partial class SettingPage : Page
    {
        private ObservableCollection<Station> _StationsList = null;
        private ObservableCollection<Syncs> _syncList = null;
        private Syncs _syncs;
        public SettingPage()
        {
            InitializeComponent();
            RefreshStationList();

        }
        private void RefreshStationList()
        {

            _StationsList = new ObservableCollection<Station>(App.WimeaApp.Stations);
            _syncList = new ObservableCollection<Syncs>(App.WimeaApp.Syncs);
            SyncGrid.ItemsSource = null;
            SyncGrid.ItemsSource = _syncList;

            stationTxtCbx.ItemsSource = null;
            stationTxtCbx.ItemsSource = _StationsList.Select(c => c.Name);
            if (Sending.IsInternetAvailable())
            {
                internet.Content = "internet connection available";
            }
            else
            {

                internet.Content = "no internet connection";

            }

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            if (Sending.IsInternetAvailable())
            {

                string urls = "";

                try
                {

                    if (stationTxtCbx.Text != "")
                    {

                        if (dailyChk.IsChecked == true)
                        {
                            urls = Sending.genUrl+"api/tasks/station/" + stationTxtCbx.Text + "/format/json";
                            syncs(urls, "daily");
                            validate("daily");

                        }

                        if (metarChk.IsChecked == true)
                        {
                            urls = Sending.genUrl+"apimetar/metar/station/" + stationTxtCbx.Text + "/format/json";
                            syncs(urls, "metar");
                            validate("metar");


                        }
                        if (synopticChk.IsChecked == true)
                        {
                            urls = Sending.genUrl + "apisynoptic/synoptic/station/" + stationTxtCbx.Text + "/format/json";
                            syncs(urls, "synoptic");
                            validate("synoptic");
                        }
                        if (rainChk.IsChecked == true)
                        {
                            urls = Sending.genUrl + "api/tasks/station/" + stationTxtCbx.Text + "/format/json";
                            syncs(urls, "rain");
                        }
                        if (stationChk.IsChecked == true)
                        {
                            urls = Sending.genUrl + "api/tasks/station/" + stationTxtCbx.Text + "/format/json";
                            syncs(urls, "station");
                        }
                        RefreshStationList();

                    }
                    else
                    {
                        MessageBox.Show("Please select a station");
                    }

                }
                catch
                {
                    MessageBox.Show("no data for specified station");
                }
            }
            else {

                internet.Content = "no internet connection";
            
            }
        }
        private void validate(string content)
        {
            //_syncList = new ObservableCollection<Syncs>(App.WimeaApp.Syncs);
            var objects = "";
            if (_syncList.Count <= 0)
            {
                save(stationTxtCbx.Text + "-" + content, DateTime.Now.ToString(), "new-users");
            }
            else
            {
                try
                {
                    objects = _syncList.Where(c => c.Objects.Contains(stationTxtCbx.SelectedItem.ToString() + "-" + content.ToString())).Select(c => c.Objects).SingleOrDefault().ToString();
                

                if (objects == "")
                {

                    save(stationTxtCbx.Text + "-" + content, DateTime.Now.ToString(), "new-users");
                }
                else
                {
                    update(objects, DateTime.Now.ToString(), "update-users");
                }
                }
                catch
                {
                    save(stationTxtCbx.Text + "-" + content, DateTime.Now.ToString(), "new-users");
                }
            }



        }
        private void save(string objects, string dates, string users)
        {
            try
            {
                _syncs = App.WimeaApp.Syncs.Add();
                _syncs.Objects = objects;
                _syncs.Dates = dates;
                _syncs.Users = users;
                _syncs.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void update(string objects, string dates, string users)
        {
            try
            {
                //Update(string objects, string dates, string users)
                _syncs = App.WimeaApp.Syncs.Add();
                _syncs.Update(objects, dates, users);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as System.Windows.Controls.Button;
            Syncs syncs = button.DataContext as Syncs;

            if (MessageBox.Show("Are you sure you want to delete " + syncs.Objects + " ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                syncs.Delete(syncs.Id.ToString());
                RefreshStationList();
            }
            else
            {
                return;
            }
        }

        private void syncs(string url, string content)
        {

            using (var client = new WebClient())
            {
                var json = client.DownloadString(url);
                System.IO.File.WriteAllText(Sending.directoryUrl + stationTxtCbx.Text + "-" + content + ".json", json);

                string total = "";
                string[] lines = System.IO.File.ReadAllLines(Sending.directoryUrl + stationTxtCbx.Text + "-" + content + ".json");
                foreach (string line in lines)
                {
                    // Use a tab to indent each line of the file.
                    total += line;
                }

                List<Daily> model = JsonConvert.DeserializeObject<List<Daily>>(total);
                // TODO: do something with the model

                for (int d = 0; d < model.Count; d++)
                {
                    // System.Diagnostics.Debug.WriteLine(model.ElementAt(d).Actual);
                }
            }

        }
        private void chkSelectAll_Click(object sender, RoutedEventArgs e)
        {
            if (chkSelectAll.IsChecked.Value == true)
            {
                SyncGrid.SelectAll();
            }
            else
            {
                SyncGrid.UnselectAll();
            }
        }

        private void StationGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void stationTxtCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void btnDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all this informatiion?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Syncs u in SyncGrid.SelectedItems)
                {
                    u.Delete(u.Id.ToString());
                }
                RefreshStationList();

            }
            else
            {
                return;
            }


        }
    }
}
