using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WimeaLibrary.Helpers;

namespace WimeaLibrary
{
    public class Syncs: DBObject
    {

        public Syncs(DBObject parent)
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
        private string _objects;

        public string Objects
        {
            get { return _objects; }
            set {
                if (!Validator.IsNotEmpty(value))
                    throw new Exception("Empty field name");                
                    _objects = value; 
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
       
     
        public override void Save()
        {
            if (Objects == "" || Dates == "")
            {
                throw new Exception("Empty fields");
            }

            else
            {
                SqlCeCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO [syncs](id,objects,dates,users)VALUES(@id,@objects,@dates,@users)";
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@objects",Objects);
                cmd.Parameters.AddWithValue("@dates", Dates);
                cmd.Parameters.AddWithValue("@users", Users);
                ExecuteNonQuery(cmd);
            }

        }
        public void Update( string objects, string dates, string users)
        {

           if (!Validator.IsNotEmpty(users))
            throw new Exception("no user defined");
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [syncs] SET dates='" + dates + "',users ='" + users + "' WHERE objects = '"+ objects +"'";
            ExecuteNonQuery(cmd);            

        }

        public bool Delete(string Id)
        {
            System.Diagnostics.Debug.Write(Id + "|");            
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [syncs] WHERE id ='" + Id + "'";
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