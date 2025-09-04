using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using PROJETOMVC;

namespace PROJETOMVC
{
    public class BLL
    {
        public static void Consulta(OracleConnection con)
        {
            try
            {
                DAL.Consulta(con);
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    Console.WriteLine("Detalhes: " + e.InnerException.Message);
                }
                throw new Exception("Erro ao consultar os dados.", e);
            }
        }
    }
}
