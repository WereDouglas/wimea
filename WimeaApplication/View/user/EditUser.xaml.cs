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

namespace WimeaApplication.View
{
    /// <summary>
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        private User _user;
        //User.Id,User.Name,User.Email,User.Contact,User.Role,User.User
        private string Name;
        private string Email;
        private string Contact;
        private string Role;
        private string StationName;
        private ObservableCollection<Station> _StationsList = null;
       
        private string Id;
        public EditUser(string id, string name,string email,string contact,string role,string station)
        {
            InitializeComponent();
            Id = id;
            Name = name;
            Email = email;
            Contact = contact;
            Role = role;
            StationName = station;

            _StationsList = new ObservableCollection<Station>(App.WimeaApp.Stations);

            stationTxtCbx.ItemsSource = null;         
            stationTxtCbx.ItemsSource = _StationsList.Select(c => c.Name);
            try
            {
                stationTxtCbx.Items.Add(station);
            }
            catch { }


        }
        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _user = App.WimeaApp.Users.Add();
                //(string id, string name, string email, string contact, string role, string station)
                _user.Update(Id, nameTxtBx.Text, emailTxtBx.Text, contactTxtBx.Text, roleTxtBx.Text, stationTxtCbx.Text);
                this.DialogResult = true;
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
           
            nameTxtBx.Text=Name;
            emailTxtBx.Text= Email;
            contactTxtBx.Text= Contact;
            roleTxtBx.Text= Role;
            stationTxtCbx.Text= StationName;
        }

        public string Answer
        {
            get { return ""+Name+" has been updated"; }
        }

    }
}
