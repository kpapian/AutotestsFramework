using System;
using System.Text.RegularExpressions;

namespace CommonLib.CommonUtils
{
    public static class StringExtentions
    {
        public static String WhiteSpacesAndTabulationsCorrection(this String sourse)
        {
            Regex result = new Regex(@"\s\s+|\n|\r|\t|<br>");
            return result.Replace(sourse, " ").Trim();
        }
    }
}
