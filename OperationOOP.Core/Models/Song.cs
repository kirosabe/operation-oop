using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public class Song : Item
    {
        public int Duration { get; private set; } 
        public int AlbumId { get; private set; }  

        public Song(int id, string title, int duration, int albumId = 0) : base(id, title)
        {
            SetDuration(duration);
            AlbumId = albumId;
        }

        public void SetDuration(int duration)
        {
            if (duration > 0)
                Duration = duration;
        }

        public Song() : base(0, string.Empty) { }

        public override string ToString()
        {
            var minutes = Duration / 60;
            var seconds = Duration % 60;
            return $"{Name} ({minutes}:{seconds:D2})";
        }
    }
}

