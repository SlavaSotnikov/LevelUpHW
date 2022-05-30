using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_26_2022_EntityFramework
{
    [Table(Name = "BooksWriters")]
    internal class BooksWriters
    {
        [Column]
        public long BookId { get; set; }
        [Column]
        public long AuthorId { get; set; }

        public override string ToString()
        {
            return $"{BookId} {AuthorId}";
        }
    }
}
