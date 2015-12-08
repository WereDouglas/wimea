using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WimeaLibrary
{
  public static class Sending
    {
      public static string genUrl = "http://localhost/weather/index.php/";
      public static string fileUrl = "http://localhost/weather/file/";
      public static string directoryUrl = @"C:\wimea\";
      public static string currentstation ;
      public static string currentusername;
      public static string send(string url, NameValueCollection data)
      {

       
          WebClient webClient = new WebClient();

          byte[] responseBytes = webClient.UploadValues(url, "POST", data);
          string responsefromserver = Encoding.UTF8.GetString(responseBytes);
         // row.Update(row.Id, "F");
          //row.Update(row.Id, responsefromserver);
          Console.WriteLine(responsefromserver);
          return responsefromserver;
          webClient.Dispose();
        
      }
      [DllImport("wininet.dll")]
      private extern static bool InternetGetConnectedState(out int description, int reservedValue);

      public static bool IsInternetAvailable()
      {
          int description;
          return InternetGetConnectedState(out description, 0);
      }
    }

    
}
