using System;
using System.IO;
using System.Configuration;

namespace SampleConApp.Day4
{
    class ExceptionHandling
    {
        static void Main(string[] args)
        {
            //            basicExceptionHandling();
            //fileIOHandling();
            //collectionExceptionHandling();
            throwingException();
            Console.ReadKey();
        }

        /// <summary>
        /// This function might throw an Exception
        /// </summary>
        /// <exception cref="System.Exception"/>
        private static void throwingException()
        {
            //if U dont want an execution to progress further and U should immediately return to the caller with a certain message about this abnormality, U could throw a new Exception object with the message in it. 
            //The caller of this function will handle the exception using catch block and do the required needs...
            throw new Exception("Exception Thrown");
        }

        private static void collectionExceptionHandling()
        {
            //
            try
            {
                int[] elements = { 234, 345, 45, 6, 55, 44, 566, 345, 78 };
                for (int i = 0; i < 9; i++)
                    Console.WriteLine(elements[i]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("U R trying to read data which is not defined in the array");
            }
        }

        private static void fileIOHandling()
        {
            try
            {
                string filename = ConfigurationManager.AppSettings["menuFile"];
                string menu = File.ReadAllText(filename);
                Console.WriteLine(menu);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Invalid Path");
            }
        }

        private static void basicExceptionHandling()
        {
            tryagain:
            try
            {
                Console.WriteLine("Enter a Number to add");
                int no = int.Parse(Console.ReadLine());
                Console.WriteLine("U Entered " + no);
            }
            catch (FormatException)
            {
                Console.WriteLine("Input should be a valid Number.");
                goto tryagain;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Number should be within the range of " + int.MinValue + " and " + int.MaxValue);
                goto tryagain;
            }
            //finally
            //{
            //    Console.WriteLine("All is well!!!");
            //}
        }
    }
}
