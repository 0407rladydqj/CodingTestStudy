using System;

namespace 터렛
{
    class Program
    {
        static void Main(string[] args)
        {
            int Try = int.Parse(Console.ReadLine());
            int[][] input = new int[Try][];
            for(int i = 0; i<Try; i++)
                input[i] = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
        }
    }
}
