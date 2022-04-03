using API.Usuarios.Data.Configurations;
using API.Usuarios.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Usuarios.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        //Objeto que recebera a collection
        private readonly IMongoCollection<Categoria> _categoria;

        public CategoriaRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            //lá no mongo pega-se a coleção "usuarios" / Configuração dos usuarios no mongo
            //Faço a inicialização do objeto que receberá a colletcion
            _categoria = database.GetCollection<Categoria>("categoria");
        }

        public void Adicionar(Categoria categoria)
        {
            _categoria.InsertOne(categoria);

        }

        public void Atualizar(string id, Categoria categoriaAtualizada)
        {
            //substitui um objeto pelo outro
            _categoria.ReplaceOne(categoria => categoria.Id == id, categoriaAtualizada);
        }

        public IEnumerable<Categoria> Buscar()
        {
            //Busca os usuarios no banco
            return _categoria.Find(categoria => true).ToList();
        }

        public Categoria Buscar(string id)
        {
            //Busco um usuario por consulta através de id
            return _categoria.Find(categoria => categoria.Id == id).FirstOrDefault();
        }

        public void Remover(string id)
        {
            _categoria.DeleteOne(categoria => categoria.Id == id);
        }
    }
}
