/*
Arrays are fixed in size, they are not dynamic. Once U create an array, it cannot be modified.
Collections are classes created to solve these problems and create dynamic arrays. There are different ways of collections depending on how U use the data structure. FIFO, key-value pairs, unique values and so forth...
We are using the latest version of collections called Generics, similar to Templates of C++
Internally all generics are collection classes which implement a set of interfaces to achieve that functionality of dynamic sizing. 
Collection means a group of objects that meet a common criteria and will be iterable thro it. 
*/
using SampleConApp.Day2;
using System;
using System.Collections.Generic;//Contains the classes required to store data in collections...
using System.Linq;
namespace SampleConApp.Day3
{
    class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }

        public override int GetHashCode()
        {
            return EmpID.GetHashCode();
        }
        //Checks the equality of the object with the comparing object
        public override bool Equals(object obj)
        {
            //When U have an object of the type Object, U could check if it is any subtype..
            if(obj is Employee)
            {
                Employee temp = obj as Employee;//Typecastin of Reference types in C#..
                return this.EmpID == temp.EmpID;
            }
            return false;
            
        }
    }
    class CollectionExample
    {
        static void Main(string[] args)
        {
            //ListExample();
            //hashsetExample();
            //hashsetOnobjects();
            //DictionaryExample();
            //QueueExample();
            
        }

        private static void hashsetOnobjects()
        {
            HashSet<Employee> data = new HashSet<Employee>();

            data.Add(new Employee { EmpID = 123, EmpName = "Phaniraj" });
            if(data.Add(new Employee { EmpID = 123, EmpName = "Phaniraj" }))
                Console.WriteLine("added"); 
            else
                Console.WriteLine("duplicate");
            data.Add(new Employee { EmpID = 123, EmpName = "Phaniraj" });
            data.Add(new Employee { EmpID = 123, EmpName = "Phaniraj" });
            Console.WriteLine("Data Count: " + data.Count);
        }

        private static void QueueExample()
        {
            Queue<string> recentItems = new Queue<string>();
            do
            {
                string item = MyConsole.getString("Enter the Item to view");
                if (recentItems.Count == 3)
                    recentItems.Dequeue();//Removes the first item in the queue.
                recentItems.Enqueue(item);
                Console.WriteLine("Ur recently viewed items:");
                var iterator = recentItems.Reverse();
                foreach(string obj in iterator)
                    Console.WriteLine(obj);
            } while (true);
        }

        private static void DictionaryExample()
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            bool adding = true;
            do
            {
                Tryagain:
                string username = MyConsole.getString("Enter a Username for UR login");
                string pwd = MyConsole.getString("Enter the Password");
                if (users.ContainsKey(username))
                {
                    Console.WriteLine("User already exists\nPlease try again");
                    goto Tryagain;
                }
                else
                {
                    users[username] = pwd;
                }
                string choice = MyConsole.getString("Press A to add or any key to leave");
                adding = choice.ToUpper() == "A" ? true : false;
            } while (adding);

            Console.WriteLine("Lets allow the user to log...");
            string uname = MyConsole.getString("Enter a Username for UR login");
            string upwd = MyConsole.getString("Enter the Password");
            if (users.ContainsKey(uname))
            {
                if(users[uname] == upwd)
                    Console.WriteLine("Welcome user!!!!");
                else
                    Console.WriteLine("Password is wrong!!!!");
            }else
                Console.WriteLine("user name is wrong!!!!");
        }

        private static void hashsetExample()
        {
            //Similar to list, but stores only unique values. Lists can have duplicates as list does not check for uniqueness.
            HashSet<string> set = new HashSet<string>();
            set.Add("Apple");       
            set.Add("Mango");       
            set.Add("Orange");       
            set.Add("Apple");//Duplicates will not be added       
            set.Add("Apple");
            Console.WriteLine("The size is " + set.Count);
            //Add returns bool to check if added or not. 
            //U can add, remove,update or do any CRUD operations like we do with a list.
        }

        private static void ListExample()
        {
            //RemoveAt, Insert, InsertAt, ToArray functions, Count
            List<string> fruits = new List<string>();
            //list is similar to array but with extra methods to add, remove, insert, removeat and perform some common operations.
            fruits.Add("Apple"); //adds the new item to the bottom of the list.
            fruits.Add("Mango"); 
            fruits.Add("Orange"); 
            fruits.Add("PineApple");
            fruits.Remove("Orange");//Removes the specific element from the list. 
            foreach (var item in fruits) Console.WriteLine(item);

            for (int i = 0; i < fruits.Count; i++)
            {
                Console.WriteLine(fruits[i]);
            }
        }
    }
}