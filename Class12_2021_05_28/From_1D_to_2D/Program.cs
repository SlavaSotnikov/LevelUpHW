using System;

namespace From_1D_to_2D
{
    class Program
    {
        static Random rnd = new Random();

        private static int[,] FillInDiagonalZigZag(int[,] dest)
        {
            int Ind = -1;
            int x = -1;
            int y = 1;

            while (x != y)
            {
                // Move from left down to right top
                while (y > 0 && x < (dest.GetLength(0) - 1))
                {
                    y -= 1;
                    x += 1;

                    dest[y, x] = ++Ind;
                }
                // One right step
                if (y == 0 && x < dest.GetLength(1) - 1)
                {
                    x += 1;

                    dest[y, x] = ++Ind;
                }
                // One down step
                else
                {
                    y += 1;

                    dest[y, x] = ++Ind;
                }

                // Move from right top to left down
                while (y < (dest.GetLength(0) - 1) && x > 0)
                {
                    x -= 1;
                    y += 1;

                    dest[y, x] = ++Ind;
                }
                // One down step
                if (x == 0 && y < dest.GetLength(1) - 1)
                {
                    y += 1;

                    dest[y, x] = ++Ind;
                }
                // One right step
                else
                {
                    x += 1;

                    dest[y, x] = ++Ind;
                }
            }

            return dest;
        }

        private static int[,] SwapDiagonals(int[,] dest)
        {
            int temp = 0;
            int indexI = 0;
            int indexJ = 0;
            int z = 0;

            // Swap diagonal values in first part of array
            if (z < dest.GetLength(0) >> 1)
            {
                for (; z < (dest.GetLength(0) >> 1); z++)
                {
                    for (int j = 0; j < dest.GetLength(1); j++)
                    {
                        if (z == j)
                        {
                            temp = dest[z, j];
                            indexI = z;
                            indexJ = j;
                        }
                        if ((z + j) == dest.GetLength(0) - 1)
                        {
                            dest[indexI, indexJ] = dest[z, j];
                            dest[z, j] = temp;
                        }
                    }
                }
            }

            // Swap diagonal values in second part of array
            for (; z < dest.GetLength(0); z++)
            {
                for (int j = 0; j < dest.GetLength(1); j++)
                {
                    if (z == j)
                    {
                        dest[indexI, indexJ] = dest[z, j];
                        dest[z, j] = temp;
                    }
                    if ((z + j) == dest.GetLength(0) - 1)
                    {
                        temp = dest[z, j];
                        indexI = z;
                        indexJ = j;
                    }
                }
            }

            return dest;
        }

        private static int[,] FillInDownUp(int[,] dest, int Ind=-1)
        {
            for (int j = 0; j < dest.GetLength(1); j++)
            {
                if ((j & 1) != 1)
                {
                    for (int i = 0; i < dest.GetLength(1); i++)
                    {
                        dest[i, j] = ++Ind;
                    }
                }
                else
                {
                    for (int i = dest.GetLength(1) - 1; i >= 0; i--)
                    {
                        dest[i, j] = ++Ind;
                    }
                }
            }

            return dest;
        }

        private static int[,] FillInSnake(int[,] dest, int Ind=-1)
        {
            for (int i = 0; i < dest.GetLength(0); i++)
            {
                if ((i & 1) != 1)
                {
                    for (int j = 0; j < dest.GetLength(1); j++)
                    {
                        dest[i, j] = ++Ind;
                    }
                }
                else
                {
                    for (int j = dest.GetLength(1) - 1; j >= 0; j--)
                    {
                        dest[i, j] = ++Ind;
                    }
                }
            }

            return dest;
        }

        private static int[,] PutValuesFromSourceToDest(int[] source, int[,] dest, int sourceInd=-1)
        {
            for (int i = 0; i < dest.GetLength(0); i++)
            {
                for (int j = 0; j < dest.GetLength(1); j++)
                {
                    dest[i, j] = source[++sourceInd];
                }
            }

            return dest;
        }

        private static void Print1DArray(int[] array, string name)
        {

            Console.Write(name);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(0, 10);

                Console.Write("{0} ", array[i]);
            }
        }

        private static void Print2DArray(int[,] array, string name)
        {
            Console.WriteLine(name);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("{0}", array[i, j]);
                }

                Console.WriteLine();
            }
        } 

        static void Main()
        {
            int[] source = new int[16];

            int[,] dest = new int[4, 4];

            #region 1D to 2D fill in Line

            // Put random values in Source array and show it
            string name1D = "Source 1D Array: ";
            Print1DArray(source, name1D);

            Console.WriteLine();
            Console.WriteLine();

            // Put values from Source to Destination array
            dest = PutValuesFromSourceToDest(source, dest);
            
            // Show Destination's array values
            string name = "2D Array filled in Line: \n";
            Print2DArray(dest, name);

            Console.WriteLine();
            #endregion


            #region Snake 1D to 2D

            // Algorithm for Snake fill in
            dest = FillInSnake(dest);

            // Show Destination's array values
            name = "2D Array filled in Snake: \n";
            Print2DArray(dest, name);

            Console.WriteLine();
            #endregion


            #region Down Up fill in

            // Algorithm for Down Up fill in
            FillInDownUp(dest);

            // Show Destination's array values
            name = "2D Array filled in Down Up: \n";
            Print2DArray(dest, name);

            Console.WriteLine();
            #endregion


            #region Swap diagonals

            SwapDiagonals(dest);

            name = "Swap the main and the axiliary diagonals: \n";
            Print2DArray(dest, name);

            Console.WriteLine();
            #endregion


            #region Diagonal fill in

            FillInDiagonalZigZag(dest);

            name = "Diagonal zig zag fill in: \n";
            Print2DArray(dest, name);

            #endregion

            #region Spiral fill in

            int[,] arr = new int[5, 5];

            int x = 0;
            int y = 0;
            int n = 0;
            int ind = -1;

            while (true)
            {
                while (y < (arr.GetLength(0) - 1) - n)
                {
                    y++;

                    arr[x, y] = ++ind;

                    
                }
                x++;
                while (x < (arr.GetLength(1) - 1) - n)
                {
                    x++;
                    arr[x, y] = ++ind;

                    
                }
                y++;
                while (y > n)
                {
                    y--;

                    arr[x, y] = ++ind;
                }

                n++;
                while (x > n)
                {
                    x--;

                    arr[x, y] = ++ind;
                }

            }

            name = "Spiral fill in: \n";
            Print2DArray(arr, name);

            #endregion
            Console.ReadKey();
        }
    }
}
