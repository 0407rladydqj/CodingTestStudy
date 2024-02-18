using System;

namespace 산_모양_타일링
{
    class Program
    {
        static void Main(string[] args)
        {
            int solution(int n, int[] tops)
            {
                int[] bottom1 = new int[n + 1];
                int[] bottom2 = new int[n + 1];
                int answer = 0;
                bottom1[0] = 1;
                bottom2[0] = 0;
                for(int i = 1; i < n + 1; i++)
                {
                    bottom1[i] = (bottom1[i - 1] * 2 + bottom2[i - 1]) % 10007;
                    bottom2[i] = (bottom1[i - 1] + bottom2[i - 1]) % 10007;
                    if (tops[i - 1] == 1)
                    {
                        bottom1[i] += (bottom1[i - 1] + bottom2[i - 1]);
                        bottom1[i] %= 10007;
                    }
                }
                answer = (bottom1[n] + bottom2[n]) % 10007;
                return answer;
            }

            int n1 = 4;
            int[] tops1 = new int[] { 1, 1, 0, 1 };

            int n3 = 10;
            int[] tops3 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Console.WriteLine(solution(n1, tops1));
            Console.WriteLine(solution(n3, tops3));
        }
    }
}
