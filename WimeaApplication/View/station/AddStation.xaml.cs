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
using WimeaLibrary.Helpers;

namespace WimeaApplication.View
{
    /// <summary>
    /// Interaction logic for AddStation.xaml
    /// </summary>
    public partial class AddStation : Window
    {
        private Station _station;

        public AddStation()
                {
                        InitializeComponent();
                        
                }

                private void btnDialogOk_Click(object sender, RoutedEventArgs e)
                {
                    try
                    {
                        _station = App.WimeaApp.Stations.Add();
                        _station.Name = nameTxtBx.Text;
                        _station.Number = numberTxtBx.Text;
                        _station.Code = codeTxtBx.Text;
                        _station.Latitude = latitudeTxtBx.Text;
                        _station.Longitude = longitudeTxtBx.Text;
                        _station.Altitude = altitudeTxtBx.Text;
                        _station.Type = typeTxtBx.Text;
                        _station.Location = locationTxtBx.Text;
                        _station.Status = statusTxtCbx.Text;
                        _station.Commissioned = commissionedDatePicker.Text;
                        _station.Save();
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
