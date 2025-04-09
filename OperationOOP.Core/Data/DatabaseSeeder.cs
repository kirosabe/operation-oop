using OperationOOP.Core.Data;
using OperationOOP.Core.Models;

namespace OperationOOP.Core.Seeding;

public static class DatabaseSeeder
{
    public static void Seed(IDatabase database)
    {
        if (!database.Bands.Any())
        {
            var bands = CreateBands();
            var albums = CreateAlbums(bands);
            var songs = CreateSongs(albums);

            database.Bands.AddRange(bands);
            database.Albums.AddRange(albums);
            database.Songs.AddRange(songs);
        }
    }

    private static List<Band> CreateBands() => new()
    {
        new Band(1, "Metallica", "Heavy Metal"),
        new Band(2, "Iron Maiden", "Heavy Metal"),
        new Band(3, "Nas", "Hip Hop"),
        new Band(4, "Wu-Tang Clan", "Hip Hop"),
        new Band(5, "Charles Strouse", "Show tune"),
        new Band(6, "Andrew Lloyd Webber", "Show tune"),
        new Band(7, "John Williams", "Film Score"),
        new Band(8, "Thomas Newman", "Film Score")
    };

    private static List<Album> CreateAlbums(List<Band> bands) => new()
    {
        new Album(1, "Master of Puppets", 1986),
        new Album(2, "The Number of the Beast", 1982),
        new Album(3, "Illmatic", 1994),
        new Album(4, "Enter the Wu-Tang (36 Chambers)", 1993),
        new Album(5, "Annie", 1977),
        new Album(6, "The Phantom of the Opera", 1986),
        new Album(7, "Symphony No. 5", 1808),
        new Album(8, "Finding Nemo", 2003)
    };

    private static List<Song> CreateSongs(List<Album> albums) => new()
    {
        new Song(1, "Enter Sandman", 331, albums[0].Id),
        new Song(2, "Hallowed Be Thy Name", 432, albums[1].Id),
        new Song(3, "N.Y. State of Mind", 294, albums[2].Id),
        new Song(4, "C.R.E.A.M.", 252, albums[3].Id),
        new Song(5, "Tomorrow", 95, albums[4].Id),
        new Song(6, "The Phantom of the Opera", 216, albums[5].Id),
        new Song(7, "Symphony No. 5, Op. 67", 465, albums[6].Id),
        new Song(8, "Finding Nemo", 79, albums[7].Id)
    };
}
