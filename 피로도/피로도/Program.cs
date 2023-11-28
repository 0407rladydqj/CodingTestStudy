using System;

namespace 피로도
{
    class Program
    {
        static void Main(string[] args)
        {
            int answer = 0;
            bool[] Cleared = new bool[] { };
            int[,] dun = new int[,] { };

            int solution(int k, int[,] dungeons)
            {
                Cleared =  new bool[dungeons.GetLength(0)];
                dun = dungeons;
                Try(k, 0);
                return answer;
            }

            void Try(int SP, int count)
            {
                for (int i = 0; i < dun.GetLength(0); i++)
                {
                    if (Cleared[i] == false && dun[i, 0] <= SP)
                    {
                        Cleared[i] = true;
                        Try(SP - dun[i, 1], count + 1);
                        Cleared[i] = false;
                    }
                }
                answer = Math.Max(answer, count);
            }

            int K = 80;
            int[,] Dungeons = new int[,] { { 80, 20 },{ 50, 40 },{ 30, 10 } };

            int K2 = 100;
            int[,] Dungeons2 = new int[,] { { 80,8},{ 90,9},{ 100,10} };
            Console.WriteLine(solution(K, Dungeons));
        }
    }
}
