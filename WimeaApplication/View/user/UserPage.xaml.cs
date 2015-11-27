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
using WimeaApplication.ViewModel;
using WimeaLibrary;

namespace WimeaApplication
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {


        private ObservableCollection<User> _UsersList= null;
      
      
     
        public UserPage()
        {
            InitializeComponent();
            RefreshUserList();
            lblName.Visibility = System.Windows.Visibility.Hidden;
            alert.Visibility = System.Windows.Visibility.Hidden;
           
        
            
        }
        private void RefreshUserList()
        {
         
          _UsersList = new ObservableCollection<User>(App.WimeaApp.Users);
            UserGrid.ItemsSource= null;
            UserGrid.ItemsSource = _UsersList;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(UserGrid.ItemsSource);
            view.Filter = UserFilter;

        }
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as User).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(UserGrid.ItemsSource).Refresh();
        }

        
      private void deleteClick(object sender, RoutedEventArgs e)
        {           


        }
        private void dataGridEvaluation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UserGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
      
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
                Button button = sender as System.Windows.Controls.Button;
                User user = button.DataContext as User;

                if (MessageBox.Show("Are you sure you want to delete "+ user.Name+" ?","Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                user.Delete(user.Id.ToString());
                RefreshUserList();
                }
               else {

                return;
            }
         

        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as System.Windows.Controls.Button;
            User user = button.DataContext as User;
            EditUser inputDialog = new EditUser(user.Id,user.Name,user.Email,user.Contact,user.Role,user.Station);
            if (inputDialog.ShowDialog() == true)
                lblName.Text = inputDialog.Answer;
            lblName.Visibility = System.Windows.Visibility.Visible;
            alert.Visibility = System.Windows.Visibility.Visible;
            RefreshUserList();          

        }
        private List<User> lstMyObject = new List<User>();

        private void UserGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
           
            foreach (User item in e.RemovedItems)
            {
                lstMyObject.Remove(item);
            }

            foreach (User item in e.AddedItems)
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
           
            AddUser inputDialog = new AddUser();
            if (inputDialog.ShowDialog() == true)
            lblName.Text = inputDialog.Answer;
            lblName.Visibility = System.Windows.Visibility.Visible;
            alert.Visibility = System.Windows.Visibility.Visible;
            RefreshUserList();

        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void chkSelectAll_Click(object sender, RoutedEventArgs e)
        {
            if (chkSelectAll.IsChecked.Value == true)
            {
                UserGrid.SelectAll();
            }
            else
            {
                UserGrid.UnselectAll();
            }
        }

       

        private void btnDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all these users?",
   "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (User u in UserGrid.SelectedItems)
                {
                    u.Delete(u.Id.ToString());
                }
                RefreshUserList();
                lblName.Text = "Users deleted!";
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
