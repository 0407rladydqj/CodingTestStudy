완전탐색으로 푼다는 발상을 하기까지 시간이 너무 많이 걸렸다.

할인율을 보니까 카드 중복 순열 관련 문제를 풀었던 기억이 나서 해당 방법으로 풀어봤다.

1.할인된 값을 0~3에 맞게 계산해서 딕셔너리에 저장

2.이모티콘 수의 길이랑 같은 0~3까지의 조합을 중복순열로 구함.

3.위의 값이 나올 때 마다 사람들의 이모티콘 구매를 계산하고 구독자 수, 수익에 따라 정답을 갱신한다.

```
using System;
using System.Collections.Generic;

public class Solution
{
    int[] answer;
    int[] dis;
    Dictionary<int, int[]> price;
    int[,] _users;
    int[] _emoticons;
    int[] caled;
    
    public int[] solution(int[,] users, int[] emoticons)
            {
                answer = new int[2];
                dis = new int[emoticons.Length];
                price = new Dictionary<int, int[]>();
                _emoticons = emoticons;
                caled = new int[emoticons.Length];
                for (int i = 0; i<users.GetLength(0); i++)
                {
                    if (users[i, 0] % 10 > 0)
                        users[i, 0] = users[i, 0] / 10;
                    else
                        users[i, 0] = users[i, 0] / 10 - 1;
                }
                _users = users;
                for (int i = 0; i< emoticons.Length; i++)
                {
                    price.Add(i, new int[4]);
                    dis[i] = i;
                    for (int j = 0; j < 4; j++)
                        price[i][j] = (emoticons[i] * (10 - (j + 1))) / 10;
                }
                cal(0);
                return answer;
            }

            //순열
            void cal(int count)
            {
                if (count == _emoticons.Length)
                {
                    Ans(caled);
                    return;
                }
                for (int i = 0; i < 4; i++)
                {
                    caled[count] = i;
                    cal(count + 1);
                }
            }

            void Ans(int[] arr)
            {
                int sub = 0;
                int money = 0;
                for(int i = 0; i<_users.GetLength(0); i++)
                {
                    int mon = 0;
                    for(int j = 0; j<arr.Length; j++)
                    {
                        if (arr[j] >= _users[i, 0])
                            mon += price[j][arr[j]];
                    }
                    if (mon >= _users[i, 1])
                        sub += 1;
                    else
                        money += mon;          
                }
                if (answer[0] < sub)
                {
                    answer[0] = sub;
                    answer[1] = money;
                }
                else if(answer[0] == sub && answer[1] < money)
                    answer[1] = money;
            }
}
```
여담으로 코드가 너무 지저분해졌다. 회사였으면 백퍼 까였을듯;;

함수명, 변수명도 너무 대충지어서 늘어날수록 어지러웠다.

물론 코딩테스트에서 지저분한건 상관이 없지만 중간에 내가 혼란스러웠다.

편할 줄 알고 할인된 값을 미리 계산했는데 1번은 생략해도 될거같다.
