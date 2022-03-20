using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace KTS.Parsing.Data
{
    public sealed class WriteData
    {
        private static int _line = 1;
        private string _path;

        ///<summary>
        /// Создание эксель пакета, с преднастроенной шапкой
        ///</summary>
        public WriteData(string path)
        {
            _path = path;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage package = new ExcelPackage(_path);
            ExcelWorksheet sheet = package.Workbook.Worksheets.Add("MyData");
            sheet.Cells[1, 1].Value = "Код";
            sheet.Cells[1, 2].Value = "Имя";
            sheet.Cells[1, 3].Value = "Изменение";
            sheet.Cells[1, 4].Value = "Значение";
            sheet.Cells[1, 5].Value = "Время записи";
            package.Save();
        }

        ///<summary>
        /// Генерация пакета данных и запись данного пакета данных в эксель
        ///</summary>
        public void Generate (List<CurrentData> parserReports)
        {
            ExcelPackage package = new ExcelPackage(_path);
            ExcelWorksheet sheet = package.Workbook.Worksheets[0];
            foreach (CurrentData report in parserReports)
            {
                _line++;
                sheet.Cells[_line, 1].Value = report.Code;
                sheet.Cells[_line, 2].Value = report.Name;
                sheet.Cells[_line, 3].Value = report.Difference;
                sheet.Cells[_line, 4].Value = report.Value;
                sheet.Cells[_line, 5].Value = report.Time;
            }
            package.Save();
        }
    }
}
