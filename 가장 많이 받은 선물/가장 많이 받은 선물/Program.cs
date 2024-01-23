using System;
using System.Collections.Generic;

namespace 가장_많이_받은_선물
{
    class Program
    {
        static void Main(string[] args)
        {
            int solution(string[] friends, string[] gifts)
            {
                int answer = int.MinValue;
                Dictionary<string, int> giftNum = new Dictionary<string, int>();
                Dictionary<string, Dictionary<string, int>> GiveAndTake = new Dictionary<string, Dictionary<string, int>>();
                for (int i = 0; i < friends.Length; i++)
                {
                    giftNum.Add(friends[i], 0);
                    Dictionary<string, int> giveDic = new Dictionary<string, int>();
                    for(int j = 0; j < friends.Length; j++)
                    {
                        if (friends[j] != friends[i])
                            giveDic.Add(friends[j], 0);
                    }
                    GiveAndTake.Add(friends[i], giveDic);
                }
                for (int i = 0; i < gifts.Length; i++)
                {
                    string[] gift = new string[2];
                    gift = gifts[i].Split(' ');
                    giftNum[gift[0]]++;
                    giftNum[gift[1]]--;
                    GiveAndTake[gift[0]][gift[1]]++;
                }

                for (int i = 0; i < friends.Length; i++)
                {
                    int nextGift = 0;
                    for (int j = 0; j < friends.Length; j++)
                    {
                        if (i == j)
                            continue;
                        if (GiveAndTake[friends[i]][friends[j]] > GiveAndTake[friends[j]][friends[i]])
                            nextGift++;
                        else if (GiveAndTake[friends[i]][friends[j]] == GiveAndTake[friends[j]][friends[i]])
                            if (giftNum[friends[i]] > giftNum[friends[j]])
                                nextGift++;
                    }
                    answer = Math.Max(answer, nextGift);
                }
                return answer;
            }

            string[] friends = new string[] { "muzi", "ryan", "frodo", "neo" };
            string[] gifts = new string[] { "muzi frodo", "muzi frodo", "ryan muzi", "ryan muzi", "ryan muzi", "frodo muzi", "frodo ryan", "neo muzi" };

            string[] friends2 = new string[] { "joy", "brad", "alessandro", "conan", "david" };
            string[] gifts2 = new string[] { "alessandro brad", "alessandro joy", "alessandro conan", "david alessandro", "alessandro david" };
            Console.WriteLine(solution(friends2, gifts2));
        }
    }
}
