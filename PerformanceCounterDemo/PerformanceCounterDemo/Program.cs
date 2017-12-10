using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Timers;

namespace PerformanceCounterDemo
{
    class Program
    {
        private static PerformanceCounter heapCounter = null;
        private static PerformanceCounter exceptionCounter = null;
        private static Timer demoTimer;

        static void Main(string[] args)
        {
            demoTimer = new Timer(3000);
            demoTimer.Elapsed += new ElapsedEventHandler(OnTick);
            demoTimer.Enabled = true;

            heapCounter = new PerformanceCounter(".NET CLR Memory", "# Bytes in all Heaps");
            heapCounter.InstanceName = "_Global_";

            exceptionCounter = new PerformanceCounter(".NET CLR Exceptions", "# of Exceps Thrown");
            exceptionCounter.InstanceName = "_Global_";

            Console.WriteLine("Press [Enter] to Quit Program");
            Console.ReadLine();

        }

        private static void OnTick(object source, ElapsedEventArgs e)
        {

            Console.WriteLine("# of Bytes in all Heaps : " + heapCounter.NextValue().ToString());
            Console.WriteLine("# of Framework Exceptions Thrown : " + exceptionCounter.NextValue().ToString());
        }
    }
}
