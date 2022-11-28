using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repository
{
      public interface IRepository<TDocument>
      {
          Task<IEnumerable<TDocument>> GetAllAsync(string collectionName);


          Task<TDocument> GetBySmtAsync(FilterDefinition<TDocument> filter, string collectionName);

          Task UpdateAsync(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> document, string collectionName);


          Task CreateAsync(TDocument document, string collectionName);


          Task<bool> DeleteAsync(FilterDefinition<TDocument> filter, string collectionName);

          Task<bool> ExistsAsync(FilterDefinition<TDocument> filter, string collectionName);

       }
}
