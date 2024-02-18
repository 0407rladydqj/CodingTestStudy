using System;
using System.Collections.Generic;

namespace 유사_칸토어_비트열
{
    class Program
    {
        static void Main(string[] args)
        {
            int solution(int n, long l, long r)
            {
                int answer = 0;
                for(long i = l - 1; i<r; i++)
                {
                    if (one(i) == true)
                        answer++;
                }
                return answer;
            }

            bool one(long l)
            {
                if (l % 5 == 2)
                    return false; // 0임
                if (l < 5)
                    return true; // 1임
                //루트로 이동하는 느낌
                return one(l / 5);
            }

            int n1 = 2;
            long l1 = 4;
            long r1 = 17;
            Console.WriteLine(solution(n1, l1, r1));
        }
    }
}
