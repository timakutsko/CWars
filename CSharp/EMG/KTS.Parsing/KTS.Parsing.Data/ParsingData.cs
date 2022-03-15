using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace KTS.Parsing.Data
{
    public sealed class ParsingData
    {
        private string _url;

        public ParsingData(string url)
        {
            _url = url;
            // Инициализирую запуск Chrome через Selenium
            ChromeOptions options = new ChromeOptions();
            ChromeDriverService cService = ChromeDriverService.CreateDefaultService();
            cService.HideCommandPromptWindow = true;
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("headless");
            Driver = new ChromeDriver(cService, options);
            Driver.Navigate().GoToUrl(_url);
            // Ожидаю загрузки страницы
            Driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 1);
            Thread.Sleep(((int)Driver.Manage().Timeouts().PageLoad.TotalMilliseconds));
        }

        public readonly IWebDriver Driver;
        
        public List<CurrentData> RunParser()
        {
            // Создаю List, для хранения данных
            List<CurrentData> parserResult = new List<CurrentData>();
            // Начинаю получать данные
            ReadOnlyCollection<IWebElement> currentColl = Driver.FindElements(By.XPath(".//div[@class='rates-line rates-line-js']/ul/li"));
            for (int i = 0; i < 4; i++)
            {
                CurrentData currentData = new CurrentData();
                string[] strArray = currentColl[i].Text.Split(' ');
                currentData.Code = strArray[0];
                currentData.Name = getName(strArray[0]);
                currentData.Difference = strArray[1];
                currentData.Value = strArray[2].Trim('(', ')');
                currentData.Time = DateTime.Now;
                parserResult.Add(currentData);
            }
            return parserResult;
        }

        private string getName (string code)
        {
            switch (code)
            {
                case "ETH/USD":
                    return "Эфириум к доллару";
                case "EUR/USD":
                    return "Евро к доллару";
                case "JPM":
                    return "JPMorgan Chase & Co";
                case "SPX":
                    return "Standard and Poor's 500";
                case "SPY":
                    return "SPDR® S&P 500";
                default: 
                    return "Что-то новое...";
            }
        }
    }
}
