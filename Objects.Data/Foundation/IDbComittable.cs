using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Objects.Data.Foundation
{
    interface IDbComittable
    {
        void Save();
        List<SqlParameter> GetSqlParameters(string prefix = "");
    }
}
