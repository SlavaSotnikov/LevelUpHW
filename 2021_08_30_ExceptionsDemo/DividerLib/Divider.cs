using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DividerLib
{
    public class Divider
    {
        private int _firstArg;
        private int _secondArg;

        public Divider(int firstArg, int secondArg)
        {
            _firstArg = firstArg;
            _secondArg = secondArg;
        }

        public int Run()
        {
            if (_secondArg == 0)
            {
                throw new DividerException("An attempt devide by zero!");
            }

            try
            {
                return _firstArg / _secondArg;
            }
            catch (DivideByZeroException ex)
            {

                throw new DividerException("Dividing by zero!", ex); 
            }
        }
    }
}
