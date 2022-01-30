using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseConnection
{
    internal class Book
    {
        public long BookId { get; private set; }
        public string Title { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }

        public Book(object bookId, object title, object firstName, object lastName, object middleName)
        {
            BookId = (long)bookId;
            Title = (string)title;
            FirstName = (string)firstName;
            LastName = (string)lastName;
            MiddleName = (string) middleName;
        }

        public override string ToString()
        {
            return $"{BookId,2} {Title,30} {FirstName,10} {LastName,10} {MiddleName,10}";
        }
    }
}
