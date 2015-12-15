using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WimeaLibrary.Helpers;

namespace WimeaLibrary
{
    public class User : DBObject
    {

        public User(DBObject parent)
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
                    throw new Exception("Empty field username");                
                    _name = value; 
            }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set {

                if (!Validator.emailIsValid(value))
                    throw new Exception("Invalid email");
                _email = value; }
        }
        private string _contact;

        public string Contact
        {
            get { return _contact; }
            set {
                              
                _contact = value; 
            }
        }
        private string _role;

        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }
        private string _station;

        public string Station
        {
            get { return _station; }
            set { _station = value; }
        }

        private string _sync;

        public string Sync
        {
            get { return _sync; }
            set { _sync = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
       
     
        public override void Save()
        {
            if (Name == "" || Email == "")
            {
                throw new Exception("Empty fields");
            }

            else
            {
                SqlCeCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO [users](id,name,email,contact,role,station,password,sync)VALUES(@id,@name,@email,@contact,@role,@station,@password,@sync)";
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@contact", Contact);
                cmd.Parameters.AddWithValue("@role", Role);
                cmd.Parameters.AddWithValue("@password",Password);
                cmd.Parameters.AddWithValue("@station", Station);
                cmd.Parameters.AddWithValue("@sync", Sync);

                ExecuteNonQuery(cmd);
                //System.Diagnostics.Debug.WriteLine(cmd);

            }

        }
        public void Update(string id, string name, string email, string contact, string role, string station)
        {

            if (!Validator.emailIsValid(email))
                throw new Exception("Invalid email");
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [users] SET name='" + name + "',contact='" + contact + "',email='" + email + "',role='" + role + "',station ='" + station + "' WHERE id = '"+id+"'" ;
           
         
        ExecuteNonQuery(cmd);            

        }

        public bool Delete(string Id)
        {
            System.Diagnostics.Debug.Write(Id + "|");            
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [users] WHERE id ='" + Id + "'";
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
        public bool Deleteall()
        {           
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [users]";
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