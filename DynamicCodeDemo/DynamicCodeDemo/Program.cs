using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DynamicCodeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\System.Web.dll";
            Assembly assembly = Assembly.LoadFrom(path);
            Type assemblyType = assembly.GetType("System.Web.HttpUtility");

            MethodInfo decode = assemblyType.GetMethod("HtmlDecode", new Type[] { typeof(string)});
            MethodInfo encode = assemblyType.GetMethod("HtmlEncode", new Type[] { typeof(string)});

            string toEncode = "<&>";
            Console.WriteLine("Original string: {0}", toEncode);

            string encoded = (string)encode.Invoke(null, new object[] { toEncode });
            Console.WriteLine("Encoded string: {0}", encoded);

            string decoded = (string)decode.Invoke(null, new object[] { encoded });
            Console.WriteLine("Decoded string: {0}", decoded);

            Console.ReadKey();
        }
    }
}
