using OperationOOP.Core.Models;

namespace OperationOOP.Core.Services;

public class AlbumService
{
    private readonly List<Album> _albums = new();
    private int _nextId = 1;

    public IEnumerable<Album> GetAll() => _albums;

    public Album? GetById(int id) => _albums.FirstOrDefault(a => a.Id == id);

    public Album Create(string title, int year)
    {
        var album = new Album(_nextId++, title, year);
        _albums.Add(album);
        return album;
    }

    public bool Delete(int id)
    {
        var album = GetById(id);
        return album is not null && _albums.Remove(album);
    }

    public IEnumerable<Album> GetByYear(int year)
    {
        return _albums.Where(a => a.Year == year);
    }

    public IEnumerable<Album> SearchByTitle(string titleFragment)
    {
        return _albums.Where(a => a.Name.Contains(titleFragment, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Album> SortByTitle(bool descending = false)
    {
        return descending
            ? _albums.OrderByDescending(a => a.Name)
            : _albums.OrderBy(a => a.Name);
    }

    public IEnumerable<Album> SortByYear(bool descending = false)
    {
        return descending
            ? _albums.OrderByDescending(a => a.Year)
            : _albums.OrderBy(a => a.Year);
    }
}