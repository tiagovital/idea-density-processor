namespace Application.Services.Tests
{
    using Application.Dto;
    using Data.Repository;
    using Domain.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Ploeh.AutoFixture;

    [TestClass]
    public class DocumentServiceTests
    {
        [TestMethod]
        public void Save_ADocumentDto_CallsRepository()
        {
            // Arrange
            var repositoryMock = new Mock<IDocumentRepository>();

            var documentDto = new Fixture().Create<DocumentDto>();

            var target = new DocumentService(repositoryMock.Object);

            // Act
            target.Save(documentDto);

            // Assert
            repositoryMock.Verify(i => i.Add(It.IsAny<Document>()), Times.Exactly(1));
        }
    }
}