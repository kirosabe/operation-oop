using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public class Song : Item
    {
        public string Album { get; set; }
        public string Duration { get; set; }

        public Song(int songId, string title, string album, string duration)
        {
            Id = songId;
            Name = title;
            Album = album;
            Duration = duration;
        }
    }
}
