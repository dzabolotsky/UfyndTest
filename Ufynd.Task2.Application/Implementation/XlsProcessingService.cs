using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ufynd.Task2.Application.Enums;
using Ufynd.Task2.Application.Interfaces;
using Ufynd.Task2.Application.Utils;

[assembly: InternalsVisibleTo("Ufynd.Task2.Tests")]
namespace Ufynd.Task2.Application.Implementation
{
    public record HeaderColumn(string Name, string Title, int Width = -1, AlighmentEnum Alighment = AlighmentEnum.Center);



    internal class XlsProcessingService: IXlsProcessingService
    {
        private XLAlignmentHorizontalValues GetAlighment(AlighmentEnum alighment)
        {
            switch (alighment)
            {
                case AlighmentEnum.Center:
                    return XLAlignmentHorizontalValues.Center;
                case AlighmentEnum.Left:
                    return XLAlignmentHorizontalValues.Left;
                case AlighmentEnum.Right:
                    return XLAlignmentHorizontalValues.Right;
                default:
                    return XLAlignmentHorizontalValues.Center;
            }
        }
        public Task CreateDocument<T>(IEnumerable<HeaderColumn> columns, IEnumerable<T> items, string title, string path) where T : class => Task.Run(() =>
        {
            var type = typeof(T);
            var props = type.GetProperties().Select(propInfo => propInfo.Name);
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Worksheet 1");
            int rowIndex = 1;
            int colIndex = 1;
            ws.SetTitle(wb, title, rowIndex, colIndex, columns.Count());
            rowIndex++;
            foreach (var column in columns)
            {
                if (props.Any(r => r == column.Name))
                {
                    ws.Cell(rowIndex, colIndex).SetHeader(column.Title, column.Width);
                    colIndex++;
                }
            }
            rowIndex++;
            colIndex = 1;
            // fill content
            foreach (var item in items)
            {
                colIndex = 1;
                foreach (var column in columns)
                {
                    var itmType = item.GetType();
                    var prop = itmType.GetProperty(column.Name);

                    var value = prop.PropertyType == typeof(bool) ? Convert.ToInt32(prop.GetValue(item, null)).ToString() : prop.GetValue(item, null)?.ToString();
                    ws.Cell(rowIndex, colIndex).Value = value;
                    ws.Cell(rowIndex, colIndex).Style.SetTextAligh(true).SetBorder();
                    ws.Cell(rowIndex, colIndex).Style.Alignment.Horizontal = GetAlighment(column.Alighment);
                    colIndex++;
                }
                if (rowIndex % 2 == 0)
                    ws.Range(rowIndex, 1, rowIndex, columns.Count()).Style.Fill.SetBackgroundColor(XLColor.BlueGray);
                rowIndex++;
            }
            ws.Range(2, 1, 1 + rowIndex, columns.Count()).SetAutoFilter();

            wb.SaveAs(path);

        });
    }
}
