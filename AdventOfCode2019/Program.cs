using AdventOfCode2019.Challenges.D1;
using AdventOfCode2019.Challenges.D2;
using System;

namespace AdventOfCode2019
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.Write("Which Day? ");
                var cInput = Console.ReadLine();

                switch (cInput)
                {
                    case "1": new Day1Answer().RunChallenge1(); new Day1Answer().RunChallenge2(); break;
                    case "2": new Day2Answer().RunChallenge1(); new Day2Answer().RunChallenge2(); break;

                    case "e":
                    case "exit": 
                    case "-1":
                    default:
                        loop = false;
                        break;
                }

                Console.WriteLine("Press enter to clear....");
                Console.ReadLine();
            }
        }
    }
}
