using OperationOOP.Core.Models; 
using Xunit;

namespace OperationOOP_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void BandAddShouldWork()
        {
            var band = new Band(1, "Bandnamn", "Genre");

            Assert.Equal(1, band.Id);
            Assert.Equal("Bandnamn", band.Name);
            Assert.Equal("Genre", band.Genre);
        }

        [Fact]
        public void albumAddShouldWork()
        {
            var album = new Album(1, "Albumtitel", "0000", "Bandnamn");

            Assert.Equal(1, album.Id);
            Assert.Equal("Albumtitel", album.Name);
            Assert.Equal("0000", album.ReleaseYear);
            Assert.Equal("Bandnamn", album.Band);
        }

        [Fact]
        public void songAddShouldWork()
        {
            var song = new Song(1, "Låtnamn", "Albumtitel", "0:00");

            Assert.Equal(1, song.Id);  
            Assert.Equal("Låtnamn", song.Name);
            Assert.Equal("Albumtitel", song.Album);
            Assert.Equal("0:00", song.Duration);
        }
    }
}