using Postulate.Orm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class TdgDb : SqlServerDb<int>
    {
        public TdgDb() : base("default")
        {
        }

        public TdgDb(Configuration config) : base(config, "default")
        {
        }

        public static void Create()
        {
            using (var cn = new SqlConnection(@"Data Source=(localdb)\MSSqlLocalDb;Database=master;Integrated Security=true"))
            {
                cn.Open();
            }
        }
    }
}
