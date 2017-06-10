namespace Infrastructure.CrossCutting.Automapper
{
    using System.Collections.Generic;
    using AutoMapper;

    public interface IProfileLoader
    {
        IEnumerable<Profile> GetProfiles();
    }
}