using System;
using System.Linq;

namespace Alphanumeric
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] checkArray = new string[]
            {
                "Mazinkaiser",
                "hello world_",
                "PassW0rd",
                "         ",
                "",
            };

            foreach(string str in checkArray)
            {
                Console.WriteLine(Kata.Alphanumeric(str).ToString());
            }            
        }
    }

    internal static class Kata
    {
        /// <summary>
        /// Проверка, является ли строка ввода пользователя буквенно-цифровой. 
        /// </summary>
        public static bool Alphanumeric(string str)
        {
            bool result = true;
            int numb = str.ToCharArray().Count(c => !Char.IsLetterOrDigit(c));
            if (numb > 0 | str.Length == 0)
            {
                result = false;
            }
            return result;
        }
    }
}
