﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WimeaApplication.Helpers
{
    public class DBHelper
    {
        public string Database { get; set; }
        public string Server { get; set; }
        public static SqlCeConnection con = new SqlCeConnection(@"Data Source=C:\matrix\matrix.sdf;Password=server; Persist Security Info=True;");

        private static DBHelper _instance;

        public static DBHelper Instance
        {

            get
            {
                if (_instance == null)
                    _instance = new DBHelper();

                return _instance;
            }
        }

        public void ExecuteQuery(string Query)
        {
            openConnection();
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = Query;
            try
            {

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                closeConnection();

            }


        }

        public void openConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
        }
        public void closeConnection()
        {
            if (con.State != System.Data.ConnectionState.Closed)
                con.Close();
        }

    }

}

