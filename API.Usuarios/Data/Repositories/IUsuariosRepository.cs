using API.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Usuarios.Data.Repositories
{
    //A abstriaçã - Especificação do metodo do repositorio
    public interface IUsuariosRepository
    {
        void Adicionar(Usuario usuario);

        void Atualizar(string id, Usuario usuarioAtualizado);

        IEnumerable<Usuario> Buscar();

        Usuario Buscar(string id);

        void Remover(string id);
    }
}
