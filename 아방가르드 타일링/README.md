어려워 죽는줄 알았다.

dp로 풀어야 하는 것은 짐작을 했지만 예외케이스를 계산해야 해서 푸는게 쉽지가 않았다.

특히 예외케이스 하나를 빼먹는 바람에 시간이 너무 많이 걸렸다.

접근방식: 해당 길이로만 만들 수 있는 특수한 케이스들을 정리한다.

0: 1개(아무것도 없는것도 포함해서 1개)

1: 1개(긴거 하나 누워있는거)

2: 2개(ㄱㄴ조합 두개)

3: 5개(프로그래머스 예시에서 ‘세로로’서있는 것들만)

다음 부터가 복잡하다.

1+3*n개: 2개

2+3*n개: 2개

3+3*n개: 4개

4의 특수케이스를 생각하지 못해서 엄청 진행이 막혔었다.

근데 지금 알았는데 가로로 진행하는거였다. 나는 세로로 진행한다고 생각했는데 상관 없긴함.

4부터는 이런 특수한 케이스가 생기는데 이러한 케이스는 크게 한덩어리로 만들 수 있다는게 문제다.

따라서 4 이후부터는 3의 배수에 맞게 따로 관리를 해줘야 한다.

나의 접근 방식은 ‘숫자에 맞게 쌓는다’라고 생각을 하고 진행을 했다.

9의 입력값 위에 1의 특수케이스(1개)를 쌓는다.(9입력값에 1곱하기)

8의 입력값 위에 2의 특수케이스(2개)를 쌓는다.(8입력값에 2곱하기)

7의 입력값 위에 3의 특수케이스(5개)를 쌓는다.(7입력값에 5곱하기)

하지만 이 다음부터가 문제다. 위의 4부터 나오는 특수케이스는 유동적으로 크기를 조절할 수 있어 계산이 복잡해진다.

하지만 저 이상의 특수 케이스는 없으므로 3크기의 배열(spes)을 생성해 각각 상황에 맞게 경우의 수를 저장해뒀다.

```

using System;

public class Solution {
    long[] answers;
            int divide = 1000000007;
            public int solution(int n)
            {
                answers = new long[100001];
                answers[0] = 1;
                answers[1] = answers[0];
                answers[2] = answers[1] + answers[0] * 2;
                answers[3] = answers[2] + answers[1] * 2 + answers[0] * 5;
                answers[4] = answers[3] + answers[2] * 2 + answers[1] * 5 + answers[0] * 2;
                answers[5] = answers[4] + answers[3] * 2 + answers[2] * 5 + answers[1] * 2 + answers[0] * 2;
                answers[6] = answers[5] + answers[4] * 2 + answers[3] * 5 + answers[2] * 2 + answers[1] * 2 + answers[0] * 4;
                for (int i = 7; i < answers.Length; i++)
                    answers[i] = (answers[i - 1] % divide + answers[i - 2] * 2 % divide + answers[i - 3] * 5 % divide + special(i - 4)) % divide;
                return (int)answers[n];
            }

            int[] spe = new int[] { 2, 2, 4 };
            long[] spes = new long[] { 2, 4, 12 };
            long special(int n)
            {
                long answer = 0;
                int sp = 0;
                for(int i = n; (n - 2) <= i; i--)
                {
                    answer += (answers[i] * spe[sp]) % divide;
                    sp++;
                    sp = sp % 3;
                }
                spes[n % 3] += answer;
                spes[n % 3] = spes[n % 3] % divide;
                return spes[n % 3] % divide;
            }
}

```
6까지 하드코딩?을 했는데 저거 적다가 규칙을 발견해서 일단 뒀다.

그리고 꾸준히 값을 나눠줘서 사이즈 오버가 나올줄 몰랐는데 int로 계산하면 틀린다;;


