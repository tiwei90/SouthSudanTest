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
    /// Summary description for clsOrganizationalUnit.
    /// </summary>
    public class OrganizationalUnit
    {
        public OrganizationalUnit()
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

                                case "organizationalunitname":
                                    {
                                        ht.Add("ORGANIZATIONALUNITNAME", xReader.ReadString());
                                        break;
                                    }

                                case "organizationalunitid":
                                    {
                                        ht.Add("ORGANIZATIONALUNITID", xReader.ReadString());
                                        break;
                                    }

                                case "organizationalunitid_parent":
                                    {
                                        ht.Add("ORGANIZATIONALUNITID_PARENT", xReader.ReadString());
                                        break;
                                    }

                                case "addressid":
                                    {
                                        ht.Add("ADDRESSID", xReader.ReadString());
                                        break;
                                    }

                                case "telephonenumber1":
                                    {
                                        ht.Add("TELEPHONENUMBER1", xReader.ReadString());
                                        break;
                                    }

                                case "telephonenumber2":
                                    {
                                        ht.Add("TELEPHONENUMBER2", xReader.ReadString());
                                        break;
                                    }

                                case "telephonenumber3":
                                    {
                                        ht.Add("TELEPHONENUMBER3", xReader.ReadString());
                                        break;
                                    }

                                case "faxnumber":
                                    {
                                        ht.Add("FAXNUMBER", xReader.ReadString());
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

                                case "sessionkey":
                                    {
                                        ht.Add("SESSIONKEY", xReader.ReadString());
                                        break;
                                    }

                                case "disable":
                                    {
                                        ht.Add("DISABLE", xReader.ReadString());
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

        #region Insert(13.54.1)
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
                res.StatusCode = "13.54.1.98";
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
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[OrganizationalUnit_spi]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd;
                    if (Utilities.Utilities.HashtableEnumerator(ht, "ADDRESSID").Length > 1)
                    {
                        cmd = new OleDbCommand("OrganizationalUnit_spi_AddressId", conn);
                    }
                    else
                    {
                        cmd = new OleDbCommand("OrganizationalUnit_spi_ParentId", conn);
                    }
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@OrganizationalUnitName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ORGANIZATIONALUNITNAME");
                    cmd.Parameters.Add(param);

                    if (Utilities.Utilities.HashtableEnumerator(ht, "ADDRESSID").Length > 1)
                    {
                        param = new OleDbParameter("@AddressId", OleDbType.VarChar);
                        param.Direction = ParameterDirection.Input;
                        param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ADDRESSID");
                        cmd.Parameters.Add(param);
                    }

                    if (Utilities.Utilities.HashtableEnumerator(ht, "ORGANIZATIONALUNITID_PARENT").Length > 1)
                    {
                        param = new OleDbParameter("@OrganizationUnitId_Parent", OleDbType.VarChar);
                        param.Direction = ParameterDirection.Input;
                        param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ORGANIZATIONALUNITID_PARENT");
                        cmd.Parameters.Add(param);
                    }

                    param = new OleDbParameter("@TelephoneNumber1", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "TELEPHONENUMBER1");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@TelephoneNumber2", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "TELEPHONENUMBER2");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@TelephoneNumber3", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "TELEPHONENUMBER3");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@FaxNumber", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "FAXNUMBER");
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
                    InResult.StatusCode = "13.54.1.98";
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

        #region Select(13.54.2)
        public Status Select(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectSP(htvalue, ref res);
                //res.Payload.Add(XmlMethods.CreateXMLElement("ADDRESSID", Utilities.HashtableEnumerator(htvalue,"ADDRESSID")));
                //res.Payload.Add(XmlMethods.CreateXMLElement("ORGANIZATIONALUNITNAME", Utilities.HashtableEnumerator(htvalue,"ORGANIZATIONALUNITNAME")));
                res.Payload.Add(XmlMethods.CreateXMLElement("RECORDS", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "13.54.2.99";
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
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[OrganizationalUnit_sps]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {

                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("OrganizationalUnit_sps", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@AddressId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ADDRESSID");

                    da.SelectCommand.Parameters.Add(param);

                    param = new OleDbParameter("@OrganizationUnitName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ORGANIZATIONALUNITNAME");

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

                    DataSet ds = new DataSet("OrganizationalUnitSelectRecords");
                    da.Fill(ds, "OrganizationalUnitRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//OrganizationalUnitSelectRecords", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "13.54.2.98";
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

        #region Update(13.54.3)
        public Status Update(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                UpdateSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("OrganizationalUnitId", Utilities.Utilities.HashtableEnumerator(htvalue, "ORGANIZATIONALUNITID")));
                res.Payload.Add(XmlMethods.CreateXMLElement("OrganizationalUnitName", Utilities.Utilities.HashtableEnumerator(htvalue, "ORGANIZATIONALUNITNAME")));
                res.Payload.Add(XmlMethods.CreateXMLElement("OrganizationalUnitId_Parent", Utilities.Utilities.HashtableEnumerator(htvalue, "ORGANIZATIONALUNITID_PARENT")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "13.54.3.99";
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
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[OrganizationalUnit_spu]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();
                    OleDbCommand cmd;
                    if (Utilities.Utilities.HashtableEnumerator(ht, "ADDRESSID").Length > 1)
                    {
                        cmd = new OleDbCommand("OrganizationalUnit_spu_AddressId", conn);
                    }
                    else
                    {
                        cmd = new OleDbCommand("OrganizationalUnit_spu_ParentId", conn);
                    }
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@OrganizationalUnitId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ORGANIZATIONALUNITID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@OrganizationalUnitName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ORGANIZATIONALUNITNAME");
                    cmd.Parameters.Add(param);

                    if (Utilities.Utilities.HashtableEnumerator(ht, "ADDRESSID").Length > 1)
                    {
                        param = new OleDbParameter("@AddressId", OleDbType.VarChar);
                        param.Direction = ParameterDirection.Input;
                        param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ADDRESSID");
                        cmd.Parameters.Add(param);
                    }

                    if (Utilities.Utilities.HashtableEnumerator(ht, "ORGANIZATIONALUNITID_PARENT").Length > 1)
                    {
                        param = new OleDbParameter("@OrganizationalUnitId_Parent", OleDbType.VarChar);
                        param.Direction = ParameterDirection.Input;
                        param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ORGANIZATIONALUNITID_PARENT");
                        cmd.Parameters.Add(param);
                    }

                    param = new OleDbParameter("@TelephoneNumber1", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "TELEPHONENUMBER1");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@TelephoneNumber2", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "TELEPHONENUMBER2");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@TelephoneNumber3", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "TELEPHONENUMBER3");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@FaxNumber", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "FAXNUMBER");
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
                    InResult.StatusCode = "13.54.3.98";
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

        #region Select All(13.54.7)
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
                res.StatusCode = "13.54.7.99";
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
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[OrganizationalUnit_sps_All]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {

                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("OrganizationalUnit_sps_All", conn);
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

                    //////					param = new OleDbParameter("@PermissionCode", OleDbType.VarChar, 16); 
                    //////					param.Direction = ParameterDirection.Output;
                    //////					
                    //////					da.SelectCommand.Parameters.Add(param);
                    //////
                    //////					param = new OleDbParameter("@ActionDescription", OleDbType.VarChar, 128); 
                    //////					param.Direction = ParameterDirection.Output;
                    //////					
                    //////					da.SelectCommand.Parameters.Add(param);
                    //////
                    //////					param = new OleDbParameter("@TimeStamp", OleDbType.BigInt); 
                    //////					param.Direction = ParameterDirection.Output;
                    //////					
                    //////					da.SelectCommand.Parameters.Add(param);
                    //////


                    DataSet ds = new DataSet("OrganizationalUnitSelectRecords");
                    da.Fill(ds, "OrganizationalUnitRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//OrganizationalUnitSelectRecords", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "13.54.7.98";
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
