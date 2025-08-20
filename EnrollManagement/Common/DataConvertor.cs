using System;
using System.Globalization;

namespace EnrollManagement.Common
{
    internal class DataConvertor
    {
        internal static int? ToInt32(object value)
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            else if (string.IsNullOrEmpty(value.ToString()))
            {
                return null;
            }
            else
            {
                return Convert.ToInt32(value);
            }
        }

        internal static long? ToInt64(object value)
        {
            if (value != DBNull.Value)
            {
                return Convert.ToInt64(value);
            }
            else
            {
                return null;
            }
        }

        internal static byte[] ToByteArray(object value)
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            else
                if (value == null)
            {
                return null;
            }
            else
            {
                return (byte[])value;
            }
        }

        internal static DateTime? ToDateTime(object value)
        {
            CultureInfo MyCultureInfo = new CultureInfo("en-GB");

            if (value == DBNull.Value)
            {
                return null;
            }
            else if (string.IsNullOrEmpty(value.ToString()))
            {
                return null;
            }
            else
            {
                return Convert.ToDateTime(value, MyCultureInfo);

            }
        }




    }
}
