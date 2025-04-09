using OperationOOP.Core.Models;
using OperationOOP.Core.Data;

namespace OperationOOP.Core.Repositories;

public class MusicRepository
{
    private readonly IDatabase _db;

    public MusicRepository(IDatabase db)
    {
        _db = db;
    }

    public List<Album> GetAlbumsByName(string name)
    {
        return _db.Albums
            .Where(a => a.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Band> GetBandsByGenre(string genre)
    {
        return _db.Bands
            .Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Song> GetSongsByAlbumId(int albumId)
    {
        return _db.Songs
            .Where(s => s.AlbumId == albumId)
            .ToList();
    }

    public List<Album> SortAlbumsByYear(bool descending = false)
    {
        return descending
            ? _db.Albums.OrderByDescending(a => a.Year).ToList()
            : _db.Albums.OrderBy(a => a.Year).ToList();
    }

    public Dictionary<string, int> GetSongCountPerAlbum()
    {
        return _db.Albums.ToDictionary(
            album => album.Name,
            album => _db.Songs.Count(song => song.AlbumId == album.Id)
        );
    }

    public List<Band> GetBandsWithoutAlbums()
    {
        return _db.Bands
            .Where(b => !_db.Albums.Any(a => a.Id == b.Id))
            .ToList();
    }
}
