﻿using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using SampleConApp.Day2;
/*
Serialiation is a feature of persisiting an object state to a storage device like memory, file, database and retreiveing it to the same state from which it was saved. It is helpfull for IPC applicationss where one app will serialize the data while the other deserializes the data and reads it from there. 
In serialization, U not only read the data but also the metadata of the object that includes namespaces, assemblies, properties, internal fields and many more. 
In .NET there are 3 types of serialization:
XML serialization, Binary serialization, SOAP serialization(web services).
Binary serialization is used for serializing data in and out of Windows OS only
XML is used for multiple platforms. 
Web services uses SOAP for serializing data across its services. 
We use attributes to provide serialization to an object. 
Steps of serialization:
What: What object U should serialize?
How: Whether it is XML or SOAP or Binary?
Where: File, Memory...
Any object whose class has an attribute called Serializable can be used to serialize the data in binary format. The class should be public for XML serialization. 
U could use classes like BinaryFormatter to serialize the object as Binary, XmlSerializer class to serialize the object as XML. 
We could use FileStream to serialize the data into a file.
A public class is available across the project, if no public is given, it is implicitly called internal. internal means available only within the project 
*/
namespace SampleConApp.Day4
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }

        public override string ToString()
        {
            return string.Format($"The name: {Name} from {Address} is available at {Phone}");
        }
    }
    class Serialization
    {
        static void Main(string[] args)
        {
            binaryExample();
            //xmlExample();
            Console.ReadKey();
        }

        private static void binaryExample()
        {
            Console.WriteLine("What do U want to do today: Read or Write");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "read")
                deserializing();
            else
                serializing();
           // serializing();
           // deserializing();
        }

        private static void deserializing()
        {
            FileStream fs = new FileStream("Demo.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter fm = new BinaryFormatter();
            Student s  = fm.Deserialize(fs) as Student;
            Console.WriteLine(s.Name);
            fs.Close();
        }

        private static void serializing()
        {
            //What to serialize:
            Student s = new Student { Address = "Mysore", Name = "Martin", Phone = 23423423 };
            //how to serialize:
            BinaryFormatter fm = new BinaryFormatter();
            //Where to serialize:
            FileStream fs = new FileStream("Demo.bin", FileMode.OpenOrCreate, FileAccess.Write);
            fm.Serialize(fs, s);
            fs.Close();
        }

        private static void xmlExample()
        {
            Console.WriteLine("What do U want to do today: Read or Write");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "read")
                deserializingXml();
            else
                serializingXml();
        }

        private static void deserializingXml()
        {
            try
            {
                XmlSerializer sl = new XmlSerializer(typeof(Student));
                FileStream fs = new FileStream("Data.xml", FileMode.Open, FileAccess.Read);
                Student s = (Student)sl.Deserialize(fs);
                //old style type casting(UNBOXING)
                Console.WriteLine(s);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void serializingXml()
        {
            Student s = new Student();
            s.Name = MyConsole.getString("Enter the name");
            s.Address = MyConsole.getString("Enter the address");
            s.Phone = MyConsole.getNumber("Enter the landline Phone no");
            FileStream fs = new FileStream("Data.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer sl = new XmlSerializer(typeof(Student));
            sl.Serialize(fs, s);
            fs.Flush();//Clears the buffer into the destination so that no unused stream is left over before U close the Stream...
            fs.Close();

        }
    }
}
/*
Limits of serialization:
data can easily get corruptted. 
File reading and writing is not good for multi user environment. 
While writing U will not be able to read the data. 
If more users are using the program, scalability becomes a problem.
These limits are handled if U store the data in an external software called database...
*/
