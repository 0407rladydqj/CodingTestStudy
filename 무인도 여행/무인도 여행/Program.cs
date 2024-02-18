using System;
using System.Collections.Generic;

namespace 무인도_여행
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] visited;
            int rowCount;
            int colCount;
            int[] solution(string[] maps)
            {
                List<int> answer = new List<int>();
                visited = new bool[maps.Length, maps[0].Length];
                rowCount = maps.Length;
                colCount = maps[0].Length;
                for(int i = 0; i< rowCount; i++)
                {
                    for(int j = 0; j< colCount; j++)
                    {
                        if (visited[i, j] == true)
                            continue;
                        int islandFood = countFood(0, maps, j, i);
                        if (islandFood != 0)
                            answer.Add(islandFood);
                    }
                }
                if (answer.Count == 0)
                    answer.Add(-1);
                else
                    answer.Sort();
                return answer.ToArray();
            }

            int countFood(int count, string[] map, int X, int Y)
            {
                if (visited[Y, X] == true || map[Y][X] == 'X')
                    return 0;
                visited[Y, X] = true;
                int nowCount = map[Y][X] - '0';
                if (X > 0 && visited[Y, X - 1] == false)
                    nowCount += countFood(0, map, X - 1, Y);
                if (X < colCount - 1 && visited[Y, X + 1] == false)
                    nowCount += countFood(0, map, X + 1, Y);
                if (Y > 0 && visited[Y - 1, X] == false)
                    nowCount += countFood(0, map, X, Y - 1);
                if (Y < rowCount - 1 && visited[Y + 1, X] == false)
                    nowCount += countFood(0, map, X, Y + 1);
                return nowCount;
            }

            string[] maps1 = new string[] { "X591X", "X1X5X", "X231X", "1XXX1" };
            int[] answer1 = solution(maps1);
            foreach(int i in answer1)
                Console.Write($"{i} ");
        }
    }
}
