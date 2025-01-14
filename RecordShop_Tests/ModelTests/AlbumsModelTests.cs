using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordShop;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace RecordShop_Tests.ModelTests
{
    internal class AlbumsModelTests
    {
        RecordShopDbContext _dbContext;
        AlbumsModel _model;

        [TearDown]
        public void TeardownDb()
        {
            _dbContext.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<RecordShopDbContext>();
            optionsBuilder.UseInMemoryDatabase("RecordShopDB");
            _dbContext = new RecordShopDbContext(optionsBuilder.Options);
            Development.InjectDevelopmentDataIntoDb(_dbContext);
            _model = new AlbumsModel(_dbContext);
        }

        [Test]
        public void GetAllAlbums_Returns_List_of_Albums_Not_Null()
        {
            // Arrange
            

            // Act
            var albums = _model.FindAllAlbums();

            // Assert
            albums.Should().NotBeNull();
        }

        [Test]
        public void GetAlbumById_Returns_Not_Null()
        {
            // Arrange


            // Act
            var album = _model.FindAlbumById(1);

            // Assert
            album.Should().NotBeNull();
        }

    }
}
