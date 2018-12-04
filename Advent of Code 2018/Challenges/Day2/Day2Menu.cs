using Killerrin.Toolkit.CMD.Managers;
using Killerrin.Toolkit.CMD.Menus;
using Killerrin.Toolkit.Core.Business;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdventOfCode2018.Challenges.Day2
{
    public class Day2Menu : Menu
    {
        private List<string> m_input = new List<string>();
        long totalElapsedMilliseconds = 0;

        public Day2Menu() : base("Day2")
        {
            OnNavigatingTo += DayMenu_OnNavigatingTo;
            OnNavigatingFrom += DayMenu_OnNavigatingFrom;
        }

        private void DayMenu_OnNavigatingTo(object sender, object e)
        {
            // Refresh the Milliseconds
            totalElapsedMilliseconds = 0;

            // Start the Watch
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Get the Inputs
            var assembly = Assembly.GetAssembly(typeof(Program));
            m_input = AssemblyFileReader.ReadFile(assembly, @"AdventOfCode2018.Challenges.Day2.input.txt");

            // Stop the watch and calculate the time to run
            stopwatch.Stop();
            totalElapsedMilliseconds += stopwatch.ElapsedMilliseconds;
        }
        private void DayMenu_OnNavigatingFrom(object sender, object e)
        {
            m_input = null;
        }

        public override void Run()
        {
            Console.Clear();

            // Begin the Timer
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Stop the watch and calculate the time to run
            stopwatch.Stop();
            totalElapsedMilliseconds += stopwatch.ElapsedMilliseconds;

            // Print the Result and Exit
            Console.WriteLine($"It took {totalElapsedMilliseconds}ms to run");
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
            NavigationManager.Instance.GoBack();
        }
    }
}
