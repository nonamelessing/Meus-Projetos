using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TesteAPI.Models
{
    public class UsuarioModel
    {
        private string texto = "Textos/usuarios.txt";
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int Idade { get; set; }

        public UsuarioModel(string nome, string descricao, int idade)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.Idade = idade;
        }

        public UsuarioModel() { }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public void AddUsuario(UsuarioModel usuario)
        {
                using (StreamWriter sw = File.AppendText(texto))
                {
                    sw.WriteLine(usuario.ToJson());
                }


                System.Diagnostics.Process.Start("notepad.exe", texto);
        }
    }
}
