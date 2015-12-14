using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WimeaLibrary.Helpers;

namespace WimeaLibrary
{
  public  class Element: DBObject
    { 
        public Element(DBObject parent)
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
                    throw new Exception("Empty field Elementname");                
                    _name = value; 
            }
        }
        private string _abbrev;

        public string Abbrev
        {
            get { return _abbrev; }
            set { _abbrev = value; }
        }
        private string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _units;

        public string Units
        {
            get { return _units; }
            set { _units = value; }
        }
        private string _scale;

        public string Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }
        private string _limits;

        public string Limits
        {
            get { return _limits; }
            set { _limits = value; }
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
            if (Name == "" || Abbrev == "")
            {
                throw new Exception("Empty fields");
            }

            else
            {
                SqlCeCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO [element](id,name,abbrev,type,units,scale,limits,description,submitted)VALUES(@id,@name,@abbrev,@type,@units,@scale,@limits,@description,@submitted)";
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@abbrev", Abbrev);
                cmd.Parameters.AddWithValue("@type", Type);
                cmd.Parameters.AddWithValue("@units",Units);
                cmd.Parameters.AddWithValue("@scale", Scale);
                cmd.Parameters.AddWithValue("@limits",Limits);
                cmd.Parameters.AddWithValue("@description",Description);
                cmd.Parameters.AddWithValue("@submitted", Submitted);                
                ExecuteNonQuery(cmd);            

            }

        }
        public void Update(string id, string results)
        {
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [element] SET sync='" + results + "' WHERE id = '" + id + "'";
            ExecuteNonQuery(cmd);

        }
        public bool Delete(string Id)
        {
            System.Diagnostics.Debug.Write(Id + "|");            
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [element] WHERE id ='" + Id + "'";
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