namespace Data.Gateway
{
    using System.Linq;
    using Data.Gateway.Iltec;
    using HtmlAgilityPack;

    public class IltecAdapterFactory : IIltecAdapterFactory
    {
        public IIltecAdapter From(HtmlDocument htmlDoc)
        {
            var pageTitleEl = htmlDoc.DocumentNode.Descendants("title").Single();
            var title = pageTitleEl.InnerText;

            const string multiPageTitle = "Portal da Língua Portuguesa";

            if (title == multiPageTitle)
            {
                return new IltectMultipleTermsPageAdapter();
            }

            return new IltecSingleTermPageAdapter();
        }
    }
}