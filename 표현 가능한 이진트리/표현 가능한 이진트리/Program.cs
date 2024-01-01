using System;
using System.Collections.Generic;

namespace 표현_가능한_이진트리
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] answer;
            int[] solution(long[] numbers)
            {
                answer = new int[numbers.Length];
                for (int i = 0; i < answer.Length; i++)
                    answer[i] = 1;
                for (int idx = 0; idx<numbers.Length; idx++)
                {
                    ulong sum = 0;
                    List<long> sumList = new List<long>();
                    long nowNum = numbers[idx];

                    while(nowNum > 0)
                    {
                        sumList.Add(nowNum % 2);
                        nowNum /= 2;
                    }
                    sumList.Reverse();

                    int maxLen = 1;
                    int count = 1;
                    while (maxLen < sumList.Count)
                    {
                        count *= 2;
                        maxLen += count;
                    }
                    bool[] treeArray = new bool[maxLen];
                    int zeroRange = maxLen - sumList.Count;
                    for (int i = zeroRange; i < treeArray.Length; i++)
                    {
                        if (sumList[i - zeroRange] == 1)
                            treeArray[i] = true;
                        else if (sumList[i - zeroRange] == 0)
                            treeArray[i] = false;
                    }
                    for(int i = 0; i < zeroRange; i++)
                        treeArray[i] = false;
                    
                    UpdateAnswer(treeArray, count - 1, count, idx);
                }
                return answer;
            }

            void UpdateAnswer(bool[] tree, int idx, int range, int answerIdx)
            {
                if (answer[answerIdx] != 1)
                    return;
                if (range == 0)
                    return;
                if (tree[idx] == false && (tree[idx - range / 2] == true || tree[idx + range / 2] == true))
                    answer[answerIdx] = 0;
                UpdateAnswer(tree, idx - range / 2, range / 2, answerIdx);
                UpdateAnswer(tree, idx + range / 2, range / 2, answerIdx);
            }

            long[] numbers = new long[] { 2147483647 };
            int[] cwAnswer = solution(numbers);
            foreach(int cw in cwAnswer)
                Console.Write($"{cw} ");
        }
    }
}
