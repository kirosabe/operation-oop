using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationOOP.Core.Models;

namespace OperationOOP.Core.Data
{
    public class MusicRepository
    {
        private readonly IDatabase _db;

        public MusicRepository(IDatabase db)
        {
            _db = db;
        }
        public List<Band> GetBandsByGenre(string genre)
        {
            return _db.Bands
                .Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public List<Song> GetSongsByAlbum(string album)
        {
            return _db.Songs
                .Where(s => s.Album.Equals(album, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public List<Album> SortAlbumsByReleaseYear(bool descending = false)
        {
            return descending
                ? _db.Albums.OrderByDescending(a => a.ReleaseYear).ToList()
                : _db.Albums.OrderBy(a => a.ReleaseYear).ToList();
        }

        public Dictionary<string, int> GetSongCountPerAlbum()
        {
            return _db.Albums.ToDictionary(
                album => album.Name,
                album => _db.Songs.Count(song => song.Album.Equals(album.Name, StringComparison.OrdinalIgnoreCase))
            );
        }

        public List<Band> GetBandsWithoutAlbums()
        {
            return _db.Bands.Where(b => !_db.Albums.Any(a => a.Band.Id == b.Id)).ToList();
        }

    }
}
