using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System;
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
    /// Interaction logic for SynopticReport.xaml
    /// </summary>
    public partial class SynopticReport : Page
    {
        private Synoptic u;
        private ObservableCollection<Station> _StationsList = null;
        private List<Synoptic> metList = new List<Synoptic>();
        public SynopticReport()
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
            Synoptic synoptic = button.DataContext as Synoptic;

            if (MessageBox.Show("Are you sure you want to delete this synoptic ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                synoptic.Delete(synoptic.Id.ToString());
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
            metList = new List<Synoptic>();
            try
            {
                string total = "";
                string[] lines = System.IO.File.ReadAllLines(@"D:\" + station + "-" + "synoptic" + ".json");
                foreach (string line in lines)
                {

                    total += line;
                }

                List<SynopticOnline> model = JsonConvert.DeserializeObject<List<SynopticOnline>>(total);

                for (int d = 0; d < model.Count; d++)
                {
                    u = new Synoptic(null);
                    u.Station = model.ElementAt(d).Station;
                    u.Date = model.ElementAt(d).Date;
                    u.Time = model.ElementAt(d).Time;
                    u.Ir = model.ElementAt(d).Ir;
                    u.Ix = model.ElementAt(d).Ix;
                    u.H = model.ElementAt(d).H;
                    u.Www = model.ElementAt(d).Www;
                    u.Vv = model.ElementAt(d).Vv;
                    u.N = model.ElementAt(d).N;
                    u.Dd = model.ElementAt(d).Dd;
                    u.Ff = model.ElementAt(d).Ff;
                    u.T = model.ElementAt(d).T;
                    u.Td = model.ElementAt(d).Td;
                    u.Po = model.ElementAt(d).Po;
                    u.Gisis = model.ElementAt(d).Gisis;
                    u.Hhh = model.ElementAt(d).Hhh;
                    u.Rrr = model.ElementAt(d).Rrr;
                    u.Tr = model.ElementAt(d).Tr;
                    u.Present = model.ElementAt(d).Present;
                    u.Past = model.ElementAt(d).Past;
                    u.Nh = model.ElementAt(d).Nh;
                    u.Cl = model.ElementAt(d).Cl;
                    u.Cm = model.ElementAt(d).Cm;
                    u.Ch = model.ElementAt(d).Ch;
                    u.Tq = model.ElementAt(d).Tq;
                    u.Ro = model.ElementAt(d).Ro;
                    u.R1 = model.ElementAt(d).R1;
                    u.Tx = model.ElementAt(d).Tx;
                    u.Tm = model.ElementAt(d).Tm;
                    u.Ee = model.ElementAt(d).Ee;
                    u.E = model.ElementAt(d).E;
                    u.Sss = model.ElementAt(d).Sss;
                    u.Pchange = model.ElementAt(d).Pchange;
                    u.P24 = model.ElementAt(d).P24;
                    u.Rr = model.ElementAt(d).Rr;
                    u.Tr1 = model.ElementAt(d).Tr1;
                    u.Ns = model.ElementAt(d).Ns;
                    u.Ns1 = model.ElementAt(d).Ns1;
                    u.C = model.ElementAt(d).C;
                    u.Hs = model.ElementAt(d).Hs1;
                    u.Ns1 = model.ElementAt(d).N;
                    u.C1 = model.ElementAt(d).C1;
                    u.Hs1 = model.ElementAt(d).Hs1;
                    u.Ns2 = model.ElementAt(d).Ns2;
                    u.C2 = model.ElementAt(d).C2;
                    u.Hs2 = model.ElementAt(d).Hs2;
                    u.Supplementary = model.ElementAt(d).Supplementary;
                    u.Wb = model.ElementAt(d).Wb;
                    u.Rh = model.ElementAt(d).Rh;
                    u.Vap = model.ElementAt(d).Vap;
                    u.Users = model.ElementAt(d).User;
                    u.Submitted = model.ElementAt(d).Submitted; 
                    metList.Add(u);
                }


                List<Synoptic> metLists = new List<Synoptic>(metList.Where(c => Convert.ToDateTime(c.Date).Month.ToString() == (monthTxtCbx.SelectedIndex + 1).ToString() && Convert.ToDateTime(c.Date).Day.ToString() == dayTxtCbx.Text && Convert.ToDateTime(c.Date).Year.ToString() == yearTxtBx.Text));

                SynopticGrid.ItemsSource = null;
                SynopticGrid.ItemsSource = metLists;




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
