using System.Collections.Generic;

namespace Presentation.API.Models
{
    public class WordModel
    {
        public string Value { get; set; }

        public string Class { get; set; }

        public IEnumerable<string> AlternativeClasses { get; set; }
    }
}