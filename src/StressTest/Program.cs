using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.Devices;
using TablePlugin.Model.Kompas;
using TablePlugin.Model.Parameters;

namespace StressTest
{
    /// <summary>
    /// Класс,в котором проводят стресс тест.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var tableParameters = new TableParameters();
            TableBuilder tableBuilder = new TableBuilder();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var streamWriter = new StreamWriter("LogAfterStressTest.txt", 
                true);
            var count = 0;
            int maxTable = 100;
            for (int i = 0; i < maxTable; i++)
            {
                tableBuilder.Build(tableParameters, LegsType.RoundLegs);
                var computerInfo = new ComputerInfo();
                var usedMemory = (computerInfo.TotalPhysicalMemory 
                                  - computerInfo.AvailablePhysicalMemory) 
                                 / Math.Pow(1024, 3);
                streamWriter.WriteLine($"{++count}" +
                                       $"\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t" +
                                       $"{usedMemory}");
                streamWriter.Flush();
            }
            stopWatch.Stop();
            streamWriter.Close();
        }
    }
}
