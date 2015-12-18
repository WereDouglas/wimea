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
    /// Interaction logic for SynopticPage.xaml
    /// </summary>
    public partial class SynopticPage : Page
    {
        private ObservableCollection<Synoptic> _metarList = null;
        private Synoptic u;
        private ObservableCollection<Station> _StationsList = null;
        private BackgroundWorker bw = new BackgroundWorker();
        public SynopticPage()
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

            _metarList = new ObservableCollection<Synoptic>(App.WimeaApp.Synoptics);
            _StationsList = new ObservableCollection<Station>(App.WimeaApp.Stations);
            SynopticGrid.ItemsSource = null;
            SynopticGrid.ItemsSource = _metarList;
            stationTxtCbx.Text = Sending.currentstation;


        }

       

        private void stationTxtCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridEvaluation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("confirm this information ?" + present.Text + " " + supplementary.Text + " " + ir.Text, "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                    u = App.WimeaApp.Synoptics.Add();
                    u.Station = stationTxtCbx.Text;
                    u.Date = DateTime.Now.ToString() ;
                    u.Time = time.Text;
                    u.Ir = ir.Text;
                    u.Ix = ix.Text;
                    u.H = h.Text;
                    u.Www = present.Text;
                    u.Vv = vv.Text;
                    u.N = n.Text;
                    u.Dd = dd.Text;
                    u.Ff = ff.Text;
                    u.T = t.Text;
                    u.Td = td.Text;
                    u.Po = po.Text;
                    u.Gisis = gisis.Text;
                    u.Hhh = hhh.Text;
                    u.Rrr = rrr.Text;
                    u.Tr = tr.Text;
                    u.Present = present.Text;
                    u.Past = past.Text;
                    u.Nh = nh.Text;
                    u.Cl = c.Text;
                    u.Cm = cm.Text;
                    u.Ch = ch.Text;
                    u.Tq = tq.Text;
                    u.Ro = ro.Text;
                    u.R1 = r1.Text;
                    u.Tx = tx.Text;
                    u.Tm = tm.Text;
                    u.Ee = ee.Text;
                    u.E = es.Text;
                    u.Sss = sss.Text;
                    u.Pchange = pchange.Text;
                    u.P24 = p24.Text;
                    u.Rr = rr.Text;
                    u.Tr1 = tr1.Text;
                    u.Ns = ns.Text;
                    u.Ns1 = ns1.Text;
                    u.C = c.Text;
                    u.Hs = hs.Text;
                    u.Ns1 = ns1.Text;
                    u.C1 = c.Text;
                    u.Hs1 = hs.Text;
                    u.Ns2 = ns.Text;
                    u.C2 = c2.Text;
                    u.Hs2 = hs2.Text;
                    u.Supplementary = supplementary.Text;
                    u.Wb = wb.Text;
                    u.Rh = rh.Text;
                    u.Vap = vap.Text;
                    u.Users = "test";
                    u.Submitted = DateTime.Now.ToString();
                    u.Sync = "F";

                    u.Save();
                    RefreshUserList();
                 

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

            List<Synoptic> sendies = new List<Synoptic>();
            sendies = _metarList.Where(c => c.Sync == "F" || c.Sync == "").ToList();

            string URL = Sending.genUrl + "apisynoptic/synoptic";


            foreach (Synoptic row in sendies)
            {

                NameValueCollection formData = new NameValueCollection();
                formData["time"] = row.Time;
                formData["datenow"] = row.Date;
                formData["station"] = row.Station;
                formData["ir"] = row.Ir;
                formData["ix"] = row.Ix;
                formData["h"] = row.H;
                formData["www"] = row.Www;
                formData["vv"] = row.Vv;
                formData["n"] = row.N;
                formData["dd"] = row.Dd;
                formData["ff"] = row.Ff;
                formData["t"] = row.T;
                formData["td"] = row.Td;
                formData["Po"] = row.Po;
                formData["gisis"] = row.Gisis;
                formData["hhh"] = row.Hhh;
                formData["rrr"] = row.Rrr;
                formData["tr"] = row.Tr;
                formData["present"] = row.Present;
                formData["past"] = row.Past;
                formData["nh"] = row.Nh;
                formData["cl"] = row.Cl;
                formData["cm"] = row.Cm;
                formData["ch"] = row.Ch;
                formData["Tq"] = row.Tq;
                formData["Ro"] = row.Ro;
                formData["R1"] = row.R1;
                formData["Tx"] = row.Tx;
                formData["Tm"] = row.Tm;
                formData["EE"] = row.Ee;
                formData["E"] = row.E;
                formData["sss"] = row.Sss;
                formData["pchange"] = row.Pchange;
                formData["p24"] = row.P24;
                formData["rr"] = row.Rr;
                formData["tr1"] = row.Tr1;
                formData["ns"] = row.Ns;
                formData["c"] = row.C;
                formData["hs"] = row.Hs;
                formData["ns1"] = row.Ns1;
                formData["c1"] = row.C1; 
                formData["hs1"] = row.Hs1;
                formData["ns2"] = row.Ns2;

                formData["c2"] = row.C2;
                formData["supplementary"] = row.Supplementary;
                formData["wb"] = row.Wb;
                formData["rh"] = row.Rh;
                formData["vap"] = row.Vap;
                formData["user"] = row.Users;

                String results = Sending.send(URL, formData);

                // row.Update(row.Id, "F");
                row.Update(row.Id, results);
               // Console.WriteLine(results);
                worker.ReportProgress(((counter--)));
            }
            System.Threading.Thread.Sleep(500);

        }
       
        
    }
}
