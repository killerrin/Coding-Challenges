using Killerrin.Toolkit.CMD.Managers;
using Killerrin.Toolkit.CMD.Menus;
using Killerrin.Toolkit.Core.Business;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdventOfCode2018.Challenges.Day3
{
    public class Day3Menu : Menu
    {
        private List<string> m_input = new List<string>();
        private List<Claim> m_importedClaims = new List<Claim>();

        long totalElapsedMilliseconds = 0;

        public Day3Menu() : base("Day3")
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
            m_input = AssemblyFileReader.ReadFile(assembly, @"AdventOfCode2018.Challenges.Day3.input.txt");


            // Parse the Inputs
            m_importedClaims = new List<Claim>();
            foreach (var item in m_input)
            {
                var claim = new Claim();
                int start = 0;
                int end = 0;

                // Get the ID
                start = item.IndexOf('#') + 1;
                end = item.IndexOf('@') - 1;
                var id = item.Substring(start, end - start);
                claim.ID = int.Parse(id);

                // Get the XY
                start = item.IndexOf('@') + 2;
                end = item.IndexOf(':');
                var xy = item.Substring(start, end - start);
                var xySplit = xy.Split(',');
                claim.X = int.Parse(xySplit[0]);
                claim.Y = int.Parse(xySplit[1]);

                // Get the WidthHeight
                start = item.IndexOf(':') + 2;
                end = item.Length;
                var widthHeight = item.Substring(start, end - start);
                var widthHeightSplit = widthHeight.Split('x');
                claim.Width = int.Parse(widthHeightSplit[0]);
                claim.Height = int.Parse(widthHeightSplit[1]);

                // Add the Claim to our list
                m_importedClaims.Add(claim);
            }

            // Stop the watch and calculate the time to run
            stopwatch.Stop();
            totalElapsedMilliseconds += stopwatch.ElapsedMilliseconds;
        }
        private void DayMenu_OnNavigatingFrom(object sender, object e)
        {
            m_input = null;
            m_importedClaims = null; ;
        }

        public override void Run()
        {
            Console.Clear();

            // Create our MultiDimensional Array
            List<Claim>[,] claims = new List<Claim>[1000, 1000];
            var copyImportedClaims = new List<Claim>(m_importedClaims);

            // Begin the Timer
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Add the claims to the Fabric
            foreach (var item in m_importedClaims)
            {
                // Get the Starting Positions
                var startX = item.X;
                var startY = item.Y;

                // For every index of width...
                for (int w = 0; w < item.Width; w++)
                {
                    // For every index of height...
                    for (int h = 0; h < item.Height; h++)
                    {
                        // Get the Index in the Array
                        var iX = startX + w;
                        var iY = startY + h;

                        // If the location doesn't exist, create it
                        if (claims[iX, iY] == null) { claims[iX, iY] = new List<Claim>(); }

                        // And add the claim to it
                        claims[iX, iY].Add(item);
                    }
                }

            }

            // Next Iterate through the fabric claims, and count all the lists where Count > 1
            int duplicateClaimsCount = 0;
            for (int x = 0; x < claims.GetLength(0); x++)
            {
                for (int y = 0; y < claims.GetLength(1); y++)
                {
                    if (claims[x, y] == null) continue;
                    if (claims[x, y]?.Count > 1)
                    {
                        duplicateClaimsCount++;
                        foreach (var item in claims[x, y])
                        {
                            copyImportedClaims.Remove(item);
                        }
                    }
                }
            }

            // Calculate no overlap
            var claimRemaining = copyImportedClaims[0];

            // Stop the watch and calculate the time to run
            stopwatch.Stop();
            totalElapsedMilliseconds += stopwatch.ElapsedMilliseconds;

            // Print the Result and Exit
            Console.WriteLine($"The number of duplicate claims is {duplicateClaimsCount}");
            Console.WriteLine($"The claim which does not overlap is {claimRemaining.ID}");
            Console.WriteLine($"It took {totalElapsedMilliseconds}ms to run");
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
            NavigationManager.Instance.GoBack();
        }
    }
}
