던전의 개수가 최대 8이라는 말을 보고 바로 재귀함수를 떠올리는게 맞는데 완전탐색이라는 분류를 보지 못했으면 정렬로 생각했을 가능성이 높다.

1. 재귀함수를 사용해 들어갈 수 있는 모든 던전을 들어가서 탐색
2. 방문한 던전은 Cleared배열에서 true로 변경(탐색이 끝난 후 다음 경우의 수를 위해서 false로 다시 변경)
3. 카운트 된 숫자를 비교해 가장 큰 값을 반환

            int answer = 0;
            bool[] Cleared = new bool[] { };
            int[,] dun = new int[,] { };

            int solution(int k, int[,] dungeons)
            {
                Cleared =  new bool[dungeons.GetLength(0)];
                dun = dungeons;
                Try(k, 0);
                return answer;
            }

            void Try(int SP, int count)
            {
                for (int i = 0; i < dun.GetLength(0); i++)
                {
                    if (Cleared[i] == false && dun[i, 0] <= SP)
                    {
                        Cleared[i] = true;
                        Try(SP - dun[i, 1], count + 1);
                        Cleared[i] = false;
                    }
                }
                answer = Math.Max(answer, count);
            }