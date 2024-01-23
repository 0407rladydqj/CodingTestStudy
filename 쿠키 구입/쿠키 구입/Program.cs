using System;

namespace 쿠키_구입
{
    class Program
    {
        static void Main(string[] args)
        {
            int solution(int[] cookie)
            {
                int answer = 0;
                for(int m = 0; m < cookie.Length - 1; m++)
                {
                    int idx1 = m;
                    int idx2 = m + 1;

                    int son1 = cookie[idx1];
                    int son2 = cookie[idx2];
                    while (true)
                    {
                        if (son1 == son2)
                        {
                            answer = Math.Max(answer, son1);
                            if (idx1 == 0 || idx2 == cookie.Length - 1)
                                break;
                            idx1--;
                            son1 += cookie[idx1];
                            idx2++;
                            son2 += cookie[idx2];
                        }
                        else if(son1 < son2)
                        {
                            if (idx1 <= 0)
                                break;
                            idx1--;
                            son1 += cookie[idx1];
                        }
                        else if(son1 > son2)
                        {
                            if (idx2 >= cookie.Length - 1)
                                break;
                            idx2++;
                            son2 += cookie[idx2];
                        }
                    }
                }
                return answer;
            }

            int[] cookie1 = new int[] { 1, 1, 2, 3 };
            Console.WriteLine(solution(cookie1));
        }
    }
}
