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

namespace WimeaApplication.View
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        private User _user;
        private ObservableCollection<Station> _StationsList = null;

        public AddUser()
                {
                        InitializeComponent();
                        _StationsList = new ObservableCollection<Station>(App.WimeaApp.Stations);
                        stationTxtCbx.ItemsSource = null;
                        stationTxtCbx.ItemsSource =_StationsList.Select(c=>c.Name);

       

                        
                }

                private void btnDialogOk_Click(object sender, RoutedEventArgs e)
                {
                    try
                    {
                        _user = App.WimeaApp.Users.Add();
                        _user.Name = nameTxtBx.Text;
                        _user.Email = emailTxtBx.Text;
                        _user.Contact = contactTxtBx.Text;
                        _user.Role = roleTxtBx.Text;
                        _user.Station = stationTxtCbx.Text;
                        _user.Save();
                        this.DialogResult = true;
                    }
                    catch (Exception ex) {

                        MessageBox.Show(ex.Message.ToString());
                        return;
                    
                    }
                    
                   
                }

                private void Window_ContentRendered(object sender, EventArgs e)
                {
                      //  txtAnswer.SelectAll();
                        //txtAnswer.Focus();
                }

                public string Answer
                {
                    get { return nameTxtBx.Text; }
                }

    }
}
