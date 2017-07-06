namespace Presentation.API.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using Application.Services.MapperProfiles;
    using AutoMapper;
    using Infrastructure.CrossCutting.Automapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var profileLoader = new StaticLoadingStrategy(
                new Profile[]
                {
                    new DocumentProfile()
                });

            //MapperConfig.Initialize(profileLoader);
        }
    }
}