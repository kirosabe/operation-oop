using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public class Album : Item
    {
        public int Year { get; private set; }

        public Album(int id, string title, int year) : base(id, title)
        {
            SetYear(year);
        }

        public void SetYear(int year)
        {
            if (year > 0)
                Year = year;
        }

        public override string ToString()
        {
            return $"Album: {Name} ({Year})";
        }

        public Album() : base(0, string.Empty)
        {
        }
    }
}
