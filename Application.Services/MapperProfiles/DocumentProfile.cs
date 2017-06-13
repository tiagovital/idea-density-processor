namespace Application.Services.MapperProfiles
{
    using AutoMapper;
    using Domain.Model;
    using Dto;

    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<Document, DocumentDto>();
            CreateMap<DocumentDto, Document>()
                .ForMember(dest => dest.Sentences, opts => opts.Ignore())
                .ForMember(dest => dest.Tags, opts => opts.Ignore());
        }
    }
}