using System;

namespace _2차원_동전_뒤집기
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] Beginning = new int[,] { };
            int[,] Target = new int[,] { };
            int solution(int[,] beginning, int[,] target)
            {
                Beginning = beginning;
                Target = target;
                int colLen = beginning.GetLength(0);
                int rawLen = beginning.GetLength(1);
                int answer = int.MaxValue;

                for (int col = 0; col < Math.Pow(2, colLen); col++)
                {
                    for (int raw = 0; raw < Math.Pow(2, rawLen); raw++)
                    {
                        string colBinary = ToBinary(col, colLen);
                        string rawBinary = ToBinary(raw, rawLen);
                        int count = 0;
                        foreach (char c in rawBinary)
                            if (c == '1') { count++; }
                        foreach (char c in colBinary)
                            if (c == '1') { count++; }
                        if (CheckArr(rawBinary, colBinary) == true)
                            answer = Math.Min(answer, count);
                    }
                }
                if (answer == int.MaxValue)
                    return -1;
                return answer;
            }

            //배열 일치
            bool CheckArr(string raw, string col)
            {
                for (int c = 0; c < col.Length; c++)
                {
                    for (int r = 0; r < raw.Length; r++)
                    {
                        int compar = Beginning[c, r];
                        if ((col[c] == '0' && raw[r] == '1') || (col[c] == '1' && raw[r] == '0'))
                        {
                            if (compar == 0)
                                compar = 1;
                            else if (compar == 1)
                                compar = 0;
                        }
                        if (compar != Target[c, r])
                            return false;
                    }
                }
                return true;
            }

            //길이에 맞는 2진법 string문을 계산
            string ToBinary(int num, int leng)
            {
                string Binary = Convert.ToString(num, 2);
                char[] ZeroRange = new char[leng - Binary.Length];
                for (int i = 0; i < ZeroRange.Length; i++)
                    ZeroRange[i] = '0';
                return new string(ZeroRange) + Binary;
            }

            int[,] beginning1 = new int[,] { { 0, 1, 0, 0, 0 }, { 1, 0, 1, 0, 1 }, { 0, 1, 1, 1, 0 }, { 1, 0, 1, 1, 0 }, { 0, 1, 0, 1, 0 } };
            int[,] target1 = new int[,] { { 0, 0, 0, 1, 1 }, { 0, 0, 0, 0, 1 }, { 0, 0, 1, 0, 1 }, { 0, 0, 0, 1, 0 }, { 0, 0, 0, 0, 1 } };
            Console.WriteLine(solution(beginning1, target1));
        }
    }
}
