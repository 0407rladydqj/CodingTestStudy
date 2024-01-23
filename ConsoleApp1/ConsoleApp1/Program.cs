using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int answer;
            int range;
            int[,] Board;
            int[] Aloc;
            int[] Bloc;
            //상하좌우
            int[] X = { 0, 0, -1, 1};
            int[] Y = { -1, 1, 0, 0};

            int solution(int[,] board, int[] aloc, int[] bloc)
            {
                answer = int.MaxValue;
                range = int.MaxValue;
                Board = board;
                Aloc = aloc;
                Bloc = bloc;

                //A가 이긴다
                move(aloc, bloc, false, 0, false);
                //B가 이긴다
                move(aloc, bloc, false, 0, true);
                return answer;
            }

            //거리
            void rangeUpdate(int[] start, int[] target, int count)
            {
                if (start[0] == target[0] && start[1] == target[1])
                {
                    range = Math.Min(range, count);
                    return;
                }
                for (int i = 0; i < 4; i++)
                {
                    int[] NowPos = new int[2];
                    NowPos[0] = start[0];
                    NowPos[1] = start[1];
                    NowPos[0] += Y[i];
                    NowPos[1] += X[i];
                    if (NowPos[0] >= Board.GetLength(0) ||
                        NowPos[0] < 0 ||
                        NowPos[1] >= Board.GetLength(1) ||
                        NowPos[1] < 0 ||
                        Board[NowPos[0], NowPos[1]] == 0)
                        continue;
                    Board[start[0], start[1]] = 0;
                    rangeUpdate(NowPos, target, count + 1);
                    Board[start[0], start[1]] = 1;
                }
            }

            void move(int[] apos, int[] bpos, bool turn, int count, bool win)
            {
                if (turn == false)
                {
                    if(Board[apos[0], apos[1]] == 0)
                    {
                        answer = Math.Min(answer, count);
                        return;
                    }
                }
                else
                {
                    if (Board[bpos[0], bpos[1]] == 0)
                    {
                        answer = Math.Min(answer, count);
                        return;
                    }
                }
                //갈 수 있는 점
                List<int[]> canGo = new List<int[]>();
                for (int i = 0; i<4; i++)
                {
                    int[] NowTurnPos = new int[2];
                    if (turn == false)
                    {
                        NowTurnPos[0] = apos[0];
                        NowTurnPos[1] = apos[1];
                    }
                    else
                    {
                        NowTurnPos[0] = bpos[0];
                        NowTurnPos[1] = bpos[1];
                    }
                    NowTurnPos[0] += Y[i];
                    NowTurnPos[1] += X[i];
                    if (NowTurnPos[0] >= Board.GetLength(0) ||
                        NowTurnPos[0] < 0 ||
                        NowTurnPos[1] >= Board.GetLength(1) ||
                        NowTurnPos[1] < 0 ||
                        Board[NowTurnPos[0], NowTurnPos[1]] == 0)
                        continue;
                    canGo.Add(NowTurnPos);
                }
                if (canGo.Count == 0)
                {
                    answer = Math.Min(answer, count);
                    return;
                }
                //거리
                List<int> rangeList = new List<int>();
                for (int i = 0; i < canGo.Count; i++)
                {
                    if (turn == false)
                    {
                        range = int.MaxValue;
                        Board[apos[0], apos[1]] = 0;
                        rangeUpdate(canGo[i], bpos, 0);
                        Board[apos[0], apos[1]] = 1;
                        rangeList.Add(range);
                    }
                    else
                    {
                        range = int.MaxValue;
                        Board[bpos[0], bpos[1]] = 0;
                        rangeUpdate(apos, canGo[i], 0);
                        Board[bpos[0], bpos[1]] = 1;
                        rangeList.Add(range);
                    }
                }

                //거리 결정
                int targetRange = int.MaxValue;
                if(rangeList.Count > 0)
                {
                    if (turn == win)
                        targetRange = rangeList.Min();
                    else
                        targetRange = rangeList.Max();
                }
                for (int i = 0; i < canGo.Count; i++)
                {
                    if (rangeList[i] != targetRange)
                        continue;
                    if (turn == false)
                    {
                        Board[apos[0], apos[1]] = 0;
                        move(canGo[i], bpos, !turn, count + 1, win);
                        Board[apos[0], apos[1]] = 1;
                    }
                    else
                    {
                        Board[bpos[0], bpos[1]] = 0;
                        move(apos, canGo[i], !turn, count + 1, win);
                        Board[bpos[0], bpos[1]] = 1;
                    }
                }
            }

            int[,] board1 = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            int[] aloc1 = { 1, 0 };
            int[] bloc1 = { 1, 2 };

            int[,] board3 = { { 1, 1, 1, 1, 1 } };
            int[] aloc3 = { 0, 0 };
            int[] bloc3 = { 0, 4 };

            int[,] board4 = { { 1, 1, 1, 1, 1, 1 },{ 1, 1, 1, 1, 0, 0 } };
            int[] aloc4 = { 0, 0 };
            int[] bloc4 = { 0, 4 };
            //Console.WriteLine(solution(board1, aloc1, bloc1));
            //Console.WriteLine(solution(board3, aloc3, bloc3));
            Console.WriteLine(solution(board4, aloc4, bloc4));

            // A, 1, 1, 1, B, 1
            // 1, 1, 1, 1, 0, 0
        }
    }
}
