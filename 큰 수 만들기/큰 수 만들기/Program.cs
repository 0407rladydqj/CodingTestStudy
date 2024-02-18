using System;
using System.Collections.Generic;

namespace 큰_수_만들기
{
    class Program
    {
        static void Main(string[] args)
        {
            string solution(string number, int k)
            {
                string answer = "";
                int index = -1;
                for (int i = 0; i < number.Length - k; i++)
                {
                    char max = '0';
                    for (int j = index + 1; j <= k + i; j++)
                    {
                        if (max < number[j])
                        {
                            index = j;
                            max = number[j];
                        }
                    }
                    answer += max;
                }
                return answer;
            }

            string number1 = "19994";
            int k1 = 2;

            string number2 = "720378";
            int k2 = 2;

            string number3 = "4177252841";
            int k3 = 4;

            string number4 = "1234567890123456789012345678901234567890";
            int k4 = 1;
            Console.WriteLine(solution(number1, k1));
        }
    }
}
