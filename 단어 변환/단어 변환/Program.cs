using System;

namespace 단어_변환
{
    class Program
    {
        static void Main(string[] args)
        {
            int answer = 51;
            bool[] visited;
            string[] wardsBoard;

            int solution(string begin, string target, string[] words)
            {
                visited = new bool[words.Length];
                wardsBoard = words;
                check(0, begin, target);

                if (answer == 51)
                    return 0;
                return answer;
            }

            void check(int count, string now, string tar)
            {
                if(now == tar)
                {
                    answer = Math.Min(answer,count);
                    return;
                }

                for(int i = 0; i< wardsBoard.Length; i++)
                {
                    if (CanChange(now, wardsBoard[i]) == true && visited[i] == false)
                    {
                        visited[i] = true;
                        check(count + 1, wardsBoard[i], tar);
                        visited[i] = false;
                    }
                }
            }

            //단어 변환이 가능한지 확인하는 함수
            bool CanChange(string a, string b)
            {
                int count = 0;
                for(int i = 0; i<a.Length; i++)
                    if (a[i] == b[i])
                        count++;
                if (count == (a.Length - 1))
                    return true;
                else
                    return false;
            }

            string Begin = "hit";
            string Target = "cog";
            string[] Words = new string[] { "hot", "dot", "dog", "lot", "log", "cog" };
            Console.WriteLine(solution(Begin, Target, Words));
        }
    }
}
