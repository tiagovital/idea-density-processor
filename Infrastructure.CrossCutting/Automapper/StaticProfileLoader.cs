namespace Infrastructure.CrossCutting.Automapper
{
    using System.Collections.Generic;
    using AutoMapper;

    public class StaticProfileLoader : IProfileLoader
    {
        #region Private Members

        private readonly IEnumerable<Profile> profiles;

        #endregion Private Members

        #region Ctors

        public StaticProfileLoader(IEnumerable<Profile> profiles)
        {
            this.profiles = profiles;
        }

        #endregion Ctors

        #region IProfileLoader Methods

        public IEnumerable<Profile> GetProfiles()
        {
            return this.profiles;
        }

        #endregion IProfileLoader Methods
    }
}