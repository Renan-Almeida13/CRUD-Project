using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Connections
{
    public class MSSQL
    {
        public static string GetConnection() => Environment.GetEnvironmentVariable("CrudProject");
    }
}
