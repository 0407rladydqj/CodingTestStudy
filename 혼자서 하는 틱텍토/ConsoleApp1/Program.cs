using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int solution(string[] board)
            {
                int Xcount = 0;
                int Ocount = 0;
                foreach(string s in board)
                {
                    foreach (char c in s)
                    {
                        if (c == 'X')
                            Xcount++;
                        else if (c == 'O')
                            Ocount++;
                    }
                }

                //비정상적인 경우인지 확인
                if (Xcount > Ocount)
                    return 0;
                if ((Ocount - Xcount)>1)
                    return 0;
                if (Xcount == 0 && Ocount == 0)
                    return 1;

                //승리 확인
                int XWin = 0;
                int OWin = 0;

                if(board[0][0] == 'X' && board[1][1] == 'X'  && board[2][2] == 'X')
                    XWin++;
                if (board[0][0] == 'O' && board[1][1] == 'O' && board[2][2] == 'O')
                    OWin++;
                if(board[0][2] == 'X' && board[1][1] == 'X' && board[2][0] == 'X')
                    XWin++;
                if (board[0][2] == 'O' && board[1][1] == 'O' && board[2][0] == 'O')
                    OWin++;

                //빙고 확인
                for (int i = 0; i < 3; i++)
                {
                    if (board[i][0] == board[i][1] && board[i][1] == board[i][2])
                    {
                        if (board[i][0] == 'X')
                            XWin++;
                        else if (board[i][0] == 'O')
                            OWin++;
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    if (board[0][i] == board[1][i] && board[1][i] == board[2][i])
                    {
                        if (board[0][i] == 'X')
                            XWin++;
                        else if (board[0][i] == 'O')
                            OWin++;
                    }
                }

                //승리없음
                if (OWin == 0 && XWin == 0)
                    return 1;
                //둘다승리
                if (OWin >= 1 && XWin >= 1)
                    return 0;
                //O승리
                if (OWin >= 1)
                {
                    if (Xcount == Ocount)
                        return 0;
                }
                //X승리
                if (XWin >= 1)
                {
                    if (Xcount < Ocount)
                        return 0;
                }

                return 1;
            }

            string[] board = new string[] { ".OX", "OXO", "XO." };//찾았다
            string[] board1 = new string[] { "OOX", "XXO", "OXO" };//1
            string[] board2 = new string[] { "XXX", "XXX", "XXX" };//0
            string[] board3 = new string[] { "OOO", "OOO", "OOO" };//0
            string[] board4 = new string[] { "OXO", ".XO", "X.O" };//1
            string[] board5 = new string[] { "OOO", "X.X", "..." };//1
            Console.WriteLine(solution(board));
        }
    }
}
