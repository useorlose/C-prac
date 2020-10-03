using System;
using System.Text;

namespace SampleConApp.Day4
{
    class Data : IDisposable
    {
        private string Name;

        public Data(string data)
        {
            this.Name = data;
            Console.WriteLine($"The object by name {Name} is created");

        }
        //No access specifier for a destructor. As this method is never called by the user, U dont control it. It cannot any args.  
        ~Data()
        {
            StringBuilder mutableString = new StringBuilder("The object by name ");
            mutableString.Append(Name);
            mutableString.Append(" is destroyed");
            Console.WriteLine(mutableString);
        }

        public void Dispose()
        {
            StringBuilder mutableString = new StringBuilder("The object by name ");
            mutableString.Append(Name);
            mutableString.Append(" is destroyed");
            Console.WriteLine(mutableString);
            GC.SuppressFinalize(this);//It will tell the GC not to call the Destructor of this object...
        }
    }
    class MemoryManagement
    {

        static void createAndDestroyObjects()
        {
            for (int i = 0; i < 10; i++)
            {
                using (Data ex = new Data("SampleData" + i))
                {
                   // ex.Dispose();//U must call it....
                    GC.Collect();//This will invoke the GC to remove unused references of any objects in the heap....
                    GC.WaitForPendingFinalizers();//This will ensure that while GC is doing is destruction, UR Main Thread will wait(pause) till all the unused objects are removed.
                }//The object's dispose method gets called automatically..
                //Data ex = new Data("SampleData " + i);
                
            }
        }
        static void Main()
        {
            //Data ex = new Data("SampleData");
            createAndDestroyObjects();
            Console.WriteLine("back to main");
        }
    }
}
//Dispose vs. Destructors: Destructors in C# are also called as Finalizers. finally method is one formal way to call the Destructor methods or Finalizers..
//U dont need to create Destructors if U R working with C# code and .NET Code only. They are managed by GC of the CLR. 
//If UR Code is interacting with any COM based Components or Unmanaged C++ code, then U should explicitly destroy those C++ components. To do that we will implement our classes with IDisposable interface. This interface comes with single method called Dispose. 
//We implement the Dispose method to call all unmanaged code destruction logic here.
//Programmers who use the C# Classes with IDisposable interface must call the Dispose method once the work with the C# Component is completed.  