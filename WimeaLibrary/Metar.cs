using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WimeaApplication.Helpers;
using WimeaLibrary.Helpers;

namespace WimeaLibrary
{
  public  class Metar : DBObject
    { 
        public Metar(DBObject parent)
            : base(parent)
        {
            Id = Guid.NewGuid().ToString();

        }
        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _station;

        public string Station
        {
            get { return _station; }
            set {
                if (!Validator.IsNotEmpty(value))
                    throw new Exception("Empty field Station name");                
                    _station = value; 
            }
        }
        private string _types;

        public string Types
        {
            get { return _types; }
            set { _types = value; }
        }
        private string _datetimes;

        public string Datetimes
        {
            get { return _datetimes; }
            set { _datetimes = value; }
        }
        private string _timezones;

        public string Timezones
        {
            get { return _timezones; }
            set { _timezones = value; }
        }
        private string _direction;

        public string Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
        private string _speed;

        public string Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        private string _unit;

        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }
        private string _visibility;

        public string Visibility
        {
            get { return _visibility; }
            set { _visibility = value; }
        }
        private string _weather;

        public string Weather
        {
            get { return _weather; }
            set { _weather = value; }
        }
        private string _cloud;

        public string Cloud
        {
            get { return _cloud; }
            set { _cloud = value; }
        }
        private string _temperature;

        public string Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }
        private string _humidity;

        public string Humidity
        {
            get { return _humidity; }
            set { _humidity = value; }
        }
        private string _dew;

        public string Dew
        {
            get { return _dew; }
            set { _dew = value; }
        }
        private string _wet;

        public string Wet
        {
            get { return _wet; }
            set { _wet = value; }
        }
        private string _stationhpa;

        public string Stationhpa
        {
            get { return _stationhpa; }
            set { _stationhpa = value; }
        }
        private string _seahpa;

        public string Seahpa
        {
            get { return _seahpa; }
            set { _seahpa = value; }
        }
        private string _recent;

        public string Recent
        {
            get { return _recent; }
            set { _recent = value; }
        }
        private string _users;

        public string Users
        {
            get { return _users; }
            set { _users = value; }
        }
        private string _days;

        public string Days
        {
            get { return _days; }
            set { _days = value; }
        }
        

       
       
     
        public override void Save()
        {
            if (Station == "" || Types == "")
            {
                throw new Exception("Empty fields");
            }

            else
            {
                SqlCeCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO [metar](id,station,types,datetimes,timezones,direction,speed,unit,visibility,weather,cloud,temperature,humidity,dew,wet,stationhpa,seahpa,recent,users,days)VALUES(@id,@station,@types,@datetimes,@timezones,@direction,@speed ,@unit,@visibility,@weather,@cloud,@temperature,@humidity,@dew,@wet,@stationhpa,@seahpa,@recent,@users,@days)";
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@station", Station);
                cmd.Parameters.AddWithValue("@types", Types);
                cmd.Parameters.AddWithValue("@datetimes", Datetimes);
                cmd.Parameters.AddWithValue("@timezones", Timezones);
                cmd.Parameters.AddWithValue("@direction",Direction);
                cmd.Parameters.AddWithValue("@speed", Speed);
                cmd.Parameters.AddWithValue("@unit", Unit);
                cmd.Parameters.AddWithValue("@visibility", Visibility);
                cmd.Parameters.AddWithValue("@weather", Weather);
                cmd.Parameters.AddWithValue("@cloud", Cloud);
                cmd.Parameters.AddWithValue("@temperature", Temperature);
                cmd.Parameters.AddWithValue("@humidity", Humidity);
                cmd.Parameters.AddWithValue("@dew", Dew);
                cmd.Parameters.AddWithValue("@wet", Wet);
                cmd.Parameters.AddWithValue("@stationhpa", Stationhpa);
                cmd.Parameters.AddWithValue("@seahpa",Seahpa);
                cmd.Parameters.AddWithValue("@recent", Recent);
                cmd.Parameters.AddWithValue("@users", Users);
                cmd.Parameters.AddWithValue("@days", Days);
                ExecuteNonQuery(cmd);
             

            }

        }
        public void Update(string id, string name, string number, string code, string latitude, string longitude,string altitude,string type,string location,string status,string commissioned)
        {

            
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [Metar] SET name='" + name + "',code='" + code + "',number='" + number + "',latitude='" + latitude + "',longitude ='" + longitude + "',altitude='" + altitude + "',type='" + type + "',location='" + location + "',status='" + status + "',commissioned='" + commissioned + "' WHERE id = '" + id + "'";
           
         
        ExecuteNonQuery(cmd);            

        }

        public bool Delete(string Id)
        {
            System.Diagnostics.Debug.Write(Id + "|");            
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [metar] WHERE id ='" + Id + "'";
            try
            {

               ExecuteNonQuery(cmd);
            }
            catch (SqlCeException ex)
            {
                throw ex;
            }
            finally
            {
               
            }
            return true;

        }


    }
}