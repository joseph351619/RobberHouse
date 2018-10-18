using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobberHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayNums = new int[] {200, 234, 182, 111, 87, 194, 221, 217, 71, 162, 140, 51, 81, 80, 232, 193, 223, 103, 139, 103 };
            Console.WriteLine(Robber(arrayNums));
            Console.ReadLine();
        }
        static int Robber(int[] nums)
        {
            int length = nums.Length;
            if (length == 0)
            {
                return 0;
            }
            int answer = 0;
            int robbed = 0;
            int previousAnswer = 0;
            int[][] answerArray = new int[length][];
            int[] robbedArray = new int[length];
            for(int i=0; i<length; ++i)
            {
                robbedArray[i] = 0;
            }
            for(int i=0; i< length; ++i)
            {
                answerArray[i] = new int[] { i, nums[i] };
            }
            Array.Sort(answerArray, new Comparison<int[]>((x, y) => { return x[1] > y[1] ? -1 : (x[1] < y[1] ? 1 : 0); }));
            for (int i=0;i < length ; i++)
            {
                answer += answerArray[i][1];
                robbed = answerArray[i][0];
                robbedArray[robbed] = 1;
                if (robbed != 0) robbedArray[robbed - 1] = 1;
                if (robbed != length-1) robbedArray[robbed + 1] = 1;
                for (int j=0; j<length; ++j)
                {
                    if (robbedArray[answerArray[j][0]] != 1)
                    {
                        answer += answerArray[j][1];
                        robbed = answerArray[j][0];
                        robbedArray[robbed] = 1;
                        if (robbed != 0) robbedArray[robbed - 1] = 1;
                        if (robbed != length-1) robbedArray[robbed + 1] = 1;
                    }
                }
                if (answer > previousAnswer)
                {
                    previousAnswer = answer;
                }
                answer = 0;
                for (int k = 0; k < length; ++k)
                {
                    robbedArray[k] = 0;
                }
                if(length-1 == i)
                {
                    break;
                }
            }
            return previousAnswer;
        }

    }
}
