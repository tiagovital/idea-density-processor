namespace Data.Gateway
{
    using System.Collections.Generic;
    using Domain.Model;

    public class IltecResponse
    {
        public bool HasError { get; set; }

        public WordClass Class { get; set; }

        public IEnumerable<WordClass> AlternativeClasses { get; set; }
    }
}