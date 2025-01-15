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
            mockService
                .Setup(service => service.DeleteAlbumById(1))
                .Returns(false);

            // Act
            var response = (StatusCodeResult)controller.DeleteAlbumById(1);

            // Assert
            Assert.That(response.StatusCode == 410);
        }

        [Test]
        public void DeleteAlbumById_Returns_404_If_Album_Not_Found()
        {
            // Arrange
            mockService
                .Setup(service => service.DeleteAlbumById(1))
                .Returns<bool?>(null);

            // Act
            var response = (StatusCodeResult)controller.DeleteAlbumById(1);

            // Assert
            Assert.That(response.StatusCode == 404);
        }

        [Test]
        public void DeleteAlbumById_Returns_204_If_Album_Successfully_Deleted()
        {
            // Arrange
            mockService
                .Setup(service => service.DeleteAlbumById(1))
                .Returns(true);

            // Act
            var response = (StatusCodeResult)controller.DeleteAlbumById(1);

            // Assert
            Assert.That(response.StatusCode == 204);
        }

        [Test]
        public void GetAllAlbums_Returns_Ok_If_Finds_Albums()
        {
            // Arrange
            mockService
                .Setup(service => service.FindAllAlbums())
                .Returns([new Album(1, "Great title", "Great artist")]);

            // Act
            var response = (OkObjectResult)controller.GetAllAlbums();

            // Assert
            Assert.That(response.StatusCode == 200);
        }

        [Test]
        public void GetAllAlbums_Returns_500_If_No_Albums()
        {
            // Arrange
            mockService
                .Setup(service => service.FindAllAlbums())
                .Returns<List<Album>?>(null);

            // Act
            var response = (StatusCodeResult)controller.GetAllAlbums();

            // Assert
            Assert.That(response.StatusCode == 500);
        }

        [Test]
        public void GetAlbumById_Returns_Ok_If_Finds_Album()
        {
            // Arrange
            mockService
                .Setup(service => service.FindAlbumById(1))
                .Returns(new Album(1, "Great title", "Great artist"));

            // Act
            var response = (OkObjectResult)controller.GetAlbumById(1);

            // Assert
            Assert.That(response.StatusCode == 200);
        }

        [Test]
        public void GetAlbumById_Returns_404_If_Does_Not_Find_Album()
        {
            // Arrange
            mockService
                .Setup(service => service.FindAlbumById(1))
                .Returns<Album?>(null);

            // Act
            var response = (NotFoundResult)controller.GetAlbumById(1);

            // Assert
            Assert.That(response.StatusCode == 404);
        }

        [Test]
        public void PostAlbum_Returns_500_If_Fails_To_Add_Album()
        {
            // Arrange
            var newAlbum = new Album(1, "Great title", "Great artist");
            mockService
                .Setup(service => service.AddNewAlbum(newAlbum))
                .Returns<Album?>(null);

            // Act
            var response = (StatusCodeResult)controller.PostAlbum(newAlbum);

            // Assert
            Assert.That(response.StatusCode == 500);
        }

        public void PostAlbum_Returns_Ok_If_Successfully_Adds_Album()
        {
            // Arrange
            var newAlbum = new Album(2, "Great title", "Great artist");
            mockService
                .Setup(service => service.AddNewAlbum(newAlbum))
                .Returns(newAlbum);

            // Act
            var response = (OkObjectResult)controller.PostAlbum(newAlbum);

            // Assert
            Assert.That(response.StatusCode == 200);
        }

        [Test]
        public void PostAlbum_Returns_404_If_Fails_To_Add_Album()
        {
            // Arrange
            var newAlbum = new Album(2, "Great title", "Great artist");
            mockService
                .Setup(service => service.UpdateAlbumById(2, newAlbum))
                .Returns<Album?>(null);

            // Act
            var response = (NotFoundResult)controller.PutAlbum(2, newAlbum);

            // Assert
            Assert.That(response.StatusCode == 404);
        }

        public void PutAlbum_Returns_Ok_If_Successfully_Updates_Album()
        {
            // Arrange
            var updatedAlbum = new Album(2, "Great title", "Great artist");
            mockService
                .Setup(service => service.UpdateAlbumById(2, updatedAlbum))
                .Returns(updatedAlbum);

            // Act
            var response = (OkObjectResult)controller.PutAlbum(2, updatedAlbum);

            // Assert
            Assert.That(response.StatusCode == 200);
        }

    }
}
