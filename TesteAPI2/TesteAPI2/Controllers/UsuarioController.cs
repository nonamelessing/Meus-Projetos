﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TesteAPI2.Models;
using TesteAPI2.Repositorios.Interfaces;

namespace TesteAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            this._usuarioRepositorio = usuarioRepositorio;
        }

        List<UsuarioModel> users = new List<UsuarioModel>();

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> buscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.buscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>>buscarPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.buscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.adicionarUsuario(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> atualizarUsuario([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRepositorio.atualizarUsuario(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            bool apagado = await _usuarioRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}