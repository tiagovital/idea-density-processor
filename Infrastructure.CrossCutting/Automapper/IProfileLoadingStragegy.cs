namespace Infrastructure.CrossCutting.Automapper
{
    using System.Collections.Generic;
    using AutoMapper;

    public interface IProfileLoadingStrategy
    {
        IEnumerable<Profile> GetProfiles();
    }
}