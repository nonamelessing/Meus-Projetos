using Microsoft.EntityFrameworkCore;
using TesteAPI2.Data;
using TesteAPI2.Models;
using TesteAPI2.Repositorios.Interfaces;

namespace TesteAPI2.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly UsuariosDbContext _DbContext;

        public UsuarioRepositorio(UsuariosDbContext userDB)
        {
            _DbContext = userDB;
        }

        public async Task<UsuarioModel> buscarPorId(int id)
        {
            return await _DbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> buscarTodosUsuarios()
        {
            return await _DbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> adicionarUsuario(UsuarioModel usuario)
        {
            await _DbContext.Usuarios.AddAsync(usuario);
            await _DbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> atualizarUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await buscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID {id} não foi encontrado");
            }
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _DbContext.Usuarios.Update(usuarioPorId);
            await _DbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await buscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID {id} não foi encontrado");
            }
            _DbContext.Usuarios.Remove(usuarioPorId);
            await _DbContext.SaveChangesAsync();

            return true;    
        }
    }
}
