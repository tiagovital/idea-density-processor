using System.Collections.Generic;
using AutoMapper;

namespace Infrastructure.CrossCutting
{
    public interface ProfileBuilder
    {
        IEnumerable<Profile> Configure();
    }
}