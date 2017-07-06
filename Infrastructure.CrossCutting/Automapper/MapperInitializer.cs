namespace Infrastructure.CrossCutting.Automapper
{
    using System.Linq;
    using AutoMapper;

    public static class MapperInitializer
    {
        public static void Initialize(IProfileLoadingStrategy profileLoader)
        {
            Mapper.Initialize(cfg =>
            {
                var profilesTypes = profileLoader.GetProfiles().Select(i => i.GetType());

                cfg.AddProfiles(profilesTypes);
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}