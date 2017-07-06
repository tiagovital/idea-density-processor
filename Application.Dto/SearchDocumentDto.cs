using System;

namespace Presentation.API.Models
{
    public class SearchDocumentModel
    {
        public string DocumentName { get; set; }

        public string Author { get; set; }

        public DateTime DocumentCreatedAt { get; set; }
    }
}