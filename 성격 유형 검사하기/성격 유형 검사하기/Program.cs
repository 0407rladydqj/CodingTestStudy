using System;
using System.Collections.Generic;

namespace 성격_유형_검사하기
{
    class Program
    {
        static void Main(string[] args)
        {
            string solution(string[] survey, int[] choices)
            {
                string answer = "";

                Dictionary<string, int[]> person = new Dictionary<string, int[]>();
                person.Add("RT", new int[] { 0, 0 });
                person.Add("CF", new int[] { 0, 0 });
                person.Add("JM", new int[] { 0, 0 });
                person.Add("AN", new int[] { 0, 0 });

                for (int i = 0; i<survey.Length; i++)
                {
                    string nowKey = survey[i];
                    int nowNum = choices[i];
                    if (person.ContainsKey(nowKey) == false)
                    {
                        nowKey = "" + survey[i][1] + survey[i][0];
                        nowNum = 8 - nowNum;
                    }
                    nowNum -= 4;
                    if (nowNum < 0)
                        person[nowKey][0] += nowNum * (-1);
                    if (nowNum > 0)
                        person[nowKey][1] += nowNum;
                }

                foreach(KeyValuePair<string,int[]> kv in person)
                {
                    if (kv.Value[0] < kv.Value[1])
                        answer += kv.Key[1];
                    else
                        answer += kv.Key[0];
                }

                return answer;
            }

            string[] survey1 = new string[] { "AN", "CF", "MJ", "RT", "NA" };
            int[] choices1 = new int[] { 5, 3, 2, 7, 5 };

            Console.WriteLine(solution(survey1, choices1));
        }
        /*
         * 1번 지표	라이언형(R), 튜브형(T)
           2번 지표	콘형(C), 프로도형(F)
           3번 지표	제이지형(J), 무지형(M)
           4번 지표	어피치형(A), 네오형(N)
         */
    }
}
