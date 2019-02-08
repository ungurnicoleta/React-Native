using System;
using System.Collections.Generic;
using System.Text;

namespace AccesaStart.DAL
{
    public static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                //return "Data Source=.;Initial Catalog=AccesaStart;Integrated Security=True;";
                return
                    "Server=tcp:accesastart.database.windows.net,1433;Initial Catalog=AccesaStart;Persist Security Info=False;User ID=AccesaStart;Password=Acc3s@Start;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }
        }
    }
}
