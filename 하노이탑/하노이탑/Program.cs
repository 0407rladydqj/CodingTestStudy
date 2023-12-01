using System;
using System.Collections.Generic;

namespace 하노이탑
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> track = new List<int[]>();
            int[,] solution(int n)
            {
                Hanoi(n, 1, 2, 3);
                int[,] answer = new int[track.Count, 2];
                for(int i = 0; i<track.Count; i++)
                {
                    answer[i, 0] = track[i][0];
                    answer[i, 1] = track[i][1];
                }
                return answer;
            }

            void Hanoi(int num, int from, int sub, int to)
            {
                if (num == 0)
                    return;
                else
                {
                    //옮길게 여러개인 경우 위에꺼 다 치우는 판정
                    Hanoi(num - 1, from, to, sub);
                    //다 치우고 옮김
                    track.Add(new int[] { from, to });
                    //옮긴거에서 다시 목표지점으로
                    Hanoi(num - 1, sub, from, to);
                }
            }
            solution(2);
        }
    }
}
