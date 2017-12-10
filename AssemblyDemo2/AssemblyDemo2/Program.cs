using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AssemblyDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\System.ServiceProcess.dll";
            BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance;
            Assembly assembly = Assembly.LoadFrom(path);

            Console.WriteLine(assembly.FullName);
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                Console.WriteLine("\nNAME: {0}", type.FullName);
                var members = type.GetMembers(flags);
                foreach (var member in members)
                {
                    Console.WriteLine("Member name: {0}, member type: {1}", member.Name, member.MemberType);
                }
            }

            Console.ReadKey();
        }
    }
}
