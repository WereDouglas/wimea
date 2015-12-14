using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WimeaLibrary.Helpers;


namespace WimeaLibrary
{
 public  class SyncsCollection:DBObject,IEnumerable<Syncs>
    {
        #region Members
        private List<Syncs> _syncs;
        #endregion

        #region Properties
        public int Count
        { get { return _syncs.Count; } }

        public bool IsLoaded { get; private set; }
        #endregion
        public SyncsCollection(DBObject parent)
            :base(parent)
        {          
            _syncs = new List<Syncs>();
           // _syncss.Clear();
        }

        public Syncs Add()
        {
            Syncs u = new Syncs(this);            
            _syncs.Add(u);
            return u;
        }

        public IEnumerator<Syncs> GetEnumerator()
        {
            foreach (var item in _syncs)
            yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load()
        {
            _syncs.Clear();
            string sql = "select * from [syncs]";

            DataTable table = new DataTable();
            ExecuteQuery(sql, table);

            foreach (DataRow row in table.Rows)
            {
                Syncs u=Add();
                    u.Id = row["id"].ToString();
                    u.Objects = row["objects"].ToString();
                    u.Dates = row["dates"].ToString();                  
                    u.Users = row["users"].ToString();
                                
               //  _syncss.Add(u);
        }
            IsLoaded = true;
        }

        public void Refresh()
        {
            _syncs.Clear();
            Load();
        }
    }
}
