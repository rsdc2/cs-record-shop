using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordShop;
using FluentAssertions;

namespace RecordShop_Tests.ModelTests
{
    internal class AlbumsModelTests
    {
        AlbumsModel _model;

        private static Album greatAlbum = new Album(id: 1, title: "Great album", artist: "Great artist");
        private static List<Album> testAlbums = new()
        {
            greatAlbum
        };

        [SetUp]
        public void Setup()
        {
            _model = new AlbumsModel();

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
