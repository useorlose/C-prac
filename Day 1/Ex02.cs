using System;
namespace SampleConApp
{
    /*
    Variabes in C# are based on the Common Type System of .NET Framework.
    All data types in .NET follow the guidelines defined in Common language specification
    Variables in .NET are of 2 types: Value types, Reference types.
    Value types: primitive and are structures. 
    Integral Types: byte(Byte), short(Int16) , int(Int32), long(Int64)
    Floating Types: float(Single), double(Double)
    Other Types: char(Char), bool(Boolean), decimal(Decimal-128 Bit no). 
    All data types of c# are implicitly objects of their wrapper types created in .NET. Implicitly they are all objects. The wrapper types provide the functions to perform conversions from one type to another. 
    */
    class Ex02
    {
        static void Main(string[] args)
        {
            int value = 123;
            Console.WriteLine("the value is " + value);

            double dVal = 234.345;
            Console.WriteLine("The double value is " + dVal);

            int bigInt = int.MaxValue;//U R using the wrapper class's const value which gives the max value of int...
            Console.WriteLine("The max value of int is " + bigInt);
            Console.WriteLine("The Range of int is {0} to {1}", int.MinValue, int.MaxValue);
        }
    }
}
