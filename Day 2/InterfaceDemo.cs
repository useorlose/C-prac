using System;
/*
Interfaces are similar to abstract classes in the way that it allows abstract methods. However U cannot have implementation methods. 
All interfaces are abstract classes but all abstract classes are not interfaces. 
A class can implement multiple interfaces at the same level. 
Methods of the interfaces are by default public and will remain public. 
The classes that implement the interface must also implement them as public only. U cant change the access specifier.
Syntax of implementing interface is same as inheritance. However we use a Convention of naming the interface prefixed with I 
*/
namespace SampleConApp
{
    interface ICustomerManager
    {
        void AddNewCustomer(int id, string name);
        void UpdateCustomer(int id, string name);
        void DeleteCustomer(int id);
        Array GetAllCustomers(string name);
    }

    class SuperMarket : ICustomerManager
    {
        public void AddNewCustomer(int id, string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Array GetAllCustomers(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(int id, string name)
        {
            throw new NotImplementedException();
        }
    }
    class InterfaceDemo
    {
        static void Main(string[] args)
        {
            ICustomerManager mgr = new SuperMarket();
           
        }
    }
}
