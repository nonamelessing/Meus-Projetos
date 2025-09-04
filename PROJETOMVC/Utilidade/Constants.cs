using System;
using System.Xml;

namespace PROJETOMVC.Utilidade
{
    public class Constant
    {
        public static string? Connection { get; set; }

        public static string ConnectionFilePath
        {
            set
            {
                try
                {
                    XmlDocument xml = new();
                    xml.Load(value);
                    XmlNode? node = xml.DocumentElement?.SelectSingleNode("connectionStrings/add[@name='ANIMALDB']");
                    Connection = node?.Attributes?["value"]?.Value;

                    if (string.IsNullOrEmpty(Connection))
                    {
                        throw new Exception("A string de conexão não foi encontrada ou está vazia.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao carregar a string de conexão do arquivo de configuração.", ex);
                }
            }
        }
    }
}
