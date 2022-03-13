using System;
using System.Linq;

namespace ArrayDiff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5 };
            int[] b = new int[5];
            Array.Copy(a, b, a.Length);
            Array.Reverse(b);

            
            
            int[] arr11 = new int[] { 3 };
            int[] arr21 = new int[] { 1, 2, 3 };
            int[] res1 = Kata.ArrayDiff(arr11, arr21);
            
            int[] arr12 = new int[] { 1, 2, 2, 2, 3 };
            int[] arr22 = new int[] { 2 };
            int[] res2 = Kata.ArrayDiff(arr12, arr22);

            int[] arr13 = new int[] { 2, 2 };
            int[] arr23 = new int[] { 1, 2, 2 };
            int[] res3 = Kata.ArrayDiff(arr13, arr23);

            int[] arr14 = new int[] { };
            int[] arr24 = new int[] { 1, 2 };
            int[] res4 = Kata.ArrayDiff(arr14, arr24);

            int[] arr15 = new int[] { 1, 2, 2 };
            int[] arr25 = new int[] { 1 };
            int[] res5 = Kata.ArrayDiff(arr15, arr25);
        }
    }

    public class Kata
    {
        public static int[] ArrayDiff(int[] a, int[] b)
        {
            int maxItems = a.Length > b.Length ? a.Length : b.Length;
            int[] result = new int[maxItems];
            if(a.Length == 0 && b.Length == 0)
            {
                return new int[] { 1, 2 };
            }
            else if(a.Length == 0 || b.Length == 0)
            {
                return a.Length > b.Length ? a : b;
            }
            else if (Enumerable.SequenceEqual(a, b))
            {
                return Array.Empty<int>();
            }
            else
            {
                foreach(int i in b)
                {
                    result = Array.FindAll(a, x => x != i);
                }
                if(result.Length == 0)
                {
                    foreach (int i in a)
                        {
                            result = Array.FindAll(b, x => x != i);
                        }
                }
                return result;
            }
        }
    }
}
