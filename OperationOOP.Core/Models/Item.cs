using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public abstract class Item
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; } = string.Empty;

        protected Item(int id, string name)
        {
            Id = id;
            Name = name;
        }

        protected Item() { }

        public virtual void Rename(string newName)
        {
            if (!string.IsNullOrWhiteSpace(newName))
                Name = newName;
        }
    }
}
