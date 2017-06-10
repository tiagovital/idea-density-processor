namespace Domain.Model
{
    using System.Collections.Generic;

    public class Word
    {
        public Word()
        {
            this.AlternativeClasses = new List<WordClass>();
        }

        public string Value { get; set; }

        public WordClass Class { get; set; }

        public IList<WordClass> AlternativeClasses { get; set; }
    }
}