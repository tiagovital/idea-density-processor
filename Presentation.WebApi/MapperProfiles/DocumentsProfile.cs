﻿namespace Presentation.API.MapperProfiles
{
    using Application.Dto;
    using AutoMapper;
    using Presentation.API.Models;

    public class DocumentsProfile : Profile
    {
        public DocumentsProfile()
        {
            this.CreateMap<DocumentDto, DocumentModel>();

            this.CreateMap<SentenceDto, SentenceModel>();

            this.CreateMap<WordDto, WordModel>();

            this.CreateMap<AddOrUpdateDocumentModel, DocumentDto>()
                .ConstructUsing((model) =>

                    new DocumentDto
                    {
                        Author = model.Author,
                        Content = model.Content,
                        Title = model.Title
                    }
                )
                .ForAllMembers(opts => opts.Ignore());
        }
    }
}