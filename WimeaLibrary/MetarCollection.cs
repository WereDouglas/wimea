using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WimeaApplication.Helpers;

namespace WimeaLibrary
{
 public class MetarCollection: DBObject, IEnumerable<Metar>
    {
        #region Members
        private List<Metar> _metars;
        #endregion

        #region Properties
        public int Count
        { get { return _metars.Count; } }

        public bool IsLoaded { get; private set; }
        #endregion
        public MetarCollection(DBObject parent)
            :base(parent)
        {          
            _metars = new List<Metar>();
           // _Metars.Clear();
        }

        public Metar Add()
        {
            Metar u = new Metar(this);            
            _metars.Add(u);
            return u;
        }

        public IEnumerator<Metar> GetEnumerator()
        {
            foreach (var item in _metars)
            yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load()
        {
            _metars.Clear();
            string sql = "select * from [metar]";

            DataTable table = new DataTable();
            ExecuteQuery(sql, table);

            foreach (DataRow row in table.Rows)
            {
                Metar u=Add();
                    u.Id = row["id"].ToString();
                    u.Station = row["station"].ToString();
                    u.Types = row["types"].ToString();
                    u.Datetimes = row["datetimes"].ToString();
                    u.Timezones = row["timezones"].ToString();
                    u.Direction = row["direction"].ToString();
                    u.Speed = row["speed"].ToString();
                    u.Unit = row["unit"].ToString();
                    u.Visibility = row["visibility"].ToString();
                    u.Weather = row["weather"].ToString();
                    u.Cloud = row["cloud"].ToString();
                    u.Temperature = row["temperature"].ToString();
                    u.Humidity = row["humidity"].ToString();
                    u.Dew = row["dew"].ToString();
                    u.Wet = row["wet"].ToString();
                    u.Stationhpa = row["stationhpa"].ToString();
                    u.Seahpa = row["seahpa"].ToString();
                    u.Recent = row["recent"].ToString();                
                    u.Users = row["users"].ToString();
                    u.Days = row["days"].ToString();
              
        }
            IsLoaded = true;
        }

        public void Refresh()
        {
            _metars.Clear();
            Load();
        }
    }
}
