using TesteAPI2.Models;

namespace TesteAPI2.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {

        Task<List<UsuarioModel>> buscarTodosUsuarios();
        Task<UsuarioModel> buscarPorId(int id);
        Task<UsuarioModel> adicionarUsuario(UsuarioModel usuario);
        Task<UsuarioModel> atualizarUsuario(UsuarioModel usuario, int id);
        Task<bool> Apagar(int id);
    }
}
