using System;

namespace 올바른_괄호의_갯수
{
    class Program
    {
        static void Main(string[] args)
        {
            int solution(int n)
            {
                int[] OneBlock = new int[15];
                int[] MixBlock = new int[15];
                OneBlock[0] = 0;
                OneBlock[1] = 1;
                OneBlock[2] = 1;

                MixBlock[0] = 0;
                MixBlock[1] = 0;
                MixBlock[2] = 1;
                for (int i = 3; i < OneBlock.Length; i++)
                {
                    OneBlock[i] = OneBlock[i - 1] + MixBlock[i - 1];
                    for (int j = 1; j < i; j++)
                        MixBlock[i] += OneBlock[j] * (OneBlock[i - j] + MixBlock[i - j]);
                }
                return OneBlock[n] + MixBlock[n];
            }

            solution(5);
        }
    }
}
