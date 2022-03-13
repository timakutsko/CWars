using System;
using System.Linq;

namespace SpimWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input1 = "Hey wollef sroirraw";
            string result1 = Kata.SpinWords(input1);

            string input2 = "This is a test";
            string result2 = Kata.SpinWords(input2);

        }
    }
    public class Kata
    {
        public static string SpinWords(string sentence)
        {
            return string.Join(" ", sentence.Split().Select(x => x.Length < 5 ? x : new string(x.Reverse().ToArray())));
        }
    }


}
