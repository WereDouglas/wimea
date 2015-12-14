using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WimeaLibrary.Helpers;

namespace WimeaLibrary
{
  public  class Station : DBObject
    { 
        public Station(DBObject parent)
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
        private string _name;

        public string Name
        {
            get { return _name; }
            set {
                if (!Validator.IsNotEmpty(value))
                    throw new Exception("Empty field Stationname");                
                    _name = value; 
            }
        }
        private string _number;

        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }
        private string _code;

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        private string _latitude;

        public string Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }
        private string _longitude;

        public string Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
        private string _altitude;

        public string Altitude
        {
            get { return _altitude; }
            set { _altitude = value; }
        }
        private string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _location;

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        private string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private string _commissioned;

        public string Commissioned
        {
            get { return _commissioned; }
            set { _commissioned = value; }
        }
        private string _sync;

        public string Sync
        {
            get { return _sync; }
            set { _sync = value; }
        }
     
        public override void Save()
        {
            if (Name == "" || Number == "")
            {
                throw new Exception("Empty fields");
            }

            else
            {
                SqlCeCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO [station](id,name,number,code,latitude,longitude,altitude,type,location,status,commissioned)VALUES(@id,@name,@number,@code,@latitude,@longitude,@altitude,@type,@location,@status,@commissioned)";
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@number", Number);
                cmd.Parameters.AddWithValue("@code", Code);
                cmd.Parameters.AddWithValue("@latitude", Latitude);
                cmd.Parameters.AddWithValue("@longitude", Longitude);
                cmd.Parameters.AddWithValue("@altitude", Altitude);
                cmd.Parameters.AddWithValue("@type",Type);
                cmd.Parameters.AddWithValue("@location", Location);
                cmd.Parameters.AddWithValue("@status", Status);
                cmd.Parameters.AddWithValue("@commissioned",Commissioned);
                ExecuteNonQuery(cmd);             

            }

        }
        public void Update(string id, string name, string number, string code, string latitude, string longitude,string altitude,string type,string location,string status,string commissioned)
        {

            
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [station] SET name='" + name + "',code='" + code + "',number='" + number + "',latitude='" + latitude + "',longitude ='" + longitude + "',altitude='" + altitude + "',type='" + type + "',location='" + location + "',status='" + status + "',commissioned='" + commissioned + "' WHERE id = '" + id + "'";
           
         
        ExecuteNonQuery(cmd);            

        }

        public bool Delete(string Id)
        {
            System.Diagnostics.Debug.Write(Id + "|");            
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [station] WHERE id ='" + Id + "'";
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