난이도 자체는 어렵지 않았지만 예외처리가 까다로웠다.

또한 long타입으로 선언만 하면 문제가 없을줄 알았는데 런타임에러가 떠서 당황했다.

접근방법

1. 큐라고 써있었지만 큐로 안하고 두 배열을 합쳐서 돌아도 문제가 없었다.
2. 목표는 첫번째 큐의 값이 목표값(두 큐 합의 절반)이 될 때 까지 1에서 합친 배열(Allqueue)을 순회 하는 것.
3. 왼쪽값(left)은 0으로 설정하고 오른쪽값(right)는 배열의 길이만큼 설정해 주고 목표 값보다 작으면 오른쪽값 인덱스의 값을 더해준 후 오른쪽 값을 1 늘려주고 목표 값보다 작으면 왼쪽 값의 인덱스의 값을 빼주고 을 1늘려주는 방법을 썼다.
4. 만약 왼쪽값과 오른쪽값이 일치하면 한 큐가 비어있다는 뜻이므로 -1을 리턴한다.
5. 오른쪽 값 혹은 왼쪽 값이 합친 배열(Allqueue)의 끝에 가면 0으로 해주고 몇바퀴 순회했는지 카운트 하는 circle에 1을 더해준다.
6. circle값이 1을 초과하면 왼쪽값, 오른쪽값 모두 순회를 마쳤다는 뜻이므로 모든 값을 확인 했으므로 답이 없다 판단하고 -1을 리턴.

```
using System;
using System.Linq;

public class Solution {
    public int solution(int[] queue1, int[] queue2)
            {
                long now = 0;
                foreach (int i in queue1)
                    now += (long)i;
                long dis = now;
                foreach (int i in queue2)
                    dis += (long)i;
                dis /= 2;

                int left = 0;
                int right = queue1.Length;
                int end = queue1.Length + queue2.Length;
                int[] Allqueue = queue1.Concat(queue2).ToArray();
                int answer = 0;

                int circle = 0;
                while(now != dis)
                {
                    //한쪽 큐가 0인 상황
                    if(left == right) { answer = -1; break; }
                    //한바퀴돌아서 안되면 없는거라 판단해서 넣었는데 반바퀴만 돌아도 안되더라;;
                    if(circle > 1) { answer = -1; break; }

                    if (now < dis)
                    {
                        now += Allqueue[right];
                        right += 1;
                    }
                    else if(now > dis)
                    {
                        now -= Allqueue[left];
                        left += 1;
                    }
                    if (right == end) { right = 0; circle += 1; }
                    if (left == end) { left = 0; circle += 1; }
                    answer += 1;
                }
                return answer;
            }
}
```

사실 long값을 사용하는 과정에서 런타임 에러가 났다.

단순히 sum을 사용하고 long를 적용하면 끝이 아니라 그냥 sum을 int에서 사용한거 부터 에러였다.

그래서 foreach를 사용해 더해주는 방식으로 했다.

해설은 안보는게 원칙이지만 long부분에서 오류난게 뻔한데 정확한 원인 절대 못찾을거 같아서 검색했다… 다음번에는 이런일 없도록.

그리고 아직도 의문인가 circle에서 왼쪽값, 오른쪽값이 순회를 마쳐야 모든 경우의 수를 확인했다고 판단 했는데 오른쪽 값만 순회를 마쳐도 정답이 나오더라. 왜그런지는 좀 더 생각해 봐야겠음.