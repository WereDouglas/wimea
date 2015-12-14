using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WimeaLibrary.Helpers;

namespace WimeaLibrary
{
    public class MetarOnline 
    {


        private string id;

        public string Id
        {
            get;
            set;
        }
        private string station;

        public string Station
        {
            get;
            set;
        }
        private string type;

        public string Type
        {
            get;
            set;
        }
        private string datetime;

        public string Datetime
        {
             get;
            set;
        }
        private string timezone;

        public string Timezone
        {
             get;
            set;
        }
        private string wind_direction;

        public string Wind_direction
        {
             get;
            set;
        }
        private string wind_speed;

        public string Wind_speed
        {
             get;
            set;
        }
        private string unit;

        public string Unit
        {
            get;
            set;
        }
        private string visibility;

        public string Visibility
        {
             get;
            set;
        }
        private string present_weather;

        public string Present_weather
        {
            get;
            set;
        }
        private string cloud;

        public string Cloud
        {
             get;
            set;
        }
        private string air_temperature;

        public string Air_temperature
        {
             get;
            set;
        }
        private string humidity;

        public string Humidity
        {
             get;
            set;
        }
        private string dew_temperature;

        public string Dew_temperature
        {
            get;
            set;
        }
        private string wet_bulb;

        public string Wet_bulb
        {
            get;
            set;
        }
        private string station_pressure_hpa;

        public string Station_pressure_hpa
        {
            get;
            set;
        }
        private string sea_pressure_hpa;

        public string Sea_pressure_hpa
        {
             get;
            set;
        }
        private string recent_weather;

        public string Recent_weather
        {
            get;
            set;
        }
        private string user;

        public string User
        {
            get;
            set;
        }
        private string day;

        public string Day
        {
            get;
            set;
        }





     

    }
}