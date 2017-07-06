﻿namespace Presentation.API.Tests.Controllers
{
    using System;
    using System.Threading.Tasks;
    using API.Controllers.v1;
    using Application.Dto;
    using Application.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Ploeh.AutoFixture;

    [TestClass]
    public class DocumentsControllerTests
    {
        [TestMethod]
        public async Task AddOrUpdate_ValidIdAndDocument_CallsApplicationService()
        {
            // Arrange
            var service = new Mock<IDocumentService>();

            var target = new DocumentsController(service.Object);

            var fixture = new Fixture();

            var model = fixture.Create<AddOrUpdateDocumentDto>();
            var documentId = Guid.NewGuid().ToString();

            // Act
            await target.AddOrUpdate(documentId, model);

            // Assert
            service.Verify(i => i.Save(documentId, model));
        }

        //public async Task
    }
}