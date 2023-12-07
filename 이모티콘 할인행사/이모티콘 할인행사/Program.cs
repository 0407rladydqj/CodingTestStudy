using System;
using System.Collections.Generic;

namespace 이모티콘_할인행사
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] answer;
            int[] dis;
            Dictionary<int, int[]> price;
            int[,] _users;
            int[] _emoticons;
            int[] caled;

            int[] solution(int[,] users, int[] emoticons)
            {
                answer = new int[2];
                dis = new int[emoticons.Length];
                price = new Dictionary<int, int[]>();
                
                _emoticons = emoticons;
                caled = new int[emoticons.Length];
                for (int i = 0; i<users.GetLength(0); i++)
                {
                    if (users[i, 0] % 10 > 0)
                        users[i, 0] = users[i, 0] / 10;
                    else
                        users[i, 0] = users[i, 0] / 10 - 1;
                }
                _users = users;
                for (int i = 0; i< emoticons.Length; i++)
                {
                    price.Add(i, new int[4]);
                    dis[i] = i;
                    for (int j = 0; j < 4; j++)
                        price[i][j] = (emoticons[i] * (10 - (j + 1))) / 10;
                }

                cal(0);
                return answer;
            }

            
            void cal(int count)
            {
                if (count == _emoticons.Length)
                {
                    Ans(caled);
                    return;
                }
                for (int i = 0; i < 4; i++)
                {
                    caled[count] = i;
                    cal(count + 1);
                }
            }

            void Ans(int[] arr)
            {
                int sub = 0;
                int money = 0;
                for(int i = 0; i<_users.GetLength(0); i++)
                {
                    int mon = 0;
                    for(int j = 0; j<arr.Length; j++)
                    {
                        if (arr[j] >= _users[i, 0])
                            mon += price[j][arr[j]];
                    }
                    if (mon >= _users[i, 1])
                        sub += 1;
                    else
                        money += mon;
                        
                }
                if (answer[0] < sub)
                {
                    answer[0] = sub;
                    answer[1] = money;
                }
                else if(answer[0] == sub && answer[1] < money)
                    answer[1] = money;
            }

            int[,] Users = new int[,] { { 40, 2900 }, { 23, 10000 }, { 11, 5200 }, { 5, 5900 },{ 40, 3100 },{ 27, 9200 },{ 32, 6900 } };
            int[] Emoticons = new int[] { 1300, 1500, 1600, 4900 };

            int[,] Users2 = new int[,] { { 40, 10000 }, { 25, 10000 } };
            int[] Emoticons2 = new int[] { 7000, 9000 };

            foreach (int i in solution(Users, Emoticons))
                Console.WriteLine(i);
        }
    }
}
