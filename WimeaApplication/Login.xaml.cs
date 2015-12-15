using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.SqlServerCe;
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
using System.Windows.Shapes;
using WimeaLibrary;
using WimeaLibrary.Helpers;

namespace WimeaApplication
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private ObservableCollection<User> _UsersList = null;
        private ObservableCollection<Station> _stationList = null;
        private Station _station;
        private User r;
        private Station s;
        private Element e;
        private Instrument i;
        public string name = "";
        private Daily d;
        private Synoptic u;
        private Metar m;
        private BackgroundWorker bw = new BackgroundWorker();
        public Login()
        {
            InitializeComponent();
            string fileName = @"c:\wimea\wimeas.sdf";
            if (!File.Exists(fileName))
            {
                login.Visibility = System.Windows.Visibility.Hidden;
                cancel.Visibility = System.Windows.Visibility.Hidden;
                CreateDB();

                if (Sending.IsInternetAvailable())
                {
                    tbProgress.Content = "updating user list.---------";
                    login.Visibility = System.Windows.Visibility.Hidden;
                    cancel.Visibility = System.Windows.Visibility.Hidden;
                    syncs(Sending.genUrl + "user/all", "users", "center");
                    Loading_users();

                    tbProgress.Content = "user list upto date---------";
                    login.Visibility = System.Windows.Visibility.Visible;
                    cancel.Visibility = System.Windows.Visibility.Visible;
                }

                _UsersList = new ObservableCollection<User>(App.WimeaApp.Users);
            }
            _UsersList = new ObservableCollection<User>(App.WimeaApp.Users);
            _stationList = new ObservableCollection<Station>(App.WimeaApp.Stations);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (_UsersList.Count < 1)
            {
                tbProgress.Content = "you have no users in your list!";

            }
            else
            {

                string usernames = ""; string roles = ""; string station = ""; 
            try {

                       usernames = _UsersList.Where(l => l.Email == EmailTxtBx.Text && l.Password == Encryption.SimpleEncrypt(passwordTxt.Password)).Select(l => l.Name).SingleOrDefault().ToString();
                       roles = _UsersList.Where(l => l.Email == EmailTxtBx.Text).Select(l => l.Role).SingleOrDefault().ToString();
                       station = _UsersList.Where(l => l.Email == EmailTxtBx.Text).Select(l => l.Station).SingleOrDefault().ToString();
              }
                catch {

                    tbProgress.Content = "invalid user!";                
                }

                if (usernames != "")
                {
                    if (roles.ToString().Contains("Observer") || roles.ToString().Contains("O/C"))
                    {
                        Sending.currentinstance = "data";
                        tbProgress.Content = "Welcome observer..........";

                        if (_stationList.Count < 1)
                        {
                            login.Visibility = System.Windows.Visibility.Hidden;
                            cancel.Visibility = System.Windows.Visibility.Hidden;
                            string URLs = Sending.genUrl + "apicheck/check";
                            NameValueCollection formDatas = new NameValueCollection();
                            formDatas["station"] = station;
                            String results = Sending.send(URLs, formDatas);

                            if (results == "F")
                            {
                                tbProgress.Content = "Invalid station";
                            }
                            else
                            {
                                tbProgress.Content = "welcome " + station;
                                Station models = JsonConvert.DeserializeObject<Station>(results);
                                //System.Diagnostics.Debug.WriteLine(model.ElementAt(d).Number);

                                _station = App.WimeaApp.Stations.Add();
                                _station.Name = models.Name;
                                _station.Number = models.Number;
                                _station.Code = models.Code;
                                _station.Latitude = models.Latitude;
                                _station.Longitude = models.Longitude;
                                _station.Altitude = models.Altitude;
                                _station.Type = models.Type;
                                _station.Location = models.Location;
                                _station.Status = models.Status + " ";
                                _station.Commissioned = DateTime.Now.Date.ToString();
                                _station.Save();

                                name = models.Name;
                                bw.RunWorkerAsync();
                                bw.WorkerReportsProgress = true;
                                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                                bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

                                Sending.currentinstance = "observer";
                                Sending.currentusername = r.Name;
                                Sending.currentstation = r.Station;
                                Sending.currentstation = station;
                                Sending.currentusername = usernames;
                                HomeWindow w = new HomeWindow();
                                w.Owner = Window.GetWindow(this);
                                w.Show();
                            }
                        }
                        else {

                            Sending.currentstation = station;
                            Sending.currentusername = usernames;
                            HomeWindow w = new HomeWindow();
                            w.Owner = Window.GetWindow(this);
                            w.Show();
                        }
                       
                    }
                    if (roles.ToString().Contains("Data") || roles.ToString().Contains("Manager"))
                    {
                        Sending.currentinstance = "center";
                        if (_stationList.Count < 1)
                        {
                            tbProgress.Content = "syncing information";
                            //syncs(Sending.genUrl + "apiuser/user/station/centers/format/json", "users", "center");
                            syncs(Sending.genUrl + "apistation/station/station/center/format/json", "stations", "center");
                            syncs(Sending.genUrl + "apielement/element/format/json", "elements", "center");
                            syncs(Sending.genUrl + "apiinstrument/instrument/format/json", "instruments", "center");
                            tbProgress.Content = "Loading to database";
                            Loading_stations();
                            Loading_elements();
                            Loading_allinstruments();
                            tbProgress.Content = "Redirecting...................";
                        }

                        Sending.currentstation = station;
                        Sending.currentusername = usernames;
                        HomeWindow w = new HomeWindow();
                        w.Owner = Window.GetWindow(this);
                        w.Show();

                    }
                 
                }
            }

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

                HomeWindow w = new HomeWindow();
                w.Owner = Window.GetWindow(this);
                w.Show();

            }
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.tbProgress.Content = ("File download! left with " + e.ProgressPercentage.ToString() + " file(s)");
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            int counter = 5;
            BackgroundWorker worker = sender as BackgroundWorker;
            //  syncs(Sending.genUrl + "apiuser/user/station/" + name + "/format/json", "user", name);
            counter = 4;
            syncs(Sending.genUrl + "api/tasks/station/" + name + "/format/json", "daily", name);
            counter = 3;
            worker.ReportProgress(((counter)));
            syncs(Sending.genUrl + "apimetar/metar/station/" + name + "/format/json", "metar", name);
            counter = 2;
            worker.ReportProgress(((counter)));
            syncs(Sending.genUrl + "apisynoptic/synoptic/station/" + name + "/format/json", "synoptic", name);
            counter = 1;
            worker.ReportProgress(((counter)));
            syncs(Sending.genUrl + "api/tasks/station/" + name + "/format/json", "rain", name);
            worker.ReportProgress(((counter)));
            syncs(Sending.genUrl + "apiinstrument/instrument/station/" + name + "/format/json", "instruments", name);
            worker.ReportProgress(((counter)));

            Loading_daily(name);
            Loading_synoptic(name);
            Loading_metar(name);
            //  Loading_user(name);
            Loading_instruments(name);


            System.Threading.Thread.Sleep(5000);


        }
        private string Loading_instruments(string station)
        {

            try
            {
                string total = "";
                string[] lines = System.IO.File.ReadAllLines(Sending.directoryUrl + station + "-" + "instruments" + ".json");
                foreach (string line in lines)
                {

                    total += line;
                }

                List<Instrument> model = JsonConvert.DeserializeObject<List<Instrument>>(total);

                for (int d = 0; d < model.Count; d++)
                {
                    i = new Instrument(null);
                    i.Station = model.ElementAt(d).Station;
                    i.Name = model.ElementAt(d).Name;
                    i.Element = model.ElementAt(d).Element;
                    i.DateRegister = model.ElementAt(d).DateRegister;
                    i.DateExpire = model.ElementAt(d).DateExpire;
                    i.Code = model.ElementAt(d).Code;
                    i.Manufacturer = model.ElementAt(d).Manufacturer;
                    i.Description = model.ElementAt(d).Description;
                    i.Submitted = model.ElementAt(d).Submitted;
                    i.Sync = "T";
                    i.Save();

                }
                return "Loaded synoptic information into local database!";

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
                return "done loading instruments";

            }


        }

        private string Loading_daily(string station)
        {
            string reply = "";
            try
            {
                string total = "";
                string[] lines = System.IO.File.ReadAllLines(Sending.directoryUrl + station + "-" + "daily" + ".json");
                foreach (string line in lines)
                {

                    total += line;
                }

                List<DailyOnline> model = JsonConvert.DeserializeObject<List<DailyOnline>>(total);

                for (int p = 0; p < model.Count; p++)
                {
                    d = new Daily(null);
                    d.Station = model.ElementAt(p).Station;
                    d.Id = model.ElementAt(p).Id;
                    d.Maxs = model.ElementAt(p).Max;
                    d.Mins = model.ElementAt(p).Min;
                    d.Actual = model.ElementAt(p).Actual;
                    d.Anemometer = model.ElementAt(p).Anemometer;
                    d.Wind = model.ElementAt(p).Wind;
                    d.Maxi = model.ElementAt(p).Maxi;
                    d.Rain = model.ElementAt(p).Rain;
                    d.Thunder = model.ElementAt(p).Thunder;
                    d.Fog = model.ElementAt(p).Fog;
                    d.Haze = model.ElementAt(p).Haze;
                    d.Storm = model.ElementAt(p).Storm;
                    d.Quake = model.ElementAt(p).Quake;
                    d.Height = model.ElementAt(p).Height;
                    d.Duration = model.ElementAt(p).Duration;
                    d.Sunshine = model.ElementAt(p).Sunshine;
                    d.Radiationtype = model.ElementAt(p).Radiationtype;
                    d.Radiation = model.ElementAt(p).Radiation;
                    d.Evaptype1 = model.ElementAt(p).Evaptype1;
                    d.Evap1 = model.ElementAt(p).Evap1;
                    d.Evaptype2 = model.ElementAt(p).Evaptype2;
                    d.Evap2 = model.ElementAt(p).Evap2;
                    d.Users = model.ElementAt(p).User;
                    d.Dates = model.ElementAt(p).Date;
                    d.Sync = "T";
                    d.Save();

                }
                return "Loaded daily information into local database!";
            }
            catch (Exception ex)
            {

                return (ex.Message.ToString());
            }

        }
        private string Loading_elements()
        {
            //string reply = "";
            //try
            //{
            string total = "";
            string[] lines = System.IO.File.ReadAllLines(Sending.directoryUrl + "center-" + "elements" + ".json");
            foreach (string line in lines)
            {

                total += line;
            }

            List<Element> model = JsonConvert.DeserializeObject<List<Element>>(total);

            for (int d = 0; d < model.Count; d++)
            {
                try
                {
                    e = new Element(null);
                    e.Name = model.ElementAt(d).Name;
                    e.Abbrev = model.ElementAt(d).Abbrev;
                    e.Type = model.ElementAt(d).Type;
                    e.Units = model.ElementAt(d).Units;
                    e.Scale = model.ElementAt(d).Scale;
                    e.Limits = model.ElementAt(d).Limits;
                    e.Description = model.ElementAt(d).Description;
                    e.Submitted = model.ElementAt(d).Submitted;
                    e.Sync = "T";
                    e.Save();

                }
                catch (Exception)
                {
                    e = new Element(null);
                    e.Name = model.ElementAt(d).Name;
                    e.Abbrev = model.ElementAt(d).Abbrev;
                    e.Type = model.ElementAt(d).Type;
                    e.Units = model.ElementAt(d).Units;
                    e.Scale = model.ElementAt(d).Scale;
                    e.Limits = model.ElementAt(d).Limits;
                    e.Description = model.ElementAt(d).Description;
                    e.Submitted = model.ElementAt(d).Submitted;
                    e.Sync = "T";
                    e.Save();

                }

            }
            return "Loaded synoptic information into local database!";

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message.ToString());
            //    return "done loading metars";

            //}


        }


        private string Loading_synoptic(string station)
        {
            string reply = "";
            try
            {
                string total = "";
                string[] lines = System.IO.File.ReadAllLines(Sending.directoryUrl + station + "-" + "synoptic" + ".json");
                foreach (string line in lines)
                {

                    total += line;
                }

                List<SynopticOnline> model = JsonConvert.DeserializeObject<List<SynopticOnline>>(total);

                for (int d = 0; d < model.Count; d++)
                {
                    u = new Synoptic(null);
                    u.Station = model.ElementAt(d).Station;
                    u.Date = model.ElementAt(d).Date + " ";
                    u.Time = model.ElementAt(d).Time + " ";
                    u.Ir = model.ElementAt(d).Ir + " ";
                    u.Ix = model.ElementAt(d).Ix + " ";
                    u.H = model.ElementAt(d).H + " ";
                    u.Www = model.ElementAt(d).Www + " ";
                    u.Vv = model.ElementAt(d).Vv + " ";
                    u.N = model.ElementAt(d).N + " ";
                    u.Dd = model.ElementAt(d).Dd + " ";
                    u.Ff = model.ElementAt(d).Ff + " ";
                    u.T = model.ElementAt(d).T + " ";
                    u.Td = model.ElementAt(d).Td + " ";
                    u.Po = model.ElementAt(d).Po;
                    u.Gisis = model.ElementAt(d).Gisis;
                    u.Hhh = model.ElementAt(d).Hhh + " ";
                    u.Rrr = model.ElementAt(d).Rrr + " ";
                    u.Tr = model.ElementAt(d).Tr + " ";
                    u.Present = model.ElementAt(d).Present + " ";
                    u.Past = model.ElementAt(d).Past + " ";
                    u.Nh = model.ElementAt(d).Nh + " ";
                    u.Cl = model.ElementAt(d).Cl + " ";
                    u.Cm = model.ElementAt(d).Cm + " ";
                    u.Ch = model.ElementAt(d).Ch + " ";
                    u.Tq = model.ElementAt(d).Tq + " ";
                    u.Ro = model.ElementAt(d).Ro + " ";
                    u.R1 = model.ElementAt(d).R1 + " ";
                    u.Tx = model.ElementAt(d).Tx + " ";
                    u.Tm = model.ElementAt(d).Tm + " ";
                    u.Ee = model.ElementAt(d).Ee + " ";
                    u.E = model.ElementAt(d).E + " ";
                    u.Sss = model.ElementAt(d).Sss + " ";
                    u.Pchange = model.ElementAt(d).Pchange + " ";
                    u.P24 = model.ElementAt(d).P24 + " ";
                    u.Rr = model.ElementAt(d).Rr + " ";
                    u.Tr1 = model.ElementAt(d).Tr1 + " ";
                    u.Ns = model.ElementAt(d).Ns + " ";
                    u.Ns1 = model.ElementAt(d).Ns1 + " ";
                    u.C = model.ElementAt(d).C + " ";
                    u.Hs = model.ElementAt(d).Hs1 + " ";
                    u.Ns1 = model.ElementAt(d).N + " ";
                    u.C1 = model.ElementAt(d).C1 + " ";
                    u.Hs1 = model.ElementAt(d).Hs1 + " ";
                    u.Ns2 = model.ElementAt(d).Ns2 + " ";
                    u.C2 = model.ElementAt(d).C2 + " ";
                    u.Hs2 = model.ElementAt(d).Hs2 + " ";
                    u.Supplementary = model.ElementAt(d).Supplementary + " ";
                    u.Wb = model.ElementAt(d).Wb + " ";
                    u.Rh = model.ElementAt(d).Rh + " ";
                    u.Vap = model.ElementAt(d).Vap + " ";
                    u.Users = model.ElementAt(d).User + " ";
                    u.Submitted = model.ElementAt(d).Submitted + " ";
                    u.Sync = "T";
                    u.Save();

                }
                return "Loaded synoptic information into local database!";

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
                return "done loading synoptics";

            }


        }

        private string Loading_metar(string station)
        {
            string reply = "";
            try
            {
                string total = "";
                string[] lines = System.IO.File.ReadAllLines(Sending.directoryUrl + station + "-" + "metar" + ".json");
                foreach (string line in lines)
                {

                    total += line;
                }

                List<MetarOnline> model = JsonConvert.DeserializeObject<List<MetarOnline>>(total);

                for (int d = 0; d < model.Count; d++)
                {
                    m = new Metar(null);
                    m.Station = model.ElementAt(d).Station;
                    m.Types = model.ElementAt(d).Type;
                    m.Datetimes = model.ElementAt(d).Datetime;
                    m.Timezones = model.ElementAt(d).Timezone;
                    m.Direction = model.ElementAt(d).Wind_direction;
                    m.Speed = model.ElementAt(d).Wind_speed;
                    m.Unit = model.ElementAt(d).Unit;
                    m.Visibility = model.ElementAt(d).Visibility;
                    m.Weather = model.ElementAt(d).Present_weather;
                    m.Cloud = model.ElementAt(d).Cloud;
                    m.Temperature = model.ElementAt(d).Air_temperature;
                    m.Humidity = model.ElementAt(d).Humidity;
                    m.Dew = model.ElementAt(d).Dew_temperature;
                    m.Wet = model.ElementAt(d).Wet_bulb;
                    m.Stationhpa = model.ElementAt(d).Station_pressure_hpa;
                    m.Seahpa = model.ElementAt(d).Sea_pressure_hpa;
                    m.Recent = model.ElementAt(d).Recent_weather;
                    m.Users = model.ElementAt(d).User;
                    m.Days = model.ElementAt(d).Day;
                    m.Sync = "T";
                    m.Save();

                }
                return "Loaded synoptic information into local database!";

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
                return "done loading metars";

            }


        }

        private string Loading_stations()
        {
            //string reply = "";
            //try
            //{
            string total = "";
            string[] lines = System.IO.File.ReadAllLines(Sending.directoryUrl + "center-" + "stations" + ".json");
            foreach (string line in lines)
            {

                total += line;
            }

            List<Station> model = JsonConvert.DeserializeObject<List<Station>>(total);

            for (int d = 0; d < model.Count; d++)
            {
                try
                {

                    s = new Station(null);
                    s.Name = model.ElementAt(d).Name;
                    s.Number = model.ElementAt(d).Number;
                    s.Code = model.ElementAt(d).Code;
                    s.Latitude = model.ElementAt(d).Latitude;
                    s.Longitude = model.ElementAt(d).Longitude;
                    s.Altitude = model.ElementAt(d).Altitude;
                    s.Type = model.ElementAt(d).Type;
                    s.Location = model.ElementAt(d).Location;
                    s.Status = model.ElementAt(d).Status;
                    s.Commissioned = model.ElementAt(d).Commissioned + " ";
                    s.Sync = "T";
                    s.Save();

                }
                catch (Exception)
                {
                    s = new Station(null);
                    s.Name = model.ElementAt(d).Name;
                    s.Number = model.ElementAt(d).Number;
                    s.Code = model.ElementAt(d).Code;
                    s.Latitude = model.ElementAt(d).Latitude;
                    s.Longitude = model.ElementAt(d).Longitude;
                    s.Altitude = model.ElementAt(d).Altitude;
                    s.Type = model.ElementAt(d).Type;
                    s.Location = model.ElementAt(d).Location;
                    s.Status = model.ElementAt(d).Status;
                    s.Commissioned = model.ElementAt(d).Commissioned + " ";
                    s.Sync = "T";
                    s.Save();

                }

            }
            return "Loaded synoptic information into local database!";

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message.ToString());
            //    return "done loading metars";

            //}


        }

        private string Loading_allinstruments()
        {

            //try
            //{
            string total = "";
            string[] lines = System.IO.File.ReadAllLines(Sending.directoryUrl + "center-" + "instruments" + ".json");
            foreach (string line in lines)
            {

                total += line;
            }

            List<Instrument> model = JsonConvert.DeserializeObject<List<Instrument>>(total);

            for (int d = 0; d < model.Count; d++)
            {
                i = new Instrument(null);
                i.Station = model.ElementAt(d).Station;
                i.Name = model.ElementAt(d).Name;
                i.Element = model.ElementAt(d).Element;
                i.DateRegister = model.ElementAt(d).DateRegister;
                i.DateExpire = model.ElementAt(d).DateExpire;
                i.Code = model.ElementAt(d).Code;
                i.Manufacturer = model.ElementAt(d).Manufacturer;
                i.Description = model.ElementAt(d).Description;
                i.Submitted = model.ElementAt(d).Submitted;
                i.Sync = "T";
                i.Save();

            }
            return "Loaded synoptic information into local database!";

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message.ToString());
            //    return "done loading instruments";

            //}


        }

        private void syncs(string url, string content, string station)
        {
            try
            {
                using (var client = new WebClient())
                {
                    var json = client.DownloadString(url);
                    System.IO.File.WriteAllText(Sending.directoryUrl + station + "-" + content + ".json", json);
                }
            }
            catch { }

        }
        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void CreateDB()
        {
            // public static string conString = @"Data Source=C:\transporter\wimea.sdf;Password=wimea; Persist Security Info=True;";
            string path = @"c:\wimea";
            if (Directory.Exists(path))
            {
                Console.WriteLine("That path exists already.");
                return;
            }
            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(path);
            Console.WriteLine("The directory was created successfully at {0}.",
            Directory.GetCreationTime(path));


            string con;

            //if (File.Exists(fileName))
            //{
            //    File.Delete(fileName);
            //}
            // string pathString = System.IO.Path.Combine(path, fileName);
            //File.Create(pathString);

            con = string.Format(@"Data Source=C:\wimea\wimeas.sdf;Password=wimea; Persist Security Info=True;");
            SqlCeEngine en = new SqlCeEngine(con);
            en.CreateDatabase();

            SqlCeConnection conn = new SqlCeConnection(con);
            conn.Open();
            SqlCeCommand cmd = conn.CreateCommand();

            //         CREATE TABLE daily (id nvarchar(255) NOT NULL, dates nvarchar(100) NULL, station nvarchar(100) NULL, maxs nvarchar(100) NULL, mins nvarchar(100) NULL, actual nvarchar(100) NULL, anemometer nvarchar(100) NULL, wind nvarchar(100) NULL, maxi nvarchar(100) NULL, rain nvarchar(100) NULL, thunder nvarchar(100) NULL, fog nvarchar(100) NULL, haze nvarchar(100) NULL,storm nvarchar(100) NULL, quake nvarchar(100) NULL,height nvarchar(100) NULL, duration nvarchar(100) NULL, sunshine nvarchar(100) NULL, radiationtype nvarchar(100) NULL, radiation nvarchar(100) NULL, evaptype1 nvarchar(100) NULL, evap1 nvarchar(100) NULL, evaptype2 nvarchar(100) NULL, evap2 nvarchar(100) NULL, users nvarchar(100) NULL, sync nvarchar(25) NULL);
            if (!TableExists(conn, "users"))
            {
                cmd.CommandText = "CREATE TABLE users (id nvarchar(255)  NULL, name nvarchar(255) NULL, contact nvarchar(255)  NULL, role nvarchar(255)  NULL, station nvarchar(255)  NULL,email nvarchar(255) NULL,password nvarchar(255) NULL,sync nvarchar(255) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table users");
            }
            if (!TableExists(conn, "daily"))
            {
                cmd.CommandText = "CREATE TABLE daily (id nvarchar(255) NOT NULL, dates nvarchar(100) NULL, station nvarchar(100) NULL, maxs nvarchar(100) NULL, mins nvarchar(100) NULL, actual nvarchar(100) NULL, anemometer nvarchar(100) NULL, wind nvarchar(100) NULL, maxi nvarchar(100) NULL, rain nvarchar(100) NULL, thunder nvarchar(100) NULL, fog nvarchar(100) NULL, haze nvarchar(100) NULL,storm nvarchar(100) NULL, quake nvarchar(100) NULL,height nvarchar(100) NULL, duration nvarchar(100) NULL, sunshine nvarchar(100) NULL, radiationtype nvarchar(100) NULL, radiation nvarchar(100) NULL, evaptype1 nvarchar(100) NULL, evap1 nvarchar(100) NULL, evaptype2 nvarchar(100) NULL, evap2 nvarchar(100) NULL, users nvarchar(100) NULL, sync nvarchar(25) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table");
            }
            if (!TableExists(conn, "metar"))
            {
                cmd.CommandText = "CREATE TABLE metar (id nvarchar(255) NULL, station nvarchar(255) NULL, types nvarchar(255) NULL, datetimes nvarchar(255) NULL, timezones nvarchar(255) NULL, direction nvarchar(255) NULL, speed nvarchar(255) NULL, unit nvarchar(255) NULL, visibility nvarchar(255) NULL, weather nvarchar(255) NULL, cloud nvarchar(255) NULL, temperature nvarchar(255) NULL, humidity nvarchar(255) NULL, dew nvarchar(255) NULL, wet nvarchar(255) NULL, stationhpa nvarchar(255) NULL, seahpa nvarchar(255) NULL, recent nvarchar(255) NULL, users nvarchar(255) NULL, days nvarchar(255) NULL, sync nvarchar(25) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table metar");
            }
            if (!TableExists(conn, "station"))
            {
                cmd.CommandText = "CREATE TABLE station( id nvarchar(255) NOT NULL, name nvarchar(255) NULL, number nvarchar(255) NULL, code nvarchar(255) NULL, latitude nvarchar(255) NULL, longitude nvarchar(255) NULL, altitude nvarchar(255) NULL, type nvarchar(255) NULL, location nvarchar(255) NULL, status nvarchar(255) NULL, commissioned nvarchar(255) NULL, sync nvarchar(25) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table station");
            }
            if (!TableExists(conn, "syncs"))
            {
                cmd.CommandText = "CREATE TABLE syncs(id nvarchar(100) NULL, objects nvarchar(100) NULL, dates nvarchar(100) NULL, users nvarchar(100) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table sync");
            }

            //CREATE TABLE synoptic (  id nvarchar(100) NULL, station nvarchar(100) NULL, dates nvarchar(100) NULL, times nvarchar(100) NULL, ir nvarchar(100) NULL, ix nvarchar(100) NULL, h nvarchar(100) NULL, www nvarchar(100) NULL, vv nvarchar(100) NULL, n nvarchar(100) NULL, dd nvarchar(100) NULL, ff nvarchar(100) NULL, t nvarchar(100) NULL, td nvarchar(100) NULL, po nvarchar(100) NULL, gisis nvarchar(100) NULL, hhh nvarchar(100) NULL, rrr nvarchar(100) NULL, tr nvarchar(100) NULL, present nvarchar(100) NULL, past nvarchar(100) NULL, nh nvarchar(100) NULL, cl nvarchar(100) NULL, cm nvarchar(100) NULL, ch nvarchar(100) NULL, tq nvarchar(100) NULL, ro nvarchar(100) NULL, r1 nvarchar(100) NULL, tx nvarchar(100) NULL, tm nvarchar(100) NULL, ee nvarchar(100) NULL, e nvarchar(100) NULL, sss nvarchar(100) NULL, pchange nvarchar(100) NULL, p24 nvarchar(100) NULL, rr nvarchar(100) NULL, tr1 nvarchar(100) NULL, ns nvarchar(100) NULL, c nvarchar(100) NULL, hs nvarchar(100) NULL, ns1 nvarchar(100) NULL, c1 nvarchar(100) NULL, hs1 nvarchar(100) NULL, ns2 nvarchar(100) NULL, c2 nvarchar(100) NULL, hs2 nvarchar(100) NULL, supplementary nvarchar(100) NULL, wb nvarchar(100) NULL, rh nvarchar(100) NULL, vap nvarchar(100) NULL, users nvarchar(100) NULL, submitted nvarchar(100) NULL, sync nvarchar(25) NULL);
            if (!TableExists(conn, "synoptic"))
            {
                cmd.CommandText = "CREATE TABLE synoptic (id nvarchar(100) NULL, station nvarchar(100) NULL, dates nvarchar(100) NULL, times nvarchar(100) NULL, ir nvarchar(100) NULL, ix nvarchar(100) NULL, h nvarchar(100) NULL, www nvarchar(100) NULL, vv nvarchar(100) NULL, n nvarchar(100) NULL, dd nvarchar(100) NULL, ff nvarchar(100) NULL, t nvarchar(100) NULL, td nvarchar(100) NULL, po nvarchar(100) NULL, gisis nvarchar(100) NULL, hhh nvarchar(100) NULL, rrr nvarchar(100) NULL, tr nvarchar(100) NULL, present nvarchar(100) NULL, past nvarchar(100) NULL, nh nvarchar(100) NULL, cl nvarchar(100) NULL, cm nvarchar(100) NULL, ch nvarchar(100) NULL, tq nvarchar(100) NULL, ro nvarchar(100) NULL, r1 nvarchar(100) NULL, tx nvarchar(100) NULL, tm nvarchar(100) NULL, ee nvarchar(100) NULL, e nvarchar(100) NULL, sss nvarchar(100) NULL, pchange nvarchar(100) NULL, p24 nvarchar(100) NULL, rr nvarchar(100) NULL, tr1 nvarchar(100) NULL, ns nvarchar(100) NULL, c nvarchar(100) NULL, hs nvarchar(100) NULL, ns1 nvarchar(100) NULL, c1 nvarchar(100) NULL, hs1 nvarchar(100) NULL, ns2 nvarchar(100) NULL, c2 nvarchar(100) NULL, hs2 nvarchar(100) NULL, supplementary nvarchar(100) NULL, wb nvarchar(100) NULL, rh nvarchar(100) NULL, vap nvarchar(100) NULL, users nvarchar(100) NULL, submitted nvarchar(100) NULL, sync nvarchar(25) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table synoptic");
            }
            //CREATE TABLE user (  id nvarchar(255) NOT NULL, name nvarchar(255) NOT NULL, contact nvarchar(255) NOT NULL, role nvarchar(255) NOT NULL, station nvarchar(255) NOT NULL, email nvarchar(255) NULL);
            if (!TableExists(conn, "element"))
            {
                cmd.CommandText = "CREATE TABLE element (id nvarchar(100) NULL, name nvarchar(100) NULL, abbrev nvarchar(100) NULL, type nvarchar(100) NULL, units nvarchar(100) NULL,scale nvarchar(100) NULL, limits nvarchar(100) NULL,description nvarchar(100) NULL,submitted nvarchar(100) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table element");
            }
            if (!TableExists(conn, "instrument"))
            {
                cmd.CommandText = "CREATE TABLE instrument (id nvarchar(100) NULL, name nvarchar(100) NULL, station nvarchar(100) NULL, element nvarchar(100) NULL, dateRegister nvarchar(100) NULL,dateExpire nvarchar(100) NULL, code nvarchar(100) NULL, manufacturer nvarchar(100) NULL,description nvarchar(100) NULL,submitted nvarchar(100) NULL);";
                cmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Created table instrument");
            }

            conn.Close();
            login.Visibility = System.Windows.Visibility.Visible;
            cancel.Visibility = System.Windows.Visibility.Visible;
        }
        public bool TableExists(SqlCeConnection connection, string tableName)
        {
            using (var command = new SqlCeCommand())
            {
                command.Connection = connection;
                var sql = string.Format("SELECT COUNT(*) FROM information_schema.tables WHERE table_name = '{0}'", tableName);
                command.CommandText = sql;
                var count = Convert.ToInt32(command.ExecuteScalar());
                return (count > 0);
            }
        }
        private string Loading_users()
        {
            try
            {
                string total = "";
                string[] lines = System.IO.File.ReadAllLines(Sending.directoryUrl + "center-" + "users" + ".json");
                foreach (string line in lines)
                {
                    total += line;
                }

                List<User> model = JsonConvert.DeserializeObject<List<User>>(total);

                for (int d = 0; d < model.Count; d++)
                {
                    r = App.WimeaApp.Users.Add();
                    r.Station = model.ElementAt(d).Station;
                    r.Name = model.ElementAt(d).Name;
                    r.Email = model.ElementAt(d).Email;
                    r.Contact = model.ElementAt(d).Contact;
                    r.Role = model.ElementAt(d).Role;
                    r.Password = Encryption.SimpleEncrypt(model.ElementAt(d).Password);
                    r.Sync = "T";
                    r.Save();

                }
                return "Loaded synoptic information into local database!";

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
                return "done loading metars";

            }


        }



    }
}
