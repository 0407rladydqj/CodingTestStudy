using System;
using System.Collections.Generic;

namespace 도넛과_막대_그래프
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] solution(int[,] edges)
            {
                Dictionary<int, List<int>> edgesDic = new Dictionary<int, List<int>>();
                HashSet<int> startNode = new HashSet<int>();
                HashSet<int> allNode = new HashSet<int>();

                int bar = 0;
                int donut = 0;
                int eight = 0;

                for (int i = 0; i<edges.GetLength(0); i++)
                {
                    startNode.Add(edges[i, 0]);
                    allNode.Add(edges[i, 1]);
                    if (edgesDic.ContainsKey(edges[i, 1]) == false)
                    {
                        List<int> NodeQueue = new List<int>();
                        edgesDic.Add(edges[i, 1], NodeQueue);
                    }
                    if (edgesDic.ContainsKey(edges[i, 0]) == false)
                    {
                        List<int> NodeQueue = new List<int>();
                        NodeQueue.Add(edges[i, 1]);
                        edgesDic.Add(edges[i, 0], NodeQueue);
                    }
                    else
                        edgesDic[edges[i, 0]].Add(edges[i, 1]);
                }
                foreach (int i in allNode)
                    startNode.Remove(i);
                int startNum = -1;
                int stackCount = 0;
                foreach(int i in startNode)
                {
                    if (edgesDic[i].Count >= stackCount)
                    {
                        startNum = i;
                        stackCount = edgesDic[i].Count;
                    }
                }

                for (int i = 0; i < edgesDic[startNum].Count; i++)
                {
                    int nowPos = edgesDic[startNum][i];
                    int start = nowPos;
                    while (true)
                    {
                        if(edgesDic[nowPos].Count > 1)
                        {
                            eight++;
                            break;
                        }
                        if (edgesDic[nowPos].Count == 0)
                        {
                            bar++;
                            break;
                        } 
                        int nextPos = edgesDic[nowPos][0];
                        if (edgesDic[nextPos].Count > 1)
                        {
                            eight++;
                            break;
                        }
                        if (start == nextPos)
                        {
                            donut++;
                            break;
                        }
                        nowPos = nextPos;
                    }
                }
                int[] answer = new int[4] { startNum, donut, bar, eight}; ;
                return answer;
            }
            int[,] edges1 = new int[,] { { 2, 3 },{ 4, 3 },{ 1, 1 },{ 2, 1 } };

            int[,] edges2 = new int[,] { { 4, 11 },{ 1, 12 },{ 8, 3 },{ 12, 7 } ,{ 4, 2 },{ 7, 11 },
                { 4, 8 },{ 9, 6 },{ 10, 11 },{ 6, 10 },{ 3, 5 },{ 11, 1 },{ 5, 3},{11, 9},{ 3, 8} };

            int[,] edges3 = new int[,] { { 2, 1 },{ 2, 5 },{ 3, 4 },{ 4, 5 },{ 5, 6 },{ 6, 7 },{ 7, 3 } ,{ 3, 8 },{ 8, 9 },{ 9, 10 },{ 10, 11 },{ 11, 3 } };
            int[,] edges4 = new int[,] { { 2, 1 },{ 1, 3 },{ 2, 4 },{ 4, 5 },{ 2, 6 },{ 6, 7 } };

            int[] answerarr = solution(edges2);
            foreach(int i in answerarr)
                Console.Write($" {i}");

        }
    }
}
