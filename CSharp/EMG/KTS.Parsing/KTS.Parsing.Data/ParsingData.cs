using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading;

namespace KTS.Parsing.Data
{
    public sealed class ParsingData
    {
        private readonly string _apiKey = "890861bddafd480d932873d23412a0f9";

        public ParsingData()
        {
        }

        ///<summary>
        /// Чтение данных с помощью веб-запросов из источника
        ///</summary>
        public List<CurrentData> RunParser(string[] requestsSymbol)
        {
            List<CurrentData> parserResult = new List<CurrentData>();
            foreach (var currentSymbol in requestsSymbol)
            {
                // Создаю web-запрос
                string apiUrl = $"https://api.twelvedata.com/quote?symbol={currentSymbol}&apikey={_apiKey}";
                WebRequest webRequest = WebRequest.Create(apiUrl);
                // Получаю ответ и преобразовываю его
                WebResponse response = webRequest.GetResponse();
                Stream contentStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(contentStream);
                string strContent = reader.ReadToEnd();
                // Десерилизация данных
                JsonDocument document = JsonDocument.Parse(strContent);
                JsonElement root = document.RootElement;
                string symbol = root.GetProperty("symbol").GetString();
                string name = root.GetProperty("name").GetString();
                string close = root.GetProperty("close").GetString();
                string percent_change = root.GetProperty("percent_change").GetString();
                string dateTime = DateTime.Now.ToString();
                CurrentData cData = new CurrentData()
                {
                    Code=symbol,
                    Name=name,
                    Difference=percent_change,
                    Value=close,
                    Time = dateTime
                };
                // Сбор данных в List<T>
                parserResult.Add(cData);
            }
            return parserResult;
        }
    }
}
