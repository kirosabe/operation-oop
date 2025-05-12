using OperationOOP.Core.Models;
using OperationOOP.Core.Data;

namespace OperationOOP.Core.Services;

public class SongService
{
    private readonly IDatabase _db;

    public SongService(IDatabase db)
    {
        _db = db;
    }

    public List<Song> GetAll() => _db.Songs.ToList();

    public Song? GetById(int id) => _db.Songs.FirstOrDefault(s => s.Id == id);

    public Song Create(string title, int duration)
    {
        var id = _db.Songs.Any() ? _db.Songs.Max(s => s.Id) + 1 : 1;
        var song = new Song(id, title, duration);
        _db.Songs.Add(song);
        return song;
    }

    public bool Delete(int id)
    {
        var song = GetById(id);
        return song is not null && _db.Songs.Remove(song);
    }

    public List<Song> GetSongsLongerThan(int duration)
    {
        return _db.Songs.Where(s => s.Duration > duration).ToList();
    }

    public List<Song> SearchByTitle(string titleFragment)
    {
        return _db.Songs
            .Where(s => s.Name.Contains(titleFragment, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Song> SortByTitle(bool descending = false)
    {
        return descending
            ? _db.Songs.OrderByDescending(s => s.Name).ToList()
            : _db.Songs.OrderBy(s => s.Name).ToList();
    }

    public List<Song> SortByDuration(bool descending = false)
    {
        return descending
            ? _db.Songs.OrderByDescending(s => s.Duration).ToList()
            : _db.Songs.OrderBy(s => s.Duration).ToList();
    }
}