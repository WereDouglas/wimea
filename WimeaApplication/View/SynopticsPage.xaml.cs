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
    /// Interaction logic for SynopticsPage.xaml
    /// </summary>
    public partial class SynopticsPage : Page
    {
        private ObservableCollection<Synoptic> _metarList = null;
        private Synoptic u;
        private ObservableCollection<Station> _StationsList = null;
        public SynopticsPage()
        {
            InitializeComponent();
            RefreshUserList();
        }
        private void RefreshUserList()
        {

            _metarList = new ObservableCollection<Synoptic>(App.WimeaApp.Synoptics);
            _StationsList = new ObservableCollection<Station>(App.WimeaApp.Stations);
            SynopticGrid.ItemsSource = null;
            SynopticGrid.ItemsSource = _metarList.Where(c => Convert.ToDateTime(c.Date).Month.ToString() == (DateTime.Now.Month).ToString() && Convert.ToDateTime(c.Date).Day == DateTime.Now.Day && Convert.ToDateTime(c.Date).Year == DateTime.Now.Year); ;
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
            yearTxtBx.Text = DateTime.Now.Year.ToString();


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
        private void btnDeleteAll_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete all this information?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Synoptic u in SynopticGrid.SelectedItems)
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
                SynopticGrid.SelectAll();
            }
            else
            {
                SynopticGrid.UnselectAll();
            }
        }

        private void Button_Click_generate(object sender, RoutedEventArgs e)
        {
            SynopticGrid.ItemsSource = null;
            SynopticGrid.ItemsSource = _metarList.Where(c => Convert.ToDateTime(c.Date).Month.ToString() == (monthTxtCbx.SelectedIndex + 1).ToString() && Convert.ToDateTime(c.Date).Day.ToString() == dayTxtCbx.Text && Convert.ToDateTime(c.Date).Year.ToString() == yearTxtBx.Text);

        }
    }
}
