using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EventLogDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!EventLog.SourceExists("Demo", "DESKTOP-1HDILI5"))
            {
                EventLog.CreateEventSource("Demo", "Application", "DESKTOP-1HDILI5");
            }
            EventLog LogDemo = new EventLog("Application", "DESKTOP-1HDILI5", "Demo"); LogDemo.WriteEntry("Event Written to Application Log", EventLogEntryType.Information, 234, Convert.ToInt16(3));

            // printing LogEntries t console
            foreach (EventLogEntry log in LogDemo.Entries)
            {
                Console.WriteLine(log.Message);
            }

            Console.ReadKey();
        }
    }
}
