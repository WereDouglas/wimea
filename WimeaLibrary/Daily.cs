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
   public class Daily: DBObject
    { 
        public Daily(DBObject parent)
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
      
        private string _dates;

        public string Dates
        {
            get { return _dates; }
            set { _dates = value; }
        }
        
        private string _users;

        public string Users
        {
            get { return _users; }
            set { _users = value; }
        }
        private string _maxs;

        public string Maxs
        {
            get { return _maxs; }
            set { _maxs = value; }
        }
        private string _mins;

        public string Mins
        {
            get { return _mins; }
            set { _mins = value; }
        }
        private string _actual;

        public string Actual
        {
            get { return _actual; }
            set { _actual = value; }
        }
        private string _anemometer;

        public string Anemometer
        {
            get { return _anemometer; }
            set { _anemometer = value; }
        }
        private string _wind;

        public string Wind
        {
            get { return _wind; }
            set { _wind = value; }
        }
        private string _maxi;

        public string Maxi
        {
            get { return _maxi; }
            set { _maxi = value; }
        }
        private string _rain;

        public string Rain
        {
            get { return _rain; }
            set { _rain = value; }
        }
        private string _sync;

        public string Sync
        {
            get { return _sync; }
            set { _sync = value; }
        }
        private string _thunder;

        public string Thunder
        {
            get { return _thunder; }
            set { _thunder = value; }
        }
        private string _fog;

        public string Fog
        {
            get { return _fog; }
            set { _fog = value; }
        }
        private string _haze;

        public string Haze
        {
            get { return _haze; }
            set { _haze = value; }
        }
        private string _storm;

        public string Storm
        {
            get { return _storm; }
            set { _storm = value; }
        }
        private string _quake;

        public string Quake
        {
            get { return _quake; }
            set { _quake = value; }
        }
        private string _height;

        public string Height
        {
            get { return _height; }
            set { _height = value; }
        }
        private string _duration;

        public string Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        private string _sunshine;

        public string Sunshine
        {
            get { return _sunshine; }
            set { _sunshine = value; }
        }
        private string _radiationtype;

        public string Radiationtype
        {
            get { return _radiationtype; }
            set { _radiationtype = value; }
        }
        private string _radiation;

        public string Radiation
        {
            get { return _radiation; }
            set { _radiation = value; }
        }
        private string _evaptype1;

        public string Evaptype1
        {
            get { return _evaptype1; }
            set { _evaptype1 = value; }
        }
        private string _evap1;

        public string Evap1
        {
            get { return _evap1; }
            set { _evap1 = value; }
        }
        private string _evaptype2;

        public string Evaptype2
        {
            get { return _evaptype2; }
            set { _evaptype2 = value; }
        }
        private string _evap2;

        public string Evap2
        {
            get { return _evap2; }
            set { _evap2 = value; }
        }
       
       
     
        public override void Save()
        {
            if (Station == "" || Users == "")
            {
                throw new Exception("Empty fields");
            }

            else
            {
                SqlCeCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO [daily](id,dates,station,maxs,mins,actual,anemometer,wind,maxi,rain,thunder,fog,haze,storm,quake,height,duration,sunshine,radiationtype,radiation,evaptype1,evap1,evaptype2,evap2,users,sync)VALUES(@id,@dates,@station,@maxs,@mins,@actual,@anemometer,@wind,@maxi,@rain,@thunder,@fog,@haze,@storm,@quake,@height,@duration,@sunshine,@radiationtype,@radiation,@evaptype1,@evap1,@evaptype2,@evap2,@users,@sync)";
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@station", Station);
                cmd.Parameters.AddWithValue("@dates", Dates);
                cmd.Parameters.AddWithValue("@maxs", Maxs);
                cmd.Parameters.AddWithValue("@mins", Mins);
                cmd.Parameters.AddWithValue("@actual",Actual);
                cmd.Parameters.AddWithValue("@anemometer", Anemometer);
                cmd.Parameters.AddWithValue("@wind", Wind);
                cmd.Parameters.AddWithValue("@maxi", Maxi);
                cmd.Parameters.AddWithValue("@rain",Rain);
                cmd.Parameters.AddWithValue("@thunder", Thunder);
                cmd.Parameters.AddWithValue("@fog", Fog);
                cmd.Parameters.AddWithValue("@haze", Haze);
                cmd.Parameters.AddWithValue("@storm",Storm);
                cmd.Parameters.AddWithValue("@quake", Quake);
                cmd.Parameters.AddWithValue("@height",Height);
                cmd.Parameters.AddWithValue("@duration",Duration);
                cmd.Parameters.AddWithValue("@sunshine", Sunshine);
                cmd.Parameters.AddWithValue("@radiationtype", Radiationtype);
                cmd.Parameters.AddWithValue("@radiation", Radiation);
                cmd.Parameters.AddWithValue("@evaptype1", Evaptype1);
                cmd.Parameters.AddWithValue("@evap1", Evap1);
                cmd.Parameters.AddWithValue("@evaptype2", Evaptype2);
                cmd.Parameters.AddWithValue("@evap2", Evap2);               
                cmd.Parameters.AddWithValue("@users", Users);
                cmd.Parameters.AddWithValue("@sync", Sync);              
                ExecuteNonQuery(cmd);
             

            }

        }
        public void Update(string id, string sync)
        {
            
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [daily] SET sync='" + sync + "' WHERE id = '" + id + "'";
           
         
        ExecuteNonQuery(cmd);            

        }

        public bool Delete(string Id)
        {
            System.Diagnostics.Debug.Write(Id + "|");            
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [daily] WHERE id ='" + Id + "'";
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