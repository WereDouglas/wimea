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

                if (!Validator.IsDigitsOnly(value))
                    throw new Exception("Contact can only take on numbers");                
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
       
     
        public override void Save()
        {
            if (Name == "" || Email == "")
            {
                throw new Exception("Empty fields");
            }

            else
            {
                SqlCeCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO [user](id,name,email,contact,role,station)VALUES(@id,@name,@email,@contact,@role,@station)";
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@contact", Contact);
                cmd.Parameters.AddWithValue("@role", Role);
                // cmd.Parameters.AddWithValue("@password", Encryption.SimpleEncrypt(Password));

                cmd.Parameters.AddWithValue("@station", Station);

                ExecuteNonQuery(cmd);
                //System.Diagnostics.Debug.WriteLine(cmd);

            }

        }
        public void Update(string id, string name, string email, string contact, string role, string station)
        {

            if (!Validator.emailIsValid(email))
                throw new Exception("Invalid email");
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [user] SET name='" + name + "',contact='" + contact + "',email='" + email + "',role='" + role + "',station ='" + station + "' WHERE id = '"+id+"'" ;
           
         
        ExecuteNonQuery(cmd);            

        }

        public bool Delete(string Id)
        {
            System.Diagnostics.Debug.Write(Id + "|");            
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [user] WHERE id ='" + Id + "'";
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