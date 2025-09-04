using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using PROJETOMVC.Model;
using PROJETOMVC.Utilidade;

namespace PROJETOMVC
{
    public class PROJETOMVC
    {
        static async Task Main(string[] args)
        {
            try
            {
                using (StreamReader reader = new StreamReader(@"C:\Users\user\source\repos\PROJETOMVC\settings.json"))
                {
                    string json = reader.ReadToEnd();
                    Config? config = JsonConvert.DeserializeObject<Config>(json);

                    Constant.ConnectionFilePath = config?.ConfigPath ?? "";

                    using (OracleConnection conn = Connection.GetConnection())
                    {
                        DAL.VerificarAnimaisComPet(conn);

                        BLL.Consulta(conn);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                if (e.InnerException != null)
                {
                    Console.WriteLine("Detalhes: " + e.InnerException.Message);
                }
            }
        }
    }
}
