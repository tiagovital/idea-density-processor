namespace Application.Services.MapperProfiles
{
    using AutoMapper;
    using Domain.Model;
    using Dto;

    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<DocumentDto, Document>();
        }
    }
}