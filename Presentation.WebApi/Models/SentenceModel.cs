namespace Presentation.API.Models
{
    using System.Collections.Generic;

    public class SentenceModel
    {
        public IEnumerable<WordModel> Words { get; set; }
    }
}