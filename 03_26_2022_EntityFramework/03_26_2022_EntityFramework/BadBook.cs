using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_26_2022_EntityFramework
{
    internal class BadBook
    {
        public long CopyId { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return $"{CopyId} {Title}";
        }
    }
}
