using Application.Dto;
using AutoMapper;
using Presentation.API.Models;

namespace Presentation.WebApi.MapperProfiles
{
    public class DocumentsProfile : Profile
    {
        public DocumentsProfile()
        {
            this.CreateMap<DocumentDto, DocumentModel>();

            this.CreateMap<SentenceDto, SentenceModel>();

            this.CreateMap<WordDto, WordModel>();
        }
    }
}