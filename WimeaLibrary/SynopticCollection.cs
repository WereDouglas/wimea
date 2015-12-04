using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WimeaApplication.Helpers;

namespace WimeaLibrary
{
   public class SynopticCollection: DBObject, IEnumerable<Synoptic>
    {
        #region Members
        private List<Synoptic> _synoptics;
        #endregion

        #region Properties
        public int Count
        { get { return _synoptics.Count; } }

        public bool IsLoaded { get; private set; }
        #endregion
        public SynopticCollection(DBObject parent)
            :base(parent)
        {          
            _synoptics = new List<Synoptic>();
           // _Synoptics.Clear();
        }

        public Synoptic Add()
        {
            Synoptic u = new Synoptic(this);            
            _synoptics.Add(u);
            return u;
        }

        public IEnumerator<Synoptic> GetEnumerator()
        {
            foreach (var item in _synoptics)
            yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Load()
        {
            _synoptics.Clear();
            string sql = "select * from [synoptic]";

            DataTable table = new DataTable();
            ExecuteQuery(sql, table);

            foreach (DataRow row in table.Rows)
            {
                Synoptic u=Add();
                    u.Id = row["id"].ToString();
                    u.Station = row["station"].ToString();
                    u.Date = row["dates"].ToString();
                    u.Time = row["times"].ToString();
                    u.Ir = row["ir"].ToString();
                    u.Ix = row["ix"].ToString();
                    u.H = row["h"].ToString();
                    u.Www = row["www"].ToString();
                    u.Vv = row["vv"].ToString();
                    u.N = row["n"].ToString();
                    u.Dd = row["dd"].ToString();
                    u.Ff = row["ff"].ToString();
                    u.T = row["t"].ToString();
                    u.Td = row["td"].ToString();
                    u.Po = row["po"].ToString();
                    u.Gisis = row["gisis"].ToString();
                    u.Hhh = row["hhh"].ToString();
                    u.Rrr = row["rrr"].ToString();                
                    u.Tr = row["tr"].ToString();
                    u.Present = row["present"].ToString();
                    u.Past = row["past"].ToString();
                    u.Nh = row["nh"].ToString();
                    u.Cl = row["cl"].ToString();
                    u.Cm = row["cm"].ToString();
                    u.Ch = row["ch"].ToString();
                    u.Tq = row["tq"].ToString();
                    u.Ro = row["ro"].ToString();
                    u.R1 = row["r1"].ToString();
                    u.Tx = row["tx"].ToString();
                    u.Tm = row["tm"].ToString();
                    u.Ee = row["ee"].ToString();
                    u.E = row["e"].ToString();
                    u.Sss = row["sss"].ToString();
                    u.Pchange = row["pchange"].ToString();
                    u.P24 = row["p24"].ToString();
                    u.Rr = row["rr"].ToString();
                    u.Tr1 = row["tr1"].ToString();
                    u.Ns1 = row["ns"].ToString();
                    u.C = row["c"].ToString();
                    u.Hs = row["hs"].ToString();
                    u.Ns1 = row["ns1"].ToString();
                    u.C1 = row["c1"].ToString();
                    u.Hs1 = row["hs1"].ToString();
                    u.Ns2 = row["ns2"].ToString();
                    u.C2 = row["c2"].ToString();
                    u.Hs2 = row["hs2"].ToString();
                    u.Supplementary = row["supplementary"].ToString();
                    u.Wb = row["wb"].ToString();
                    u.Rh = row["rh"].ToString();
                    u.Vap = row["vap"].ToString();
                    u.Users = row["users"].ToString();
                    u.Submitted = row["submitted"].ToString();
            }
            IsLoaded = true;
        }

        public void Refresh()
        {
            _synoptics.Clear();
            Load();
        }
    }
}