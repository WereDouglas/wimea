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
using WimeaApplication.View;
using WimeaLibrary;

namespace WimeaApplication
{
    /// <summary>
    /// Interaction logic for StationPage.xaml
    /// </summary>
    public partial class StationPage : Page
    {
          private ObservableCollection<Station> _StationsList= null;
      
      
     
        public StationPage()
        {
            InitializeComponent();
            RefreshStationList();
            lblName.Visibility = System.Windows.Visibility.Hidden;
            alert.Visibility = System.Windows.Visibility.Hidden;
           
        
            
        }
        private void RefreshStationList()
        {
         
          _StationsList = new ObservableCollection<Station>(App.WimeaApp.Stations);
            StationGrid.ItemsSource= null;
            StationGrid.ItemsSource = _StationsList;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(StationGrid.ItemsSource);
            view.Filter = StationFilter;

        }
        private bool StationFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Station).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(StationGrid.ItemsSource).Refresh();
        }

        
      private void deleteClick(object sender, RoutedEventArgs e)
        {           


        }
        private void dataGridEvaluation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void StationGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
      
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
                Button button = sender as System.Windows.Controls.Button;
                Station Station = button.DataContext as Station;

                if (MessageBox.Show("Are you sure you want to delete "+ Station.Name+" ?","Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                Station.Delete(Station.Id.ToString());
                RefreshStationList();
                }
               else {

                return;
            }
         

        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as System.Windows.Controls.Button;
            Station Station = button.DataContext as Station;
                                                     //(string id, string name, string number, string code, string latitude, string longitude, string altitude, string type, string location, string status, string commissioned)
            EditStation inputDialog = new EditStation(Station.Id,Station.Name,Station.Number,Station.Code,Station.Latitude,Station.Longitude,Station.Altitude,Station.Type,Station.Location,Station.Status,Station.Commissioned);
            if (inputDialog.ShowDialog() == true)
                lblName.Text = inputDialog.Answer;
            lblName.Visibility = System.Windows.Visibility.Visible;
            alert.Visibility = System.Windows.Visibility.Visible;
            RefreshStationList();          

        }
        private List<Station> lstMyObject = new List<Station>();

        private void StationGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
           
            foreach (Station item in e.RemovedItems)
            {
                lstMyObject.Remove(item);
            }

            foreach (Station item in e.AddedItems)
            {
                lstMyObject.Add(item);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
           
            AddStation inputDialog = new AddStation();
            if (inputDialog.ShowDialog() == true)
            lblName.Text = inputDialog.Answer;
            lblName.Visibility = System.Windows.Visibility.Visible;
            alert.Visibility = System.Windows.Visibility.Visible;
            RefreshStationList();

        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void chkSelectAll_Click(object sender, RoutedEventArgs e)
        {
            if (chkSelectAll.IsChecked.Value == true)
            {
                StationGrid.SelectAll();
            }
            else
            {
                StationGrid.UnselectAll();
            }
        }

       

        private void btnDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all these Stations?","Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Station u in StationGrid.SelectedItems)
                {
                    u.Delete(u.Id.ToString());
                }
                RefreshStationList();
                lblName.Text = "Stations deleted!";
                lblName.Visibility = System.Windows.Visibility.Visible;
                alert.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                return;
            } 
           
           
        }

        private void print_Click(object sender, RoutedEventArgs e)
        {
           
        }

    }
}