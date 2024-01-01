using System;

namespace 양궁대회
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] answer = new int[11];
            int[] board = new int[11];
            int[] _info = new int[11];
            bool[] visited = new bool[11];
            int target = 0;
            int maxPoint = 0;
            int[] solution(int n, int[] info)
            {
                for (int i = 0; i < info.Length; i++)
                    board[i] = 0;
                _info = info;
                target = n;
                ChedkMaxPoint(0, 0);
                
                if (0 >= maxPoint)
                    return new int[] { -1 };
                else
                    return answer;
            }

            void ChedkMaxPoint(int sum, int idx)
            {
                if (sum == target) { Point(); return; }
                for (int i = 0; i < board.Length; i++)
                {
                    board[i] += 1;
                    ChedkMaxPoint(sum + 1, i);
                    board[i] -= 1;
                }
            }

            void Point()
            {
                int a = 0;
                int l = 0;
                for (int i = 0; i < board.Length; i++)
                {
                    if (board[i] == 0 && _info[i] == 0)
                        continue;
                    if (board[i] > _info[i])
                        l += (10 - i);
                    else if (_info[i] != 0)
                        a += (10 - i);
                }
                int dif = l - a;
                if (maxPoint == dif)
                {
                    for (int i = 10; i >= 0; i--)
                    {
                        if (answer[i] < board[i])
                        {
                            answer = (int[])board.Clone();
                            break;
                        }
                        else if (answer[i] > board[i])
                        {
                            break;
                        }
                    }
                }
                else
                {
                    answer = (int[])board.Clone();
                }
                maxPoint = dif;
            }

            int n1 = 5;
            int[] info1 = new int[] { 2, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 };
            int[] Answer = solution(n1, info1);
            Console.WriteLine();
            foreach(int i in Answer)
                Console.Write($"{i} ");
        }
    }
}
