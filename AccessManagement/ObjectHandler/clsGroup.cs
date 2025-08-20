using AccessManagement.Shared;
using AccessManagement.Utilities;
using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Xml;

namespace AccessManagement.ObjectHandler
{
    /// <summary>
    /// Summary description for clsGroup.
    /// </summary>
    public class Group
    {
        public Group()
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

                                case "groupid":
                                    {
                                        ht.Add("GROUPID", xReader.ReadString());
                                        break;
                                    }

                                case "groupname":
                                    {
                                        ht.Add("GROUPNAME", xReader.ReadString());
                                        break;
                                    }

                                case "permissioncode":
                                    {
                                        if (ht.ContainsKey("PERMISSIONCODE"))
                                            ht.Remove("PERMISSIONCODE");
                                        ht.Add("PERMISSIONCODE", xReader.ReadString());
                                        break;
                                    }

                                case "sessionkey":
                                    {
                                        ht.Add("SESSIONKEY", xReader.ReadString());
                                        break;
                                    }

                                case "userid":
                                    {
                                        ht.Add("USERID", xReader.ReadString());
                                        break;
                                    }

                                case "descriptionenglish":
                                    {
                                        ht.Add("DESCRIPTIONENGLISH", xReader.ReadString());
                                        break;
                                    }

                                case "descriptionnative1":
                                    {
                                        ht.Add("DESCRIPTIONNATIVE1", xReader.ReadString());
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

                                case "loginname":
                                    {
                                        ht.Add("LOGINNAME", xReader.ReadString());
                                        break;
                                    }

                                case "fullname":
                                    {
                                        ht.Add("FULLNAME", xReader.ReadString());
                                        break;
                                    }

                                case "administratorsessionkey":
                                    {
                                        ht.Add("ADMINISTRATORSESSIONKEY", xReader.ReadString());
                                        break;
                                    }

                                case "disable":
                                    {
                                        ht.Add("DISABLE", xReader.ReadString());
                                        break;
                                    }

                                case "inputstatuscode":
                                    {
                                        ht.Add("INPUTSTATUSCODE", xReader.ReadString());
                                        break;
                                    }

                                case "objectspecifid":
                                    {
                                        ht.Add("OBJECTSPECIFID", xReader.ReadString());
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

        #region InsertGroup (16.30.1)
        public Status InsertGroup(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                InsertGroupSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("DescriptionEnglish", Utilities.Utilities.HashtableEnumerator(htvalue, "DESCRIPTIONENGLISH")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.30.1.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void InsertGroupSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Group_spi]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("Group_spi", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@DescriptionEnglish", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "DESCRIPTIONENGLISH");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@DescriptionNative1", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "DESCRIPTIONNATIVE1");
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
                    InResult.StatusCode = "16.30.1.98";
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

        #region SelectGroup (16.30.2)
        public Status SelectGroup(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectGroupSP(htvalue, ref res);
                //res.Payload.Add(XmlMethods.CreateXMLElement("GROUPNAME", Utilities.Utilities.HashtableEnumerator(htvalue,"GROUPNAME")));
                res.Payload.Add(XmlMethods.CreateXMLElement("GroupRecords", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.30.2.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void SelectGroupSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Group_sps]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("Group_sps", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@GroupName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "GROUPNAME");

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

                    DataSet ds = new DataSet();
                    da.Fill(ds, "SelectGroup");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//SelectGroup", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "16.30.2.98";
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

        #region UpdateGroup (16.30.3)
        public Status UpdateGroup(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                UpdateGroupSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("DescriptionEnglish", Utilities.Utilities.HashtableEnumerator(htvalue, "DESCRIPTIONENGLISH")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.30.3.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void UpdateGroupSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Group_spu]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("Group_spu", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@GroupId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "GROUPID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@DescriptionEnglish", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "DESCRIPTIONENGLISH");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@DescriptionNative1", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "DESCRIPTIONNATIVE1");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@Obsolete", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    if (Utilities.Utilities.HashtableEnumerator(ht, "OBSOLETE").ToUpper() == "TRUE")
                        param.Value = "1";
                    else if (Utilities.Utilities.HashtableEnumerator(ht, "OBSOLETE").ToUpper() == "FALSE")
                        param.Value = "0";
                    else
                        param.Value = Utilities.Utilities.HashtableEnumerator(ht, "OBSOLETE");
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
                    InResult.StatusCode = "16.30.3.98";
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

        #region SelectAllGroup (16.30.7)
        public Status SelectAllGroup(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectAllGroupSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("AllGroupRecords", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.30.7.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void SelectAllGroupSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Group_sps_All]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("Group_sps_All", conn);
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

                    DataSet ds = new DataSet("SelectAllGroup");
                    da.Fill(ds, "GroupPermissionRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//SelectAllGroup", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "16.30.7.98";
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

        #region InsertGroupPermission (16.31.1)
        public Status InsertGroupPermission(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                InsertGroupPermissionSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("GroupId", Utilities.Utilities.HashtableEnumerator(htvalue, "GROUPID")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.31.1.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void InsertGroupPermissionSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[GroupPermission_spi]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("GroupPermission_spi", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@GroupId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "GROUPID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@PermissionCode", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "PERMISSIONCODE");
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
                    InResult.StatusCode = "16.31.1.98";
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

        #region SelectGroupPermission (16.31.2)
        public Status SelectGroupPermission(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectGroupPermissionSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("Records", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.31.2.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void SelectGroupPermissionSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[GroupPermission_sps]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("GroupPermission_sps", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@GroupId", OleDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "GROUPID");

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

                    DataSet ds = new DataSet("SelectGroup");
                    da.Fill(ds, "GroupPermissionRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//SelectGroup", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "16.31.2.98";
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

        #region DeleteGroupPermission (16.31.4)
        public Status DeleteGroupPermission(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                DeleteGroupPermissionSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("GroupId", Utilities.Utilities.HashtableEnumerator(htvalue, "GROUPID")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.31.4.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void DeleteGroupPermissionSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[GroupPermission_spd]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("GroupPermission_spd", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@GroupId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "GROUPID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@PermissionCode", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "PERMISSIONCODE");
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
                    InResult.StatusCode = "16.31.4.98";
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

        #region SelectAllGroupPermission (16.31.7)
        public Status SelectAllGroupPermission(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectAllGroupPermissionSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("Records", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.31.7.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void SelectAllGroupPermissionSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[GroupPermission_sps_All]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("GroupPermission_sps_All", conn);
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

                    DataSet ds = new DataSet("SelectAllGroup");
                    da.Fill(ds, "GroupPermissionRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//SelectAllGroup", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "16.31.7.98";
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

        #region InsertGroupUser (16.32.1)
        public Status InsertGroupUser(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                InsertGroupUserSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("GroupId", Utilities.Utilities.HashtableEnumerator(htvalue, "GROUPID")));
                res.Payload.Add(XmlMethods.CreateXMLElement("UserId", Utilities.Utilities.HashtableEnumerator(htvalue, "USERID")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.32.1.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void InsertGroupUserSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[GroupUser_spi]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("GroupUser_spi", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@GroupId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "GROUPID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@UserId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "USERID");
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
                    InResult.StatusCode = "16.32.1.98";
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

        #region SelectGroupUser (16.32.2)
        public Status SelectGroupUser(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectGroupUserSP(htvalue, ref res);
                //res.Payload.Add(XmlMethods.CreateXMLElement("GROUPID", Utilities.Utilities.HashtableEnumerator(htvalue,"GROUPID")));
                res.Payload.Add(XmlMethods.CreateXMLElement("Records", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.32.2.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void SelectGroupUserSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[GroupUser_sps]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("GroupUser_sps", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@GroupId", OleDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "GROUPID");

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

                    DataSet ds = new DataSet();
                    da.Fill(ds, "SelectUserGroup");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//SelectUserGroup", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "16.32.2.98";
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

        #region DeleteGroupUser (16.32.4)
        public Status DeleteGroupUser(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                DeleteGroupUserSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("GroupId", Utilities.Utilities.HashtableEnumerator(htvalue, "GROUPID")));
                res.Payload.Add(XmlMethods.CreateXMLElement("UserId", Utilities.Utilities.HashtableEnumerator(htvalue, "USERID")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.32.4.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void DeleteGroupUserSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[GroupUser_spd]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("GroupUser_spd", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@GroupId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "GROUPID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@UserId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "USERID");
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
                    InResult.StatusCode = "16.32.4.98";
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

        #region SelectAllGroupUser (16.32.7)
        public Status SelectAllGroupUser(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectAllGroupUserSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("Records", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.32.7.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void SelectAllGroupUserSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[GroupPermission_sps_All]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("GroupUser_sps_All", conn);
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

                    DataSet ds = new DataSet("SelectAllGroupUser");
                    da.Fill(ds, "GroupUserRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//SelectAllGroupUser", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "16.32.7.98";
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

        #region SelectPermission (16.56.2)
        public Status SelectPermission(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectPermissionSP(htvalue, ref res);
                //res.Payload.Add(XmlMethods.CreateXMLElement("PERMISSIONCODE", Utilities.Utilities.HashtableEnumerator(htvalue,"PERMISSIONCODE")));
                res.Payload.Add(XmlMethods.CreateXMLElement("RECORDS", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.56.2.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void SelectPermissionSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Permission_sps]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("Permission_sps", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@PermissionCode", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "PERMISSIONCODE");

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

                    DataSet ds = new DataSet();
                    da.Fill(ds, "SelectPermission");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//SelectPermission", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "16.56.2.98";
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

        #region SelectAllPermission (16.56.7)
        public Status SelectAllPermission(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectAllPermissionSP(htvalue, ref res);
                //SelectAllGroupPermissionSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("Records", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                //res.Payload.Add(XmlMethods.CreateXMLElement("GroupPermissionRecords", Utilities.Utilities.HashtableEnumerator(htvalue,"GROUPPERMISSIONRECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.56.7.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void SelectAllPermissionSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Permission_sps_All]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("Permission_sps_All", conn);
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

                    DataSet ds = new DataSet("SelectAllPermission");
                    da.Fill(ds, "PermissionRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//SelectAllPermission", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "16.56.7.98";
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

        #region CheckAllPermission (16.56.5)
        public Status CheckAllPermission(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                CheckAllPermissionSP(htvalue, ref res);
                //SelectAllGroupPermissionSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("Records", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                //res.Payload.Add(XmlMethods.CreateXMLElement("GroupPermissionRecords", Utilities.Utilities.HashtableEnumerator(htvalue,"GROUPPERMISSIONRECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.56.7.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void CheckAllPermissionSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Permission_sps_CheckAll]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("Permission_sps_CheckAll", conn);
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

                    DataSet ds = new DataSet("CheckAllPermission");
                    da.Fill(ds, "PermissionRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//CheckAllPermission", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "16.56.7.98";
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

        #region CheckSinglePermission (16.56.4)
        public Status CheckSinglePermission(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                CheckSinglePermissionSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("PermissionCode", Utilities.Utilities.HashtableEnumerator(htvalue, "PERMISSIONCODE")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "16.32.4.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void CheckSinglePermissionSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Permission_sps_CheckSingle]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("Permission_sps_CheckSingle", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@PermissionCode", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "PERMISSIONCODE");
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
                    InResult.StatusCode = "16.32.4.98";
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
