using System;
using System.Collections.Generic;

namespace n___1_카드게임
{
    class Program
    {
        static void Main(string[] args)
        {
            int solution(int coin, int[] cards)
            {
                int answer = 0;
                int N = cards.Length;
                Queue<int> deckQueue = new Queue<int>(cards);
                List<int> hand = new List<int>();
                List<int> draw = new List<int>();
                for (int i = 0; i < (N / 3); i++)
                    hand.Add(deckQueue.Dequeue());
                while (true)
                {
                    answer++;
                    if (deckQueue.Count < 2)
                        break;
                    
                    //카드 두장 뽑기
                    for (int n = 0; n < 2; n++)
                        draw.Add(deckQueue.Dequeue());

                    //여기서 숫자 조합 찾기
                    int firCard = -1;
                    int secCard = -1;
                    for (int i = 0; i < hand.Count + draw.Count; i++)
                    {
                        //첫번째 카드가 초기 카드인 경우
                        if (i < hand.Count)
                        {
                            //초기 카드 끼리 비교하는 경우
                            if (hand.Contains((N + 1) - hand[i]))
                            {
                                firCard = hand[i];
                                secCard = (N + 1) - hand[i];
                                hand.Remove(firCard);
                                hand.Remove(secCard);
                                break;
                            }
                            //초기 카드랑 뽑았던 카드랑 비교하는 경우
                            if (coin >= 1)
                            {
                                if (draw.Contains((N + 1) - hand[i]))
                                {
                                    firCard = hand[i];
                                    secCard = (N + 1) - hand[i];
                                    hand.Remove(firCard);
                                    draw.Remove(secCard);
                                    coin--;
                                    break;
                                }
                            }
                        }
                        //첫번째 카드가 뽑았던 카드인 경우
                        if (i >= hand.Count)
                        {
                            if(coin >= 1)
                            {
                                //뽑았던 카드랑 초기 카드랑 비교하는 경우
                                if (hand.Contains((N + 1) - draw[i - hand.Count]))
                                {
                                    firCard = draw[i - hand.Count];
                                    secCard = (N + 1) - draw[i - hand.Count];
                                    draw.Remove(firCard);
                                    hand.Remove(secCard);
                                    coin--;
                                    break;
                                }
                            }
                            if (coin >= 2)
                            {
                                //뽑았던 카드끼리 비교하는 경우
                                if (draw.Contains((N + 1) - draw[i - hand.Count]))
                                {
                                    firCard = draw[i - hand.Count];
                                    secCard = (N + 1) - draw[i - hand.Count];
                                    draw.Remove(firCard);
                                    draw.Remove(secCard);
                                    coin -= 2;
                                    break;
                                }
                            }
                        }
                    }
                    if (firCard == -1 || secCard == -1)
                        break;
                }
                return answer;
            }

            int coin1 = 4;
            int[] cards1 = new int[] { 3, 6, 7, 2, 1, 10, 5, 9, 8, 12, 11, 4 };

            int coin2 = 3;
            int[] cards2 = new int[] { 1, 2, 3, 4, 5, 8, 6, 7, 9, 10, 11, 12 };

            Console.WriteLine($"test1: {solution(coin1, cards1)} answer: 5");
            Console.WriteLine($"test2: {solution(coin2, cards2)} answer: 2");
        }
    }
}
