using System;
using System.Configuration;
using System.IO;
using System.Web;

namespace EnrollmentIssuanceSite.Shared
{
    /// <summary>
    /// Summary description for common
    /// </summary>
    public class Common
    {
        #region Constant String Variable(s)
        //Constant string use for all forms

        #region permission code
        public static string GETAPPLICATIONID = GetValue("GetApplicationIDCode");
        public static string COMPLETEPERMISSIONCODE = GetValue("CompleteEnrolCode");
        public static string PARTIALENROL = GetValue("PartialEnrolCode");
        public static string GETDETAILSPERMISSIONCODE = GetValue("GetDetailsPermissionCode");
        public static string STATUSUPDATECODE = GetValue("StatusUpdateCode");
        public static string GETDETAILSBYNAME = GetValue("GetDetailsByName");
        public static string DATAENTRYLISTCODE = GetValue("DataEntryListCode");
        public static string QUERYBYNAMECODE = GetValue("QueryByNameCode");
        public static string VISITPURPOSECODE = GetValue("VisitPurposeCode");
        public static string IMMSTATUSCODE = GetValue("ImmStatusCode");
        public static string GETCOUNTRY = GetValue("SelectCountry");
        public static string ENROLCONTACT = GetValue("EnrolContactInfo");
        public static string ENROLTRAVEL = GetValue("EnrolTravelInfo");
        public static string ENROLEMPLOYMENT = GetValue("EnrolEmpInfo");
        public static string ENROLFAMILY = GetValue("EnrolFamilyInfo");
        public static string ENROLEDUCATION = GetValue("EnrolEduInfo");
        public static string ENROLADDITIONAL = GetValue("EnrolAddInfo");

        public static string SCANDOCLISTCODE = GetValue("ScanDocListCode");
        public static string INSERTSCANDOC = GetValue("InsertScanDoc");
        public static string DELETESCANDOC = GetValue("DeleteScanDoc");

        //LOOKUP TABLE
        public static string NAMECHANGEDCODE = GetValue("NameChangedPCode");
        public static string SIGNREASONCODE = GetValue("SignatureReasonPCode");
        public static string FINGERREASONCODE = GetValue("FingerReasonPCode");
        public static string CITIZENMODECODE = GetValue("CitizenModePCode");
        public static string DOCTYPECODE = GetValue("DocTypePCode");
        public static string SCANDOCTYPECODE = GetValue("SelectScanTypeCode");
        public static string CONFIGDOCTYPECODE = GetValue("SelectConfigDocType");
        public static string INCOMECODE = GetValue("SelectIncomeCode");

        #endregion
        public static string COUNTRYCODE = GetValue("CountryCode");
        public static string COUNTRYNAME = GetValue("CountryName");
        public static string NATIONALITY = GetValue("Nationality");
        public static string NATIONALITYCODE = GetValue("NationalityCode");
        public static string PRIORITY = GetValue("Priority");
        public static string LOCATION = GetValue("LocationName");
        public static string BRANCHCODE = GetValue("BranchCode");
        public static string BRANCHNAME = GetValue("BranchName");
        public static string LAYOUT = GetValue("PassportLayout");
        public static string IDENTIFIER = GetValue("Identifier");
        public static string AUTHORITYCODE = GetValue("AuthorityCode");

        #region DOCTYPE
        public static string WORKPERMIT = GetValue("WorkPermit");
        public static string PERMITTORESIDE = GetValue("PermitToReside");
        public static string PERMANENTRESIDENCE = GetValue("PermanentResidence");
        public static string HOMEOWNER = GetValue("HomeOwner");
        public static string RESIDENTSPOUSE = GetValue("ResidentSpouse");
        public static string NATURALIZATION = GetValue("Naturalization");
        public static string CITIZENSHIP = GetValue("Citizenship");
        public static string REGISTRATION = GetValue("Registration");
        #endregion

        public static string IMGSIG = "imgSignature";
        public static string COMPLETEENROLECODE = GetValue("DEStage");
        public static string UPDATEPROFILECODE = GetValue("UpdateProfileEntry");
        public static string UPDATEPROFILEENROLCODE = GetValue("UpdateProfileEnroll");
        public static string UPDATEPROFILEPECODE = GetValue("UpdateProfilePE");
        public static string ACLERK = GetValue("AcceptanceClerk");
        public static string DATAENTRY = GetValue("DataEntry");
        public static string IRISENGINEER = GetValue("IrisEngineer");
        public const int SuccessfulCode = 0;

        //Messages use for all forms
        public const string FAILEDINSERT = "Failed to insert record!";
        public const string FAILEDDELETE = "Failed to delete record!";
        public const string FAILEDUPDATE = "Unable to perform update profile!";
        public const string FAILEDATAENTRY = "Unable to perform data entry!";
        public const string NOAVAUPDATE = "Update is not available";
        public const string FAILED = "Transaction failed!";
        public const string SUCCESS = "Transaction completed!";
        public const string NORECORD = "No record found!";
        public const string ERRORMSG = "Error! ";
        public const string ErPage = "ErrorPage.aspx";
        public const string ONGOING = "On going transaction detected. Current Form Number:";
        public const string NOONGOING = @"No on going transaction detected. Insert the GMPC Number and press 'Search Local' to update record";
        public const string PROCEED = "Continue on previous transaction. Form Number:";
        public const string UPDATE = "Updating records for Form Number:";
        public const string FILENOTFOUND = " The particular xml file is not found!";
        public const string NOGMPC = "Please insert the Form number.";
        public const string FILLMAN = @"Please fill in all mandatory (*) field!";
        public static string logoutErrMsg = "Logout Error!";

        #endregion

        #region Image file location

        static public string calImgUrl = "./images/button.gif";
        static public string ImgSig = GetValue("imgSig");
        static public string ImgLeft1 = GetValue("imgL1");
        static public string ImgRight1 = GetValue("imgR1");
        static public string ImgDefaultUrl = GetValue("imgDefaultPath");
        static public string NoImage = GetValue("noImage");

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
            //to MMddyyyy
            return ddMMyyyy.Substring(2, 2) + ddMMyyyy.Substring(0, 2) + ddMMyyyy.Substring(4, 4);

            #endregion
        }

        public static string RedirectToPage(int pageNo, string sm)
        {
            #region ***
            string page;
            switch (pageNo)
            {
                case 0:
                    page = "ApplicationPart1.aspx?sm=" + sm;
                    break;
                case 1:
                    page = "VisaPayment.aspx?sm=" + sm;
                    break;
                case 2:
                    page = "CollectionSummary.aspx?sm=" + sm;
                    break;
                case 3:
                    page = "ApplicationPart2.aspx?sm=" + sm;
                    break;
                case 4:
                    page = "ApplicationPart3.aspx?sm=" + sm;
                    break;
                case 5:
                    page = "ApplicationPart4.aspx?sm=" + sm;
                    break;
                case 6:
                    page = "ApplicationPart5.aspx?sm=" + sm;
                    break;
                case 7:
                    page = "CheckDMS.aspx?sm=" + sm;
                    break;
                case 8:
                    page = "ApplicationPart6.aspx?sm=" + sm;
                    break;
                case 9:
                    page = "CollectionSummary.aspx?sm=" + sm;
                    break;
                default:
                    page = "ApplicationPart1.aspx?sm=" + sm;
                    break;
            }
            return page;
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

        public static string DisplayDateFromDB_(Object inDate)
        {
            string outDate = string.Empty;

            DateTime dt = Convert.ToDateTime(inDate);

            if (dt != null)
                outDate = dt.ToString("dd/MM/yyyy").Replace("/", "");

            return outDate;
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

        public static bool DecodeBase64toImage(string base64data, out string msg, out byte[] binaryData)
        {
            #region ***
            #region Convert Base64 into Binary File
            // Convert the Base64 UUEncoded input into binary output.
            try
            {
                binaryData = System.Convert.FromBase64String(base64data);

            }
            catch (System.ArgumentNullException)
            {

                msg = "Base 64 string is null.";
                binaryData = null;
                return false;
            }
            catch (System.FormatException)
            {
                msg = "Base 64 string length is not 4 or is not an even multiple of 4.";
                binaryData = null;
                return false;
            }
            #endregion

            #region Output Image File
            // Write out the decoded data.
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

            //return GetUpperPath(GetValue("ImgServerPath")) + msg;
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

        public static string GetThumbUrl(byte[] binaryData, string outputFile)
        {
            #region ***

            System.IO.FileStream outFile = new System.IO.FileStream(outputFile, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            outFile.Write(binaryData, 0, binaryData.Length);
            outFile.Close();

            return outputFile;
            #endregion
        }

        public static void WriteThumbToFile(byte[] binaryData, string outputFile)
        {
            #region ***
            try
            {
                System.IO.FileStream outFile = new System.IO.FileStream(outputFile, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                outFile.Write(binaryData, 0, binaryData.Length);
                outFile.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        public static bool DecodeImagetoBase64(string strSrc, byte[] imgByte, out string msg)
        {
            #region ***
            if (strSrc == null)
            {
                strSrc = null;
                msg = "Image cannot be found";
                return false;
            }
            else
            {
                //Convert image jpg into binary
                MemoryStream ms = new MemoryStream();
                System.Drawing.Image jpg = System.Drawing.Image.FromFile(strSrc);
                jpg.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                imgByte = ms.ToArray();

                // convert binary into base64string
                msg = System.Convert.ToBase64String(imgByte);
                return true;
            }
            #endregion
        }

        public static void WriteLog(string LogPath, string ErrMessage)
        {
            #region ***
            if (!System.IO.Directory.Exists(LogPath))
            {
                System.IO.Directory.CreateDirectory(LogPath);
            }

            try
            {
                // Write to exception error log
                System.IO.StreamWriter file = new System.IO.StreamWriter(LogPath + "//" + DateTime.Now.ToString("ddMMyyyy") + "error.log", true);
                file.WriteLine("[ " + DateTime.Now + " ] " + ErrMessage + "\n\n");
                file.Close();
            }
            catch
            {
                // Dunno known who to throw it to
            }
            #endregion
        }

        public static bool SetCookie(System.Web.UI.Page page, string cookiename, string cookievalue)
        {
            try
            {
                HttpCookie objCookie = new HttpCookie(cookiename);

                string[] cookies = page.Request.Cookies.AllKeys;

                foreach (string cookie in cookies)
                {
                    if (cookie == cookiename)
                    {
                        page.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
                        page.Response.Expires = -1500;
                        page.Response.CacheControl = "no-cache";

                        page.Response.Cookies[cookie].Value = null;
                        page.Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
                    }
                }

                page.Response.Cookies.Add(objCookie);

                objCookie.Value = cookievalue;

                objCookie.Expires = DateTime.Now.AddDays(1);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static string GetCookie(System.Web.UI.Page page, string cookiename)
        {
            string cookyval = "";

            try
            {
                cookyval = page.Request.Cookies[cookiename].Value;
            }
            catch (Exception)
            {
                cookyval = null;
            }
            return cookyval;
        }
    }
}
