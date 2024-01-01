using System;
using System.Collections.Generic;

namespace 빛의_경로_사이클
{

    class Program
    {
        static void Main(string[] args)
        {
            char[,] grids;
            int[] solution(string[] grid)
            {
                grids = new char[grid.Length, grid[0].Length];
                //아래 오 위 왼
                //오른쪽 = -1
                //왼쪽 = + 1
                int[] dirX = new int[] { 0, 1, 0, -1 };
                int[] dirY = new int[] { 1, 0, -1, 0 };
                int[,,] visited = new int[grid.Length, grid[0].Length, 4];
                List<int> answerList = new List<int>();
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        grids[i, j] = grid[i][j];
                        visited[i, j, 0] = 0;
                        visited[i, j, 1] = 0;
                        visited[i, j, 2] = 0;
                        visited[i, j, 3] = 0;
                    }
                }
                for(int i = 0; i< grid.Length; i++)
                {
                    for(int j = 0; j < grid[0].Length; j++)
                    {
                        for (int dir = 0; dir < 4; dir++)
                        {
                            int count = 0;

                            int NowPosX = i;
                            int NowPosY = j;
                            int NowDir = dir;
                            if (visited[i, j, dir] == 1)
                                continue;
                            while (true)
                            {
                                if (visited[NowPosX, NowPosY, NowDir] == 1)
                                {
                                    answerList.Add(count);
                                    break;
                                }
                                visited[NowPosX, NowPosY, NowDir] = 1;
                                count++;
                                //위치 갱신
                                NowPosX = (NowPosX + dirX[NowDir] + grid.Length) % grid.Length;
                                NowPosY = (NowPosY + dirY[NowDir] + grid[0].Length) % grid[0].Length;
                                //방향 갱신
                                NowDir = UpdateDir(NowPosX, NowPosY, NowDir); 
                            }
                        }
                    }
                }
                answerList.Sort();
                return answerList.ToArray();
            }

            int UpdateDir(int nowPosX, int nowPosY, int nowDir)
            {
                switch (grids[nowPosX, nowPosY])
                {
                    case 'S':
                        break;
                    case 'L':
                        nowDir = (nowDir + 1 + 4) % 4;
                        break;
                    case 'R':
                        nowDir = (nowDir - 1 + 4) % 4;
                        break;
                    default:
                        break;
                }
                return nowDir;
            }

            string[] grid1 = new string[] { "SL", "LR" };
            solution(grid1);
        }
    }
}
