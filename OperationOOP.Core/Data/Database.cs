using OperationOOP.Core.Models;

namespace OperationOOP.Core.Data;

public class Database : IDatabase
{
    public List<Band> Bands { get; } = new();
    public List<Album> Albums { get; } = new();
    public List<Song> Songs { get; } = new();
}
