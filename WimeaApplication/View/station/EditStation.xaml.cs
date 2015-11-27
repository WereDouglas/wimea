using System;
using System.Collections.Generic;
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
    /// Interaction logic for EditStation.xaml
    /// </summary>
    public partial class EditStation : Window
    {
        private Station _station;
        //station.Id,station.Name,station.Email,station.Contact,station.Role,station.Station
        private string Name;
        private string Number;
        private string Code;
        private string Latitude;
        private string Longitude;
        private string Altitude;
        private string Type;
        private string Location;
        private string Status;
        private string Commissioned;
        private string Id;
        public EditStation(string id, string name, string number, string code, string latitude, string longitude, string altitude, string type, string location, string status, string commissioned)
        {
            InitializeComponent();
            Id = id;
       Name= name;
        Number= number;
       Code= code;
       Latitude= latitude;
       Longitude= longitude;
        Altitude= altitude;
        Type= type;
         Location= location;
        Status= status;
        Commissioned= commissioned;
       
            



        }
        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _station = App.WimeaApp.Stations.Add();
                //(string id, string name, string number, string code, string latitude, string longitude,string altitude,string type,string location,string status,string commissioned)
                _station.Update(Id, nameTxtBx.Text, numberTxtBx.Text, codeTxtBx.Text, latitudeTxtBx.Text, longitudeTxtBx.Text,altitudeTxtBx.Text,typeTxtBx.Text,locationTxtBx.Text,statusTxtCbx.Text,commissionedDatePicker.Text);
                this.DialogResult = true;
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
           
            nameTxtBx.Text=Name;

            numberTxtBx.Text = Number; codeTxtBx.Text = Code; latitudeTxtBx.Text = Latitude; longitudeTxtBx.Text = Longitude; altitudeTxtBx.Text = Altitude; typeTxtBx.Text = Type; locationTxtBx.Text = Location; statusTxtCbx.Text = Status; commissionedDatePicker.Text = Commissioned;
        }

        public string Answer
        {
            get { return ""+ Name +" has been updated"; }
        }

    }
}
