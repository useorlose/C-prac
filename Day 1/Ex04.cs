//Arrays Example...
using System;
namespace SampleConApp
{
    class Ex04  
    {
        static void Main(string[] args)
        {
            //string[] names = new string[5];
            //for (int i = 0; i < names.Length; i++)
            //{
            //    Console.WriteLine("Enter the participant's name please");
            //    names[i] = Console.ReadLine();
            //}

            //foreach (string name in names) Console.WriteLine(name);

            ///////////Other way of creating array
            //int[] data = { 234, 345, 345, 35, 345, 5 };
            //foreach (int val in data) Console.WriteLine(val);

            /////multi dimensional array..............
            //int[,] TwoD = new int[,] { 
            //    { 2, 3, 4 }, 
            //    { 3, 4, 5 }, 
            //    { 4, 5, 6 }
            //};//3x3...
            //Console.WriteLine("The no of dimensions:" +  TwoD.Rank);
            //Console.WriteLine("The length of the First Dimension: " + TwoD.GetLength(0));
            //Console.WriteLine("The length of the 2nd Dimension: " + TwoD.GetLength(1));

            //for (int i = 0; i < TwoD.GetLength(0); i++)
            //{
            //    for (int j = 0; j < TwoD.GetLength(1); j++)
            //    {
            //        Console.Write(TwoD[i,j] + " ");
            //    }
            //    Console.WriteLine();
            //}
            //////////////////////Jagged Array////////////////
            /*
            Array of Arrays is called as Jagged Array...
            In this case, U have a fixed no of rows, but variable no of columns. 
            */

    int[][] School = new int[5][];//Rows are 5....
    School[0] = new int[] { 45, 55, 66, 56, 44, 23 };
    School[1] = new int[] { 45, 55, 78 };
    School[2] = new int[] { 90, 98, 78, 78, 55 };
    School[3] = new int[] { 45, 23 };
    School[4] = new int[] { 45, 44, 23 };
    //Each Row is an independent array...
    for (int i = 0; i < School.Length; i++)
    {
        foreach(int no in School[i])
            Console.Write(no + " ");
        Console.WriteLine();
    }
        }
    }
}