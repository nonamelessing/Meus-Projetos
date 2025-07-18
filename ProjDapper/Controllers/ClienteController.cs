using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using ProjDapper.Models;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ProjDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly string _connectionString;

        public ClienteController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleDb");
        }

        private IDbConnection conexao => new OracleConnection(_connectionString);

        [HttpGet]
        public async Task<IActionResult> buscarClientes()
        {
            using var banco = conexao;
            var usuarios = await banco.QueryAsync<Cliente>("SELECT ID, NOME, EMAIL, CPF FROM CLIENTE");
            /*EXECUTA A QUERY E RETORNA A CONSULTA*/

            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> inserirCliente([FromBody] Cliente client)
        {
            if (client == null || string.IsNullOrWhiteSpace(client.Email) || string.IsNullOrWhiteSpace(client.Nome))
                return BadRequest("Usuário inválido");

            using var banco = conexao;
            string insert = "INSERT INTO CLIENTE (EMAIL, NOME, CPF) VALUES (:Email, :Nome, :Cpf)";
            await banco.ExecuteAsync(insert, client);
            /*EXECUTA A QUERY DE INSERT A PARTIR DO MAPEAMENTO DOS DADOS DA INSTANCIA DE CLIENTE*/

            return Ok("Cliente criado com sucesso");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> alterarUsuario(int id, [FromBody] Cliente client)
        {
            if (client == null || string.IsNullOrWhiteSpace(client.Email) || string.IsNullOrWhiteSpace(client.Nome))
                return BadRequest("Cliente inválido");

            using var banco = conexao;
            var clientesExistentes = await banco.QueryFirstOrDefaultAsync<Cliente>("SELECT ID FROM CLIENTE WHERE ID = :id", new {Id = id});

            if (clientesExistentes == null)
                return NotFound("Cliente não encontrado");

            string update = "UPDATE CLIENTE SET EMAIL = :Email, NOME = :Nome, CPF = :Cpf WHERE ID = :Id";
            var linhasAfetadas = await banco.ExecuteAsync(update, new { client.Email, client.Nome, client.Cpf, Id = id});
            /*RETORNA AS LINHAS AFETADAS, ONDE OS PARAMETROS SÃO A QUERY QUE SERÁ EXECUTADA E O MAPEAMENTO DOS DADOS A SEREM INSERIDOS*/

            if (linhasAfetadas == 0)
                return StatusCode(500, "Falha ao atualizar o cliente");
            /*CASO NÃO HAJA NENHUMA LINHA AFETADA, OU SEJA, QUE CONTENHA AS INFORMAÇÕES INSERIDAS, RETORNA STATUS 500*/

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deletarCliente(int id, Cliente client)
        {
            if (client == null || string.IsNullOrWhiteSpace(client.Email) || string.IsNullOrWhiteSpace(client.Nome))
                return BadRequest("Cliente inválido");
            var banco = conexao;

            var clientesExistentes = await banco.QueryFirstOrDefaultAsync<Cliente>("SELECT ID FROM CLIENTE WHERE ID = :id", new { Id = id });
            /*SELECIONA A PRIMEIRA OCORRENCIA DO ID INSERIDO*/

            if (clientesExistentes == null)
                return NotFound("Cliente não encontrado");

            string delete = "DELETE FROM CLIENTE WHERE ID = :Id";
            var linhasAfetadas = await banco.ExecuteAsync(delete, new { client.Email, client.Nome, client.Cpf, Id = id });
            /*EXECUTA A QUERY A PARTIR DO MAPEAMENTO DE CLIENTE E RETORNA AS LINHAS QUE FORAM AFETADAS*/

            if (linhasAfetadas == 0)
                return StatusCode(500, "Falha ao deletar o cliente");

            return NoContent();

        }
    }
}
