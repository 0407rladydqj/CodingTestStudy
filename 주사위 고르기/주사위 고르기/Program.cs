using System;
using System.Collections.Generic;

namespace 주사위_고르기
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] allDice;
            int[] answer;
            int half;
            int[] diceNum;
            int[] teamA;
            int[] teamB;
            Dictionary<int, int> teamAsum;
            Dictionary<int, int> teamBsum;
            int winCount;
            int[] solution(int[,] dice)
            {
                allDice = new int[,] { };
                allDice = dice;
                answer = new int[dice.GetLength(0) / 2];
                diceNum = new int[dice.GetLength(0)];
                teamA = new int[dice.GetLength(0) / 2];
                teamB = new int[dice.GetLength(0) / 2];
                teamAsum = new Dictionary<int, int>();
                teamBsum = new Dictionary<int, int>();
                winCount = 0;
                for (int i = 0; i < dice.GetLength(0); i++)
                    diceNum[i] = i;
                half = 1;
                for (int i = dice.GetLength(0); i > dice.GetLength(0) / 2; i--)
                    half *= i;
                for (int i = 1; i < dice.GetLength(0) / 2 + 1; i++)
                    half /= i;
                half /= 2;
                bool[] visited = new bool[dice.GetLength(0)];
                DiceTeam(visited, 0, dice.GetLength(0) / 2);
                for (int i = 0; i < answer.Length; i++)
                    answer[i] += 1;
                Array.Sort(answer);
                return answer;
            }

            void DiceTeam(bool[] visited, int start, int count)
            {
                if (half == 0)
                    return;
                if (count == 0)
                {
                    half--;
                    int idxA = 0;
                    int idxB = 0;
                    for (int i = 0; i < allDice.GetLength(0); i++)
                    {
                        if (visited[i] == true) { teamA[idxA] = diceNum[i]; idxA++; }
                        else { teamB[idxB] = diceNum[i]; idxB++; }
                    }
                    teamAsum.Clear();
                    teamBsum.Clear();
                    UpdateTeamSum(teamA, teamAsum, 0, 0);
                    UpdateTeamSum(teamB, teamBsum, 0, 0);
                    int aWin = 0;
                    int bWin = 0;
                    foreach(KeyValuePair<int, int> A in teamAsum)
                    {
                        foreach (KeyValuePair<int, int> B in teamBsum)
                        {
                            if (A.Key > B.Key)
                                aWin += A.Value * B.Value;
                            else if (A.Key < B.Key)
                                bWin += A.Value * B.Value;
                        }
                    }
                    
                    if (winCount < aWin)
                    {
                        winCount = aWin;
                        for(int i = 0; i<answer.Length; i++)
                            answer[i] = teamA[i];
                    }
                    if (winCount < bWin)
                    {
                        winCount = bWin;
                        for (int i = 0; i < answer.Length; i++)
                            answer[i] = teamB[i];
                    }
                    return;
                }
                for (int i = start; i < diceNum.Length; i++)
                {
                    visited[i] = true;
                    DiceTeam(visited, i + 1, count - 1);
                    visited[i] = false;
                }
            }

            void UpdateTeamSum(int[] team, Dictionary<int, int> nowTeam, int sum, int count)
            {
                if(count == team.Length)
                {
                    if (nowTeam.ContainsKey(sum))
                        nowTeam[sum] += 1;
                    else
                        nowTeam.Add(sum, 1);
                    return;
                }
                for (int i = 0; i < 6; i++)
                    UpdateTeamSum(team, nowTeam, sum + allDice[team[count], i], count + 1);
            }

            int[,] dice1 = new int[,] { { 1, 2, 3, 4, 5, 6 },{ 3, 3, 3, 3, 4, 4 },{ 1, 3, 3, 4, 4, 4 },{ 1, 1, 4, 4, 5, 5 } };
            int[,] dice2 = new int[,] { { 1, 2, 3, 4, 5, 6 },{ 2, 2, 4, 4, 6, 6 } };
            int[,] dice3 = new int[,] { { 40, 41, 42, 43, 44, 45 },{ 43, 43, 42, 42, 41, 41 },{ 1, 1, 80, 80, 80, 80 },{ 70, 70, 1, 1, 70, 70 } };
            int[] answer1 = solution(dice1);
            //int[] answer2 = solution(dice2);
            //int[] answer3 = solution(dice3);
            foreach(int i in answer1)
                Console.Write($"{i} ");
        }
    }
}
