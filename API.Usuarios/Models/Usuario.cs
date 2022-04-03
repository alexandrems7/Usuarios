using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Usuarios.Models
{
    public class Usuario
    {
       

        public Usuario(string nome, string email, string senha)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Email = email;
            Senha = senha;
        }
        [Display(Name = "#")]
        public string Id { get; private set; }

        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o email do usuário!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string Senha { get; set; }

        public void AtualizarUsuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
        List<Usuario> Usuarios { get; set; }
    

    }
}

//12m32s