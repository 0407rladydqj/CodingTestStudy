예전에 풀었던 적이 있는 테스트였지만 당시에 힌트를 봤던거 같아서 다른 방법으로 다시 풀어봤다.

1. 상하 버튼 누르는 횟수 구하기
2. 좌우 버튼 누르는 횟수 구하기

1번은 사실상 없는 문제다. 13을 넘어가는지 여부 확인 후 빠르게 구했고 다른 테스트 케이스를 사용할때도 A와B만 사용해도 전혀 문제가 없었다.

문제는 2번이다. 아예 반댓편으로 이동할 수 있는 메커니즘 상 어느 경로가 최적의 경로일지 구하기가 어려웠다.

어제 ‘피로도’문제에서 재귀함수를 써서 그런지 name의 길이가 20 이하라는 말을 보고 재귀함수를 사용하기로 했다.

왼쪽으로 갈지 오른쪽으로 갈지 고민할거 없이 모든 경우의 수를 확인해보고 최솟값을 적용하는 방식으로 진행했다.

‘피로도’문제와 마찬가지로 방문한 곳의 bool값을 변경해주고 끝나고 다시 원래대로 바꿔놨다.



<pre><code>
using System;

public class Solution {
    int LRButton;
    bool[] NotAButton;
    public int solution(string name)
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
            //얼마나 움직였는지, 지금 위치
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
}
</code></pre>


피로도 문제를 못풀었으면 접근하기 쉽지 않았을 듯.

통과는 했지만 효율성은 좋지 않은 것 같다.

