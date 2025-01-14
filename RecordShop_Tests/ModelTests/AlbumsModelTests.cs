﻿using System;
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
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        public static void InjectInitialTestDataIntoDb(RecordShopDbContext dbContext)
        {
            var greatAlbum = new Album(id: 1, title: "Great album", artist: "Great artist");
            if (dbContext != null)
            {
                dbContext.Albums.Add(greatAlbum);
                dbContext.SaveChanges();
                return;
            }
            throw new NullReferenceException("No database context present");
        }

        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<RecordShopDbContext>();
            optionsBuilder.UseInMemoryDatabase("RecordShopDB");
            _dbContext = new RecordShopDbContext(optionsBuilder.Options);
            InjectInitialTestDataIntoDb(_dbContext);
            _model = new AlbumsModel(_dbContext);
        }


        [Test]
        public void AddNewAlbum_Returns_Album_To_Be_Added()
        {
            // Arrange
            var album = new Album(1, "Fantastic album", "Fantastic artist");

            // Act
            var album_ = _model.AddNewAlbum(album);

            // Assert
            _model.FindAllAlbums().Count().Should().Be(2);
        }

        [Test]
        public void FindFirstUnusedId_Returns_2()
        {
            _model.FindFirstUnusedId().Should().Be(2);
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
