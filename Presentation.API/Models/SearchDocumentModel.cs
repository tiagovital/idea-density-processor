using System;

namespace Presentation.API.Models
{
    public class SearchDocumentModel
    {
        public string DocumentName { get; set; }

        public DateTime DocumentCreatedAt { get; set; }

        public string DocumentCreatedBy { get; set; }
    }
}