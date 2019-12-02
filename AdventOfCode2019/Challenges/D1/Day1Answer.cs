using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Challenges.D1
{
    public class Day1Answer
    {
        public void RunChallenge1()
        {
            var input = ChallengeHelper.LoadInput<int>("D1");
            int totalFuel = 0;
            foreach (var mass in input)
            {
                int fuel = CalculateFuel(mass);
                totalFuel += fuel;
            }

            Console.WriteLine($"Challenge 1: {totalFuel}");
        }

        public void RunChallenge2()
        {
            var input = ChallengeHelper.LoadInput<int>("D1");
            int totalFuel = 0;
            foreach (var mass in input)
            {
                int fuel = CalculateFuel(mass);
                totalFuel += fuel;

                while (fuel > 0)
                {
                    fuel = CalculateFuel(fuel);
                    if (fuel > 0)
                    {
                        totalFuel += fuel;
                    }
                }
            }

            Console.WriteLine($"Challenge 2: {totalFuel}");
        }

        private int CalculateFuel(int mass)
        {
            int fuel = (int)Math.Floor(((decimal)mass) / 3) - 2;
            return fuel;
        }

    }
}
