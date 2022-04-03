using API.Usuarios.Data.Repositories;
using API.Usuarios.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace API.Usuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase

    {
        private IUsuariosRepository _usuariosRepository;
        //Faz parte da injeção de dependência
        //Classe que usa a mesma interface de usuarios


        public UsuariosController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;

        }

        // GET: api/usuarios
        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _usuariosRepository.Buscar();


            return Ok(usuarios);
        }

        // GET api/usuarios/{id}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var usuario = _usuariosRepository.Buscar(id);
            
            if (usuario == null)
            {
                return NotFound("Usuario não encontrado");
            }
                       
            return Ok(usuario);
                        
        }

        // POST api/usuarios
        //1h15m44s
        [HttpPost]
        public IActionResult Post([FromBody] Usuario novoUsuario)
        {
            _usuariosRepository.Adicionar(novoUsuario);
            return Created("", novoUsuario);
        }

        // PUT api/usuarios/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Usuario usuarioAtualizado)
        {
           var usuario =  _usuariosRepository.Buscar(id);

            if (usuario == null)
            {
                return NotFound("Usuario não encontrado");
            }


            usuario.AtualizarUsuario(usuarioAtualizado.Nome, usuarioAtualizado.Email, usuarioAtualizado.Senha);

            _usuariosRepository.Atualizar(id, usuario);

            return Ok(usuario);
        
        }

        // DELETE api/usuarios/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var usuario = _usuariosRepository.Buscar(id);

            if (usuario == null)
            {
                return NotFound("Usuario não encontrado");
            }

            _usuariosRepository.Remover(id);

            return NoContent();

        }
    }
}
