using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AssemblyAttrDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type assemblyType = typeof(AssemblyDescriptionAttribute);
            Object[] customAttributes = assembly.GetCustomAttributes(assemblyType, false);
            if (customAttributes.Length > 0)
            {
                AssemblyDescriptionAttribute description = (AssemblyDescriptionAttribute)customAttributes[0];
                Console.WriteLine(description.Description);
            }

            Console.ReadKey();
        }
    }
}
