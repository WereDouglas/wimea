using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WimeaApplication.Helpers;

namespace WimeaLibrary
{
    public class UserCollection:DBObject,IEnumerable<User>
    {
        #region Members
        private List<User> _users;
        #endregion

        #region Properties
        public int Count
        { get { return _users.Count; } }

        public bool IsLoaded { get; private set; }
        #endregion
        public UserCollection(DBObject parent)
            :base(parent)
        {          
            _users = new List<User>();
           // _users.Clear();
        }

        public User Add()
        {
            User u = new User(this);            
            _users.Add(u);
            return u;
        }

        public IEnumerator<User> GetEnumerator()
        {
            foreach (var item in _users)
            yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load()
        {
            _users.Clear();
            string sql = "select * from [user]";

            DataTable table = new DataTable();
            ExecuteQuery(sql, table);

            foreach (DataRow row in table.Rows)
            {
                User u=Add();
                    u.Id = row["id"].ToString();
                    u.Name = row["name"].ToString();
                    u.Contact = row["contact"].ToString();
                    u.Role = row["role"].ToString();
                    u.Email = row["email"].ToString();
                    u.Station = row["station"].ToString();               
               //  _users.Add(u);
        }
            IsLoaded = true;
        }

        public void Refresh()
        {
            _users.Clear();
            Load();
        }
    }
}
