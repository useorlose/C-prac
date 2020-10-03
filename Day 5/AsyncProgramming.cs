using System;

//Invoking a function asynchronously is called async programming. function invocation would happen and the calling function will not wait for the function to return. 
//from .NET 4.0, we have 2 delegates which are of generic type: Func<> and Action<>. Action used for void functions and Func is used for non void functions. These generic delegates give us 16 different options of passing parameters of various types using generic concept.. 
//Explore: CallBack function for BeginInvoke 
namespace SampleConApp.Day5
{
    class AsyncProgramming
    {
        //Example of a function that takes a longer time to complete...
        static void bigFunc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Beep #{i}");
                Console.Beep(100, 1000);
            }
        }

        static void Main(string[] args)
        {
           //invoke the big func using delegate...
            Action act = new Action(bigFunc);//old syntax
            var temp = act.BeginInvoke(null, null);//Invokes the method asynchronously
            Console.WriteLine("back to main and continuing some more operations");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main doing some job");
                Console.Beep(100, 1000);
            }
            act.EndInvoke(temp);//Makes the calling function to wait till the async function returns(Completes its operations)...
        }
    }
}
