using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Repository
{
    public class Repository<TDocument> : IRepository<TDocument>
    {
        public IMongoDatabase Database { get; set; }
        //public IMongoCollection<TDocument> Collection { get; set; }
        public Repository(IPawSettings settings)
        {
            var cliente = new MongoClient(settings.ConnectionString);
            Database = cliente.GetDatabase(settings.Database);
            //Collection = Database.GetCollection<TDocument>(settings.Collection);
        }

        public async Task<IEnumerable<TDocument>> GetAllAsync(string collectionName)
        {
            var collection = GetCollection<TDocument>(collectionName);
            return await collection.Find(x => true).ToListAsync();
        }
        public async Task<TDocument> GetBySmtAsync(FilterDefinition<TDocument> filter, string collectionName)
        {
            return await GetCollection<TDocument>(collectionName).Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> document, string collectionName)
        {
            var updated = await GetCollection<TDocument>(collectionName).UpdateOneAsync(filter, document);
        }

        public async Task CreateAsync(TDocument document, string collectionName)
        {

            await GetCollection<TDocument>(collectionName).InsertOneAsync(document);
 
             
        }

        public async Task<bool> DeleteAsync(FilterDefinition<TDocument> filter, string collectionName)

        { 
           var deleted =  await GetCollection<TDocument>(collectionName).DeleteOneAsync(filter);

            return deleted.DeletedCount > 0; 
        }

        public async Task<bool> ExistsAsync(FilterDefinition<TDocument> filter, string collectionName)
        {
            long changes = await GetCollection<TDocument>(collectionName).CountDocumentsAsync(filter);
            return changes > 0;
        }

        private IMongoCollection<TDocument> GetCollection<T>(string collectionName)
        {
            return Database.GetCollection<TDocument>(collectionName);
        }


    }
}