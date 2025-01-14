using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RecordShop;
using Microsoft.AspNetCore.Mvc;


namespace RecordShop_Tests.ControllersTests
{
    internal class AlbumsControllerTests
    {
        Mock<IAlbumsService> mockService;
        AlbumsController controller;

        [SetUp]
        public void Setup()
        {
            mockService = new Mock<IAlbumsService>();
            controller = new AlbumsController(mockService.Object);
        }

        [Test]
        public void DeleteAlbumById_Returns_410_If_Album_Not_Deleted()
        {
            // Arrange
            mockService.Setup(service => service.DeleteAlbumById(1)).Returns(false);

            // Act
            var response = (StatusCodeResult)controller.DeleteAlbumById(1);

            // Assert
            Assert.That(response.StatusCode == 410);
        }

        [Test]
        public void DeleteAlbumById_Returns_404_If_Album_Not_Found()
        {
            // Arrange
            mockService.Setup(service => service.DeleteAlbumById(1)).Returns<bool?>(null);

            // Act
            var response = (StatusCodeResult)controller.DeleteAlbumById(1);

            // Assert
            Assert.That(response.StatusCode == 404);
        }

        [Test]
        public void DeleteAlbumById_Returns_204_If_Album_Successfully_Deleted()
        {
            // Arrange
            mockService.Setup(service => service.DeleteAlbumById(1)).Returns(true);

            // Act
            var response = (StatusCodeResult)controller.DeleteAlbumById(1);

            // Assert
            Assert.That(response.StatusCode == 204);
        }
    }
}
