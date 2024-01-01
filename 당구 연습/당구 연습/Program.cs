using System;
using System.Collections.Generic;
using System.Linq;

namespace 당구_연습
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] solution(int m, int n, int startX, int startY, int[,] balls)
            {
                int[] answer = new int[balls.GetLength(0)];
                for(int i = 0; i<balls.GetLength(0); i++)
                {
                    List<int> answers = new List<int>();
                    //윗벽
                    if(!(startX == balls[i, 0] && startY < balls[i, 1]))
                        answers.Add((int)Math.Pow((startX - balls[i, 0]), 2) +
                            (int)Math.Pow((startY + balls[i, 1] - 2 * n), 2));

                    //오른쪽벽
                    if(!(startY == balls[i, 1] && startX < balls[i, 0]))
                        answers.Add((int)Math.Pow((startX + balls[i, 0] - 2 * m), 2) +
                            (int)Math.Pow((startY - balls[i, 1]), 2));

                    //아랫벽
                    if(!(startX == balls[i, 0] && startY > balls[i, 1]))
                        answers.Add((int)Math.Pow((startX - balls[i, 0]), 2) +
                            (int)Math.Pow((startY + balls[i, 1]), 2));

                    //왼쪽벽
                    if(!(startY == balls[i, 1] && startX > balls[i, 0]))
                        answers.Add((int)Math.Pow((startX + balls[i, 0]), 2) +
                            (int)Math.Pow((startY - balls[i, 1]), 2));
                    answer[i] = answers.Min();
                }
                return answer;
            }

            int m1 = 10;
            int n1 = 10;
            int startX1 = 3;
            int startY1 = 7;
            int[,] balls1 = new int[,] { { 2, 7 } };
            solution(m1, n1, startX1, startY1, balls1);
        }
    }
}
