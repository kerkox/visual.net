using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulo2TracingLogging
{
    enum EstadoTransaccion {
        Iniciada,
        Cerrada,
        EnProceso
    }

    public class S1esaTraceListener : TraceListener
    {
        public override void Write(string message)
        {
            Console.Write("SIESA {0}", message);
        }

        public override void WriteLine(string message)
        {
            Console.WriteLine("SIESA {0}", message);
        }
    }

    public class S1esa2TraceListener : IComparable
    {
        int IComparable.CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Debug.AutoFlush = true;
            Trace.AutoFlush = true;


            Debug.Listeners.Add(new S1esaTraceListener());
            Debug.Listeners.Add(new TextWriterTraceListener("s1iesademo.log"));
            Debug.WriteLine("Escribiendo mensaje desde debug");
            Trace.WriteLine("Escribiendo mensaje desde trace");
            

            //DemoTraceDebug();
            //DemoPerfMon();
            
            //DemoEventViewer();
            //DemoCompilacionCondicional();


            bool esProduccion = true;
#if MIGRACION
            esProduccion = false;
            //DemoEventViewer();
#endif
            Console.ReadLine();
        }

        [Conditional("DEBUG")]
        private static void DemoEventViewer()
        {
            Console.WriteLine("Entrando a demo event viewer");
            EventLog.WriteEntry("DemoMod02", "Realizando demo 2", EventLogEntryType.Warning);


            if (EventLog.SourceExists("Demo02"))
            {
                EventLog.CreateEventSource("Demo02", "DemosEventLog");
                EventLog.WriteEntry("Demo02", "Realizando demo 2 en el log", EventLogEntryType.Information);
            }
        }

#if DEBUG
        private static void DemoCompilacionCondicional()
        {
            Console.WriteLine("Entrando a demo event viewer");
            EventLog.WriteEntry("DemoMod02", "Realizando demo 2", EventLogEntryType.Warning);


            if (EventLog.SourceExists("Demo02"))
            {
                EventLog.CreateEventSource("Demo02", "DemosEventLog");
                EventLog.WriteEntry("Demo02", "Realizando demo 2 en el log", EventLogEntryType.Information);
            }
        }
#endif
    
        private static void DemoPerfMon()
        {
            if (!PerformanceCounterCategory.Exists("FourthCoffeeOrders"))
            {
                CounterCreationDataCollection counters = new CounterCreationDataCollection();

                CounterCreationData totalOrders = new CounterCreationData();
                totalOrders.CounterName = "# Orders";
                totalOrders.CounterHelp = "Total number of orders placed";
                totalOrders.CounterType = PerformanceCounterType.NumberOfItems32;
                counters.Add(totalOrders);

                CounterCreationData ordersPerSecond = new CounterCreationData();
                ordersPerSecond.CounterName = "# Orders/Sec";
                ordersPerSecond.CounterHelp = "Number of orders placed per second";
                ordersPerSecond.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
                counters.Add(ordersPerSecond);

                PerformanceCounterCategory.Create("FourthCoffeeOrders", "A custom category for demonstration",
                PerformanceCounterCategoryType.SingleInstance, counters);
            }

            // Get a reference to the custom performance counters.
            PerformanceCounter counterOrders = new PerformanceCounter("FourthCoffeeOrders", "# Orders", false);
            PerformanceCounter counterOrdersPerSec = new PerformanceCounter("FourthCoffeeOrders", "# Orders/Sec", false);
            // Update the performance counter values at appropriate points in your code.
            counterOrders.Increment();
            counterOrdersPerSec.Increment();
        }

        private static void DemoTraceDebug()
        {
            int number;
            Console.WriteLine("Please type a number between 1 and 10, and then press Enter");
            string userInput = Console.ReadLine();
            Debug.Assert(int.TryParse(userInput, out number),
               string.Format("Unable to parse {0} as integer", userInput));
            Debug.WriteLine("The current value of userInput is: { 0}", userInput);
            Debug.WriteLine("The current value of number is: { 0}", number);
            Trace.WriteLine("Aparece tanto en modo debug como en release");
            Console.WriteLine("Press Enter to finish");
            Console.ReadLine();
        }

        public static void DemoAssert(EstadoTransaccion estado)
        {
            switch (estado)
            {
                case EstadoTransaccion.Iniciada:
                    Console.WriteLine("caso iniciado");
                    break;
                case EstadoTransaccion.Cerrada:
                    Console.WriteLine("caso iniciado");
                    break;
                default:
                    Debug.Assert(false, "Este estado no se supone que deberia existir");
                    break;
            }
        }
    }
}