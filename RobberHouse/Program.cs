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
            int[] arrayNums = new int[] { 200, 234, 182, 111, 87, 194, 221, 217, 71, 162, 140, 51, 81, 80, 232, 193, 223, 103, 139, 103 };
            //                            200,    , 182,        , 194,    , 217,   , 162,        , 81,   , 232,    , 223,    , 139,
            //                            200,    , 182,    , 87,    , 221,    , 71,    , 140,   , 81,   , 232,    , 223,    , 139,
            //                            200,    , 182,    , 87,    ,    , 217,   , 162,    , 51,   , 80,    , 193,    , 103,    , 103
            arrayNums = new int[] { 1, 3, 1, 3, 100 };
            arrayNums = new int[] { 8, 2, 8, 9, 2 };
            //Console.WriteLine(Robber(arrayNums));
            Console.WriteLine(Robber3(arrayNums));
            //Console.WriteLine(Robber2(arrayNums));
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
            //Array.Sort(answerArray, new Comparison<int[]>((x, y) => { return x[1] > y[1] ? -1 : (x[1] < y[1] ? 1 : 0); }));
            for (int i=0;i < length ; i++)
            {
                answer += answerArray[i][1];
                robbed = answerArray[i][0];
                robbedArray[robbed] = 1;
                if (robbed != 0) robbedArray[robbed - 1] = 1;
                if (robbed != length-1) robbedArray[robbed + 1] = 1;
                Console.Write(answerArray[i][1] + ",");
                for (int j=0; j<length; ++j)
                {
                    if (robbedArray[answerArray[j][0]] != 1)
                    {
                        answer += answerArray[j][1];
                        robbed = answerArray[j][0];
                        robbedArray[robbed] = 1;
                        if (robbed != 0) robbedArray[robbed - 1] = 1;
                        if (robbed != length-1) robbedArray[robbed + 1] = 1;
                        Console.Write(answerArray[j][1] + ",");
                    }
                }
                if (answer > previousAnswer)
                {
                    previousAnswer = answer;
                }
                Console.Write(answer);
                answer = 0;
                for (int k = 0; k < length; ++k)
                {
                    robbedArray[k] = 0;
                }
                if(length-1 == i)
                {
                    break;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            return previousAnswer;
        }
        static int Robber2(int[] nums)
        {
            int length = nums.Length;
            int possible1 = 0;
            int possible2 = 0;
            int possible3 = 0;
            int answer = 0;
            int secondAnswer = 0;
            for (int i=0; i<length; ++i)
            {
                possible1 = nums[i];
                if (i + 1 < length)
                {
                    possible2 = nums[i + 1];
                    if (i + 2 < length)
                    {
                        possible1 = nums[i] + nums[i + 2];
                        if (i + 3 < length)
                        {
                            possible2 = nums[i] + nums[i + 3];
                            possible3 = nums[i + 1] + nums[i + 3];
                        }
                    }
                }
                if(possible1>=possible2 && possible1 >= possible3)
                {
                    answer += possible1;
                    if (i + 2 < length) Console.Write(nums[i] + "," + nums[i + 2] + ",");
                    i += 3;
                }
                else if (possible2 >= possible1 && possible2 >= possible3)
                {
                    answer += possible2;
                    if (i + 3 < length) Console.Write(nums[i] + "," + nums[i + 3] +",");
                    i += 4;
                }
                else if (possible3 >= possible1 && possible3 >= possible2)
                {
                    answer += possible3;
                    if (i + 3 < length) Console.Write(nums[i+1] + "," + nums[i + 3] + ",");
                    i += 4;
                }
                possible1 = 0;
                possible2 = 0;
                possible3 = 0;
            }
            nums = nums.Reverse().ToArray();
            for (int i = 0; i < length; ++i)
            {
                possible1 = nums[i];
                if (i + 1 < length)
                {
                    possible2 = nums[i + 1];
                    if (i + 2 < length)
                    {
                        possible1 = nums[i] + nums[i + 2];
                        if (i + 3 < length)
                        {
                            possible2 = nums[i] + nums[i + 3];
                            possible3 = nums[i + 1] + nums[i + 3];
                        }
                    }
                }
                if (possible1 >= possible2 && possible1 >= possible3)
                {
                    secondAnswer += possible1;
                    if (i + 2 < length) Console.Write(nums[i] + "," + nums[i + 2] + ",");
                    i += 3;
                }
                else if (possible2 >= possible1 && possible2 >= possible3)
                {
                    secondAnswer += possible2;
                    if (i + 3 < length) Console.Write(nums[i] + "," + nums[i + 3] + ",");
                    i += 4;
                }
                else if (possible3 >= possible1 && possible3 >= possible2)
                {
                    secondAnswer += possible3;
                    if (i + 3 < length) Console.Write(nums[i + 1] + "," + nums[i + 3] + ",");
                    i += 4;
                }
                possible1 = 0;
                possible2 = 0;
                possible3 = 0;
            }
            if (secondAnswer > answer)
            {
                return secondAnswer;
            }
            else
            {
                return answer;
            }
        }
        static int ans = 0;
        static int Robber3(int[] nums)
        {
            ans = 0;
            RobberRecursion(nums, 0, 0);
            RobberRecursion(nums, 1, 0);
            return ans;
        }
        static void RobberRecursion(int[] nums, int index, int answer)
        {
            if (index >= nums.Length)
            {
                if (answer > ans) ans = answer;
            }
            else
            {
                RobberRecursion(nums, index + 2, answer + nums[index]);
                RobberRecursion(nums, index + 3, answer + nums[index]);
            }
        }

    }
}
