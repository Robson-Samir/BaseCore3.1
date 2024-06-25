using Base.Domain.Entities.Domain;
using Base.Domain.Interfaces.Repositories;
using Base.Infrastructure.CrossCutting.Utilities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Net;

namespace Base.Infrastructure.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        IConfiguration config;
        private IMongoDatabase mongoDatabase;

        public PedidoRepository(IConfiguration _config)            
        {
            config = _config;
        }


        public bool CadastroPedido(Pedido pedido)
        {
            var connMongo = MontaConMongoDb();

            if (connMongo == null)
                throw new PortalHttpException(HttpStatusCode.NotImplemented, "Não configurado servidor mongo");

            var col = mongoDatabase.GetCollection<Pedido>("Pedido");
            col.InsertOne(pedido);
            return true;
        }

        public bool CadastroUsuario(Usuario usuario)
        {
            var connMongo = MontaConMongoDb();

            if (connMongo == null)
                throw new PortalHttpException(HttpStatusCode.NotImplemented, "Não configurado servidor mongo");

            //Aqui um manipulação de serviço externo para preencher dados dos CEP
            var col = mongoDatabase.GetCollection<Usuario>("Usuario");
            col.InsertOne(usuario);
            return true;
        }

        MongoClient MontaConMongoDb()
        {
            MongoClientSettings configuracaoMongo = MongoClientSettings.FromUrl(new MongoUrl($"mongodb://{config["mongo:User"]}:{config["mongo:Senha"]}@{config["mongo:Server"]}"));

            if (Convert.ToBoolean(config["mongo:Ssl"]))
                configuracaoMongo.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls11 | System.Security.Authentication.SslProtocols.Tls12 | System.Security.Authentication.SslProtocols.Tls13
                    | System.Security.Authentication.SslProtocols.Tls
                };

            var mongoClient = new MongoClient(configuracaoMongo);
            mongoDatabase = mongoClient.GetDatabase(config["mongo:DataBase"]);
            return mongoClient;
        }
    }
}
