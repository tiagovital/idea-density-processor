namespace Presentation.API.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using AutoMapper;
    using Infrastructure.CrossCutting.Automapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Presentation.API.MapperProfiles;

    [ExcludeFromCodeCoverage]
    [TestClass]
    public class TestsSetup
    {
        /// <summary>
        /// The setup.
        /// </summary>
        /// <param name="context"></param>
        [AssemblyInitialize]
        public static void Setup(TestContext context)
        {
            var profileLoader = new StaticProfileLoader(
                new Profile[]
                {
                    new DocumentsProfile()
                });

            MapperConfig.Initialize(profileLoader);
        }
    }
}