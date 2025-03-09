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
    }
}
