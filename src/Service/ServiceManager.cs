using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class ServiceManager
    {
        public static void Initialize(String connectionString)
        {
            DbManager.Initialize(connectionString);
        }
    }
}
