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
            SynopticGrid.ItemsSource = _metarList;
            stationTxtCbx.ItemsSource = null;
            stationTxtCbx.ItemsSource = _StationsList.Select(c => c.Name);


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
    }
}
