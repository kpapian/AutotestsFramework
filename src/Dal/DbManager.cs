using System;

namespace Dal
{
    public class DbManager
    {
        public static String ConnectionString { get; private set; }

        public static void Initialize(String connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
