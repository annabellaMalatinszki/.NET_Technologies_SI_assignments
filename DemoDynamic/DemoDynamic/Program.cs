using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace DemoDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyName assemblyName = new AssemblyName();
            assemblyName.Name = "DemoAssembly";
            assemblyName.Version = new Version("1.0.0.0");

            AppDomain appDomain = AppDomain.CurrentDomain;

            AssemblyBuilder assemblyBuilder = appDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.ReflectionOnly);

            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("CodeModule", "DemoAssembly.dll");

            TypeBuilder typeBuilder = moduleBuilder.DefineType("Animal", TypeAttributes.Public);

            Type animal = typeBuilder.CreateType();
            Console.WriteLine(animal.FullName);

            foreach (MemberInfo info in animal.GetMembers())
            {
                Console.WriteLine(" Member ({0}): {1}", info.MemberType, info.Name);

            }

            Console.ReadKey();
        }
    }
}
