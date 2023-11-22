using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Connections
{
    public class MSSQL
    {
        public static string GetConnection() => Environment.GetEnvironmentVariable("DESKTOP-F2C1P8P");
    }
}
