using ClosedXML.Excel;
using System;
using Ufynd.Task2.Application.Utils;

namespace Ufynd.Task2.Application.Utils
{
    public static class IXCellExtension
    {
        public static void SetHeader(this IXLCell cell, string title, int width)
        {
            cell = cell ?? throw new ArgumentNullException(nameof(cell));
            cell.WorksheetColumn().Width = width > 0 ? width : 100;
            // ws.Column(colIndex).Width = kvp.Item3 > 0 ? kvp.Item3 : 100;
            cell.Value = title;
            cell.Style.SetBold().SetTextAligh(true).SetBorder();
            cell.Style.Fill.BackgroundColor = XLColor.LightGray;
        }
    }
}
