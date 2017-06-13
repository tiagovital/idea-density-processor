namespace Domain.Model
{
    using System;
    using System.Collections.Generic;

    public class Document
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string OriginalText { get; set; }

        public IList<Sentence> Sentences { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public IList<string> Tags { get; set; }
    }
}