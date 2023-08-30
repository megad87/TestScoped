namespace ScodedAll
{
    public static class ConnectionString
    {
        private static string cName = "Data Source=.; Initial Catalog=Testdb;User ID=sa;Password=SQL@2022";
        public static string CName
        {
            get => cName;
        }
    }
}
