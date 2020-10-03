using System;
namespace SampleConApp
{
    //In C# as Class can have fields, Functions, properties, events, nested classes. 
    //data of the class is called Fields. 
    //Operations of the class is called Function or member functions.
    //Properties are smart functions with get/set blocks. 
    //Fields are usually hidden members(Private)...
    //To access fields we use properties: get/set  
    //As a class is UDT, U need a definition of the class. The definition tells what UR user defined type does: what data it will represent, what operations it does, what data it holds.
    //The actual variable of the class is created using new operator in C#. This variable is called OBJECT in OOP.
    class Employee
    {
        int id;
        string name, address;
        long phoneNo;

        public int EmployeeID
        {
            get { return id; }
            set { id = value; }
        }

        public string EmpName
        {
            get { return name; }
            set { name = value; }
        }

        public string EmpAddress
        {
            get { return address; }
            set { address = value; }
        }

        public long EmpPhone
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }

    }
    class ClassesDemo
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.EmployeeID = 123;
            emp.EmpName = "Phaniraj";
            emp.EmpAddress = "Bangalore";
            emp.EmpPhone = 234234234;
            Console.WriteLine($"The name of the Employee is {emp.EmpName} from {emp.EmpAddress} who can be contacted on {emp.EmpPhone}");
            //New Syntax for text formatting in C# 6.0..
        }
    }
}