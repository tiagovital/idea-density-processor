using System;
using System.Collections.Generic;

namespace Application.Dto
{
    public class WordDto
    {
        public string Value { get; set; }

        public string Class { get; set; }

        public IEnumerable<string> AlternativeClasses { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }
    }
}