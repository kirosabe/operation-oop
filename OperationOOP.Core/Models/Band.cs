namespace OperationOOP.Core.Models
{
    public class Band : Item
    {
        public string Genre { get; private set; } = string.Empty;

        public Band(int id, string name, string genre) : base(id, name)
        {
            SetGenre(genre);
        }

        public void SetGenre(string genre)
        {
            if (!string.IsNullOrWhiteSpace(genre))
                Genre = genre;
        }

        public Band() : base(0, string.Empty) { }

        public override string ToString()
        {
            return $"{Name} ({Genre})";
        }
    }
}
