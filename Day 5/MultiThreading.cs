using System;
using System.Threading;
//Threading namespace contains the classes to create threads, synchronize threads and do other activities on threads. 
//Every thread is represented programmatically by a class called Thread.
//Thread is associated with a function that defines what needs to be done when the thread starts. A Thread when instantiated, will be associated with a function thro a delegate called ThreadStart. The function is generally called as THREAD FUNCTION. The Thread will return to the caller once the functionality of the thred is completed. 
//When a resource or a data has to be synchronized when multiple threads are accessing the same resource, U go for thread synchronization. Thread Synchronization is created to ensure data concurrancy. This is required when U want the data to be used by one thread at a time. While one thread is using the resource, the other thread must wait till the first thread completes the task. 
//Monitor is the class used to perform synchronization in C# using the concept of CS in Windows Programming. In this case, the Thread owned by the Monitor will run and other threads will wait. Once the job is completed by the holding thread, it should release the Monitor to be accessed by the next thread in the pipeline.  
//Monitor can be implemented using a keyword lock {} which locks the block from accessing.  
//In C#, there are 2 types of threads: Foreground Threads and Background threads. Foreground threads are by default. They will make the calling thread wait till the thread completes its operation. Background threads will not make the main thread wait till the job is completed. U could make the thread back ground by setting IsBackground property to true. 
namespace SampleConApp.Day5
{
    class MultiThreading
    {
        static int No = 0;
        static void threadFunc()
        {
            //lock (typeof(MultiThreading))
            Monitor.Enter(typeof(MultiThreading));
            {
                No++;
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);//Sleeps the thread for a specific interval of time..
                    Console.WriteLine($"Thread no {No} with Beep#{i + 1}");
                }
            }
            Monitor.Exit(typeof(MultiThreading));
        }

        static void Main(string[] args)
        {
            //ThreadStart fn = new ThreadStart(threadFunc);
            //ThreadStart fn = threadFunc;//new syntx
            Thread Th = new Thread(threadFunc);//It internally uses ThreadStart Delegate 
            Th.IsBackground = true;
            Th.Start();//Start the thread...

            //2nd Thread using the same function...
            Thread Th2 = new Thread(threadFunc);//It internally uses ThreadStart Delegate 
            Th2.IsBackground = true;
            Th2.Start();//Start the thread...


        }
    }
}
//mailto:phani.blrtraining@gmail.com
