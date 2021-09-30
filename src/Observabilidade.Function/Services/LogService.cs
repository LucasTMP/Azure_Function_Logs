using Observabilidade.Function.Data;
using Observabilidade.Function.Data.Interfaces;
using Observabilidade.Function.Model;
using Observabilidade.Function.Services.Interfaces;
using System.Threading.Tasks;

namespace Observabilidade.Function.Services
{
    internal class LogService : ILogService
    {
        private readonly ElasticSearch _elasticSearch;
        private readonly ILogRepository _repository;

        public LogService(ILogRepository repository, ElasticSearch elasticSearch)
        {
            _elasticSearch = elasticSearch;
            _repository = repository;
        }

        public async Task AddLog(Log log)
        {
            await _repository.Add(log);
            var response = await _elasticSearch.Client.IndexAsync(log, idx => idx.Index(_elasticSearch.IndexNameDefault));
            if (!response.IsValid) throw response.ApiCall.OriginalException;
        }
    }
}
