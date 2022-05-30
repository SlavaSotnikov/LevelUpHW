using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_26_2022_EntityFramework
{
    internal class BookInfo
    {
        public long BookId { get; set; }
        public string Title { get; set; }
        public long WriterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"{BookId} {Title} {WriterId} {FirstName} {LastName} {Country}";
        }
    }
}
