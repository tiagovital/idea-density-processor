using System;

namespace Application.Dto
{
    public class DocumentDto
    {
        public Guid Id { get; set; }

        public string OriginalText { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string Name { get; set; }
    }
}