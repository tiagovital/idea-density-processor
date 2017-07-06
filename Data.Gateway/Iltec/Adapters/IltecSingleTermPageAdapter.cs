namespace Data.Gateway.Iltec
{
    using System.Linq;
    using Adapters;
    using Domain.Model;
    using HtmlAgilityPack;

    /// <summary> Adapter for pages such as
    /// http://www.portaldalinguaportuguesa.org/index.php?action=lemma&lemma=123120 </summary>
    internal class IltecSingleTermPageAdapter : IIltecAdapter
    {
        public IltecResponse Adapt(HtmlAgilityPack.HtmlDocument htmlDoc)
        {
            var wordClasses = htmlDoc.DocumentNode
                                .Descendants("h1")
                                .Where(t => t.ParentNode.Id == "maintext")
                                .Select(GetWordClass)
                                .ToList();

            return new IltecResponse
            {
                HasError = !wordClasses.Any(),
                Class = wordClasses.FirstOrDefault(),
                AlternativeClasses = wordClasses.Skip(1).ToList()
            };
        }

        private WordClass GetWordClass(HtmlNode el)
        {
            var wordClassValue = el.InnerText.Split('-').Last().Trim();
            return WordClassFactory.Create(wordClassValue);
        }
    }
}