using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WimeaApplication.Helpers;

namespace WimeaLibrary
{
    public class StationCollection : DBObject, IEnumerable<Station>
    {
        #region Members
        private List<Station> _stations;
        #endregion

        #region Properties
        public int Count
        { get { return _stations.Count; } }

        public bool IsLoaded { get; private set; }
        #endregion
        public StationCollection(DBObject parent)
            :base(parent)
        {          
            _stations = new List<Station>();
           // _Stations.Clear();
        }

        public Station Add()
        {
            Station u = new Station(this);            
            _stations.Add(u);
            return u;
        }

        public IEnumerator<Station> GetEnumerator()
        {
            foreach (var item in _stations)
            yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load()
        {
            _stations.Clear();
            string sql = "select * from [station]";

            DataTable table = new DataTable();
            ExecuteQuery(sql, table);

            foreach (DataRow row in table.Rows)
            {
                Station u=Add();
                    u.Id = row["id"].ToString();
                    u.Name = row["name"].ToString();
                    u.Code = row["code"].ToString();
                    u.Number = row["number"].ToString();
                    u.Latitude = row["latitude"].ToString();
                    u.Longitude = row["longitude"].ToString();
                    u.Altitude = row["altitude"].ToString();
                    u.Type = row["type"].ToString();
                    u.Location = row["location"].ToString();
                    u.Status = row["status"].ToString();
                    u.Commissioned = row["commissioned"].ToString();  
              
        }
            IsLoaded = true;
        }

        public void Refresh()
        {
            _stations.Clear();
            Load();
        }
    }
}
