using System.Data.Linq.Mapping;

namespace _03_26_2022_EntityFramework
{
    [Table(Name = "Books")]
    internal class Book
    {
        [Column]
        public long BookId { get; set; }

        [Column]
        public string Title { get; set; }

        public override string ToString()
        {
            return $"{BookId} {Title}";
        }
    }
}
