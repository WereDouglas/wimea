using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WimeaLibrary;

namespace WimeaApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static Wimea WimeaApp { get; private set; }
        public App()
        {
            WimeaApp = new Wimea();
           
        }
    }
}
