using ClosedXML.Excel;
using System;

namespace Ufynd.Task2.Application.Utils
{
    public static class IXlStyleExtensions
    {
        public static IXLStyle SetBorder(this IXLStyle value)
        {
            value = value ?? throw new ArgumentNullException(nameof(value));
            value.Border.SetBottomBorder(XLBorderStyleValues.Thin);
            value.Border.SetBottomBorderColor(XLColor.Black);
            value.Border.SetTopBorder(XLBorderStyleValues.Thin);
            value.Border.SetTopBorderColor(XLColor.Black);
            value.Border.SetRightBorder(XLBorderStyleValues.Thin);
            value.Border.SetRightBorderColor(XLColor.Black);
            value.Border.SetLeftBorder(XLBorderStyleValues.Thin);
            value.Border.SetLeftBorderColor(XLColor.Black);
            return value;
        }

        public static IXLStyle SetBold(this IXLStyle value)
        {
            value = value ?? throw new ArgumentNullException(nameof(value));
            value.Font.Bold = true;
            return value;
        }

        public static IXLStyle SetTextAligh(this IXLStyle value, bool isCenter)
        {
            value = value ?? throw new ArgumentNullException(nameof(value));
            value.Alignment.Horizontal = isCenter ? XLAlignmentHorizontalValues.Center : XLAlignmentHorizontalValues.Left;
            return value;
        }
    }
}
