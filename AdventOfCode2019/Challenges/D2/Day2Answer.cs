using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Challenges.D2
{
    public class Day2Answer
    {
        public void RunChallenge1()
        {
            var input = ChallengeHelper.LoadSingleLineInput<int>("D2", ',');
            input[1] = 12;
            input[2] = 2;

            CalculateIntCode(input);
            Console.WriteLine($"Challenge 1: Position 0 == {input[0]}");
        }

        public void RunChallenge2()
        {
            const int ANSWER = 19690720;
            int noun = 0;
            int verb = 0;
            int output = 0;

            for (noun = 0; noun < 99; noun++)
            {
                for (verb = 0; verb < 99; verb++)
                {
                    var input = ChallengeHelper.LoadSingleLineInput<int>("D2", ',');
                    input[1] = noun;
                    input[2] = verb;
                    CalculateIntCode(input);
                    output = input[0];

                    if (output == ANSWER) { break; }
                }

                if (output == ANSWER) { break; }
            }

            Console.WriteLine($"Challenge 2: noun={noun}, verb={verb}, output={output}, answer={100*noun+verb}");
        }

        private void CalculateIntCode(List<int> input)
        {
            int i = 0;
            while (true)
            {
                int opCode = input[i];
                int inPos1 = input[i + 1];
                int inPos2 = input[i + 2];
                int outPos1 = input[i + 3];

                switch (opCode)
                {
                    case 1:
                        {
                            int in1 = input[inPos1];
                            int in2 = input[inPos2];
                            int out1 = in1 + in2;
                            input[outPos1] = out1;
                            break;
                        }
                    case 2:
                        {
                            int in1 = input[inPos1];
                            int in2 = input[inPos2];
                            int out1 = in1 * in2;
                            input[outPos1] = out1;
                            break;
                        }
                    case 99: return;
                }

                i += 4;
            }
        }
    }
}
