using SampleConApp.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp.Day3
{
    class Customer : IComparable<Customer>
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string  CustomerCity { get; set; }

        public override string ToString()
        {
            return string.Format($"The Name:{CustomerName}\nAddress: {CustomerCity}\nCustomer ID: {CustomerID}");
        }
        public int CompareTo(Customer other)
        {
            //if (this.CustomerID < other.CustomerID)
            //    return -1;
            //else if (this.CustomerID > other.CustomerID)
            //    return 1;
            //else return 0;
            return this.CustomerID.CompareTo(other.CustomerID);
        }
    }

    class CustomerComparer : IComparer<Customer>
    {
        private string criteria = string.Empty;

        public CustomerComparer(string criteria)
        {
            this.criteria = criteria;
        }
        public int Compare(Customer x, Customer y)
        {
            switch (criteria)
            {
                case "Name":
                    return x.CustomerName.CompareTo(y.CustomerName);
                case "Address":
                    return x.CustomerCity.CompareTo(y.CustomerCity);
                default:
                    return x.CompareTo(y);
            }
        }
    }
    class ComparingObjects
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { CustomerCity = "Bangalore", CustomerID = 143, CustomerName = "Anand P Sharma" });
            customers.Add(new Customer { CustomerCity = "Mysore", CustomerID = 184, CustomerName = "Mohit Kumar" });
            customers.Add(new Customer { CustomerCity = "Chennai", CustomerID = 125, CustomerName = "Srujjan" });
            customers.Add(new Customer { CustomerCity = "Agra", CustomerID = 126, CustomerName = "Sampath" });
            customers.Add(new Customer { CustomerCity = "Mumbai", CustomerID = 117, CustomerName = "Antony" });
            customers.Add(new Customer { CustomerCity = "Pune", CustomerID = 132, CustomerName = "Siad" });
            customers.Add(new Customer { CustomerCity = "Hyderabad", CustomerID = 129, CustomerName = "Joe Biden" });
            customers.Add(new Customer { CustomerCity = "Coimbatore", CustomerID = 133, CustomerName = "Sam Jackson" });

            string input = MyConsole.getString("Enter the criteria of Comparing");
            IComparer<Customer> comparer = new CustomerComparer(input);
            customers.Sort(comparer);

            foreach(var cst in customers)
                Console.WriteLine(cst);//cst.ToString();
        }
    }
}
