using OperationOOP.Core.Models;

namespace OperationOOP.Core.Data
{
    public interface IDatabase
    {
        List<Band> Bands { get; set; }
        List<Album> Albums { get; set; }
        List<Song> Songs { get; set; }
    }

    public class Database : IDatabase
    {
        public List<Band> Bands { get; set; } = new List<Band>();
        public List<Album> Albums { get; set; } = new List<Album>();
        public List<Song> Songs { get; set; } = new List<Song>();
    }
}
