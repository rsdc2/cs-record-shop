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

        private static Album greatAlbum = new Album(id: 1, title: "Great album", artist: "Great artist");
        private static List<Album> testAlbums = new()
        {
            greatAlbum
        };

        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<RecordShopDbContext>();
            optionsBuilder.UseInMemoryDatabase("RecordShopDB");
            _dbContext = new RecordShopDbContext(optionsBuilder.Options);
            _model = new AlbumsModel(_dbContext);

        }

        [Test]
        public void GetAllAlbumsReturnsListOfAlbums()
        {
            // Arrange
            

            // Act
            var albums = _model.GetAllAlbums();

            // Assert
            albums.Should().NotBeNull();
        }
    }
}
