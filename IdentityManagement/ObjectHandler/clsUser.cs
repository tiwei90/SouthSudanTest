using IdentityManagement.Shared;
using IdentityManagement.Utilities;
using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Xml;

namespace IdentityManagement.ObjectHandler
{
    /// <summary>
    /// Summary description for clsPersonalizationLayout.
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

                                case "loginname":
                                    {
                                        ht.Add("LOGINNAME", xReader.ReadString());
                                        break;
                                    }

                                case "userid":
                                    {
                                        ht.Add("USERID", xReader.ReadString());
                                        break;
                                    }

                                case "passwordhash":
                                    {
                                        ht.Add("PASSWORDHASH", xReader.ReadString());
                                        break;
                                    }

                                case "oldpasswordhash":
                                    {
                                        ht.Add("OLDPASSWORDHASH", xReader.ReadString());
                                        break;
                                    }

                                case "newpasswordhash":
                                    {
                                        ht.Add("NEWPASSWORDHASH", xReader.ReadString());
                                        break;
                                    }

                                case "administratorsessionkey":
                                    {
                                        ht.Add("ADMINISTRATORSESSIONKEY", xReader.ReadString());
                                        break;
                                    }

                                case "ipaddress":
                                    {
                                        ht.Add("IPADDRESS", xReader.ReadString());
                                        break;
                                    }

                                case "sessionkey":
                                    {
                                        ht.Add("SESSIONKEY", xReader.ReadString());
                                        break;
                                    }

                                case "disabled":
                                    {
                                        ht.Add("DISABLED", xReader.ReadString());
                                        break;
                                    }

                                case "fullname":
                                    {
                                        ht.Add("FULLNAME", xReader.ReadString());
                                        break;
                                    }

                                case "passwordexpires":
                                    {
                                        ht.Add("PASSWORDEXPIRES", xReader.ReadString());
                                        break;
                                    }

                                case "biometrictemplate":
                                    {
                                        ht.Add("BIOMETRICTEMPLATE", xReader.ReadString());
                                        break;
                                    }

                                case "designation":
                                    {
                                        ht.Add("DESIGNATION", xReader.ReadString());
                                        break;
                                    }

                                case "officetelephonenumber1":
                                    {
                                        ht.Add("OFFICETELEPHONENUMBER1", xReader.ReadString());
                                        break;
                                    }

                                case "officetelephonenumber2":
                                    {
                                        ht.Add("OFFICETELEPHONENUMBER2", xReader.ReadString());
                                        break;
                                    }

                                case "officetelephonenumber3":
                                    {
                                        ht.Add("OFFICETELEPHONENUMBER3", xReader.ReadString());
                                        break;
                                    }

                                case "officefaxnumber":
                                    {
                                        ht.Add("OFFICEFAXNUMBER", xReader.ReadString());
                                        break;
                                    }

                                case "housetelephonenumber":
                                    {
                                        ht.Add("HOUSETELEPHONENUMBER", xReader.ReadString());
                                        break;
                                    }

                                case "mobiletelephonenumber":
                                    {
                                        ht.Add("MOBILETELEPHONENUMBER", xReader.ReadString());
                                        break;
                                    }

                                case "emailaddress1":
                                    {
                                        ht.Add("EMAILADDRESS1", xReader.ReadString());
                                        break;
                                    }

                                case "emailaddress2":
                                    {
                                        ht.Add("EMAILADDRESS2", xReader.ReadString());
                                        break;
                                    }

                                case "emailaddress3":
                                    {
                                        ht.Add("EMAILADDRESS3", xReader.ReadString());
                                        break;
                                    }

                                case "organizationalunitid":
                                    {
                                        ht.Add("ORGANIZATIONALUNITID", xReader.ReadString());
                                        break;
                                    }

                                case "username":
                                    {
                                        ht.Add("USERNAME", xReader.ReadString());
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

                    //					TextLogFile.WriteLog(InResult.LogMessage);
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

        #region Insert (13.63.1)
        public Status Insert(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                InsertSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("LOGINNAME", Utilities.Utilities.HashtableEnumerator(htvalue, "LOGINNAME")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "13.63.1.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void InsertSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[User_spi]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("User_spi", conn);
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

                    //					param = new OleDbParameter("@BiometricTemplate", OleDbType.VarChar); 
                    //					param.Direction = ParameterDirection.Input;
                    //					param.Value = Utilities.Utilities.HashtableEnumerator(ht, "BIOMETRICTEMPLATE");
                    //					cmd.Parameters.Add(param);

                    param = new OleDbParameter("@Designation", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "DESIGNATION");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@OfficeTelephoneNumber1", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "OFFICETELEPHONENUMBER1");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@OfficeTelephoneNumber2", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "OFFICETELEPHONENUMBER2");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@OfficeTelephoneNumber3", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "OFFICETELEPHONENUMBER3");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@OfficeFaxNumber", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "OFFICEFAXNUMBER");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@HouseTelephoneNumber", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "HOUSETELEPHONENUMBER");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@MobileTelephoneNumber", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "MOBILETELEPHONENUMBER");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@eMailAddress1", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "EMAILADDRESS1");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@eMailAddress2", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "EMAILADDRESS2");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@eMailAddress3", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "EMAILADDRESS3");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@OrganizationalUnitId", OleDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ORGANIZATIONALUNITID");
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
                    InResult.StatusCode = "13.63.1.98";
                    InResult.StatusMessage = "[" + InResult.PermissionCode + "] " + " [" + InResult.StatusCode + "] " + err.Message;

                    //					TextLogFile.WriteLog(InResult.StatusMessage  , err.GetType().ToString());
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

        #region Select (13.63.2)
        public Status Select(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectSP(htvalue, ref res);
                //res.Payload.Add(XmlMethods.CreateXMLElement("LOGINNAME", Utilities.Utilities.HashtableEnumerator(htvalue,"LOGINNAME")));
                res.Payload.Add(XmlMethods.CreateXMLElement("RECORDS", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "13.63.2.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void SelectSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[User_sps]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {

                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("User_sps", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@UserName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "USERNAME");

                    da.SelectCommand.Parameters.Add(param);

                    param = new OleDbParameter("@SessionKey", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "SESSIONKEY");

                    da.SelectCommand.Parameters.Add(param);

                    param = new OleDbParameter("@StatusCode", OleDbType.VarChar, 16);
                    param.Direction = ParameterDirection.Output;

                    da.SelectCommand.Parameters.Add(param);

                    param = new OleDbParameter("@StatusMessage", OleDbType.VarChar, 1152);
                    param.Direction = ParameterDirection.Output;

                    da.SelectCommand.Parameters.Add(param);

                    DataSet ds = new DataSet("UserSelectRecords");
                    da.Fill(ds, "UserRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//UserSelectRecords", Encoding.UTF8.GetBytes(ds.GetXml())));

                    InResult.StatusCode = da.SelectCommand.Parameters["@StatusCode"].Value.ToString();
                    InResult.StatusMessage = da.SelectCommand.Parameters["@StatusMessage"].Value.ToString();

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
                    InResult.StatusCode = "13.63.2.98";
                    InResult.StatusMessage = "[" + InResult.PermissionCode + "] " + " [" + InResult.StatusCode + "] " + err.Message;

                    //					TextLogFile.WriteLog(InResult.StatusMessage  , err.GetType().ToString());
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

        #region Update (13.63.3)
        public Status Update(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                UpdateSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("LOGINNAME", Utilities.Utilities.HashtableEnumerator(htvalue, "LOGINNAME")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "13.63.3.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void UpdateSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[User_spu]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("User_spu", conn);
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

                    ////////					param = new OleDbParameter("@PasswordExpires", OleDbType.VarChar); 
                    ////////					param.Direction = ParameterDirection.Input;
                    ////////					param.Value = Utilities.Utilities.HashtableEnumerator(ht, "PASSWORDHASH");
                    ////////					cmd.Parameters.Add(param);

                    //					param = new OleDbParameter("@BiometricTemplate", OleDbType.VarChar); 
                    //					param.Direction = ParameterDirection.Input;
                    //					param.Value = Utilities.Utilities.HashtableEnumerator(ht, "BIOMETRICTEMPLATE");
                    //					cmd.Parameters.Add(param);

                    param = new OleDbParameter("@Designation", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "DESIGNATION");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@OfficeTelephoneNumber1", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "OFFICETELEPHONENUMBER1");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@OfficeTelephoneNumber2", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "OFFICETELEPHONENUMBER2");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@OfficeTelephoneNumber3", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "OFFICETELEPHONENUMBER3");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@OfficeFaxNumber", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "OFFICEFAXNUMBER");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@HouseTelephoneNumber", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "HOUSETELEPHONENUMBER");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@MobileTelephoneNumber", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "MOBILETELEPHONENUMBER");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@eMailAddress1", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "EMAILADDRESS1");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@eMailAddress2", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "EMAILADDRESS2");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@eMailAddress3", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "EMAILADDRESS3");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@OrganizationalUnitId", OleDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ORGANIZATIONALUNITID");
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
                    InResult.StatusCode = "13.63.3.98";
                    InResult.StatusMessage = "[" + InResult.PermissionCode + "] " + " [" + InResult.StatusCode + "] " + err.Message;

                    //					TextLogFile.WriteLog(InResult.StatusMessage  , err.GetType().ToString());
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

        #region Select All (13.63.4)
        public Status SelectAll(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectAllSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("RECORDS", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "13.63.4.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void SelectAllSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[User_sps_All]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {

                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("User_sps_All", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@SessionKey", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "SESSIONKEY");

                    da.SelectCommand.Parameters.Add(param);

                    param = new OleDbParameter("@StatusCode", OleDbType.VarChar, 16);
                    param.Direction = ParameterDirection.Output;

                    da.SelectCommand.Parameters.Add(param);

                    param = new OleDbParameter("@StatusMessage", OleDbType.VarChar, 1152);
                    param.Direction = ParameterDirection.Output;

                    da.SelectCommand.Parameters.Add(param);

                    DataSet ds = new DataSet("UserSelectRecords");
                    da.Fill(ds, "UserRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//UserSelectRecords", Encoding.UTF8.GetBytes(ds.GetXml())));

                    InResult.StatusCode = da.SelectCommand.Parameters["@StatusCode"].Value.ToString();
                    InResult.StatusMessage = da.SelectCommand.Parameters["@StatusMessage"].Value.ToString();

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
                    InResult.StatusCode = "13.63.4.98";
                    InResult.StatusMessage = "[" + InResult.PermissionCode + "] " + " [" + InResult.StatusCode + "] " + err.Message;

                    //					TextLogFile.WriteLog(InResult.StatusMessage  , err.GetType().ToString());
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

        #region Update Challenge (13.63.5)
        public Status UpdateChallenge(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                UpdateChallengeSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("USERID", Utilities.Utilities.HashtableEnumerator(htvalue, "USERID")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "13.63.5.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void UpdateChallengeSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[User_spu_Challenge]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("User_spu_Challenge", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@UserId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "USERID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@Challenge", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "CHALLENGE");
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

                    param = new OleDbParameter("@PermissionCode", OleDbType.VarChar, 16);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@ActionDescription", OleDbType.VarChar, 128);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@TimeStamp", OleDbType.BigInt);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@SessionKey", OleDbType.VarChar, 64);
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
                    InResult.StatusCode = "13.63.5.98";
                    InResult.StatusMessage = "[" + InResult.PermissionCode + "] " + " [" + InResult.StatusCode + "] " + err.Message;

                    //					TextLogFile.WriteLog(InResult.StatusMessage  , err.GetType().ToString());
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

        #region Select Challenge (13.63.6)
        public Status SelectChallenge(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectChallengeSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("USERID", Utilities.Utilities.HashtableEnumerator(htvalue, "USERID")));
                res.Payload.Add(XmlMethods.CreateXMLElement("CHALLENGE", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "13.63.6.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void SelectChallengeSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[User_sps_Challenge]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("User_sps_Challenge", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@UserId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "USERID");

                    da.SelectCommand.Parameters.Add(param);

                    param = new OleDbParameter("@AdministratorSessionKey", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ADMINISTRATORSESSIONKEY");

                    da.SelectCommand.Parameters.Add(param);

                    param = new OleDbParameter("@StatusCode", OleDbType.VarChar, 16);
                    param.Direction = ParameterDirection.Output;

                    da.SelectCommand.Parameters.Add(param);

                    param = new OleDbParameter("@StatusMessage", OleDbType.VarChar, 1152);
                    param.Direction = ParameterDirection.Output;

                    da.SelectCommand.Parameters.Add(param);

                    DataSet ds = new DataSet("UserSelectChallenge");
                    da.Fill(ds, "ChallengeRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//UserSelectChallenge", Encoding.UTF8.GetBytes(ds.GetXml())));


                    InResult.StatusCode = da.SelectCommand.Parameters["@StatusCode"].Value.ToString();
                    InResult.StatusMessage = da.SelectCommand.Parameters["@StatusMessage"].Value.ToString();

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
                    InResult.StatusCode = "13.63.6.98";
                    InResult.StatusMessage = "[" + InResult.PermissionCode + "] " + " [" + InResult.StatusCode + "] " + err.Message;

                    //					TextLogFile.WriteLog(InResult.StatusMessage  , err.GetType().ToString());
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

        #region ChangePassword (13.63.7)
        public Status ChangePassword(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                ChangePasswordSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("LOGINNAME", Utilities.Utilities.HashtableEnumerator(htvalue, "LOGINNAME")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "13.63.7.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void ChangePasswordSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[User_spu_ChangePassword]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);

                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("User_spu_ChangePassword", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@LoginName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "LOGINNAME");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@OldPasswordHash", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "OLDPASSWORDHASH");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@NewPasswordHash", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "NEWPASSWORDHASH");
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
                    InResult.StatusCode = "13.63.7.98";
                    InResult.StatusMessage = "[" + InResult.PermissionCode + "] " + " [" + InResult.StatusCode + "] " + err.Message;

                    //					TextLogFile.WriteLog(InResult.StatusMessage  , err.GetType().ToString());
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

        #region DisableEnable (13.63.8)
        public Status DisableEnable(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                DisableEnableSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("USERID", Utilities.Utilities.HashtableEnumerator(htvalue, "USERID")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "13.63.8.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void DisableEnableSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[User_spu_DisableEnable]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);

                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("User_spu_DisableEnable", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@UserId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "USERID");
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
                    InResult.StatusCode = "13.63.8.98";
                    InResult.StatusMessage = "[" + InResult.PermissionCode + "] " + " [" + InResult.StatusCode + "] " + err.Message;

                    //					TextLogFile.WriteLog(InResult.StatusMessage  , err.GetType().ToString());
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

        #region Login (13.63.9)
        public Status Login(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                LoginSP(ref htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("LoginName", Utilities.Utilities.HashtableEnumerator(htvalue, "LOGINNAME")));
                res.Payload.Add(XmlMethods.CreateXMLElement("TimeStamp", Utilities.Utilities.HashtableEnumerator(htvalue, "DBTIMESTAMP")));
                res.Payload.Add(XmlMethods.CreateXMLElement("SessionKey", Utilities.Utilities.HashtableEnumerator(htvalue, "DBSESSIONKEY")));
                //ConstructPayLogin(htvalue, ref res);
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "13.63.9.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void LoginSP(ref Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[User_spu_PasswordLogIn]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("User_spu_PasswordLogIn", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@LoginName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "LOGINNAME");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@PasswordHash", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "PASSWORDHASH");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@IPAddress", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "IPADDRESS");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StatusCode", OleDbType.VarChar, 16);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StatusMessage", OleDbType.VarChar, 1152);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@PermissionCode", OleDbType.VarChar, 16);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@ActionDescription", OleDbType.VarChar, 128);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@SessionKey", OleDbType.VarChar, 64);
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
                    else
                    {
                        ht.Add("DBTIMESTAMP", cmd.Parameters["@TimeStamp"].Value.ToString());
                        ht.Add("DBSESSIONKEY", cmd.Parameters["@SessionKey"].Value.ToString());
                    }
                }
                catch (Exception err)
                {
                    InResult.StatusCode = "13.63.9.98";
                    InResult.StatusMessage = "[" + InResult.PermissionCode + "] " + " [" + InResult.StatusCode + "] " + err.Message;

                    //					TextLogFile.WriteLog(InResult.StatusMessage  , err.GetType().ToString());
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

        #region ResetPassword (13.63.10)
        public Status ResetPassword(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                ResetPasswordSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("UserID", Utilities.Utilities.HashtableEnumerator(htvalue, "USERID")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "13.63.10.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void ResetPasswordSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[User_spu_ResetPassword]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("User_spu_ResetPassword", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@UserId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "USERID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@NewPasswordHash", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "NEWPASSWORDHASH");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@AdministratorSessionKey", OleDbType.VarChar, 64);
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
                    InResult.StatusCode = "13.63.10.98";
                    InResult.StatusMessage = "[" + InResult.PermissionCode + "] " + " [" + InResult.StatusCode + "] " + err.Message;

                    //					TextLogFile.WriteLog(InResult.StatusMessage  , err.GetType().ToString());
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
        /*
		#region Construct Payload
		private void ConstructPayLogin(Hashtable ht,ref Status InResult)
		{			
			if (Globals.m_sDebugMode=="1")
			{
				TextLogFile.WriteTrace("[TRACE] Constructing Payload for  " + InResult.PermissionCode);
			}

			try
			{
				
			}
			catch(Exception err)
			{
				InResult.StatusCode="13.86.11.4";
				InResult.StatusMessage = "[" + InResult.PermissionCode + "] " +  " [" + InResult.StatusCode + "] " + err.Message;

				TextLogFile.WriteLog(InResult.StatusMessage  , err.GetType().ToString());
				if (Globals.m_sDebugMode.ToString()== "1")
				{
					TextLogFile.WriteTrace("[TRACE]" + " - " + InResult.StatusMessage) ; 
				}
			}
	
		}	

		#endregion
*/
    }
}
