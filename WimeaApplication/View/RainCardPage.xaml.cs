using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
using WimeaLibrary;

namespace WimeaApplication.View
{
    /// <summary>
    /// Interaction logic for RainCardPage.xaml
    /// </summary>
    public partial class RainCardPage : Page
    {
        public RainCardPage()
        {
            InitializeComponent();
           // RainfallCard.Navigate("http://localhost/weather/index.php/welcome/reports/");
        }

        private void stationTxtCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
  
         
            using (var client = new WebClient())
            {
                var json = client.DownloadString("http://localhost/weather/index.php/api/tasks/station/Makerere/format/json");
                System.IO.File.WriteAllText(@"D:\makerere.json", json);


                string total = "";
                string[] lines = System.IO.File.ReadAllLines(@"D:\makerere.json");
                foreach (string line in lines)
                {
                    // Use a tab to indent each line of the file.
                    total += line;
                  
                }

                List<Daily> model = JsonConvert.DeserializeObject<List<Daily>>(total);
                // TODO: do something with the model
             
                for (int d=0; d < model.Count; d++)
                {
                    System.Diagnostics.Debug.WriteLine(model.ElementAt(d).Actual);
                }
            }
            
            // string json = JsonConvert.SerializeObject(_data.ToArray());
           // System.IO.File.WriteAllText(@"D:\path.txt", json);
        }
    
        string GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }


    }
}
