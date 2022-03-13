using System;
using System.Linq;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] res1 = Kata.TwoSum(new []{ 1, 2, 3 }, 4);
            int[] res2 = Kata.TwoSum(new []{ 2, 2, 3 }, 4);
            int[] res3 = Kata.TwoSum(new[] { 1234, 5678, 9012 }, 14690);
        }

    }
    public class Kata
    {
        public static int[] TwoSum(int[] numbers, int target)
        {
            int i = 0;
            int trueIndex = 0;
            for (i = 0; i < numbers.Length; i++)
            {
                trueIndex = Array.FindIndex(numbers, (n => (n + numbers[i] == target)));
                if (trueIndex != -1 && trueIndex != i)
                {
                    break;
                }
            }
            return new int[] { i, trueIndex };
        }
    }
}
