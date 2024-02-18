using System;

namespace 행렬_테두리_회전하기
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] solution(int rows, int columns, int[,] queries)
            {
                int[] answer = new int[queries.GetLength(0)];
                int[,] board = new int[rows, columns];

                for (int i = 0; i< rows; i++)
                    for (int j = 0; j < columns; j++)
                        board[i, j] = i * columns + j + 1;
                for (int i = 0; i < answer.Length; i++)
                    answer[i] = int.MaxValue;

                for (int i = 0; i < queries.GetLength(0); i++)
                {
                    int change = board[queries[i, 0] - 1, queries[i, 1] - 1];
                    answer[i] = Math.Min(answer[i], change);
                    for (int j = queries[i, 1]; j < queries[i, 3]; j++)
                    {
                        int c = change;
                        change = board[queries[i, 0] - 1, j];
                        board[queries[i, 0] - 1, j] = c;
                        answer[i] = Math.Min(answer[i], change);
                    }
                    for (int j = queries[i, 0]; j < queries[i, 2] - 1; j++)
                    {
                        int c = change;
                        change = board[j, queries[i, 3] - 1];
                        board[j, queries[i, 3] - 1] = c;
                        answer[i] = Math.Min(answer[i], change);
                    }
                    for (int j = queries[i, 3] - 1; j > queries[i, 1] - 2; j--)
                    {
                        int c = change;
                        change = board[queries[i, 2] - 1, j];
                        board[queries[i, 2] - 1, j] = c;
                        answer[i] = Math.Min(answer[i], change);
                    }
                    for (int j = queries[i, 2] - 2; j > queries[i, 0] - 1; j--)
                    {
                        int c = change;
                        change = board[j, queries[i, 1] - 1];
                        board[j, queries[i, 1] - 1] = c;
                        answer[i] = Math.Min(answer[i], change);
                    }
                    board[queries[i, 0] - 1, queries[i, 1] - 1] = change;
                    answer[i] = Math.Min(answer[i], change);
                }
                return answer;
            }

            int rows1 = 6;
            int columns1 = 6;
            int[,] queries1 = new int[,] { { 2, 2, 5, 4 },{ 3, 3, 6, 6 },{ 5, 1, 6, 3 } };

            int rows2 = 3;
            int columns2 = 3;
            int[,] queries2 = new int[,] { { 1, 1, 2, 2 }, { 1, 2, 2, 3 }, { 2, 1, 3, 2 } ,{ 2, 2, 3, 3 } };

            int rows3 = 100;
            int columns3 = 97;
            int[,] queries3 = new int[,] { { 1, 1, 100, 97 }};

            int[] answers = solution(rows1, columns1, queries1);
            foreach(int i in answers)
                Console.Write($"{i} ");
        }
    }
}
