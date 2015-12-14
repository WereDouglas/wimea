using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WimeaLibrary.Helpers;


namespace WimeaLibrary
{
  public class DailyCollection:DBObject, IEnumerable<Daily>
    {
        #region Members
        private List<Daily> _dailys;
        #endregion

        #region Properties
        public int Count
        { get { return _dailys.Count; } }

        public bool IsLoaded { get; private set; }
        #endregion
        public DailyCollection(DBObject parent)
            :base(parent)
        {          
            _dailys = new List<Daily>();
           // _dailys.Clear();
        }

        public Daily Add()
        {
            Daily u = new Daily(this);            
            _dailys.Add(u);
            return u;
        }

        public IEnumerator<Daily> GetEnumerator()
        {
            foreach (var item in _dailys)
            yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load()
        {
            _dailys.Clear();
            string sql = "select * from [daily]";

            DataTable table = new DataTable();
            ExecuteQuery(sql, table);

            foreach (DataRow row in table.Rows)
            {
                Daily u=Add();
                    u.Id = row["id"].ToString();
                    u.Station = row["station"].ToString();
                    u.Maxs = row["maxs"].ToString();
                    u.Mins = row["mins"].ToString();
                     u.Actual =  row["actual"].ToString();
                    u.Anemometer = row["anemometer"].ToString();
                    u.Wind = row["wind"].ToString();
                    u.Maxi = row["maxi"].ToString();
                    u.Rain = row["rain"].ToString();
                    u.Thunder = row["thunder"].ToString();
                    u.Fog = row["fog"].ToString();
                    u.Haze = row["haze"].ToString();
                    u.Storm = row["storm"].ToString();
                    u.Quake = row["quake"].ToString();
                    u.Height = row["height"].ToString();
                    u.Duration = row["duration"].ToString();
                    u.Sunshine = row["sunshine"].ToString();
                    u.Radiationtype = row["radiationtype"].ToString();
                    u.Radiation = row["radiation"].ToString();
                    u.Evaptype1 = row["evaptype1"].ToString();
                    u.Evap1 = row["evap1"].ToString();
                    u.Evaptype2 = row["evaptype2"].ToString();
                    u.Evap2 = row["evap2"].ToString();
                    u.Users = row["users"].ToString();
                    u.Dates = row["dates"].ToString();
                    u.Sync = row["sync"].ToString();
              
        }
            IsLoaded = true;
        }

        public void Refresh()
        {
            _dailys.Clear();
            Load();
        }
    }
}
