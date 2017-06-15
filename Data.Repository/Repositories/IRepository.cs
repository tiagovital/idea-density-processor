namespace Data.Repository.Specifications
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<TEntity>
    {
        Task<TEntity> Get(Guid id);

        Task<TEntity> Find(ISpecification<TEntity> specification);

        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> FindAll();

        Task<TEntity> Save();

        Task Delete(Guid id);
    }
}