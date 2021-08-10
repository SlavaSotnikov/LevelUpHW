using System;

namespace Life
{
    class Program
    {
        static void Main()
        {
            int rows      = UI.GetValue("Enter the number of rows: ", Ocean.DEFAULT_ROWS);
            int columns   = UI.GetValue("Enter the number of columns: ", Ocean.DEFAULT_COLUMNS);
            int prey      = UI.GetValue("Enter the number of prey: ", Ocean.DEFAULT_PREY);
            int predator  = UI.GetValue("Enter the number of predators: ", Ocean.DEFAULT_PREDATORS);
            int obstacles = UI.GetValue("Enter the number of obstacles: ", Ocean.DEFAULT_OBSTACLES);

            Ocean ocean1 = new Ocean(rows, columns, prey, predator, obstacles);
            ocean1.FillInOcean();
        }
    }
}
