using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteAPI.Models;

namespace TesteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        List<UsuarioModel> usuarios = new List<UsuarioModel>();

        [HttpPost("Adicionar Usuario")]
        public ActionResult<List<UsuarioModel>> Post([FromBody] UsuarioModel usuario)
        {
            if (!usuarios.Contains(usuario))
            {
                usuarios.Add(usuario);
                usuario.AddUsuario(usuario);
            }
            return usuarios;
        }
    }
}