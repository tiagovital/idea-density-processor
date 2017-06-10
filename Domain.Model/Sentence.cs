﻿namespace Domain.Model
{
    using System.Collections.Generic;

    public class Sentence
    {
        public Sentence()
        {
            this.Words = new List<Word>();
        }

        public IList<Word> Words { get; set; }
    }
}