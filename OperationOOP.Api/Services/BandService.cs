using OperationOOP.Core.Models;
using OperationOOP.Core.Data;

namespace OperationOOP.Core.Services;

public class BandService
{
    private readonly IDatabase _db;

    public BandService(IDatabase db)
    {
        _db = db;
    }

    public List<Band> GetAll() => _db.Bands.ToList();

    public Band? GetById(int id) => _db.Bands.FirstOrDefault(b => b.Id == id);

    public Band Create(string name, string genre)
    {
        var id = _db.Bands.Any() ? _db.Bands.Max(b => b.Id) + 1 : 1;
        var band = new Band(id, name, genre);
        _db.Bands.Add(band);
        return band;
    }

    public bool Delete(int id)
    {
        var band = GetById(id);
        return band is not null && _db.Bands.Remove(band);
    }

    public IEnumerable<Band> FilterByGenre(string genre)
    {
        return _db.Bands
            .Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Band> SearchByName(string nameFragment)
    {
        return _db.Bands
            .Where(b => b.Name.Contains(nameFragment, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Band> SortByName(bool descending = false)
    {
        return descending
            ? _db.Bands.OrderByDescending(b => b.Name)
            : _db.Bands.OrderBy(b => b.Name);
    }

    public IEnumerable<Band> SortByGenre(bool descending = false)
    {
        return descending
            ? _db.Bands.OrderByDescending(b => b.Genre)
            : _db.Bands.OrderBy(b => b.Genre);
    }

    public IEnumerable<Band> GetBandsWithoutGenre()
    {
        return _db.Bands.Where(b => string.IsNullOrWhiteSpace(b.Genre));
    }
}