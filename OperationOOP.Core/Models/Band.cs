using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public class Band : Item
    {
        private string _genre;
        public string Genre
        {
            get { return _genre; }
            private set { _genre = value; }
        }
        public Band(int bandId, string name, string genre)
        {
            Id = bandId;
            Name = name;
            Genre = genre;
        }
        public void SetGenre(string genre)
        {
            if (!string.IsNullOrEmpty(genre))
            {
                Genre = genre;
            }
        }
    }
}
