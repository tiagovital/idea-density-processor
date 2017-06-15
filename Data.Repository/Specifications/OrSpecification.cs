namespace Data.Repository.Specifications
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> leftSpec;
        private readonly ISpecification<T> rightSpec;

        public OrSpecification(ISpecification<T> leftSpec, ISpecification<T> rightSpec)
        {
            this.leftSpec = leftSpec;
            this.rightSpec = rightSpec;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return this.leftSpec.IsSatisfiedBy(o)
                || this.rightSpec.IsSatisfiedBy(o);
        }
    }
}