using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public SynopticPage()
        {
            InitializeComponent();
            RefreshUserList();
        }
        private void RefreshUserList()
        {

            _metarList = new ObservableCollection<Synoptic>(App.WimeaApp.Synoptics);
            _StationsList = new ObservableCollection<Station>(App.WimeaApp.Stations);
            SynopticGrid.ItemsSource = null;
            SynopticGrid.ItemsSource = _metarList;
            stationTxtCbx.ItemsSource = null;
            stationTxtCbx.ItemsSource = _StationsList.Select(c => c.Name);


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
    }
}
