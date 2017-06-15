namespace Data.Repository.Specifications
{
    public interface ISpecification<TEntity>
    {
        bool IsSatisfiedBy(TEntity o);

        ISpecification<TEntity> And(ISpecification<TEntity> specification);

        ISpecification<TEntity> Or(ISpecification<TEntity> specification);

        ISpecification<TEntity> Not(ISpecification<TEntity> specification);
    }
}