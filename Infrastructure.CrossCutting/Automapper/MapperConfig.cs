namespace Infrastructure.CrossCutting.Automapper
{
    using System.Linq;
    using AutoMapper;

    public static class MapperConfig
    {
        public static void Initialize(IProfileLoader profileLoader)
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