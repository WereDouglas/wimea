using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WimeaLibrary.Helpers;

namespace WimeaLibrary
{
 public  class InstrumentCollection: DBObject, IEnumerable<Instrument>
    {
        #region Members
        private List<Instrument> _instrument;
        #endregion

        #region Properties
        public int Count
        { get { return _instrument.Count; } }

        public bool IsLoaded { get; private set; }
        #endregion
        public InstrumentCollection(DBObject parent)
            :base(parent)
        {          
            _instrument = new List<Instrument>();
           // _Instruments.Clear();
        }

        public Instrument Add()
        {
            Instrument u = new Instrument(this);            
            _instrument.Add(u);
            return u;
        }

        public IEnumerator<Instrument> GetEnumerator()
        {
            foreach (var item in _instrument)
            yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load()
        {
            _instrument.Clear();
            string sql = "select * from [instrument]";

            DataTable table = new DataTable();
            ExecuteQuery(sql, table);

            foreach (DataRow row in table.Rows)
            {
                Instrument u=Add();
                    u.Id = row["id"].ToString();
                    u.Name = row["name"].ToString();
                    u.Station = row["station"].ToString();
                    u.Element = row["element"].ToString();
                    u.DateRegister = row["dateRegister"].ToString();
                    u.DateExpire = row["dateExpire"].ToString();
                    u.Code = row["code"].ToString();
                    u.Manufacturer = row["manufacturer"].ToString();
                    u.Description = row["description"].ToString();
                    u.Submitted = row["submitted"].ToString();                  
              
        }
            IsLoaded = true;
        }

        public void Refresh()
        {
            _instrument.Clear();
            Load();
        }
    }
}
