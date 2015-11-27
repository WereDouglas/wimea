using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManagementLibrary.Helpers;

namespace WimeaApplication.Helpers
{
    public abstract class DBObject : DBHelper
    {
        public DBObject Parent { get; private set; }
        public DBObject(DBObject parent) { Parent = parent; }
        public virtual void Save() { }
        public virtual void Delete() { }
        public virtual void Edit() { }
    }
}
