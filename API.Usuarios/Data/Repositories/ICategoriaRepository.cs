using API.Usuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Usuarios.Data.Repositories
{
    public interface ICategoriaRepository
    {
        void Adicionar(Categoria categoria);

        void Atualizar(string id, Categoria categoriaAtualizada);

        IEnumerable<Categoria> Buscar();

        Categoria Buscar(string id);

        void Remover(string id);
    }
}
