using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using KTS.Parsing.Data;

namespace KTS.Parsing.Runner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаю список символов для запросов. На хард-коде, после - можно через ui сделать выборку, что писать
            string[] requestsSymbol = new string[] {
                "ETH/USD",
                "EUR/USD",
                "JPM",
                "SPX",
                "USD/JPY"
            };
            // Пользовательский ввод
            Console.WriteLine("Укажи путь для сохранения:");
            string userPath = Console.ReadLine();
            userPath = string.Concat(userPath, "\\sample1.xlsx");
            // Возможность выхода из приложения
            Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);
            // Обработка
            ParsingData parser = new ParsingData();
            WriteData writeData = new WriteData(userPath);
            Console.WriteLine("Процесс записи запущен. Для прекращения - нажми 'Ctrl+C'");
            int count = 0;
            while (true)
            {
                count++;
                Console.WriteLine($"Итерация №{count} прошла успешно!");
                List<CurrentData> parsingResult = parser.RunParser(requestsSymbol);
                writeData.Generate(parsingResult);
                Thread.Sleep(60000);
            }
        }
        private static void myHandler(object sender, ConsoleCancelEventArgs args)
        {
            {
                if (args.SpecialKey == ConsoleSpecialKey.ControlC)
                {
                    Console.WriteLine("Процесс записи завершен!");
                    Environment.Exit(0);
                }
            }
        }
    }
}
