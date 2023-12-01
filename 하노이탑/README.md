삽질을 많이했다;;

재귀 함수로 쓰는걸 감은 잡았는데 어떻게 풀어야 할지 몰랐다.

삽질코드
'''
public class Hanoi
        {
            Stack<int[,]> track = new Stack<int[,]>();
            Stack<Stack<int>> reco = new Stack<Stack<int>>();
            Dictionary<int, Stack<int>> Pins = new Dictionary<int, Stack<int>>();

            void StartSet(int num)
            {
                Pins.Add(1, new Stack<int>());
                Pins.Add(2, new Stack<int>());
                Pins.Add(3, new Stack<int>());
                for(int i = 0; i<num; i++)
                    Pins[i].Push(i);
            }
            /*
             ~~
            */
        }
'''


직접 하노이탑 어플을 깔아서 게임을 해보고 감을 잡아서 풀었다.

핵심은 2개를 옮기는 과정에서 1개를 옮길때 과정이 포함되고 3개를 옮기는 과정에서 1개를 옮기는 과정이 포함되고~~ 라는 개념을 살려서 재귀함수를 작성해야 한다.

1. 옮길게 여러개인 경우 위에 있는 원반을 먼저 보조 핀에 옮긴다.
2. 위에 원반을 다 옮기면 목표 지점으로 옮긴다.
3. 보조 핀에 있는 원반을 목표 지점으로 옮긴다.

'''
using System;
using System.Collections.Generic;
public class Solution {
    List<int[]> track = new List<int[]>();
    public int[,] solution(int n)
    {
        Hanoi(n, 1, 2, 3);
        int[,] answer = new int[track.Count, 2];
        for(int i = 0; i<track.Count; i++)
        {
            answer[i, 0] = track[i][0];
            answer[i, 1] = track[i][1];
        }
        return answer;
    }
    void Hanoi(int num, int from, int sub, int to)
    {
        if (num == 0)
            return;
        else
        {
            //옮길게 여러개인 경우 위에꺼 다 치우는 판정
            Hanoi(num - 1, from, to, sub);
            //다 치우고 옮김
            track.Add(new int[] { from, to });
            //옮긴거에서 다시 목표지점으로
            Hanoi(num - 1, sub, from, to);
        }
    }
}
'''

코테중 게임을 깔아서 시험하기엔 좀 곤란하니 연습을 많이 해야 할듯
