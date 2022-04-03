using API.Usuarios.Data.Configurations;
using API.Usuarios.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Mogo DB auxilia no acesso ais dados, ao banco de dados

namespace API.Usuarios.Data.Repositories
{
    //Implementação
    public class UsuariosRepository : IUsuariosRepository

    {
        //Objeto que recebera a collection
        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuariosRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            //lá no mongo pega-se a coleção "usuarios" / Configuração dos usuarios no mongo
            //Faço a inicialização do objeto que receberá a colletcion
            _usuarios = database.GetCollection<Usuario>("usuarios");
        }

        
        
        
        public void Adicionar(Usuario usuario)
        {
            _usuarios.InsertOne(usuario);

        }



        public void Atualizar(string id, Usuario usuarioAtualizado)
        {
            //substitui um objeto pelo outro
            _usuarios.ReplaceOne(usuario => usuario.Id == id, usuarioAtualizado);
        }



        public IEnumerable<Usuario> Buscar()
        {
            //Busca os usuarios no banco

            return _usuarios.Find(usuario => true).ToList();
            
        }



        public Usuario Buscar(string id)
        {
            //Busco um usuario por consulta através de id
            return _usuarios.Find(usuario => usuario.Id == id).FirstOrDefault();
        }

        public void Remover(string id)
        {
            _usuarios.DeleteOne(usuario => usuario.Id == id);
        }

    }
}
