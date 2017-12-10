using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AssemblyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\System.dll";
            Assembly assembly = Assembly.LoadFile(path);
            ShowAssembly(assembly);

            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            ShowAssembly(executingAssembly);

            Console.ReadKey();
        }

        static void ShowAssembly(Assembly assembly)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\nFull name: " + assembly.FullName);
            sb.Append("\nGlobal Assembly Cache: " + assembly.GlobalAssemblyCache);
            sb.Append("\nLocation: " + assembly.Location);
            sb.Append("\nImage Runtime Version: " + assembly.ImageRuntimeVersion);
            Console.WriteLine(sb);

            Console.WriteLine("Assembly modules: ");
            foreach (Module module in assembly.GetModules())
            {
                Console.WriteLine(module.Name);
            }
        }
    }
}
