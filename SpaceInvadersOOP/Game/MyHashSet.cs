using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class MyHashSet<T> : HashSet<T>
    {
        public T this[int index]
        {
            get
            {
                T result = default(T);
                int i = 0;
                foreach (T t in this)
                {
                    if (i == index)
                    {
                        result = t;
                    }

                    i++;
                }

                return result;
            }

            set
            {
                int i = 0;
                foreach (T t in this)
                {
                    if (i == index)
                    {
                        this[index] = value;
                    }

                    i++;
                }
            }
        }
    }
}
