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
   public class Synoptic : DBObject
    {

        public Synoptic(DBObject parent)
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
        private string _station;

        public string Station
        {
            get { return _station; }
            set
            {
                if (!Validator.IsNotEmpty(value))
                    throw new Exception("Empty field Station name");
                _station = value;
            }
        }
        private string _date;

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        private string _time;

        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }
        private string _ir;

        public string Ir
        {
            get { return _ir; }
            set { _ir = value; }
        }
        private string _ix;

        public string Ix1
        {
            get { return _ix; }
            set { _ix = value; }
        }

        public string Ix
        {
            get { return _ix; }
            set { _ix = value; }
        }
        private string _h;

        public string H
        {
            get { return _h; }
            set { _h = value; }
        }
        private string _www;

        public string Www
        {
            get { return _www; }
            set { _www = value; }
        }
        private string _vv;

        public string Vv
        {
            get { return _vv; }
            set { _vv = value; }
        }
        private string _n;

        public string N
        {
            get { return _n; }
            set { _n = value; }
        }
        private string _dd;

        public string Dd
        {
            get { return _dd; }
            set { _dd = value; }
        }
        private string _ff;

        public string Ff
        {
            get { return _ff; }
            set { _ff = value; }
        }
        private string _t;

        public string T
        {
            get { return _t; }
            set { _t = value; }
        }
        private string _td;

        public string Td
        {
            get { return _td; }
            set { _td = value; }
        }
        private string _po;

        public string Po
        {
            get { return _po; }
            set { _po = value; }
        }
        private string _gisis;

        public string Gisis
        {
            get { return _gisis; }
            set { _gisis = value; }
        }
        private string _hhh;

        public string Hhh
        {
            get { return _hhh; }
            set { _hhh = value; }
        }
        private string _rrr;

        public string Rrr
        {
            get { return _rrr; }
            set { _rrr = value; }
        }
        private string _tr;

        public string Tr
        {
            get { return _tr; }
            set { _tr = value; }
        }
        private string _present;

        public string Present
        {
            get { return _present; }
            set { _present = value; }
        }
        private string _past;

        public string Past
        {
            get { return _past; }
            set { _past = value; }
        }
        private string _nh;

        public string Nh
        {
            get { return _nh; }
            set { _nh = value; }
        }
        private string _cl;

        public string Cl
        {
            get { return _cl; }
            set { _cl = value; }
        }
        private string _cm;

        public string Cm
        {
            get { return _cm; }
            set { _cm = value; }
        }
        private string _ch;

        public string Ch
        {
            get { return _ch; }
            set { _ch = value; }
        }
        private string _tq;

        public string Tq
        {
            get { return _tq; }
            set { _tq = value; }
        }
        private string _ro;

        public string Ro
        {
            get { return _ro; }
            set { _ro = value; }
        }
        private string _r1;

        public string R1
        {
            get { return _r1; }
            set { _r1 = value; }
        }
        private string _tx;

        public string Tx
        {
            get { return _tx; }
            set { _tx = value; }
        }
        private string _tm;

        public string Tm
        {
            get { return _tm; }
            set { _tm = value; }
        }
        private string _ee;

        public string Ee
        {
            get { return _ee; }
            set { _ee = value; }
        }
        private string _e;

        public string E
        {
            get { return _e; }
            set { _e = value; }
        }
        private string _sss;

        public string Sss
        {
            get { return _sss; }
            set { _sss = value; }
        }
        private string _pchange;

        public string Pchange
        {
            get { return _pchange; }
            set { _pchange = value; }
        }
        private string _p24;

        public string P24
        {
            get { return _p24; }
            set { _p24 = value; }
        }
        private string _rr;

        public string Rr
        {
            get { return _rr; }
            set { _rr = value; }
        }
        private string _tr1;

        public string Tr1
        {
            get { return _tr1; }
            set { _tr1 = value; }
        }
        private string _ns;

        public string Ns
        {
            get { return _ns; }
            set { _ns = value; }
        }
        private string _c;

        public string C
        {
            get { return _c; }
            set { _c = value; }
        }
        private string _hs;

        public string Hs
        {
            get { return _hs; }
            set { _hs = value; }
        }
        private string _ns1;

        public string Ns1
        {
            get { return _ns1; }
            set { _ns1 = value; }
        }
        private string _c1;

        public string C1
        {
            get { return _c1; }
            set { _c1 = value; }
        }
        private string _hs1;

        public string Hs1
        {
            get { return _hs1; }
            set { _hs1 = value; }
        }
        private string _ns2;

        public string Ns2
        {
            get { return _ns2; }
            set { _ns2 = value; }
        }
        private string _c2;

        public string C2
        {
            get { return _c2; }
            set { _c2 = value; }
        }
        private string _hs2;

        public string Hs2
        {
            get { return _hs2; }
            set { _hs2 = value; }
        }
        private string _supplementary;

        public string Supplementary
        {
            get { return _supplementary; }
            set { _supplementary = value; }
        }
        private string _wb;

        public string Wb
        {
            get { return _wb; }
            set { _wb = value; }
        }
        private string _rh;

        public string Rh
        {
            get { return _rh; }
            set { _rh = value; }
        }
        private string _vap;

        public string Vap
        {
            get { return _vap; }
            set { _vap = value; }
        }
        private string _user;

        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
        private string _submitted;

        public string Submitted
        {
            get { return _submitted; }
            set { _submitted = value; }
        }

        public override void Save()
        {
            if (Station == "" || User == "")
            {
                throw new Exception("Empty fields");
            }

            else
            {
                SqlCeCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO [synoptic](id,station,dates,times,ir,ix,h,www,vv,n,dd,ff,t,td,po,gisis,hhh,rrr,tr,present,past,nh,cl,cm,ch,tq,ro,r1,tx,tm,ee,e,sss,pchange,p24,rr,tr1,ns,c,hs,ns1,c1,hs1,ns2,c2,hs2,supplementary,wb,rh,vap,user,submitted)VALUES(@id,@station,@dates,@times,@ir,@ix,@h,@www,@vv,@n,@dd,@ff,@t,@td,@po,@gisis,@hhh,@rrr,@tr,@present,@past,@nh,@cl,@cm,@ch,@tq,@ro,@r1,@tx,@tm,@ee,@e,@sss,@pchange,@p24,@rr,@tr1,@ns,@c,@hs,@ns1,@c1,@hs1,@ns2,@c2,@hs2,@supplementary,@wb,@rh,@vap,@user,@submitted)";
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@station", Station);
                cmd.Parameters.AddWithValue("@dates", Date);
                cmd.Parameters.AddWithValue("@times", Time);
                cmd.Parameters.AddWithValue("@ir", Ir);
                cmd.Parameters.AddWithValue("@ix", Ix);
                cmd.Parameters.AddWithValue("@h", H);
                cmd.Parameters.AddWithValue("@www", Www);
                cmd.Parameters.AddWithValue("@vv", Vv);
                cmd.Parameters.AddWithValue("@n", N);
                cmd.Parameters.AddWithValue("@dd", Dd);
                cmd.Parameters.AddWithValue("@ff", Ff);
                cmd.Parameters.AddWithValue("@t", T);
                cmd.Parameters.AddWithValue("@td", Td);
                cmd.Parameters.AddWithValue("@po", Po);
                cmd.Parameters.AddWithValue("@gisis", Gisis);
                cmd.Parameters.AddWithValue("@hhh", Hhh);
                cmd.Parameters.AddWithValue("@rr", Rr);
                cmd.Parameters.AddWithValue("@tr", Tr);
                cmd.Parameters.AddWithValue("@present", Present);
                cmd.Parameters.AddWithValue("@past", Past);
                cmd.Parameters.AddWithValue("@nh", Nh);
                cmd.Parameters.AddWithValue("@cl", Cl);
                cmd.Parameters.AddWithValue("@cm", Cm);
                cmd.Parameters.AddWithValue("@ch", Ch);
                cmd.Parameters.AddWithValue("@tq", Tq);
                cmd.Parameters.AddWithValue("@ro", Ro);
                cmd.Parameters.AddWithValue("@r1", R1);
                cmd.Parameters.AddWithValue("@tx", Tx);
                cmd.Parameters.AddWithValue("@tm", Tm);
                cmd.Parameters.AddWithValue("@ee", Ee);
                cmd.Parameters.AddWithValue("@e", E);
                cmd.Parameters.AddWithValue("@sss", Sss);
                cmd.Parameters.AddWithValue("@pchange", Pchange);
                cmd.Parameters.AddWithValue("@p24", P24);
                cmd.Parameters.AddWithValue("@rr", Rr);
                cmd.Parameters.AddWithValue("@tr1", Tr1);
                cmd.Parameters.AddWithValue("@ns", Ns);
                cmd.Parameters.AddWithValue("@c", C);
                cmd.Parameters.AddWithValue("@hs", Hs);
                cmd.Parameters.AddWithValue("@ns1", Ns1);
                cmd.Parameters.AddWithValue("@c1", C1);
                cmd.Parameters.AddWithValue("@hs1", Hs1);
                cmd.Parameters.AddWithValue("@ns2", Ns2);
                cmd.Parameters.AddWithValue("@c2", C2);
                cmd.Parameters.AddWithValue("@hs2", Hs2);
                cmd.Parameters.AddWithValue("@supplementary", Supplementary);
                cmd.Parameters.AddWithValue("@wb", Wb);
                cmd.Parameters.AddWithValue("@rh", Rh);
                cmd.Parameters.AddWithValue("@vap", Vap);
                cmd.Parameters.AddWithValue("@user", User);
                cmd.Parameters.AddWithValue("@submitted", Submitted);               
                ExecuteNonQuery(cmd);


            }

        }
        public void Update(string id, string name, string number, string code, string latitude, string longitude, string altitude, string type, string location, string status, string commissioned)
        {


            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [Synoptic] SET name='" + name + "',code='" + code + "',number='" + number + "',latitude='" + latitude + "',longitude ='" + longitude + "',altitude='" + altitude + "',type='" + type + "',location='" + location + "',status='" + status + "',commissioned='" + commissioned + "' WHERE id = '" + id + "'";


            ExecuteNonQuery(cmd);

        }

        public bool Delete(string Id)
        {
            System.Diagnostics.Debug.Write(Id + "|");
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM [synoptic] WHERE id ='" + Id + "'";
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