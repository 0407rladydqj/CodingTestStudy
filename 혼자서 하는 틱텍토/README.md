입력값은 3*3의 배열이라 경우의 수가 많진 않았음.

설명을 잘 읽고 있을 수 없는 상황을 하나 제거하는 게 핵심.

O이 선공이면 있을 수 없는 경우가 상당히 많다.

대각선의 경우의 수를 찾는 과정에서 잘못된 코드를 짜 시간이 오래 걸려버렸다.

분류는 뭐로 해야 할지 아직도 모르겠음;;


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
