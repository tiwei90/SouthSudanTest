using AccessManagement.Shared;
using AccessManagement.Utilities;
using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Xml;

namespace AccessManagement.ObjectHandler
{
    /// <summary>
    /// Summary description for clsGroup.
    /// </summary>
    public class User
    {
        public User()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region ParseXML
        private void ParseXml(byte[] postXML, ref Hashtable ht, ref Status InResult)
        {
            // Check for previous error.
            if (InResult.StatusCode == "0")
            {
                XmlTextReader xReader = null;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Parsing XML data for " + InResult.PermissionCode);
                }

                try
                {
                    // Read out the xml looking for the details.
                    xReader = new XmlTextReader(new MemoryStream(postXML, false));

                    // Read the whole xml file line by line.
                    while (xReader.Read())
                    {
                        // load xml data into hash table
                        if (xReader.NodeType == XmlNodeType.Element)
                        {
                            switch (xReader.Name.ToLower())
                            {

                                case "sessionkey":
                                    {
                                        ht.Add("SESSIONKEY", xReader.ReadString());
                                        break;
                                    }

                                case "fullname":
                                    {
                                        ht.Add("FULLNAME", xReader.ReadString());
                                        break;
                                    }

                                case "passwordhash":
                                    {
                                        ht.Add("PASSWORDHASH", xReader.ReadString());
                                        break;
                                    }

                                case "disabled":
                                    {
                                        ht.Add("DISABLED", xReader.ReadString());
                                        break;
                                    }

                                case "userid":
                                    {
                                        ht.Add("USERID", xReader.ReadString());
                                        break;
                                    }

                                case "loginname":
                                    {
                                        ht.Add("LOGINNAME", xReader.ReadString());
                                        break;
                                    }

                                case "userloginname":
                                    {
                                        ht.Add("USERLOGINNAME", xReader.ReadString());
                                        break;
                                    }

                                case "identitymanagersessionkey":
                                    {
                                        ht.Add("IDENTITYMANAGERSESSIONKEY", xReader.ReadString());
                                        break;
                                    }

                                case "administratorsessionkey":
                                    {
                                        ht.Add("ADMINISTRATORSESSIONKEY", xReader.ReadString());
                                        break;
                                    }


                                default:
                                    break;
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    InResult.StatusCode = "13.86.11.1";
                    InResult.LogMessage = "[" + InResult.PermissionCode + "] " + "[" + InResult.StatusCode + "] " + err.Message;

                    TextLogFile.WriteLog(InResult.LogMessage);
                    if (Globals.m_sDebugMode == "1")
                    {
                        TextLogFile.WriteTrace("[TRACE]" + " - " + InResult.LogMessage);
                    }
                }
                finally
                {
                    if (xReader != null) xReader.Close();
                }
            }
        }
        #endregion

        #region InsertUser (16.63.1)
        public Status InsertUser(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                InsertUserSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("LoginName", Utilities.Utilities.HashtableEnumerator(htvalue, "LOGINNAME")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.63.1.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void InsertUserSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[User_spi_AccessManagement]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("User_spi_AccessManagement", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@LoginName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "LOGINNAME");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@FullName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "FULLNAME");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@PasswordHash", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "PASSWORDHASH");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@SessionKey", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "SESSIONKEY");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StatusCode", OleDbType.VarChar, 16);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StatusMessage", OleDbType.VarChar, 1152);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    InResult.StatusCode = cmd.Parameters["@StatusCode"].Value.ToString();
                    InResult.StatusMessage = cmd.Parameters["@StatusMessage"].Value.ToString();

                    if (string.Equals(InResult.StatusCode, "0") != true)
                    {
                        InResult.TransResult = "[" + InResult.PermissionCode + "] [" + InResult.StatusCode + "] [" +
                            InResult.StatusMessage + "]";

                        if (Globals.m_sDebugMode == "1")
                        {
                            TextLogFile.WriteTrace("[TRACE]" + " - " + InResult.TransResult);
                        }
                    }
                }

                catch (Exception err)
                {
                    InResult.StatusCode = "16.63.1.98";
                    InResult.StatusMessage = "[" + InResult.PermissionCode + "] " + "[" + InResult.StatusCode + "] " + err.Message;

                    if (Globals.m_sDebugMode.ToString() == "1")
                    {
                        TextLogFile.WriteTrace("[TRACE]" + " - " + InResult.StatusMessage);
                    }
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }
        #endregion

        #region UpdateUser (16.63.3)
        public Status UpdateUser(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                UpdateUserSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("UserId", Utilities.Utilities.HashtableEnumerator(htvalue, "USERID")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.63.3.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void UpdateUserSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[User_spu_AccessManagement]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("User_spu_AccessManagement", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@UserId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "USERID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@LoginName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "LOGINNAME");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@FullName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "FULLNAME");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@Disabled", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    if (Utilities.Utilities.HashtableEnumerator(ht, "DISABLED").ToUpper() == "TRUE")
                        param.Value = "1";
                    else if (Utilities.Utilities.HashtableEnumerator(ht, "DISABLED").ToUpper() == "FALSE")
                        param.Value = "0";
                    else
                        param.Value = Utilities.Utilities.HashtableEnumerator(ht, "DISABLED");

                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@SessionKey", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "SESSIONKEY");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StatusCode", OleDbType.VarChar, 16);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StatusMessage", OleDbType.VarChar, 1152);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    InResult.StatusCode = cmd.Parameters["@StatusCode"].Value.ToString();
                    InResult.StatusMessage = cmd.Parameters["@StatusMessage"].Value.ToString();

                    if (string.Equals(InResult.StatusCode, "0") != true)
                    {
                        InResult.TransResult = "[" + InResult.PermissionCode + "] [" + InResult.StatusCode + "] [" +
                            InResult.StatusMessage + "]";

                        if (Globals.m_sDebugMode == "1")
                        {
                            TextLogFile.WriteTrace("[TRACE]" + " - " + InResult.TransResult);
                        }
                    }
                }

                catch (Exception err)
                {
                    InResult.StatusCode = "16.63.3.98";
                    InResult.StatusMessage = "[" + InResult.PermissionCode + "] " + "[" + InResult.StatusCode + "] " + err.Message;

                    if (Globals.m_sDebugMode.ToString() == "1")
                    {
                        TextLogFile.WriteTrace("[TRACE]" + " - " + InResult.StatusMessage);
                    }
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }
        #endregion

        #region UpdateEndOtherSession (16.63.5)
        public Status UpdateEndOtherSession(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                UpdateEndOtherSessionSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("UserId", Utilities.Utilities.HashtableEnumerator(htvalue, "USERID")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.63.5.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void UpdateEndOtherSessionSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[User_spu_EndOtherSession]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("User_spu_EndOtherSession", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@UserId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "USERID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@AdministratorSessionKey", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ADMINISTRATORSESSIONKEY");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StatusCode", OleDbType.VarChar, 16);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StatusMessage", OleDbType.VarChar, 1152);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    InResult.StatusCode = cmd.Parameters["@StatusCode"].Value.ToString();
                    InResult.StatusMessage = cmd.Parameters["@StatusMessage"].Value.ToString();

                    if (string.Equals(InResult.StatusCode, "0") != true)
                    {
                        InResult.TransResult = "[" + InResult.PermissionCode + "] [" + InResult.StatusCode + "] [" +
                            InResult.StatusMessage + "]";

                        if (Globals.m_sDebugMode == "1")
                        {
                            TextLogFile.WriteTrace("[TRACE]" + " - " + InResult.TransResult);
                        }
                    }
                }

                catch (Exception err)
                {
                    InResult.StatusCode = "16.63.5.98";
                    InResult.StatusMessage = "[" + InResult.PermissionCode + "] " + "[" + InResult.StatusCode + "] " + err.Message;

                    if (Globals.m_sDebugMode.ToString() == "1")
                    {
                        TextLogFile.WriteTrace("[TRACE]" + " - " + InResult.StatusMessage);
                    }
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }
        #endregion

        #region UpdateEndMySession (16.63.6)
        public Status UpdateEndMySession(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                UpdateEndMySessionSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("SessionKey", Utilities.Utilities.HashtableEnumerator(htvalue, "SESSIONKEY")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.63.6.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void UpdateEndMySessionSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[User_spu_EndMySession]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("User_spu_EndMySession", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@SessionKey", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "SESSIONKEY");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StatusCode", OleDbType.VarChar, 16);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StatusMessage", OleDbType.VarChar, 1152);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@TimeStamp", OleDbType.BigInt);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    InResult.StatusCode = cmd.Parameters["@StatusCode"].Value.ToString();
                    InResult.StatusMessage = cmd.Parameters["@StatusMessage"].Value.ToString();

                    if (string.Equals(InResult.StatusCode, "0") != true)
                    {
                        InResult.TransResult = "[" + InResult.PermissionCode + "] [" + InResult.StatusCode + "] [" +
                            InResult.StatusMessage + "]";

                        if (Globals.m_sDebugMode == "1")
                        {
                            TextLogFile.WriteTrace("[TRACE]" + " - " + InResult.TransResult);
                        }
                    }
                }

                catch (Exception err)
                {
                    InResult.StatusCode = "16.63.6.98";
                    InResult.StatusMessage = "[" + InResult.PermissionCode + "] " + "[" + InResult.StatusCode + "] " + err.Message;

                    if (Globals.m_sDebugMode.ToString() == "1")
                    {
                        TextLogFile.WriteTrace("[TRACE]" + " - " + InResult.StatusMessage);
                    }
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }
        #endregion

        #region UpdateSessionKey (16.63.8)
        public Status UpdateSessionKey(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                UpdateSessionKeySP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("DescriptionEnglish", Utilities.Utilities.HashtableEnumerator(htvalue, "DESCRIPTIONENGLISH")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.63.8.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void UpdateSessionKeySP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[User_spu_SeesionKey]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("User_spu_SeesionKey", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@UserLoginName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "USERLOGINNAME");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@IdentityManagerSessionKey", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "IDENTITYMANAGERSESSIONKEY");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StatusCode", OleDbType.VarChar, 16);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StatusMessage", OleDbType.VarChar, 1152);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();

                    InResult.StatusCode = cmd.Parameters["@StatusCode"].Value.ToString();
                    InResult.StatusMessage = cmd.Parameters["@StatusMessage"].Value.ToString();

                    if (string.Equals(InResult.StatusCode, "0") != true)
                    {
                        InResult.TransResult = "[" + InResult.PermissionCode + "] [" + InResult.StatusCode + "] [" +
                            InResult.StatusMessage + "]";

                        if (Globals.m_sDebugMode == "1")
                        {
                            TextLogFile.WriteTrace("[TRACE]" + " - " + InResult.TransResult);
                        }
                    }
                }

                catch (Exception err)
                {
                    InResult.StatusCode = "16.63.8.98";
                    InResult.StatusMessage = "[" + InResult.PermissionCode + "] " + "[" + InResult.StatusCode + "] " + err.Message;

                    if (Globals.m_sDebugMode.ToString() == "1")
                    {
                        TextLogFile.WriteTrace("[TRACE]" + " - " + InResult.StatusMessage);
                    }
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                }
            }
        }
        #endregion
    }
}
