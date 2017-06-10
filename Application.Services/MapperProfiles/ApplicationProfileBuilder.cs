using System.Collections.Generic;
using AutoMapper;
using Infrastructure.CrossCutting;

namespace Application.Services.MapperProfiles
{
    internal class ApplicationProfileBuilder : ProfileBuilder
    {
        public IEnumerable<Profile> Get()
        {
            yield return new DocumentProfile();
        }
    }
}