namespace Data.Gateway.Iltec
{
    using System.Linq;
    using Adapters;
    using HtmlAgilityPack;

    /// <summary>
    /// Adapter for pages such as
    /// </summary>
    internal class IltectMultipleTermsPageAdapter : IIltecAdapter
    {
        public IltecResponse Adapt(HtmlDocument htmlDoc)
        {
            var wordClasses = htmlDoc.DocumentNode
                                .Descendants("td")
                                .Where(t => t.Attributes.Any(att => att.Name == "label"))
                                .Select(el => WordClassFactory.Create(el.FirstChild.InnerText));

            return new IltecResponse
            {
                HasError = !wordClasses.Any(),
                Class = wordClasses.FirstOrDefault(),
                AlternativeClasses = wordClasses.Skip(1).ToList()
            };
        }
    }
}