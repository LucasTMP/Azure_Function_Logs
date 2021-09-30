using Observabilidade.Function.Data.Interfaces;
using Observabilidade.Function.Model;
using System.Threading.Tasks;

namespace Observabilidade.Function.Data
{
    internal class LogRepository : ILogRepository
    {
        private readonly MongoDbContext _context;

        public LogRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task Add(Log log) => await _context.Logs.InsertOneAsync(log);
    }
}
