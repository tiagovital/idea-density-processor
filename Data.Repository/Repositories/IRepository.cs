namespace Data.Repository.Specifications
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<TEntity>
    {
        Task<TEntity> Get(string id);

        Task<TEntity> Find(ISpecification<TEntity> specification);

        Task<IEnumerable<TEntity>> GetAll(int page, int pageSize);

        Task<IEnumerable<TEntity>> FindAll(ISpecification<TEntity> specification, int page, int pageSize);

        Task<TEntity> Save(TEntity entity);

        Task Delete(string id);
    }
}