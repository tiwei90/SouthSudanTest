using AccessManagement.Shared;
using System;
using System.IO;
using System.Xml;

namespace AccessManagement.Utilities
{
    #region FILE SYSTEM METHODS CLASS
    /// <summary>
    /// Summary description for FileSystem.
    /// </summary>
    public sealed class FileSystem
    {
        /// <summary>
        /// Read a file to a specified string.
        /// </summary>	
        public static string ReadFile2String(string SourceFile)
        {
            if (SourceFile == String.Empty)
                return String.Empty;

            FileStream file = null;
            StreamReader sr = null;

            try
            {
                file = new FileStream(SourceFile, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);

                return sr.ReadToEnd();
            }
            catch (Exception err)
            {
                throw new Exception("Error in ReadFile2String " + err.Message);
            }
            finally
            {
                if (sr != null) sr.Close();
                if (file != null) file.Close();
            }
        }

        /// <summary>
        /// Copy a directory to a specified path. The directory and it's subdirectory shall be 
        /// replicated on the destination path
        /// </summary>	
        public static bool CopyDirectory(string SourceDir, string DestinationDir)
        {
            if ((SourceDir == String.Empty) || (DestinationDir == String.Empty))
                return false;

            try
            {
                String[] Files;

                if (DestinationDir[DestinationDir.Length - 1] != Path.DirectorySeparatorChar)
                    DestinationDir += Path.DirectorySeparatorChar;

                if (!Directory.Exists(DestinationDir)) Directory.CreateDirectory(DestinationDir);

                Files = Directory.GetFileSystemEntries(SourceDir);

                foreach (string Element in Files)
                {
                    // Sub directories
                    if (Directory.Exists(Element))
                        CopyDirectory(Element, DestinationDir + Path.GetFileName(Element));
                    // Files in directory
                    else
                        File.Copy(Element, DestinationDir + Path.GetFileName(Element), true);
                }

                return true;
            }
            catch (Exception err)
            {
                throw new Exception("Error in CopyDirectory " + err.Message);
            }
        }

        /// <summary>
        /// Copy a file to a specified folder path.
        /// </summary>	
        public static bool CopyFile(string SourceFile, string DestinationDir)
        {
            if ((SourceFile == String.Empty) || (DestinationDir == String.Empty))
                return false;

            try
            {
                if (DestinationDir[DestinationDir.Length - 1] != Path.DirectorySeparatorChar)
                    DestinationDir += Path.DirectorySeparatorChar;

                if (!Directory.Exists(DestinationDir)) Directory.CreateDirectory(DestinationDir);

                File.Copy(SourceFile, DestinationDir + Path.GetFileName(SourceFile), true);

                return true;
            }
            catch (Exception err)
            {
                throw new Exception("Error in CopyFile " + err.Message);
            }
        }

        /// <summary>
        /// Writes a string to a specified file.
        /// </summary>	
        public static bool WriteToFile(string Lines, string DestPath, bool Append)
        {
            if (DestPath == String.Empty)
                return false;

            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(DestPath, Append);
                file.WriteLine(Lines);
                file.Close();
                return true;
            }
            catch (Exception err)
            {
                throw new Exception("Error in WriteToFile " + err.Message);
            }
        }
    }
    #endregion

    #region TEXT LOGGING METHODS CLASS
    /// <summary>
    /// Summary description for TextLogFile.
    /// </summary>
    public sealed class TextLogFile
    {
        private static string LogPath = Globals.m_sLogPath + Utilities.DateTimeFormat(DateTime.Now, 0) + "websvr_error.log";


        /// <summary>
        /// Writes error logs to the systems erro log.
        /// </summary>	
        public static void WriteLog(string ErrMessage)
        {
            try
            {
                // Write to webservice log
                System.IO.StreamWriter file = new System.IO.StreamWriter(LogPath, true);
                file.WriteLine("[ " + DateTime.Now + " ] " + ErrMessage + "\n\n");
                file.Close();
            }
            catch (System.Exception err)
            {
                // Dunno known who to throw it to
                throw err;
            }
        }

        /// <summary>
        /// Writes error logs to the systems erro log.
        /// </summary>	
        public static void WriteLog(string ErrMessage, string ErrStack)
        {
            try
            {
                // Write to webservice log
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(LogPath, true))
                {
                    file.WriteLine("[ " + DateTime.Now + " ] " + ErrMessage + "; " + ErrStack + "\n\n\n");
                    file.Flush();
                    file.Close();
                }
            }
            catch (System.Exception err)
            {
                // Dunno known who to throw it to
                throw err;
            }
        }

        public static void WriteTrace(string ErrMessage)
        {
            string RequestPath = Globals.m_sRequestPath + Utilities.DateTimeFormat(DateTime.Now, 0) + "WF_trace.log";

            try
            {
                // Write to webservice trace
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(RequestPath, true))
                {
                    file.WriteLine("[ " + DateTime.Now + " ] " + ErrMessage + "\n\n");
                    file.Flush();
                    file.Close();
                }

            }
            catch (System.Exception err)
            {
                throw err;
            }
        }

        public static void WriteRequest(string PostXML)
        {
            string RequestPath = Globals.m_sRequestPath + DateTime.Now.ToFileTime().ToString() + "ijpn_request.xml";
            try
            {
                XmlDocument XDoc = new XmlDocument();
                XDoc.LoadXml(PostXML);
                XDoc.Save(RequestPath);
            }
            catch (System.Exception err)
            {
                // Dunno known who to throw it to
                throw err;
            }
        }
    }
    #endregion

    #region XML LOGGING METHODS CLASS
    /// <summary>
    /// Summary description for XmlLogFile.
    /// </summary>
    public sealed class XmlLogFile
    {
        private string m_sXmlLogFileName = null;

        /// <summary>
        /// Get/Set xml log file name and location
        /// </summary>	
        public string FileLocation
        {
            get
            {
                return this.m_sXmlLogFileName;
            }

            set
            {
                m_sXmlLogFileName = value;
            }
        }

        public void WriteLog(string Message)
        {
            using (FileStream fs = File.Open(m_sXmlLogFileName, FileMode.Append, FileAccess.Write, FileShare.Read))
            {
                XmlTextWriter xmlWrite = new XmlTextWriter(fs, System.Text.Encoding.UTF8);
                xmlWrite.WriteStartElement("Item");
                xmlWrite.WriteAttributeString("Message", Message);
                xmlWrite.Close();
            }
        }

        public void WriteLog(string Message, string TimeStamp)
        {
            using (FileStream fs = File.Open(m_sXmlLogFileName, FileMode.Append, FileAccess.Write, FileShare.Read))
            {
                XmlTextWriter xmlWrite = new XmlTextWriter(fs, System.Text.Encoding.UTF8);
                xmlWrite.WriteStartElement("Item");
                xmlWrite.WriteAttributeString("Message", Message);
                xmlWrite.WriteAttributeString("DateTime", TimeStamp);
                xmlWrite.Close();
            }
        }
    }
    #endregion
}
