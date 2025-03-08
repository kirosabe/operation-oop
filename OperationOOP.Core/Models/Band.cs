using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public class Band : Item
    {
        public string Genre { get; set; }

        public Band(int bandId, string name, string genre)
        {
            Id = bandId;
            Name = name;
            Genre = genre;
        }
    }
}
