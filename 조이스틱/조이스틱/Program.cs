using System;

namespace 조이스틱
{
    class Program
    {
        static void Main(string[] args)
        {
            int LRButton;
            bool[] NotAButton;
            int solution(string name)
            {
                int answer = 0;
                //무조건 해야하는 알파벳 상하버튼 누르는 횟수 더하기
                int ASCIIA = (int)'A';
                foreach(char ch in name)
                {
                    int ASCIIch = (int)ch;
                    if((ASCIIch - ASCIIA) > 13)
                        answer += (26 - (ASCIIch - ASCIIA));
                    else
                        answer += (ASCIIch - ASCIIA);
                }

                //좌우버튼 누르는 횟수 구하기
                LRButton = name.Length - 1;
                NotAButton = new bool[name.Length];
                for(int i = 0; i< NotAButton.Length; i++)
                {
                    if (name[i] != 'A')
                        NotAButton[i] = false;
                    else
                        NotAButton[i] = true;
                }
                NotAButton[0] = true;
                LR(0, 0);
                answer += LRButton;
                return answer;
            }
            //가야할 위치의 bool값, 얼마나 움직였는지, 지금 위치
            void LR(int count, int Pos)
            {
                //모든 배열을 방문했으면 끝
                if (Array.IndexOf(NotAButton, false) == -1)
                {
                    LRButton = Math.Min(count, LRButton);
                    return;
                }
                    
                //왼쪽 오른쪽 둘다 보내기
                int RPos = Pos;
                int Rcount = count;
                for(int i = 1; i< NotAButton.Length; i++ )
                {
                    Rcount++;
                    if (NotAButton[(Pos + i) % NotAButton.Length] == false)
                    {
                        RPos = (Pos + i) % NotAButton.Length;
                        NotAButton[RPos] = true;
                        break;
                    }
                }
                LR(Rcount, RPos);
                NotAButton[RPos] = false;

                int LPos = Pos;
                int Lcount = count;
                for (int i = NotAButton.Length - 1; i >= 0 ; i--)
                {
                    Lcount++;
                    if (NotAButton[(Pos + i) % NotAButton.Length] == false)
                    {
                        LPos = (Pos + i) % NotAButton.Length;
                        NotAButton[LPos] = true;
                        break;
                    }
                }
                LR(Lcount, LPos);
                NotAButton[LPos] = false;
            }

            string Name = "BAAAAAAAAAABAAAAAABB";
            Console.WriteLine(solution(Name));
        }
    }
}
