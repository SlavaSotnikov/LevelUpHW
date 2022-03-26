using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_26_2022_EntityFramework
{
    [Table(Name = "Writers")]
    internal class Writer
    {
        [Column]
        public long WriterId { get; set; }
        [Column]
        public string FirstName { get; set; }
        [Column]
        public string LastName { get; set; }
        [Column]
        public string MiddleName { get; set; }
        [Column]
        public string Country { get; set; }

        public override string ToString()
        {
            return $"{WriterId} {FirstName} {LastName} {MiddleName} {Country}";
        }
    }
}
