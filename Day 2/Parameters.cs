using System;
namespace SampleConApp.Day2
{
    /*
    In C# there are 4 ways of passing parameters into a function
    Default is pass by value.
    Pass by Reference
    Pass by out 
    Params. 
    */
    class ParametersDemo
    {
        static void simpleFunc(int arg)
        {
            Console.WriteLine("The passed value: " + arg);
            arg += 123;
            //the parameter is local to the function. Any changes made to the parameter is not reflected after the function returns. 
        }

        static void refFunc(ref int arg)
        {
            Console.WriteLine("The arg passed" + arg);
            arg += 123;
        }

        static void passByRefDemo()
        {
            int value = 432;
            refFunc(ref value);
            Console.WriteLine("The value after the function returns: " + value);
        }
        static void passByValue()
        {
            int value = 123;
            simpleFunc(value);
            Console.WriteLine("The value after the function returns: " + value);
        }
        static void Main(string[] args)
        {
            // passByValue();
            //passByRefDemo();
            //arithematicDemo();
            passByParams();
        }

        private static void passByOutDemo()
        {
            /*
            Similar to pass by ref, except that the parameter need not be initialized before it is passed to the function. 
            However, the function must set some value to the out parameter before it returns to the caller. 
            Example displayed in arithematic Demo...
            */
        }

        private static void passByParams()
        {
            /*variable no args passed into a function is done using params.
              In this case, the params will be an array and user can pass multiple values into the array using , 
              Similar to ... in JS and C++ 
              There can be only one params in a given function
              It should be the last of the parameter list. 
              params can be passed by value only
            */
            double res = getSum(123, 234,345,34,54,4,5,5,5,345);
            //float val = 234.34543543f;
            //Console.WriteLine("The value: {0:##.##}", val);
            Console.WriteLine("The output: " + res);
        }

        private static double getSum(params double [] values)
        {
            double sum = 0.0;
            foreach (double val in values)
                sum += val;
            return sum;
        }
        private static void arithematicDemo()
        {
            int v1 = 123, v2 = 23;
            double addedNo = 0, subNo = 0, divNo;
            getArithmaticValues(v1, v2, ref addedNo, ref subNo, out divNo);
            Console.WriteLine("The added value : " + addedNo);
            Console.WriteLine("The subtracted value : " + subNo);
            Console.WriteLine("The divided value : " + divNo);
        }

        static void getArithmaticValues(int v1, int v2, ref double add, ref double sub, out double div)
        {
            add = v1 + v2;
            sub = v1 - v2;
            if (v2 != 0)
                div = v1 / v2;
            else
                div = 0;
        }
    }
}