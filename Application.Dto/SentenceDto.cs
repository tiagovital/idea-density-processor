namespace Application.Dto
{
    using System.Collections.Generic;

    public class SentenceDto
    {
        public IEnumerable<WordDto> Words { get; set; }
    }
}