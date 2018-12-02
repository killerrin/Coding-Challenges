using Killerrin.Toolkit.CMD.Managers;
using Killerrin.Toolkit.CMD.Menus;
using Killerrin.Toolkit.Core.Business;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdventOfCode2018.Challenges.Day1
{
    public class Day1Menu : Menu
    {
        private List<string> m_input = new List<string>();
        long totalElapsedMilliseconds = 0;

        public Day1Menu() : base("Day1")
        {
            OnNavigatingTo += Day1Menu_OnNavigatingTo;
            OnNavigatingFrom += Day1Menu_OnNavigatingFrom;
        }

        private void Day1Menu_OnNavigatingTo(object sender, object e)
        {
            // Refresh the Milliseconds
            totalElapsedMilliseconds = 0;

            // Start the Watch
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Get the Inputs
            var assembly = Assembly.GetAssembly(typeof(Day1Menu));
            m_input = AssemblyFileReader.ReadFile(assembly, @"AdventOfCode2018.Challenges.Day1.input.txt");

            // Stop the watch and calculate the time to run
            stopwatch.Stop();
            totalElapsedMilliseconds += stopwatch.ElapsedMilliseconds;
        }
        private void Day1Menu_OnNavigatingFrom(object sender, object e)
        {
            m_input = null;
        }

        public override void Run()
        {
            Console.Clear();

            // Begin the Timer
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Parse the Inputs to integers
            List<int> parsedInputs = m_input.Select(x =>
            {
                if (int.TryParse(x, out int i)) { return i; }
                return 0;
            }).ToList();

            // Calculate the Frequency
            int currentFrequency = 0;
            foreach (var i in parsedInputs)
            {
                currentFrequency += i;
            }

            // Stop the watch and calculate the time to run
            stopwatch.Stop();
            totalElapsedMilliseconds += stopwatch.ElapsedMilliseconds;

            // Print the Result and Exit
            Console.WriteLine($"The Final Frequency is: {currentFrequency}");
            Console.WriteLine($"It took {totalElapsedMilliseconds}ms to run");
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
            NavigationManager.Instance.GoBack();
        }
    }
}
