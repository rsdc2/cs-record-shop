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
    }
}
