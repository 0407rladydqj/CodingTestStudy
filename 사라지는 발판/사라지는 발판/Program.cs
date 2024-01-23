using System;

namespace 사라지는_발판
{
    class Program
    {
        static void Main(string[] args)
        {
            int solution(int[,] board, int[] aloc, int[] bloc)
            {
                int answer = -1;
                return answer;
            }



            int[,] board1 = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            int[] aloc1 = { 1, 0 };
            int[] bloc1 = { 1, 2 };

            int[,] board3 = { { 1, 1, 1, 1, 1 } };
            int[] aloc3 = { 0, 0 };
            int[] bloc3 = { 0, 4 };

            int[,] board4 = { { 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 0, 0 } };
            int[] aloc4 = { 0, 0 };
            int[] bloc4 = { 0, 4 };
            Console.WriteLine(solution(board1, aloc1, bloc1));
            Console.WriteLine(solution(board3, aloc3, bloc3));
            Console.WriteLine(solution(board4, aloc4, bloc4));
        }
    }
}
