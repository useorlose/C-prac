using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Abstract classes are classes that have atleast one abstract method...
abstract methods are methods which do not have implementation/body. These methods are expected to be implemented by the derived classes. 
However abstract methods can have normal methods and virtual methods in them.
abstract classes are incomplete classes. So U cannot instantiate them. So U must extend this class to a derived class, implement the abstract methods in it and finally use it thro the derived class instance. 
abstract methods in the derived classes are implemented using override keyword. 
override is required for those methods of the base class that are: virtual methods, override methods, abstract methods.
abstract classes lead to the concept of interfaces. 
*/
namespace SampleConApp.Day2
{

    abstract class AbstractClass
    {
        public void NormalMethod() => Console.WriteLine("Normal Method");
        public virtual void VirtualMethod() => Console.WriteLine("Virtual Method");
        public abstract void AbstractMethod();
    }

    //The Subclass must implement all the abstract methods...
    class ExtendedClass : AbstractClass
    {
        public override void AbstractMethod() => Console.WriteLine("Abstract method implemented in derived class");
    }
    class AbstractClassDemo
    {
        static void Main(string[] args)
        {
            AbstractClass cls = new ExtendedClass();
            cls.NormalMethod();
            cls.VirtualMethod();
            cls.AbstractMethod();//overriden, so will call the derived version...
        }
    }
}
