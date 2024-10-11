namespace Data.Connections
{
    public class MSSQL
    {
        public static string GetConnection() => Environment.GetEnvironmentVariable("CrudProject");
    }
}
