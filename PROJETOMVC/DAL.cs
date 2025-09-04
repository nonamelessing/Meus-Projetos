using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace PROJETOMVC
{
    public class DAL
    {
        public static void Consulta(OracleConnection conn)
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            using (OracleCommand cmd = new OracleCommand())
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"
                    INSERT INTO ANIMALPET (NOME, TIPO)
                    SELECT 
                        NOME, 
                        REPLACE(TIPO, ' (PET)', '') AS TIPO
                    FROM 
                        ANIMAL
                    WHERE 
                        TIPO LIKE '%(PET)%'";

                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} registros inseridos com sucesso.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro ao executar a consulta: " + e.Message);
                    if (e.InnerException != null)
                    {
                        Console.WriteLine("Detalhes: " + e.InnerException.Message);
                    }
                    throw new Exception("Erro ao executar a consulta.", e);
                }
            }
        }

        public static void VerificarAnimaisComPet(OracleConnection conn)
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            using (OracleCommand cmd = new OracleCommand())
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM ANIMAL WHERE TIPO LIKE '%(PET)%'";

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("Nenhum registro encontrado com TIPO contendo '(PET)'.");
                        }
                        else
                        {
                            int count = 0;
                            while (reader.Read())
                            {
                                string nome = reader["NOME"].ToString();
                                string tipo = reader["TIPO"].ToString();
                                Console.WriteLine($"Nome: {nome}, Tipo: {tipo}");
                                count++;
                            }
                            Console.WriteLine($"{count} registros encontrados com TIPO contendo '(PET)'.");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro ao executar a consulta: " + e.Message);
                    if (e.InnerException != null)
                    {
                        Console.WriteLine("Detalhes: " + e.InnerException.Message);
                    }
                    throw new Exception("Erro ao executar a consulta.", e);
                }
            }
        }


    }
}
