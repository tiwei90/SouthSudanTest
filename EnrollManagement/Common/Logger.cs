using EnrollManagement.Properties;
using System;
using System.Web;

namespace EnrollManagement.Common
{
    public sealed class Logger
    {
        //private static string LogPath = Environment.CurrentDirectory.ToString() + "\\" + Settings.Default._logpath;
        //private static string TracePath = HttpContext.Current.Server.MapPath("\\" + Settings.Default._tracepath);
        //private static string TracePath = "C://" + Settings.Default._tracepath;
        ////private static string TmpPath = Environment.CurrentDirectory.ToString() + "\\" + Settings.Default.TmpPath;
        private static string LogPath = HttpContext.Current.Server.MapPath(Settings.Default._logpath);
        private static string TracePath = HttpContext.Current.Server.MapPath(Settings.Default._tracepath);

        //Properties.Settings _settings = Properties.Settings.Default;
        //public static  Properties.Settings _settings = Properties.Settings.Default;

        public static void WriteTrace(string ErrMessage)
        {
            if (!System.IO.Directory.Exists(TracePath))
            {
                System.IO.Directory.CreateDirectory(TracePath);
            }

            try
            {
                // Write to webservice trace log
                DateTime DateTimeNow = DateTime.Now;
                System.IO.StreamWriter file = new System.IO.StreamWriter(TracePath + "//" + DateTimeNow.ToString("ddMMyyyy") + "trace.log", true);
                file.WriteLine("[ " + DateTime.Now + " ] " + ErrMessage + "\n\n");
                file.Close();

            }
            catch (Exception exception)
            {
                exception.GetType();
            }
        }

        public static void WriteLog(string ErrMessage)
        {
            if (!System.IO.Directory.Exists(LogPath))
            {
                System.IO.Directory.CreateDirectory(LogPath);
            }

            try
            {
                // Write to webservice error log
                System.IO.StreamWriter file = new System.IO.StreamWriter(LogPath + "//" + DateTime.Now.ToString("ddMMyyyy") + "error.log", true);
                file.WriteLine("[ " + DateTime.Now + " ] " + ErrMessage + "\n\n");
                file.Close();
            }
            catch
            {
                // Dunno known who to throw it to
            }
        }



    }
}
