﻿using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WimeaApplication.Helpers;

namespace WimeaLibrary
{
  public  class Wimea : DBObject
    {

      private UserCollection _users;
     
      public UserCollection Users
      {
          get
          {
              if (!_users.IsLoaded)
                  _users.Refresh();
                  _users.Load();
              return _users;
          }
      }
      private StationCollection _stations;
      public StationCollection Stations
      {
          get
          {
              if (!_stations.IsLoaded)
                  _stations.Refresh();
              _stations.Load();
              return _stations;
          }
      }

      private MetarCollection _metars;
      public MetarCollection Metars
      {
          get
          {
              if (!_metars.IsLoaded)
                  _metars.Refresh();
              _metars.Load();
              return _metars;
          }
      }
      private DailyCollection _dailys;
      public DailyCollection Dailys
      {
          get
          {
              if (!_dailys.IsLoaded)
                  _dailys.Refresh();
              _dailys.Load();
              return _dailys;
          }
      }




       public Wimea():base(null)
        {
           
            _users = new UserCollection(this);
            _stations = new StationCollection(this);
            _metars = new MetarCollection(this);
            _dailys = new DailyCollection(this);
           
        }
      
       



    }
}
