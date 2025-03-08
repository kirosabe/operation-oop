using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public class Album : Item
    {
        public string ReleaseYear { get; set; }
        public string Band { get; set; }

        public Album(int albumId, string title, string releaseYear, string band)
        {
            Id = albumId;
            Name = title;
            ReleaseYear = releaseYear;
            Band = band;
        }
    }
}
