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
            this.CreateMap<DocumentDto, Document>();

            this.CreateMap<Sentence, SentenceDto>();
            this.CreateMap<SentenceDto, Sentence>()
                .ForMember(dest => dest.LexicalVariety, opts => opts.Ignore())
                .ForMember(dest => dest.IdeaDensity, opts => opts.Ignore());

            this.CreateMap<Word, WordDto>()
                .ForMember(dest => dest.Class, opts => opts.ResolveUsing(src => src.Class.ToString()))
                .ForMember(dest => dest.AlternativeClasses,
                        opts => opts.ResolveUsing(
                            src => src.AlternativeClasses.Select(i => i.ToString())));

            this.CreateMap<WordDto, Word>()
                .ForMember(dest => dest.Id, opts => opts.ResolveUsing(src => src.Value))
                .ForMember(dest => dest.Class, opts => opts.Ignore())
                .ForMember(dest => dest.AlternativeClasses, opts => opts.Ignore());
        }
    }
}