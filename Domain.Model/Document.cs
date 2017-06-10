namespace Domain.Model
{
    using System;
    using System.Collections.Generic;

    public class Document
    {
        public Document(string text)
        {
            this.Id = Guid.NewGuid();
            this.Sentences = new List<Sentence>();
            this.Tags = new List<string>();
        }

        public Guid Id { get; set; }

        public string OriginalText { get; set; }

        public IList<Sentence> Sentences { get; set; }

        public DateTime CreatedAt { get; set; }

        public IList<string> Tags { get; set; }
    }
}