using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TraceEventLog
{
    class Program
    {
        static void Main(string[] args)
        {
            EventLog MyLog = new EventLog("X", "localhost", "Demo");
            Trace.AutoFlush = true;
            EventLogTraceListener MyListener = new EventLogTraceListener(MyLog);
            Trace.WriteLine("This is a test");

            //i dont know how to view the event log :(

        }
    }
}
