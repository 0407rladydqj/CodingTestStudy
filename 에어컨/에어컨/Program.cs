using System;

namespace 에어컨
{
    class Program
    {
        static void Main(string[] args)
        {
            int solution(int temperature, int t1, int t2, int a, int b, int[] onboard)
            {
                int answer = 0;
                int[] tempTimeline = new int[onboard.Length];
                if (temperature > t2)
                    temperature = t1 - (temperature - t2);
                int nowTemp = temperature;
                tempTimeline[0] = nowTemp;
                for (int i = 1; i < onboard.Length; i++)
                {
                    tempTimeline[i] = nowTemp;
                    if (onboard[i] == 1 && nowTemp < t1)//사람 탑승, 온도가 범위안에 X
                    {
                        tempTimeline[i] = t1;
                        int tempCount = 1;
                        for(int j = i - (t1 - nowTemp); j<i; j++)
                        {
                            tempTimeline[j] += tempCount;
                            tempCount++;
                        }
                    }
                    else if(onboard[i] == 0 || nowTemp >= t1 + 2)
                    {
                        if(nowTemp > temperature)
                            tempTimeline[i]--;
                    }
                    nowTemp = tempTimeline[i];
                }
                return answer;
            }

            int temperature1 = 28;
            int t1 = 18;
            int t2 = 26;
            int a1 = 10;
            int b1 = 8;
            int[] onboard1 = new int[] { 0, 0, 1, 1, 1, 1, 1 };

            Console.WriteLine(solution(temperature1, t1, t2, a1, b1, onboard1));
        }
    }
}