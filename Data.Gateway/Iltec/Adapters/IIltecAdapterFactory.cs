using HtmlAgilityPack;

namespace Data.Gateway
{
    public interface IIltecAdapterFactory
    {
        IIltecAdapter From(HtmlDocument htmlDoc);
    }
}