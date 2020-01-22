using System;

namespace CryptoTools.Helpers
{
    public class HrString
    {
        public HrString()
        {
            //
            // TODO: Add constructor logic here
            //

        }
        public static bool IsNumber(string value)
        {
            if (value == string.Empty)
                return false;
            for (int i = 0; i < value.Length; i++)
                if (!Char.IsNumber(Convert.ToChar(value.Substring(i, 1))))
                    return false;
            return true;
        }
        public static string Min(string value1, string value2)
        {

            return (String.CompareOrdinal(value1, value2) <= 0) ? value1 : value2;
        }
        public static string Max(string value1, string value2)
        {
            return (String.CompareOrdinal(value1, value2) >= 0) ? value1 : value2;
        }

       
    }
}