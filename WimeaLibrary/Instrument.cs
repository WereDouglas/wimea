using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WimeaLibrary.Helpers;

namespace WimeaLibrary
{
 public  class Instrument: DBObject
    { 
        public Instrument(DBObject parent)
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
                    throw new Exception("Empty field Instrumentname");                
                    _name = value; 
            }
        }
        private string _station;

        public string Station
        {
            get { return _station; }
            set { _station = value; }
        }
        private string _element;

        public string Element
        {
            get { return _element; }
            set { _element = value; }
        }
        private string _dateRegister;

        public string DateRegister
        {
            get { return _dateRegister; }
            set { _dateRegister = value; }
        }
        private string _dateExpire;

        public string DateExpire
        {
            get { return _dateExpire; }
            set { _dateExpire = value; }
        }
        private string _code;

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        private string _manufacturer;

        public string Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; }
        }
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private string _submitted;

        public string Submitted
        {
            get { return _submitted; }
            set { _submitted = value; }
        }
       
        private string _sync;

        public string Sync
        {
            get { return _sync; }
            set { _sync = value; }
        }
     
        public override void Save()
        {
            if (Name == "" || Station == "")
            {
                throw new Exception("Empty fields");
            }

            else
            {
                SqlCeCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO [instrument](id,name,station,element,dateRegister,dateExpire,code,manufacturer,description,submitted)VALUES(@id,@name,@station,@element,@dateRegister,@dateExpire,@code,@manufacturer,@description,@submitted)";
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@station", Station);
                cmd.Parameters.AddWithValue("@element",Element);
                cmd.Parameters.AddWithValue("@dateRegister",DateRegister);
                cmd.Parameters.AddWithValue("@dateExpire",DateExpire);
                cmd.Parameters.AddWithValue("@code",Code);
                cmd.Parameters.AddWithValue("@manufacturer", Manufacturer);
                cmd.Parameters.AddWithValue("@description",Description);
                cmd.Parameters.AddWithValue("@submitted", Submitted);
                
                ExecuteNonQuery(cmd);             

            }

        }
        public void Update(string id,string results)
        {            
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [instrument] SET sync='" + results + "' WHERE id = '" + id + "'";
           ExecuteNonQuery(cmd);            

        }

        public bool Delete(string Id)
        {
            System.Diagnostics.Debug.Write(Id + "|");            
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [instrument] WHERE id ='" + Id + "'";
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