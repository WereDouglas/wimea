using Newtonsoft.Json;
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
    /// Interaction logic for RainReport.xaml
    /// </summary>
    public partial class RainReport : Page
    {
        private Months u;
        private ObservableCollection<Station> _StationsList = null;

        private List<Months> dekadalList = new List<Months>();
        public RainReport()
        {
            InitializeComponent();
            RefreshUserList();
        }
        private void RefreshUserList()
        {


            _StationsList = new ObservableCollection<Station>(App.WimeaApp.Stations);
            stationTxtCbx.ItemsSource = null;
            stationTxtCbx.ItemsSource = _StationsList.Select(c => c.Name);
            yearTxtBx.Text = DateTime.Now.Year.ToString();

        }
        private void stationTxtCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            stationNumber.Content = _StationsList.Where(c => c.Name == stationTxtCbx.SelectedItem.ToString()).Select(p => p.Code).SingleOrDefault().ToString();

        }
       
        private void loadings(string station)
        {
            dekadalList.Clear();
           
            try
            {
                string total = "";
                string[] lines = System.IO.File.ReadAllLines(Sending.directoryUrl + station + "-" + "daily" + ".json");
                foreach (string line in lines)
                {

                    total += line;
                }

                List<DailyOnline> model = JsonConvert.DeserializeObject<List<DailyOnline>>(total);
              
                for (int day = 1; day<= 31;day++)
                {
                    u = new Months();

                    for (int d = 0; d < model.Count; d++)
                    {
                       
                         u.Days = day.ToString();
                     
                        if (Convert.ToDateTime(model.ElementAt(d).Date).Year.ToString() == yearTxtBx.Text && Convert.ToDateTime(model.ElementAt(d).Date).Day == day)
                        {                         

                            if (Convert.ToDateTime(model.ElementAt(d).Date).Month == 1 )
                            {
                                u.Jan = model.ElementAt(d).Actual;
                              
                            }
                            if (Convert.ToDateTime(model.ElementAt(d).Date).Month == 2)
                            {
                                u.Feb = model.ElementAt(d).Actual;

                            }
                            if (Convert.ToDateTime(model.ElementAt(d).Date).Month == 3)
                            {
                                u.Mar = model.ElementAt(d).Actual;

                            }
                            if (Convert.ToDateTime(model.ElementAt(d).Date).Month == 4)
                            {
                                u.Apr = model.ElementAt(d).Actual;

                            }
                            if (Convert.ToDateTime(model.ElementAt(d).Date).Month == 5)
                            {
                                u.May = model.ElementAt(d).Actual;

                            }
                            if (Convert.ToDateTime(model.ElementAt(d).Date).Month == 6)
                            {
                                u.Jun = model.ElementAt(d).Actual;

                            }
                            if (Convert.ToDateTime(model.ElementAt(d).Date).Month == 7)
                            {
                                u.Jul = model.ElementAt(d).Actual;

                            }
                            if (Convert.ToDateTime(model.ElementAt(d).Date).Month == 8)
                            {
                                u.Aug = model.ElementAt(d).Actual;

                            }
                            if (Convert.ToDateTime(model.ElementAt(d).Date).Month == 9)
                            {
                                u.Sep = model.ElementAt(d).Actual;

                            }


                            if (Convert.ToDateTime(model.ElementAt(d).Date).Month == 10)
                            {
                                u.Oct = model.ElementAt(d).Actual;

                            }
                            if (Convert.ToDateTime(model.ElementAt(d).Date).Month == 11)
                            {
                                u.Nov = model.ElementAt(d).Actual;

                            }
                            if (Convert.ToDateTime(model.ElementAt(d).Date).Month == 12)
                            {
                                u.Dec = model.ElementAt(d).Actual;

                            }

                         
                        }
                      

                    }
                    dekadalList.Add(u);
                }

                DekadalGrid.ItemsSource = null;

                DekadalGrid.ItemsSource = dekadalList;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
                return;

            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loadings(stationTxtCbx.Text);

        }
        private void ExportToExcel()
        {
            DekadalGrid.SelectAllCells();
            DekadalGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, DekadalGrid);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            DekadalGrid.UnselectAllCells();
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Wimea\dekadal.xls");
            file.WriteLine(result.Replace(',', ' '));
            file.Close();

            MessageBox.Show(" Exporting DataGrid data to Excel file created");
        }

        private void Button_Click_export(object sender, RoutedEventArgs e)
        {
            ExportToExcel();
        }
    }
}
