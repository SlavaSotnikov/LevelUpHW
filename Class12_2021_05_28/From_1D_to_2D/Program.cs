using System;

namespace From_1D_to_2D
{
    class Program
    {
        static Random rnd = new Random();
        static void Main()
        {
            int[] source = new int[16];

            int[,] dest = new int[4, 4];

            #region 1D to 2D fill in Line

            int sourceInd = -1;

            // Put random values in Source array and show it
            Console.Write("1D Array: ");
            for (int i = 0; i < source.Length; i++)
            {
                source[i] = rnd.Next(0, 10);

                Console.Write("{0} ", source[i]);
            }

            Console.WriteLine();
            Console.WriteLine();

            // Put values from Source to Destination array
            for (int i = 0; i < dest.GetLength(0); i++)
            {
                for (int j = 0; j < dest.GetLength(1); j++)
                {
                    dest[i, j] = source[++sourceInd];
                }
            }

            // Show Destination's array values
            Console.WriteLine("2D Array filled in Line: \n");
            for (int i = 0; i < dest.GetLength(0); i++)
            {
                for (int j = 0; j < dest.GetLength(1); j++)
                {
                    Console.Write("{0} ", dest[i, j]);
                }

                Console.WriteLine();
            }

            //Console.WriteLine();
            //#endregion

            //#region Snake 1D to 2D

            //sourceInd = -1;

            //// Algorithm for Snake fill in
            //for (int i = 0; i < dest.GetLength(0); i++)
            //{
            //    if ((i & 1) != 1)
            //    {
            //        for (int j = 0; j < dest.GetLength(1); j++)
            //        {
            //            dest[i, j] = source[++sourceInd];
            //        }
            //    }
            //    else
            //    {
            //        for (int j = dest.GetLength(1) - 1; j >= 0; j--)
            //        {
            //            dest[i, j] = source[++sourceInd];
            //        }
            //    }
            //}

            //// Show Destination's array values
            //Console.WriteLine("2D Array filled in Snake: \n");
            //for (int i = 0; i < dest.GetLength(0); i++)
            //{
            //    for (int j = 0; j < dest.GetLength(1); j++)
            //    {
            //        Console.Write("{0} ", dest[i, j]);
            //    }

            //    Console.WriteLine();
            //}

            //Console.WriteLine();

            //#endregion

            //#region Down Up fill in

            //sourceInd = -1;

            //// Algorithm for Down Up fill in
            //for (int j = 0; j < dest.GetLength(1); j++)
            //{
            //    if ((j & 1) != 1)
            //    {
            //        for (int i = 0; i < dest.GetLength(1); i++)
            //        {
            //            dest[i, j] = source[++sourceInd];
            //        }
            //    }
            //    else
            //    {
            //        for (int i = dest.GetLength(1) - 1; i >= 0; i--)
            //        {
            //            dest[i, j] = source[++sourceInd];
            //        }
            //    }
            //}

            //// Show Destination's array values
            //Console.WriteLine("2D Array filled in Down Up: \n");
            //for (int i = 0; i < dest.GetLength(0); i++)
            //{
            //    for (int j = 0; j < dest.GetLength(1); j++)
            //    {
            //        Console.Write("{0} ", dest[i, j]);
            //    }

            //    Console.WriteLine();
            //}

            //Console.WriteLine();
            //#endregion


            //#region Swap diagonals

            //int temp = 0;
            //int indexI = 0;
            //int indexJ = 0;
            //int z = 0;

            //// Swap diagonal values in first part of array
            //if (z < dest.GetLength(0) >> 1)
            //{
            //    for (; z < (dest.GetLength(0) >> 1); z++)
            //    {
            //        for (int j = 0; j < dest.GetLength(1); j++)
            //        {
            //            if (z == j)
            //            {
            //                temp = dest[z, j];
            //                indexI = z;
            //                indexJ = j;
            //            }
            //            if ((z + j) == dest.GetLength(0) - 1)
            //            {
            //                dest[indexI, indexJ] = dest[z, j];
            //                dest[z, j] = temp;
            //            }
            //        }
            //    }
            //}

            //// Swap diagonal values in second part of array
            //for (; z < dest.GetLength(0); z++)
            //{
            //    for (int j = 0; j < dest.GetLength(1); j++)
            //    {
            //        if (z == j)
            //        {
            //            dest[indexI, indexJ] = dest[z, j];
            //            dest[z, j] = temp;
            //        }
            //        if ((z + j) == dest.GetLength(0) - 1)
            //        {
            //            temp = dest[z, j];
            //            indexI = z;
            //            indexJ = j;
            //        }
            //    }
            //}

            //Console.WriteLine("2D Array Diagonal's swap: \n");
            //for (int i = 0; i < dest.GetLength(0); i++)
            //{
            //    for (int j = 0; j < dest.GetLength(1); j++)
            //    {
            //        Console.Write("{0} ", dest[i, j]);
            //    }

            //    Console.WriteLine();
            //}

            #endregion

            #region Diagonal fill in

            sourceInd = -1;
            int x = -1;
            int y = 1;

            while (x != y)
            {
                // Move from left down to right top
                while (y > 0 && x < (dest.GetLength(0) - 1))
                {
                    y -= 1;
                    x += 1;

                    sourceInd += 1;
                    dest[y, x] = source[sourceInd];
                }
                // One right step
                if (y == 0 && x < dest.GetLength(1) - 1)
                {
                    x += 1;

                    sourceInd += 1;
                    dest[y, x] = source[sourceInd];
                }
                // One down step
                else
                {
                    y += 1;

                    sourceInd += 1;
                    dest[y, x] = source[sourceInd];
                }

                // Move from right top to left down
                while (y < (dest.GetLength(0) - 1) && x > 0)
                {
                    x -= 1;
                    y += 1;

                    sourceInd += 1;
                    dest[y, x] = source[sourceInd];
                }
                // One down step
                if (x == 0 && y < dest.GetLength(1) - 1)
                {
                    y += 1;

                    sourceInd += 1;
                    dest[y, x] = source[sourceInd];
                }
                // One right step
                else
                {
                    x += 1;

                    sourceInd += 1;
                    dest[y, x] = source[sourceInd];
                }
            }
            

            Console.WriteLine("2D Array Diagonal fill in: \n");
            for (int i = 0; i < dest.GetLength(0); i++)
            {
                for (int j = 0; j < dest.GetLength(1); j++)
                {
                    Console.Write("{0} ", dest[i, j]);
                }

                Console.WriteLine();
            }

            #endregion

            Console.ReadKey();
        }
    }
}
