using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace Pars
{
    class PrintExel
    {
        public static void ExportToExcel(List<Price> vPices)
        {
            // Загрузить Excel, затем создать новую пустую рабочую книгу
            var excelApp = new Excel.Application();
            
            // Сделать приложение Excel видимым
            excelApp.Visible = true;
            excelApp.Workbooks.Add();
            Excel._Worksheet workSheet = excelApp.ActiveSheet;
            // Установить заголовки столбцов в ячейках
            workSheet.Cells[1, "A"] = "NameCompany";
            workSheet.Cells[1, "B"] = "Site";
            workSheet.Cells[1, "C"] = "Cost";
            workSheet.Cells[1, "D"] = "eToken";
            int row = 1;
            foreach (Price c in vPices)
            {
                row++;
                workSheet.Cells[row, "A"] = c.Name;
                workSheet.Cells[row, "B"] = c.Site;
                workSheet.Cells[row, "C"] = c.Cost;
                workSheet.Cells[row, "D"] = c.eToken;
            }

                // Придать симпатичный вид табличным данным
                workSheet.Range["A1"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);
                // Сохранить файл, выйти из Excel

                // убрать предупреждения!!! нужно для перезаписи
                excelApp.DisplayAlerts = false;
                workSheet.SaveAs(string.Format(@"{0}\Price.xlsx", Environment.CurrentDirectory));
                // Возвращаем обратно после сохранения 
                excelApp.DisplayAlerts = true;
                //excelApp.Quit();
        }
    }
}
