using System;

namespace 징검다리
{
    class Program
    {
        static void Main(string[] args)
        {
            int solution(int distance, int[] rocks, int n)
            {
                Array.Sort(rocks);
                int[] Dis = new int[rocks.Length + 1];
                for(int i = 0; i<rocks.Length; i++)
                    Dis[i] = rocks[i];
                Dis[rocks.Length] = distance;
                int left = 0;
                int right = distance;
                int mid;
                while(left <= right)
                {
                    mid = (left + right) / 2;
                    int leftRock = 0;
                    int removed = 0;
                    foreach (int rock in Dis)
                    {
                        if ((rock - leftRock) <= mid)
                            removed++;
                        else
                            leftRock = rock;
                        if (removed > n)
                            break;
                    }
                    if (removed > n)
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                return left;
            }

            int distance1 = 25;
            int[] rocks1 = new int[] { 2, 14, 11, 21, 17 };
            int n1 = 2;
            Console.WriteLine(solution(distance1, rocks1, n1));
        }
    }
}
