using AdventOfCode2019.Challenges.D1;
using AdventOfCode2019.Challenges.D2;
using AdventOfCode2019.Challenges.D3;
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
                    case "3": new Day3Answer().RunChallenge1(); new Day3Answer().RunChallenge2(); break;
                    //case "4": new Day4Answer().RunChallenge1(); new Day4Answer().RunChallenge2(); break;
                    //case "5": new Day5Answer().RunChallenge1(); new Day5Answer().RunChallenge2(); break;
                    //case "6": new Day6Answer().RunChallenge1(); new Day6Answer().RunChallenge2(); break;
                    //case "7": new Day7Answer().RunChallenge1(); new Day7Answer().RunChallenge2(); break;
                    //case "8": new Day8Answer().RunChallenge1(); new Day8Answer().RunChallenge2(); break;
                    //case "9": new Day9Answer().RunChallenge1(); new Day9Answer().RunChallenge2(); break;
                    //case "10": new Day10Answer().RunChallenge1(); new Day10Answer().RunChallenge2(); break;
                    //case "11": new Day11Answer().RunChallenge1(); new Day11Answer().RunChallenge2(); break;
                    //case "12": new Day12Answer().RunChallenge1(); new Day12Answer().RunChallenge2(); break;
                    //case "13": new Day13Answer().RunChallenge1(); new Day13Answer().RunChallenge2(); break;
                    //case "14": new Day14Answer().RunChallenge1(); new Day14Answer().RunChallenge2(); break;
                    //case "15": new Day15Answer().RunChallenge1(); new Day15Answer().RunChallenge2(); break;
                    //case "16": new Day16Answer().RunChallenge1(); new Day16Answer().RunChallenge2(); break;
                    //case "17": new Day17Answer().RunChallenge1(); new Day17Answer().RunChallenge2(); break;
                    //case "18": new Day18Answer().RunChallenge1(); new Day18Answer().RunChallenge2(); break;
                    //case "19": new Day19Answer().RunChallenge1(); new Day19Answer().RunChallenge2(); break;
                    //case "20": new Day20Answer().RunChallenge1(); new Day20Answer().RunChallenge2(); break;
                    //case "21": new Day21Answer().RunChallenge1(); new Day21Answer().RunChallenge2(); break;
                    //case "22": new Day22Answer().RunChallenge1(); new Day22Answer().RunChallenge2(); break;
                    //case "23": new Day23Answer().RunChallenge1(); new Day23Answer().RunChallenge2(); break;
                    //case "24": new Day24Answer().RunChallenge1(); new Day24Answer().RunChallenge2(); break;
                    //case "25": new Day25Answer().RunChallenge1(); new Day25Answer().RunChallenge2(); break;

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
