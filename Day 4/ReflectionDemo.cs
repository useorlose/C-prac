using SampleConApp.Day2;
using System;
//Read the metadata of the DLL and load the DLL to my project...
using System.Reflection;
//Reflection is a library used to read the metadata of UR Classes and get its Type info at runtime. Similar to RTTI features. 
namespace SampleConApp.Day4
{
    class ReflectionDemo
    {
        const string dllname = @"C:\Users\CTEA\Documents\Phaniraj-LntTraining\LnTTraining\SampleDataLib\bin\Debug\SampleDataLib.dll";
        static void Main(string[] args)
        {
            //Load the dll into UR process dynamically...
            Assembly dll = Assembly.LoadFile(dllname);
            var classes = dll.GetTypes();
            foreach(var cls in classes)
            {
                Console.WriteLine(cls.FullName);
            }

            String classname = MyConsole.getString("Enter the Class U want to instantiate");
            Type selectedType = dll.GetType(classname, false, false);
            if(selectedType == null)
            {
                Console.WriteLine("This type is not found with us");
                return;
            }
            Console.WriteLine("The list of methods are ");
            foreach(var method in selectedType.GetMethods())
            {
                Console.WriteLine(method.Name);
            }
            Console.WriteLine("Please select the method from the list");
            MethodInfo selectedmethod = selectedType.GetMethod(Console.ReadLine());
            if(selectedmethod == null)
            {
                Console.WriteLine("not a valid method");
                return;  
            }
            Console.WriteLine("The list of paramters are:" );
            ParameterInfo[] parameters = selectedmethod.GetParameters();
            object[] pmValues = new object[parameters.Length];
            int index = 0;
            foreach(ParameterInfo pm in parameters)
            {
                Console.WriteLine(pm.Name);
                Console.WriteLine(pm.ParameterType.Name);
                Console.WriteLine("Enter the value for this parameter");
                string value = Console.ReadLine();
                pmValues[index] = Convert.ChangeType(value, pm.ParameterType);
                index++;
            }
            Console.WriteLine("All values are set");
            Console.WriteLine("Lets create the object...");
            object instance = Activator.CreateInstance(selectedType);
            object result = selectedmethod.Invoke(instance, pmValues);
            Console.WriteLine($"The result for {selectedmethod.Name} is {result}" + result);
        }
    }
}
