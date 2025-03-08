using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public class Band
    {
        public int BandId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }

        public Band(int id, string name, string genre, int yearFormed)
        {
            BandId = id;
            Name = name;
            Genre = genre;
        }
    }
}
