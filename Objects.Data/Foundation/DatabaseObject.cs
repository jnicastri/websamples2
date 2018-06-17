using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Objects.Data.Foundation
{
    public abstract class DatabaseObject
    {
        protected bool DatabaseLoaded = false;

        protected abstract void Load();

        public abstract void PopulateFromReader(SqlDataReader reader, string prefix = "");
    }
}
