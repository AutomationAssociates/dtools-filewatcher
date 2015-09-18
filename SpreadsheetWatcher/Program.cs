using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryMonitoringService service = new DirectoryMonitoringService();
            Console.ReadLine();
        }
    }
}
