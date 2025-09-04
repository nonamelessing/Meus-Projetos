using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using PROJETOMVC.Utilidade;

namespace PROJETOMVC
{
    public class Connection
    {
        public static OracleConnection GetConnection()
        {
            return new OracleConnection(Constant.Connection);
        }
    }
}
