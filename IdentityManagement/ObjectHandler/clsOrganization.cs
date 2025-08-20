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
    /// Summary description for clsOrganization.
    /// </summary>
    public class Organization
    {
        public Organization()
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

                                case "organizationname":
                                    {
                                        ht.Add("ORGANIZATIONNAME", xReader.ReadString());
                                        break;
                                    }

                                case "organizationid":
                                    {
                                        ht.Add("ORGANIZATIONID", xReader.ReadString());
                                        break;
                                    }

                                case "obsolete":
                                    {
                                        ht.Add("OBSOLETE", xReader.ReadString());
                                        break;
                                    }

                                case "sessionkey":
                                    {
                                        ht.Add("SESSIONKEY", xReader.ReadString());
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

        #region Insert(13.53.1)
        public Status Insert(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                InsertSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("OrganizationUnitName", Utilities.Utilities.HashtableEnumerator(htvalue, "ORGANIZATIONUNITNAME")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "13.53.1.98";
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
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Organization_spi]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd;
                    if (Utilities.Utilities.HashtableEnumerator(ht, "ADDRESSID").Length > 1)
                    {
                        cmd = new OleDbCommand("Organization_spi_AddressId", conn);
                    }
                    else
                    {
                        cmd = new OleDbCommand("Organization_spi_ParentId", conn);
                    }
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@OrganizationName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ORGANIZATIONNAME");
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
                    InResult.StatusCode = "13.53.1.98";
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

        #region Select(13.53.2)
        public Status Select(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectSP(htvalue, ref res);
                //res.Payload.Add(XmlMethods.CreateXMLElement("OrganizationId", Utilities.HashtableEnumerator(htvalue,"ORGANIZATIONID")));
                res.Payload.Add(XmlMethods.CreateXMLElement("RECORDS", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "13.53.2.99";
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
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Organization_sps]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {

                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("Organization_sps", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@OrganizationName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ORGANIZATIONNAME");

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

                    DataSet ds = new DataSet("OrganizationSelectRecords");
                    da.Fill(ds, "OrganizationRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//OrganizationSelectRecords", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "13.53.2.98";
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

        #region Update(13.53.3)
        public Status Update(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                UpdateSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("OrganizationId", Utilities.Utilities.HashtableEnumerator(htvalue, "ORGANIZATIONID")));
                res.Payload.Add(XmlMethods.CreateXMLElement("OrganizationName", Utilities.Utilities.HashtableEnumerator(htvalue, "ORGANIZATIONNAME")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "13.53.3.99";
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
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Organization_spu]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd;
                    if (Utilities.Utilities.HashtableEnumerator(ht, "ADDRESSID").Length > 1)
                    {
                        cmd = new OleDbCommand("Organization_spu_AddressId", conn);
                    }
                    else
                    {
                        cmd = new OleDbCommand("Organization_spu_ParentId", conn);
                    }
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@OrganizationId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ORGANIZATIONID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@OrganizationName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ORGANIZATIONNAME");
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
                    InResult.StatusCode = "13.53.3.98";
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

        #region Select All(13.53.7)
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
                res.StatusCode = "13.53.7.99";
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
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Organization_sps_All]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {

                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("Organization_sps_All", conn);
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

                    DataSet ds = new DataSet("OrganizationSelectRecords");
                    da.Fill(ds, "OrganizationRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//OrganizationSelectRecords", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "13.53.7.98";
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
    }
}
