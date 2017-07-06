namespace Data.Gateway
{
    public interface IIltecAdapter
    {
        IltecResponse Adapt(HtmlAgilityPack.HtmlDocument htmlDocument);
    }
}