﻿namespace Application.Dto
{
    using System;
    using System.Collections.Generic;

    public class DocumentDto
    {
        public Guid Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public IEnumerable<SentenceDto> Sentences { get; set; }

        public float LexicalVariety { get; set; }

        public float IdeaDensity { get; set; }

        public float WordsPerSentence { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }
    }
}