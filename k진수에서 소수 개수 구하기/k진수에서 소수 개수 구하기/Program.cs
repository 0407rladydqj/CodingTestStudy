using System;
using System.Collections.Generic;

namespace k진수에서_소수_개수_구하기
{
    class Program
    {
        static void Main(string[] args)
        {
            int solution(int n, int k)
            {
                int answer = 0;
                List<int> CalList = new List<int>();
                while (n > 0)
                {
                    CalList.Add(n % k);
                    n /= k;
                }

                int multi = 1;
                int sum = 0;
                foreach(int num in CalList)
                {
                    if(num != 0)
                    {
                        sum += num * multi;
                        multi *= 10;
                    }
                    else
                    {
                        //소수 판독
                        if (PrimeNum(sum) == true)
                            answer++;
                        multi = 1;
                        sum = 0;
                    }
                }
                if(sum != 0)
                    if (PrimeNum(sum) == true)
                        answer++;
                return answer;
            }

            bool PrimeNum(int num)
            {
                if (num == 1 || num == 0)
                    return false;
                for (int i = 2; i * i <= num; i++)
                {
                    if (num % i == 0)
                        return false;
                }
                return true;
            }

            int n1 = 110011;
            int k1 = 10;
            Console.WriteLine(solution(n1, k1));
        }
    }
}
