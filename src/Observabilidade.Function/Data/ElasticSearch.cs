using Nest;
using System;

namespace Observabilidade.Function.Data
{
    public class ElasticSearch
    {

        public readonly string IndexNameDefault;
        private readonly string _elasticUrl;
        private readonly ElasticClient _elasticClient;
        public ElasticClient Client => _elasticClient;

        public ElasticSearch(string indexName, string elasticUrl)
        {
            _elasticUrl = elasticUrl;
            _elasticClient = CriarConexaoElasticsearch();
            IndexNameDefault = indexName;
        }

        private ElasticClient CriarConexaoElasticsearch()
        {
            var node = new Uri(_elasticUrl);
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            return client;
        }
    }
}
