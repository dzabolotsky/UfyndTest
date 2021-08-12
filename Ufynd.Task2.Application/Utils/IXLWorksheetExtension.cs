using ClosedXML.Excel;
using System;
using Ufynd.Task2.Application.Utils;

namespace Ufynd.Task2.Application.Utils
{
    public static class IXLWorksheetExtension
    {
        public static IXLWorksheet SetTitle(this IXLWorksheet ws, XLWorkbook wb, string title, int rowIndex, int colIndex, int columnsCount)
        {
            ws = ws ?? throw new ArgumentNullException(nameof(ws));
            wb = wb ?? throw new ArgumentNullException(nameof(wb));
            ws.Cell(rowIndex, colIndex).Value = title;
            ws.Range(rowIndex, colIndex, rowIndex, colIndex + columnsCount - 1).Merge().AddToNamed("Titles");
            var titlesStyle = wb.Style;
            titlesStyle.Font.FontSize = 16;
            titlesStyle.SetBold().SetTextAligh(true).SetBorder();
            wb.NamedRanges.NamedRange("Titles").Ranges.Style = titlesStyle;
            return ws;
        }
    }
}
