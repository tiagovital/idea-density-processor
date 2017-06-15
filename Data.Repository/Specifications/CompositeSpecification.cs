namespace Data.Repository.Specifications
{
    public abstract class CompositeSpecification<TEntity> : ISpecification<TEntity>
    {
        public abstract bool IsSatisfiedBy(TEntity o);

        public ISpecification<TEntity> And(ISpecification<TEntity> specification)
        {
            return new AndSpecification<TEntity>(this, specification);
        }

        public ISpecification<TEntity> Not(ISpecification<TEntity> specification)
        {
            return new NotSpecification<TEntity>(specification);
        }

        public ISpecification<TEntity> Or(ISpecification<TEntity> specification)
        {
            return new OrSpecification<TEntity>(this, specification);
        }
    }
}