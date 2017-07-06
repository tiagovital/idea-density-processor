namespace Domain.Model
{
    using System;
    using System.Collections.Generic;

    public class Word : IEntity
    {
        private DateTime _createdAt;

        public Word()
        {
            this.AlternativeClasses = new List<WordClass>();
        }

        public string Value { get; set; }

        public WordClass Class { get; set; }

        public IList<WordClass> AlternativeClasses { get; set; }

        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }
    }
}