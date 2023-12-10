using System;

namespace 아방가르드_타일링
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] answers;
            int divide = 1000000007;
            int solution(int n)
            {
                answers = new long[100001];
                answers[0] = 1;
                answers[1] = answers[0];
                answers[2] = answers[1] + answers[0] * 2;
                answers[3] = answers[2] + answers[1] * 2 + answers[0] * 5;
                answers[4] = answers[3] + answers[2] * 2 + answers[1] * 5 + answers[0] * 2;
                answers[5] = answers[4] + answers[3] * 2 + answers[2] * 5 + answers[1] * 2 + answers[0] * 2;
                answers[6] = answers[5] + answers[4] * 2 + answers[3] * 5 + answers[2] * 2 + answers[1] * 2 + answers[0] * 4;
                for (int i = 7; i < answers.Length; i++)
                    answers[i] = (answers[i - 1] % divide + answers[i - 2] * 2 % divide + answers[i - 3] * 5 % divide + special(i - 4)) % divide;
                return (int)answers[n];
            }

            int[] spe = new int[] { 2, 2, 4 };
            long[] spes = new long[] { 2, 4, 12 };
            long special(int n)
            {
                long answer = 0;
                int sp = 0;
                for(int i = n; (n - 2) <= i; i--)
                {
                    answer += (answers[i] * spe[sp]) % divide;
                    sp++;
                    sp = sp % 3;
                }
                spes[n % 3] += answer;
                spes[n % 3] = spes[n % 3] % divide;
                return spes[n % 3] % divide;
            }

            Console.WriteLine(solution(10));
        }
    }
}
