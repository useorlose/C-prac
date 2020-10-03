using System;

namespace SampleConApp.Day2
{
    //Super class or Base class or Parent Class
    class Account
    {
        static int no = 111;
        public Account()
        {
            AccountNo = no;
            no++;
            Balance = 5000;//Min Balance to open an Account
        }
        public int AccountNo { get; private set; }
        public string AccountHolder { get; set; }
        public double Balance { get; private set; }//only get is new in C# 6.0

        //Lambda Expression
        public void Credit(double amount) => Balance += amount;
       
        public void Debit(double amount)
        {
            if (amount > Balance)
                throw new Exception("Insufficient Funds");
            else
                Balance -= amount;
        }

    }
    //Derived class or sub class or child class will modify or add new functions to the base class
    class SBAccount : Account
    {
        //It inherits all the public, internal  and protected members into the current class..
        public void CalculateInterest()
        {
            double quarter = 0.25;
            double interestRate = 6.5 / 100;
            double interest = Balance * quarter * interestRate;
            Credit(interest);
        }
    }
    class InheritanceDemo
    {
        static void Main(string[] args)
        {
            Account acc = new Account();

            SBAccount sb = new SBAccount();
            sb.AccountHolder = MyConsole.getString("Enter the Name");
            sb.CalculateInterest();
            Console.WriteLine("The Current Balance: " + sb.Balance);
            
        }
    }
}
/*
C# supports only one base class at any level(Single Inheritance).
The Base class functions can be modified in the derived class only if the base class version has a modifier called virtual. 
C# does not support private inheritance. It supports general inheritance. 
*/
