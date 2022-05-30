using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseConnection
{
    internal class UI
    {
        private DataBaseAccessor _accessor;

        public UI(DataBaseAccessor source)
        {
            _accessor = source;
        }
    }
}
