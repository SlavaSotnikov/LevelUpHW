﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorter
{
    internal class Insertion : Sorter
    {
        #region Member Functions

        protected override double[] SortedArray()
        {
            int i = 0;
            int memory = 0;

            while (i < _data.Length - 1)
            {
                if (IsMore(i))
                {
                    if (_indexes != null)
                    {
                        _indexes.Invoke(this, new IndexEventArgs(i, i + 1));
                    }

                    double tmp = _data[i];
                    _data[i] = _data[i + 1];
                    _data[i + 1] = tmp;

                    if (i != 0)
                    {
                        i--;
                    }
                    else
                    {
                        memory++;
                        i = memory;
                    }
                }
                else
                {
                    memory++;
                    i = memory;
                }
            }

            return _data;
        }

        private bool IsMore(int i)
        {
            if (_theseIndexes != null)
            {
                _theseIndexes.Invoke(this, new IndexEventArgs(i, i + 1));
            }

            return _data[i] > _data[i + 1];
        }

        #endregion

        #region Constructor

        public Insertion(params double[] data)
            : base(data)
        {
        }

        #endregion
    }
}
