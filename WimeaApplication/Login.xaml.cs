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
        string usernames="";
        public Login()
        {
            InitializeComponent();
            _UsersList = new ObservableCollection<User>(App.WimeaApp.Users);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            //HomeWindow w = new HomeWindow();
            //w.Owner = Window.GetWindow(this);
            //w.Show();
            try
            {
                usernames = _UsersList.Where(l => l.Email == EmailTxtBx.Text).Select(l => l.Name).SingleOrDefault().ToString();
               string station = _UsersList.Where(l => l.Email == EmailTxtBx.Text).Select(l => l.Station).SingleOrDefault().ToString();
                MessageBox.Show(usernames);
                if (usernames != "")
                {
                    Sending.currentusername = usernames;
                    Sending.currentstation = station;
                    HomeWindow w = new HomeWindow();
                    w.Owner = Window.GetWindow(this);
                    w.Show();
                    //w.Close();
                    this.Visibility = Visibility.Collapsed;
                }
                else
                {

                    tbProgress.Content = "invalid user";

                }
            }
            catch {

                 tbProgress.Content = "invalid user";
            }
           
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
