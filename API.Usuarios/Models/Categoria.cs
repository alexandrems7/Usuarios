using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Usuarios.Models
{
    public class Categoria
    {
        public Categoria(string titulo, string descricao)
        {
            Id = Guid.NewGuid().ToString();
            Titulo = titulo;
            Descricao = descricao;
        }

        [Display(Name = "#")]
        public string Id { get; private set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public void AtualizarCategoria(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
        }
        [Required(ErrorMessage = "Informe um id de usuário")]
        public string usuarioId { get; set; } //Me dá acesso a esta coluna específica






    }
}
