using System;

namespace 양과_늑대
{
    class Program
    {
        static void Main(string[] args)
        {
            //굳이 배열로 answer을 설정할 필욘 없는데 버전 차이가 있어서 그냥 int로 하면 오류남;;
            int[] answer;
            int[] Info;
            int[,] Edges;
            bool[] visited;

            int solution(int[] info, int[,] edges)
            {
                answer = new int[1];
                answer[0] = 0;
                Info = info;
                Edges = edges;
                visited = new bool[info.Length];
                for (int i = 0; i < visited.Length; i++)
                    visited[i] = false;
                visited[0] = true;
                CountSheep(1, 0);
                return answer[0];
            }

            void CountSheep(int sheep, int wolf)
            {
                if (sheep <= wolf)
                    return;
                answer[0] = Math.Max(answer[0], sheep);
                for (int i = 0; i < Edges.GetLength(0); i++)
                {
                    int sheepAdd = 0;
                    int wolfAdd = 0;
                    if (Info[Edges[i, 1]] == 0)
                        sheepAdd = 1;
                    else
                        wolfAdd = 1;
                    if ((visited[Edges[i, 0]] == true) && (visited[Edges[i, 1]] == false))
                    {
                        visited[Edges[i, 1]] = true;
                        CountSheep(sheep + sheepAdd, wolf + wolfAdd);
                        visited[Edges[i, 1]] = false;
                    }
                }
            }
            int[] info1 = new int[] { 0, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1 };
            int[,] edges1 = new int[,] { { 0, 1 }, { 1, 2 }, { 1, 4 }, { 0, 8 }, { 8, 7 }, { 9, 10 }, { 9, 11 }, { 4, 3 }, { 6, 5 }, { 4, 6 }, { 8, 9 } };

            int[] info2 = new int[] { 0, 1, 0, 1, 1, 0, 1, 0, 0, 1, 0 };
            int[,] edges2 = new int[,] { { 0, 1 },{ 0, 2 },{ 1, 3 },{ 1, 4 },{ 2, 5 },{ 2, 6 },{ 3, 7 },{ 4, 8 },{ 6, 9 } ,{ 9, 10 } };

            Console.WriteLine(solution(info2, edges2));
        }
    }
}
