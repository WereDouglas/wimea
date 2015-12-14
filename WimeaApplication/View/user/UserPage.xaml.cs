using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private BackgroundWorker bw = new BackgroundWorker();
        private User r;

        private ObservableCollection<User> _UsersList= null;

        public string name = "";
     
        public UserPage()
        {
            InitializeComponent();
            RefreshUserList();
            lblName.Visibility = System.Windows.Visibility.Hidden;
            alert.Visibility = System.Windows.Visibility.Hidden;           
            name = Sending.currentstation;
            
        }
        private void RefreshUserList()
        {
         
          _UsersList = new ObservableCollection<User>(App.WimeaApp.Users);
            UserGrid.ItemsSource= null;
            UserGrid.ItemsSource = _UsersList.Where(n=>n.Station== Sending.currentstation);
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
            if (MessageBox.Show("Are you sure you want to delete all these users?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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

        private void sync_Click(object sender, RoutedEventArgs e)
        {
            if (Sending.IsInternetAvailable())
            {
                r = new User(null) ;
                r.Deleteall();
              //  r.Save();
                bw.RunWorkerAsync();
                bw.WorkerReportsProgress = true;
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            }
            else {
                this.lblName.Text = ("No internet connection");
            }
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                this.lblName.Text = "Canceled!";
            }

            else if (!(e.Error == null))
            {
                this.lblName.Text = ("Error: " + e.Error.Message);
            }

            else
            {
                this.lblName.Text = "synchronised information!";
                RefreshUserList();
               
            }
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.lblName.Text = ("File download " + e.ProgressPercentage.ToString() + " file");
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            int counter = 1;
            BackgroundWorker worker = sender as BackgroundWorker;
            syncs(Sending.genUrl + "apiuser/user/station/" + name + "/format/json", "user", name);
            counter = 4;
            
            worker.ReportProgress(((counter)));
           
            Loading_user(name);


            System.Threading.Thread.Sleep(5000);


        }
        private void syncs(string url, string content, string station)
        {

            using (var client = new WebClient())
            {
                var json = client.DownloadString(url);
                System.IO.File.WriteAllText(Sending.directoryUrl + station + "-" + content + ".json", json);
            }

        }
        private string Loading_user(string station)
        {
            string reply = "";
            try
            {
                string total = "";
                string[] lines = System.IO.File.ReadAllLines(Sending.directoryUrl + station + "-" + "user" + ".json");
                foreach (string line in lines)
                {

                    total += line;
                }

                List<User> model = JsonConvert.DeserializeObject<List<User>>(total);

                for (int d = 0; d < model.Count; d++)
                {
                    r =  App.WimeaApp.Users.Add();
                    r.Station = model.ElementAt(d).Station;
                    r.Name = model.ElementAt(d).Name;
                    r.Email = model.ElementAt(d).Email;
                    r.Contact = model.ElementAt(d).Contact;
                    r.Role = model.ElementAt(d).Role;
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
