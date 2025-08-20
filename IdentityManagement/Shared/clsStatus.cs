using System;
using System.Collections;

namespace IdentityManagement.Shared
{
    /// <summary>
    /// Summary description for clsStatus.
    /// </summary>
    /// 
    public class StatusDateTime
    {
        private string yYYY;
        private string mM;
        private string dD;
        private string hour;
        private string minute;
        private string second;
        private string milliSecond;
        public string Complete17CharString
        {
            get { return yYYY + mM + dD + hour + minute + second + milliSecond; }
        }
        public string YYYY
        {
            get { return yYYY; }
            set { yYYY = value; }
        }
        public string MM
        {
            get { return mM; }
            set { mM = value; }
        }
        public string DD
        {
            get { return dD; }
            set { dD = value; }
        }
        public string Hour
        {
            get { return hour; }
            set { hour = value; }
        }
        public string Minute
        {
            get { return minute; }
            set { minute = value; }
        }
        public string Second
        {
            get { return second; }
            set { second = value; }
        }
        public string MilliSecond
        {
            get { return milliSecond; }
            set { milliSecond = value; }
        }
        public StatusDateTime(System.DateTime dateTimeValue)
        {
            this.YYYY = dateTimeValue.Year.ToString();
            this.MM = dateTimeValue.Month.ToString();
            this.DD = dateTimeValue.Date.ToString();
            this.Hour = dateTimeValue.Hour.ToString();
            this.Minute = dateTimeValue.Minute.ToString();
            this.Second = dateTimeValue.Second.ToString();
            this.MilliSecond = dateTimeValue.Millisecond.ToString();
        }
        public StatusDateTime(Int64 dateTimeValue)
        {
            this.YYYY = dateTimeValue.ToString().Substring(0, 4);
            this.MM = dateTimeValue.ToString().Substring(4, 2);
            this.DD = dateTimeValue.ToString().Substring(6, 2);
            this.Hour = dateTimeValue.ToString().Substring(8, 2);
            this.Minute = dateTimeValue.ToString().Substring(10, 2);
            this.Second = dateTimeValue.ToString().Substring(12, 2);
            this.MilliSecond = dateTimeValue.ToString().Substring(14, 3);
        }
    }



    public class Status
    {

        public string StatusCode;
        public string StatusMessage;
        public string LogMessage;
        public string PermissionCode;
        public string ActionDescription;
        public string FunctionName;
        public string ModuleName;
        public string TransResult;
        public ArrayList Payload;

        public StatusDateTime TimeStamp;

        public Status()
        {
            StatusCode = "0";
            StatusMessage = String.Empty;
            LogMessage = String.Empty;
            PermissionCode = String.Empty;
            ActionDescription = String.Empty; ;
            FunctionName = String.Empty; ;
            ModuleName = String.Empty; ;
            TransResult = String.Empty; ;
            Payload = new ArrayList();
        }

        public Status(string statusCode, string statusMessage, string permissionCode, string actionDescription, StatusDateTime timeStamp, ArrayList payLoad, string logMessage)
        {
            this.StatusCode = statusCode;
            this.StatusMessage = statusMessage;
            this.PermissionCode = permissionCode;
            this.ActionDescription = actionDescription;
            this.TimeStamp = timeStamp;
            this.Payload = payLoad;
            this.LogMessage = logMessage;
        }
        public Status(string statusCode, string statusMessage, string permissionCode, string actionDescription, StatusDateTime timeStamp, string logMessage)
        {
            this.StatusCode = statusCode;
            this.StatusMessage = statusMessage;
            this.PermissionCode = permissionCode;
            this.ActionDescription = actionDescription;
            this.TimeStamp = timeStamp;
            this.LogMessage = logMessage;
        }

        public string Serialize()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("<Status>");
            sb.Append("<StatusCode>");
            sb.Append(this.StatusCode);
            sb.Append("</StatusCode>");
            sb.Append("<StatusMessage>");
            sb.Append(this.StatusMessage);
            sb.Append("</StatusMessage>");
            sb.Append("<PermissionCode>");
            sb.Append(this.PermissionCode);
            sb.Append("</PermissionCode>");
            sb.Append("<ActionDescription>");
            sb.Append(this.ActionDescription);
            sb.Append("</ActionDescription>");
            sb.Append("<TimeStamp>");
            sb.Append(this.TimeStamp.Complete17CharString);
            sb.Append("</TimeStamp>");
            sb.Append("<Payload>");
            //sb.Append(this.Payload);
            sb.Append("</Payload>");
            sb.Append("</Status>");
            return sb.ToString();
        }
    }


}
