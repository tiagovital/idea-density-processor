namespace Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Repository.Specifications;
    using Domain.Model;
    using Extensions;
    using MongoDB.Driver;

    public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        private readonly IMongoClient client;

        public MongoRepository(IMongoClient client)
        {
            this.client = client;
        }

        public async Task Delete(Guid id)
        {
            await this.client
                .GetDatabase("IDP")
                .GetCollectionFor<TEntity>()
                .DeleteOneAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<TEntity> Find(ISpecification<TEntity> specification)
        {
            var filter = new FilterDefinitionBuilder<TEntity>().Where(m => specification.IsSatisfiedBy(m));

            return await this.client
                .GetDatabase("IDP")
                .GetCollectionFor<TEntity>()
                .Find(filter)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }

        public Task<IEnumerable<TEntity>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> FindAll(ISpecification<TEntity> specification, int page, int pageSize)
        {
            var filter = new FilterDefinitionBuilder<TEntity>().Where(m => specification.IsSatisfiedBy(m));

            return await this.client
                .GetDatabase("IDP")
                .GetCollectionFor<TEntity>()
                .Find(filter)
                .Skip(page - 1)
                .Limit(pageSize)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await this.client
                .GetDatabase("IDP")
                .GetCollectionFor<TEntity>()
                .Find(x => x.Id == id)
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAll(int page, int pageSize)
        {
            return await this.client
                .GetDatabase("IDP")
                .GetCollectionFor<TEntity>()
                .Find(FilterDefinition<TEntity>.Empty)
                .Skip(page - 1)
                .Limit(pageSize)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task Save(TEntity entity)
        {
            var opts = new UpdateOptions { IsUpsert = true };

            await this.client
                .GetDatabase("IDP")
                .GetCollectionFor<TEntity>()
                .ReplaceOneAsync(x => x.Id == entity.Id, entity, opts);
        }
    }
}