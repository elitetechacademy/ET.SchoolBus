using System;
using ET.SchoolBus.Pack.Enumerations;

namespace ET.SchoolBus.Pack.Extensions;

public static class StringExtensions
{
    public static string ToUpperByCulture(this string strToUpper, Culture targetCulture)
    {
        var upperStr=String.Empty;

        switch (targetCulture)
        {
            case Culture.EN :
                upperStr = strToUpper.ToUpper(new System.Globalization.CultureInfo("en-US"));
                break;
            case Culture.TR : 
                upperStr = strToUpper.ToUpper(new System.Globalization.CultureInfo("tr-TR"));
                break;
            default:
                break;
        }

        return upperStr;
    }
}
