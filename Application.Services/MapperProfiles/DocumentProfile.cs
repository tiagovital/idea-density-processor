namespace Application.Services.MapperProfiles
{
    using System.Linq;
    using AutoMapper;
    using Domain.Model;
    using Dto;

    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            this.CreateMap<Document, DocumentDto>();

            this.CreateMap<Sentence, SentenceDto>();

            this.CreateMap<Word, WordDto>()
                .ForMember(dest => dest.Class, opts => opts.ResolveUsing(src => src.Class.ToString()))
                .ForMember(dest => dest.AlternativeClasses,
                        opts => opts.ResolveUsing(
                            src => src.AlternativeClasses.Select(i => i.ToString())));
        }
    }
}