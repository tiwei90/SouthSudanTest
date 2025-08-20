using System;
using System.Configuration;
using System.IO;

namespace ConfigurationSite.Shared
{
    /// <summary>
    /// Summary description for common
    /// </summary>
    public class common
    {
        #region Constant String Variable(s)

        //Messages use for all forms
        public const string UNBOUND = "Datagrid is unable to be bound";
        public const string FAILED = "Transaction failed!";
        public const string INSERTSUCC = "Record inserted successfully";
        public const string UPDATESUCC = "Record updated successfully";
        public const string DELETESUCC = "Record deleted successfully";
        public const string ErPage = "ErrorPage.aspx";
        public static string logoutErrMsg = "Logout Error!";

        public static string DELETEINCOMPLETE = GetValue("DeleteIncomplete").ToString();
        public static string DEVICETEST = GetValue("DeviceTest").ToString();

        static public string ImgDefaultUrl = GetValue("imgDefaultPath");
        #endregion

        public static string GetValue(string id)
        {
            #region ***
            try
            {
                return ConfigurationManager.AppSettings[id].ToString();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return "0";
            }
            #endregion
        }
        public static string YearMonthDayToDB(string ddMMyyyy)
        {
            #region ***
            if (ddMMyyyy == string.Empty) return string.Empty;
            //to yyyyMMdd
            return ddMMyyyy.Substring(4, 4) + ddMMyyyy.Substring(2, 2) + ddMMyyyy.Substring(0, 2);

            #endregion
        }

        public static string YearMonthDayDisplay(string yyyyMMdd)
        {
            #region ***
            if (yyyyMMdd == string.Empty) return string.Empty;
            //to dd/MM/yyyy
            return yyyyMMdd.Substring(6, 2) + "/" + yyyyMMdd.Substring(4, 2) + "/" + yyyyMMdd.Substring(0, 4);
            #endregion
        }
        public static bool DecodeBytetoImage(byte[] binaryData, out string msg)
        {
            #region ***
            if (binaryData == null)
            {
                binaryData = null;
                msg = "Binary Data string is null";
                return false;
            }
            else
            {
                #region Output Image File
                string outputFileName = System.Guid.NewGuid().ToString();
                try
                {
                    //Check for the file extension
                    if (binaryData[0] == 0x42 && binaryData[1] == 0x4D)
                    {
                        outputFileName = outputFileName + ".bmp";
                    }
                    else if (binaryData[0] == 0x47 && binaryData[1] == 0x49 && binaryData[2] == 0x46)
                    {
                        outputFileName = outputFileName + ".gif";
                    }
                    else if (binaryData[0] == 0xFF && binaryData[1] == 0xD8 && binaryData[2] == 0xFF)
                    {
                        outputFileName = outputFileName + ".jpg";
                    }
                    else if (binaryData[0] == 0x00 && binaryData[1] == 0x00 && binaryData[2] == 0x00)
                    {
                        outputFileName = outputFileName + ".jp2";
                    }
                    else if (binaryData[0] == 0xFF && binaryData[1] == 0xA0 && binaryData[2] == 0xFF)
                    {
                        outputFileName = outputFileName + ".wsq";
                    }
                    else
                    {
                        outputFileName = outputFileName + "unknown";
                    }


                    msg = outputFileName;
                    return true;

                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                    binaryData = null;
                    return false;
                }
                #endregion
            }
            #endregion
        }

        public static string GetImgUrl(byte[] binaryData, string outputFile, string msg)
        {
            #region ***

            //clean the existing image files in the folder
            int index = outputFile.Length - msg.Length;
            string dir = outputFile.Remove(index);
            string[] imgList = Directory.GetFiles(dir);
            foreach (string img in imgList)
            {
                FileInfo imgInfo = new FileInfo(img);
                if (imgInfo.LastWriteTime < DateTime.Now.AddMinutes(-15))
                {
                    try
                    {
                        imgInfo.Delete();
                    }
                    catch
                    {
                        continue;
                    }
                }
            }



            //Output the file 
            System.IO.FileStream outFile = new System.IO.FileStream(outputFile, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            outFile.Write(binaryData, 0, binaryData.Length);
            outFile.Close();

            return GetUpperPath(GetValue("ImgServerPath")) + msg;
            #endregion
        }

        public static string GetUpperPath(string path_string)
        {
            #region ***
            int startIndex = path_string.LastIndexOf("\\", path_string.Length - 2);
            return path_string.Substring(startIndex + 1);
            #endregion
        }

        public static string DisplayDateFromDB(string ddMMyyyy)
        {
            #region ***
            if (ddMMyyyy == string.Empty) return string.Empty;
            //to dd/MM/yyyy
            string day;
            string month;
            string year;


            #region get Month&date

            if (ddMMyyyy.Substring(1, 1) == "/")
            {
                month = "0" + ddMMyyyy.Substring(0, 1);
                if (ddMMyyyy.Substring(4, 1) == "/")
                {
                    day = ddMMyyyy.Substring(2, 2);
                    year = ddMMyyyy.Substring(5, 4);
                }
                else
                {
                    day = "0" + ddMMyyyy.Substring(2, 1);
                    year = ddMMyyyy.Substring(4, 4);
                }

            }
            else
            {
                month = ddMMyyyy.Substring(0, 2);
                if (ddMMyyyy.Substring(4, 1) == "/")
                {

                    day = "0" + ddMMyyyy.Substring(3, 1);
                    year = ddMMyyyy.Substring(5, 4);
                }
                else
                {
                    day = ddMMyyyy.Substring(3, 2);
                    year = ddMMyyyy.Substring(6, 4);
                }

            }
            #endregion

            return day + month + year;
            #endregion
        }

        public static string DayMonthYearDisplay(string ddMMyyyy)
        {
            #region ***
            if (ddMMyyyy == string.Empty) return string.Empty;
            //to dd/MM/yyyy
            return ddMMyyyy.Substring(0, 2) + "/" + ddMMyyyy.Substring(2, 2) + "/" + ddMMyyyy.Substring(4, 4);
            #endregion
        }
    }
}
