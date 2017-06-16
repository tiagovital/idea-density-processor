namespace Data.Gateway
{
    using Data.Gateway.Iltec;

    public class IltecAdapterFactory : IIltecAdapterFactory
    {
        public IIltecAdapter From(string htmlResult)
        {
            return new IltectMultipleTermsPageAdapter();
        }
    }
}