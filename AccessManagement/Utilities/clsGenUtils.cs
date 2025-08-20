using System;
using System.Collections;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace AccessManagement.Utilities
{
    /// <summary>
    /// General-purpose Utility Class.
    /// </summary>
    public sealed class GeneralMethods
    {
        private GeneralMethods() { }

        /// <summary>
        /// Redimension an array with specificed length
        /// </summary>
        /// <param name="arrToResize">The original array</param>
        /// <param name="length">The length of the new array</param>
        /// <returns>Returns an Array type, which may need casting</returns>
        public static Array Redim(Array arrToResize, int length)
        {
            Type t = arrToResize.GetType().GetElementType();
            Array newArray = Array.CreateInstance(t, length);
            Array.Copy(arrToResize, 0, newArray, 0, Math.Min(arrToResize.Length, length));
            return newArray;
        }

        /// <summary>
        /// Convert byte array into hexadecimal string
        /// </summary>
        public static string BytesToHexString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            for (int num = 0; num < bytes.Length; num++)
            {
                sb.Append(bytes[num].ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Convert hexadecimal string into byte array
        /// </summary>
        public static byte[] HexStringToBytes(string hex)
        {
            //Removes all non-hex characters from the hexstring
            hex = Regex.Replace(hex.ToUpper(), "[^0-9A-F]", "");
            byte[] buf = new byte[hex.Length / 2];
            for (int cnt = 0; cnt < hex.Length; cnt += 2)
            {
                buf[cnt / 2] = Byte.Parse(hex.Substring(cnt, 2), NumberStyles.AllowHexSpecifier);
            }
            return buf;
        }

        /// <summary>
        /// Search the HashTable with the specified Key for its value 
        /// </summary>
        public static String GetHashtableValue(Hashtable ht, string htKeyName)
        {
            try
            {
                IDictionaryEnumerator htEnum = ht.GetEnumerator();

                while (htEnum.MoveNext())
                {
                    if (htEnum.Key.Equals(htKeyName)) return htEnum.Value.ToString();
                }
            }
            catch (Exception err)
            {
                throw new Exception("GetHashtableValue Error: " + err.Message);
            }

            //If enumerator finished looping with finding anything, return empty string
            return String.Empty;
        }

        /// <summary>
        /// Convert DateTime to current String Format
        /// </summary>
        public static string FormatDateTime(DateTime dt)
        {
            return dt.ToString("yyyyMMddHHmmss");
        }

        /// <summary>
        /// Convert Date String to current Database Format.
        /// </summary>
        public static string DatabaseDate(string dt)
        {
            return FormatStringDate(dt, "dd/MM/yyyy", "yyyyMMdd", new DateTimeFormatInfo());
        }

        /// <summary>
        /// Convert String to current Local Date Format
        /// </summary>
        public static string LocalDate(string dt)
        {
            return FormatStringDate(dt, "yyyyMMdd", "dd/MM/yyyy", new DateTimeFormatInfo());
        }

        public static string FormatStringDate(string dt, string inFormat, string outFormat, System.IFormatProvider provider)
        {
            string result;
            try
            {
                DateTime temp = DateTime.ParseExact(dt, inFormat, provider);
                result = temp.ToString(outFormat);
            }
            catch
            {
                result = dt;
            }
            return result;
        }

    }

    //public sealed class ClientScript
    //{
    //    private ClientScript() { }

    //    public static void MessageBox(System.Web.UI.Page page, string message)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        sb.Append("<script language='JavaScript'>");
    //        sb.Append("alert(' " + message + "');");
    //        sb.Append("</script>");

    //        if (!page.IsStartupScriptRegistered("Msg"))
    //        {
    //            page.RegisterStartupScript("Msg", sb.ToString());
    //        }
    //    }

    //public static void Redirect(System.Web.UI.Page page, string URL)
    //{
    //    StringBuilder sb = new StringBuilder();
    //    sb.Append("<script language='JavaScript'>");
    //    sb.Append("location.href = '" + URL + "';");
    //    sb.Append("</script>");

    //    if (!page.IsStartupScriptRegistered("Redirect"))
    //    {
    //        page.RegisterStartupScript("Redirect", sb.ToString());
    //    }
    //}

    //}

}
