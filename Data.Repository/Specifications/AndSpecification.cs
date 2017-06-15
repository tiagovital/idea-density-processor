namespace Data.Repository.Specifications
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> leftSpec;
        private readonly ISpecification<T> rightSpec;

        public AndSpecification(ISpecification<T> leftSpec, ISpecification<T> rightSpec)
        {
            this.leftSpec = leftSpec;
            this.rightSpec = rightSpec;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return this.leftSpec.IsSatisfiedBy(o)
                && this.rightSpec.IsSatisfiedBy(o);
        }
    }
}