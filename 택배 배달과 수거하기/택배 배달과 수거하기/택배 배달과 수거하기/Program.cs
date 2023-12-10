using System;
using System.Linq;

namespace 택배_배달과_수거하기
{
    class Program
    {
        static void Main(string[] args)
        {
            long solution(int cap, int n, int[] deliveries, int[] pickups)
            {
                long answer = 0;
                int delSum = deliveries.Sum();
                int picSum = pickups.Sum();

                
                while ((delSum + picSum) > 0)
                {
                    int go = 0;
                    int back = cap;
                    int range = n;

                    //몇개 들고갈지
                    if (delSum >= cap) { go = cap; delSum -= cap; }
                    else { go = delSum; delSum = 0; }
                    //몇개 가지고 올지
                    if (picSum >= cap) { back = cap; picSum -= cap; }
                    else { back = picSum; picSum = 0; }

                    int toAdd = 0;

                    for (int i = range - 1; i >= 0; i--)
                    {
                        if (deliveries[i] == 0 && pickups[i] == 0)
                            continue;

                        toAdd = Math.Max(toAdd, i + 1);

                        if ((go + back) == 0)
                            break;
                        if (deliveries[i] > 0 && go != 0)
                        {
                            if (deliveries[i] <= go)
                            {
                                int c = deliveries[i];
                                deliveries[i] = 0;
                                go -= c;
                            }
                            else
                            {
                                deliveries[i] -= go;
                                go = 0;
                            }
                        }
                        if (pickups[i] > 0 && back != 0)
                        {
                            if (pickups[i] <= back)
                            {
                                int c = pickups[i];
                                pickups[i] = 0;
                                back -= c;
                            }
                            else
                            {
                                pickups[i] -= back;
                                back = 0;
                            }
                        }
                    }
                    n = toAdd;
                    answer += (long)toAdd * 2;
                }
                return answer;
            }

            int cap1 = 4;
            int n1 = 5;
            int[] deliveries1 = new int[] { 1, 0, 3, 1, 2 };
            int[] pickups1 = new int[] { 0, 3, 0, 4, 0 };

            int cap2 = 2;
            int n2 = 7;
            int[] deliveries2 = new int[] { 1, 0, 2, 0, 1, 0, 2 };
            int[] pickups2 = new int[] { 0, 2, 0, 1, 0, 2, 0 };

            int cap3 = 1;
            int n3 = 5;
            int[] deliveries3 = new int[] { 0, 0, 1, 0, 0 };
            int[] pickups3 = new int[] { 0, 0, 0, 0, 0 };

            int cap4 = 3;
            int n4 = 2;
            int[] deliveries4 = new int[] { 2,4 };
            int[] pickups4 = new int[] { 4,2 };

            int cap5 = 5;
            int n5 = 3;
            int[] deliveries5 = new int[] { 5, 0, 5 };
            int[] pickups5 = new int[] { 0, 1, 10 };

            Console.WriteLine($"{solution(cap1, n1, deliveries1, pickups1)} 답: 16");
            Console.WriteLine($"{solution(cap2, n2, deliveries2, pickups2)} 답: 30");
            Console.WriteLine($"{solution(cap3, n3, deliveries3, pickups3)} 답: 6");
            Console.WriteLine($"{solution(cap4, n4, deliveries4, pickups4)} 답: 8");
            Console.WriteLine($"{solution(cap5, n5, deliveries5, pickups5)} 답: 16");
        }
    }
}
