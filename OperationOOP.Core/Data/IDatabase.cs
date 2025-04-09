using OperationOOP.Core.Models;

namespace OperationOOP.Core.Data;

public interface IDatabase
{
    List<Band> Bands { get; }
    List<Album> Albums { get; }
    List<Song> Songs { get; }
}
