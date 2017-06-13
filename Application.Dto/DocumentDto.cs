using System;

namespace Application.Dto
{
    public class DocumentDto
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string Name { get; set; }
    }
}