using OperationOOP.Core.Models;
using OperationOOP.Core.Data;

namespace OperationOOP.Core.Services;

public class AlbumService
{
    private readonly IDatabase _db;

    public AlbumService(IDatabase db)
    {
        _db = db;
    }

    public List<Album> GetAll() => _db.Albums.ToList();

    public Album? GetById(int id) => _db.Albums.FirstOrDefault(a => a.Id == id);

    public Album Create(string title, int year)
    {
        var id = _db.Albums.Any() ? _db.Albums.Max(a => a.Id) + 1 : 1;
        var album = new Album(id, title, year);
        _db.Albums.Add(album);
        return album;
    }

    public bool Delete(int id)
    {
        var album = GetById(id);
        return album is not null && _db.Albums.Remove(album);
    }

    public IEnumerable<Album> GetByYear(int year)
    {
        return _db.Albums.Where(a => a.Year == year);
    }

    public IEnumerable<Album> SearchByTitle(string titleFragment)
    {
        return _db.Albums.Where(a => a.Name.Contains(titleFragment, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Album> SortByTitle(bool descending = false)
    {
        return descending
            ? _db.Albums.OrderByDescending(a => a.Name)
            : _db.Albums.OrderBy(a => a.Name);
    }

    public IEnumerable<Album> SortByYear(bool descending = false)
    {
        return descending
            ? _db.Albums.OrderByDescending(a => a.Year)
            : _db.Albums.OrderBy(a => a.Year);
    }
}