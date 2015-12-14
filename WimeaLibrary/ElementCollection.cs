using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WimeaLibrary.Helpers;

namespace WimeaLibrary
{
  public  class ElementCollection: DBObject, IEnumerable<Element>
    {
        #region Members
        private List<Element> _element;
        #endregion

        #region Properties
        public int Count
        { get { return _element.Count; } }

        public bool IsLoaded { get; private set; }
        #endregion
        public ElementCollection(DBObject parent)
            :base(parent)
        {          
            _element = new List<Element>();
           // _Elements.Clear();
        }

        public Element Add()
        {
            Element u = new Element(this);            
            _element.Add(u);
            return u;
        }

        public IEnumerator<Element> GetEnumerator()
        {
            foreach (var item in _element)
            yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load()
        {
            _element.Clear();
            string sql = "select * from [element]";

            DataTable table = new DataTable();
            ExecuteQuery(sql, table);

            foreach (DataRow row in table.Rows)
            {
                Element u=Add();
                    u.Id = row["id"].ToString();
                    u.Name = row["name"].ToString();
                    u.Abbrev = row["abbrev"].ToString();
                    u.Type = row["type"].ToString();
                    u.Units = row["units"].ToString();
                    u.Scale = row["scale"].ToString();
                    u.Limits = row["limits"].ToString();
                    u.Description = row["description"].ToString();
                    u.Submitted = row["submitted"].ToString();
                   
              
        }
            IsLoaded = true;
        }

        public void Refresh()
        {
            _element.Clear();
            Load();
        }
    }
}
