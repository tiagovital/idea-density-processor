namespace Data.Gateway
{
    public interface IIltecAdapterFactory
    {
        IIltecAdapter From(string htmlResult);
    }
}