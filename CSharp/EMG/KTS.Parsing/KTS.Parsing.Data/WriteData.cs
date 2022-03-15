using System;
using System.Collections.Generic;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KTS.Parsing.Data
{
    public sealed class WriteData
    {
        private string _path;
        private Excel.Application _excelApp;
        private Excel.Workbook _workBook;

        public WriteData(string path, string name)
        {
            _excelApp = new Excel.Application();
            _path = path + "\\" + name + ".xlsx";
        }
        public string SessionNumber { get; set; }

        public void RunWriter(List<CurrentData> currentDatas, int line)
        {
            // Создаю книгу
            try
            {
                _workBook = _excelApp.Workbooks.Open(_path);
            }
            catch
            {
                _workBook = _excelApp.Workbooks.Add();
            }
            Excel.Worksheet workSheet = _workBook.ActiveSheet;
            workSheet.Cells[1, "A"] = "Код";
            workSheet.Cells[1, "B"] = "Название";
            workSheet.Cells[1, "C"] = "Значение";
            workSheet.Cells[1, "D"] = "Изменение в процентах";
            workSheet.Cells[1, "E"] = "Время обновления";
            // Пишу в эксель
            foreach (var data in currentDatas)
            {
                workSheet.Cells[line, "A"] = data.Code;
                workSheet.Cells[line, "B"] = data.Name;
                workSheet.Cells[line, "C"] = data.Difference;
                workSheet.Cells[line, "D"] = data.Value;
                workSheet.Cells[line, "E"] = data.Time;
            }
            _workBook.Close(true, _path);
            _excelApp.Quit();
        }
    }
}
