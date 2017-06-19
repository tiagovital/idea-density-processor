namespace Data.Gateway
{
    public interface IIltecAdapter
    {
        IltecResponse Adapt(string htmlResult);
    }
}