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

            // Create a Dictionary of the previously calculated results;
            // Dictionary<CalculatedFrequency, Object>
            Dictionary<int, object> frequencies = new Dictionary<int, object>();

            // Parse the Inputs to integers
            List<int> parsedInputs = m_input.Select(x =>
            {
                if (int.TryParse(x, out int i)) { return i; }
                return 0;
            }).ToList();

            // Begin the Timer
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Calculate the Frequency
            int currentFrequency = 0;
            int duplicatedFrequency = int.MinValue;

            // Loop until the Duplicated Frequency is found
            while (duplicatedFrequency == int.MinValue)
            {
                // Go through all the inputs
                for (int i = 0; i < parsedInputs.Count; i++)
                {
                    // Calculate the Frequency
                    currentFrequency += parsedInputs[i];

                    // Check if the Frequency is in our dictionary
                    if (frequencies.ContainsKey(currentFrequency))
                    {
                        // If it is, mark the first duplicate and exit
                        duplicatedFrequency = currentFrequency;
                        break;
                    }

                    // Save the Frequency to the Dictionary
                    frequencies[currentFrequency] = new object();
                }
            }

            // Stop the watch and calculate the time to run
            stopwatch.Stop();
            totalElapsedMilliseconds += stopwatch.ElapsedMilliseconds;

            // Print the Result and Exit
            Console.WriteLine($"The Duplicate Frequency is: {duplicatedFrequency}");
            Console.WriteLine($"It took {totalElapsedMilliseconds}ms to run");
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
            NavigationManager.Instance.GoBack();
        }
    }
}
