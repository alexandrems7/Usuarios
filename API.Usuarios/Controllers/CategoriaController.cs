using API.Usuarios.Data.Repositories;
using API.Usuarios.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Usuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase 
    {
        
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUsuariosRepository _usuariosRepository;
        //Faz parte da injeção de dependência
        //Classe que usa a mesma interface de categorias

        
        public CategoriaController(ICategoriaRepository categoriaRepository, IUsuariosRepository usuariosRepository)
        {
            _categoriaRepository = categoriaRepository;
            _usuariosRepository = usuariosRepository;

        }

        // GET: api/usuarios
        [HttpGet]
        public IActionResult Get()
        {
           
            var categoria = _categoriaRepository.Buscar();
            return Ok(categoria);
        }

        // GET api/usuarios/{id}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var categoria = _categoriaRepository.Buscar(id);

            if (categoria == null)
            {
                return NotFound("Categoria não encontrada");
            }

            return Ok(categoria);

        }

        // POST api/usuarios
        //1h15m44s
        [HttpPost]
        public IActionResult Post([FromBody] Categoria novaCategoria)
        {
            

            if(novaCategoria.Titulo == "string")
            {
                novaCategoria.Titulo = "usuario comum";
                novaCategoria.Descricao = "visualizar";
            }

            




            if (novaCategoria.usuarioId == "string")
            {
                return NotFound("Insira um usuário válido");
            } 
            else
            {
                _categoriaRepository.Adicionar(novaCategoria);
                return Created("", novaCategoria);

            }


            
        }

        // PUT api/usuarios/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Categoria categoriaAtualizada)
        {
            var categoria = _categoriaRepository.Buscar(id);

            if (categoria == null)
            {
                return NotFound("Usuario não encontrado");
            }


            categoria.AtualizarCategoria(categoriaAtualizada.Titulo, categoriaAtualizada.Descricao);

            _categoriaRepository.Atualizar(id, categoria);

            return Ok(categoria);

        }

        [AutoValidateAntiforgeryToken]
        // DELETE api/usuarios/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var categoria = _categoriaRepository.Buscar(id);

            if (categoria == null)
            {
                return NotFound("Categoria não encontrada");
            }

            _categoriaRepository.Remover(id);

            return NoContent();

        }
    }
}

