using System;
using System.Linq;

namespace 두_큐_합_같게_만들기
{
    class Program
    {
        static void Main(string[] args)
        {
            int solution(int[] queue1, int[] queue2)
            {
                long now = 0;
                foreach (int i in queue1)
                    now += (long)i;
                long dis = now;
                foreach (int i in queue2)
                    dis += (long)i;

                dis /= 2;
                int left = 0;
                int right = queue1.Length;
                int end = queue1.Length + queue2.Length;
                int[] Allqueue = queue1.Concat(queue2).ToArray();
                int answer = 0;

                int circle = 0;
                while(now != dis)
                {
                    //한쪽 큐가 0인 상황
                    if(left == right) { answer = -1; break; }
                    //한바퀴쯤 돌아서 안되면 없는거 아닐까 근데 반바퀴만 돌아도 안되더라;;
                    if(circle > 1) { answer = -1; break; }

                    if (now < dis)
                    {
                        now += Allqueue[right];
                        right += 1;
                    }
                    else if(now > dis)
                    {
                        now -= Allqueue[left];
                        left += 1;
                    }
                    if (right == end) { right = 0; circle += 1; }
                    if (left == end) { left = 0; circle += 1; }
                    answer += 1;
                }
                return answer;
            }

            int[] Queue1 = new int[] { 1, 1 };
            int[] Queue2 = new int[] { 1, 5 };

            Console.WriteLine(solution(Queue1, Queue2));
        }
    }
}
