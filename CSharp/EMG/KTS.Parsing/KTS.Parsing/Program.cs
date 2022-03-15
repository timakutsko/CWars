using System;
using System.Collections.Generic;
using System.Threading;
using KTS.Parsing.Data;

namespace KTS.Parsing.Runner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParsingData parser = new ParsingData("https://twelvedata.com/pricing");
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string name = "MyParsing";
            WriteData writeData = new WriteData(path, name);
            int counter = 1;
            while (true)
            {
                Console.WriteLine("Введи 'STR' для старта, 'EXT' для выхода: ");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "str")
                {
                    counter++;
                    Console.WriteLine("Начинаю писать данные...");
                    List<CurrentData> parserData = parser.RunParser();
                    writeData.RunWriter(parserData, counter);
                    Console.WriteLine("Текущая запись завершена.");
                    Thread.Sleep(10000);
                }
                else if (userInput.ToLower() == "ext")
                {
                    Console.WriteLine("Завершено!");
                    parser.Driver.Quit();
                    break;
                }
            }
        }
    }
}
