using Killerrin.Toolkit.Core.Business;
using Killerrin.Toolkit.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AdventOfCode2019.Challenges
{
    public static class ChallengeHelper
    {
        public static List<string> LoadInput(string challenge)
        {
            // Get the Inputs
            var assembly = Assembly.GetAssembly(typeof(Program));
            return AssemblyFileReader.ReadFile(assembly, $@"AdventOfCode2019.Challenges.{challenge}.input.txt");
        }

        public static List<T> LoadInput<T>(string challenge)
        {
            List<T> newInput = new List<T>();
            var input = LoadInput(challenge);
            foreach (var item in input)
            {
                var tItem = TypeHelpers.TryParse<T>(item);
                newInput.Add(tItem);
            }

            return newInput;
        }

        public static List<T> LoadSingleLineInput<T>(string challenge, char separator)
        {
            List<T> newInput = new List<T>();
            var input = LoadInput(challenge)[0].Split(separator);
            foreach (var item in input)
            {
                var tItem = TypeHelpers.TryParse<T>(item);
                newInput.Add(tItem);
            }

            return newInput;
        }
    }
}
