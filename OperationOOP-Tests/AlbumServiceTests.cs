using System;
using System.Collections.Generic;
using System.Linq;
using OperationOOP.Core.Models;
using OperationOOP.Core.Services;
using Xunit;

namespace OperationOOP.Tests.Services
{
    public class AlbumServiceTests
    {
        private readonly AlbumService _albumService;

        public AlbumServiceTests()
        {
            _albumService = new AlbumService();
        }

        [Fact]
        public void GetAll_ShouldReturnEmptyList_WhenNoAlbumsExist()
        {
            // Act
            var result = _albumService.GetAll();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Create_ShouldAddAlbumToList()
        {
            // Act
            var album = _albumService.Create("Test Album", 2025);

            // Assert
            Assert.NotNull(album);
            Assert.Equal(1, album.Id);
            Assert.Equal("Test Album", album.Name);
            Assert.Equal(2025, album.Year);
            Assert.Single(_albumService.GetAll());
        }

        [Fact]
        public void GetById_ShouldReturnAlbum_WhenAlbumExists()
        {
            // Arrange
            var createdAlbum = _albumService.Create("Test Album", 2025);

            // Act
            var result = _albumService.GetById(createdAlbum.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdAlbum.Id, result?.Id);
        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenAlbumDoesNotExist()
        {
            // Act
            var result = _albumService.GetById(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Delete_ShouldRemoveAlbum_WhenAlbumExists()
        {
            // Arrange
            var createdAlbum = _albumService.Create("Test Album", 2025);

            // Act
            var result = _albumService.Delete(createdAlbum.Id);

            // Assert
            Assert.True(result);
            Assert.Empty(_albumService.GetAll());
        }

        [Fact]
        public void Delete_ShouldReturnFalse_WhenAlbumDoesNotExist()
        {
            // Act
            var result = _albumService.Delete(999);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetByYear_ShouldReturnAlbumsFromSpecificYear()
        {
            // Arrange
            _albumService.Create("Album 1", 2025);
            _albumService.Create("Album 2", 2024);

            // Act
            var result = _albumService.GetByYear(2025);

            // Assert
            Assert.Single(result);
            Assert.Equal(2025, result.First().Year);
        }

        [Fact]
        public void SearchByTitle_ShouldReturnAlbumsContainingTitleFragment()
        {
            // Arrange
            _albumService.Create("Rock Album", 2025);
            _albumService.Create("Pop Album", 2024);

            // Act
            var result = _albumService.SearchByTitle("Rock");

            // Assert
            Assert.Single(result);
            Assert.Contains("Rock", result.First().Name);
        }

        [Fact]
        public void SortByTitle_ShouldReturnAlbumsSortedByTitleAscending()
        {
            // Arrange
            _albumService.Create("B Album", 2025);
            _albumService.Create("A Album", 2024);

            // Act
            var result = _albumService.SortByTitle();

            // Assert
            Assert.Equal("A Album", result.First().Name);
        }

        [Fact]
        public void SortByTitle_ShouldReturnAlbumsSortedByTitleDescending()
        {
            // Arrange
            _albumService.Create("A Album", 2025);
            _albumService.Create("B Album", 2024);

            // Act
            var result = _albumService.SortByTitle(descending: true);

            // Assert
            Assert.Equal("B Album", result.First().Name);
        }

        [Fact]
        public void SortByYear_ShouldReturnAlbumsSortedByYearAscending()
        {
            // Arrange
            _albumService.Create("Album 1", 2025);
            _albumService.Create("Album 2", 2024);

            // Act
            var result = _albumService.SortByYear();

            // Assert
            Assert.Equal(2024, result.First().Year);
        }

        [Fact]
        public void SortByYear_ShouldReturnAlbumsSortedByYearDescending()
        {
            // Arrange
            _albumService.Create("Album 1", 2024);
            _albumService.Create("Album 2", 2025);

            // Act
            var result = _albumService.SortByYear(descending: true);

            // Assert
            Assert.Equal(2025, result.First().Year);
        }
    }
}
