using System;
using System.Collections.Generic;

namespace 주차_요금_계산
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Fees;
            int[] solution(int[] fees, string[] records)
            {
                Fees = new int[] { };
                Fees = fees;
                string[] RecordArray = new string[3];
                //value값은 입차시간,출차여부(차 없음 = 0,차 있음 = 1),시간
                Dictionary<int, int[]> InTimeDic = new Dictionary<int, int[]>();
                List<int> CarNumbers = new List<int>();
                for (int i = 0; i<records.Length; i++)
                {
                    RecordArray = records[i].Split(' ');
                    int CarNum = Int32.Parse(RecordArray[1]);
                    if (RecordArray[2] == "IN")
                    {
                        //딕셔너리에 해당 차 번호가 있는지 확인
                        if (InTimeDic.ContainsKey(CarNum) == true)
                        {
                            InTimeDic[CarNum][1] = 1;
                            InTimeDic[CarNum][0] = ConvertTime(RecordArray[0]);
                        }
                        //없으면 추가, 있으면 입차시간과 출차여부 갱신
                        else
                        {
                            CarNumbers.Add(CarNum);
                            InTimeDic.Add(CarNum, new int[] { ConvertTime(RecordArray[0]), 1, 0 });
                        }
                    }
                    else if(RecordArray[2] == "OUT")
                    {
                        InTimeDic[CarNum][1] = 0;
                        InTimeDic[CarNum][2] += (ConvertTime(RecordArray[0]) - InTimeDic[CarNum][0]);
                    }
                }
                CarNumbers.Sort();
                List<int> answer = new List<int>();
                foreach(int num in CarNumbers)
                {
                    int EndTime = ConvertTime("23:59");
                    if(InTimeDic[num][1] == 1)
                    {
                        InTimeDic[num][1] = 0;
                        InTimeDic[num][2] += (EndTime - InTimeDic[num][0]);
                        answer.Add(CalFees(InTimeDic[num][2]));
                    }
                    else
                    {
                        answer.Add(CalFees(InTimeDic[num][2]));
                    }
                }
                return answer.ToArray();
            }

            int ConvertTime(string TimeString)
            {
                string[] TimeArray = TimeString.Split(':');
                int time = Int32.Parse(TimeArray[0])*60 + Int32.Parse(TimeArray[1]);
                return time;
            }

            int CalFees(int Time)
            {
                if (Time <= Fees[0])
                    return Fees[1];
                else
                {
                    if((Time - Fees[0]) % Fees[2] > 0)
                        return (Fees[1] + (Time - Fees[0]) / Fees[2] * Fees[3]) + Fees[3];
                    else
                        return (Fees[1] + (Time - Fees[0]) / Fees[2] * Fees[3]);
                }
            }

            //기본시간, 기본요금, 단위, 요금
            int[] fees1 = new int[] { 180, 5000, 10, 600 };
            string[] records1 = new string[] { "05:34 5961 IN", "06:00 0000 IN", "06:34 0000 OUT", "07:59 5961 OUT", "07:59 0148 IN", "18:59 0000 IN", "19:09 0148 OUT", "22:59 5961 IN", "23:00 5961 OUT" };

            int[] Answer = new int[] { };
            Answer = solution(fees1, records1);
            foreach(int a in Answer)
                Console.WriteLine($"{a} ");
        }
    }
}
