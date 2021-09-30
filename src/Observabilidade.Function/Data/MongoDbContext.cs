using MongoDB.Driver;
using Observabilidade.Function.Model;
using System;

namespace Observabilidade.Function.Data
{
    public class MongoDbContext : IDisposable
    {
        private readonly IMongoDatabase _database;
        private readonly string _collectionLogs;
        public IMongoCollection<Log> Logs => _database.GetCollection<Log>(_collectionLogs);

        public MongoDbContext(string connectionString, string db)
        {
            _database = new MongoClient(connectionString).GetDatabase(db);
            _collectionLogs = Environment.GetEnvironmentVariable("ConnectionStrings:CollectionName");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

        }
    }
}
