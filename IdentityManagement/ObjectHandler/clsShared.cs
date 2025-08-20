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
    public class Shared
    {
        public Shared()
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
                                case "username":
                                    {
                                        ht.Add("USERNAME", xReader.ReadString());
                                        break;
                                    }

                                case "disable":
                                    {
                                        ht.Add("DISABLE", xReader.ReadString());
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

                                case "addressid":
                                    {
                                        ht.Add("ADDRESSID", xReader.ReadString());
                                        break;
                                    }

                                case "addressname":
                                    {
                                        ht.Add("ADDRESSNAME", xReader.ReadString());
                                        break;
                                    }

                                case "friendlyname":
                                    {
                                        ht.Add("FRIENDLYNAME", xReader.ReadString());
                                        break;
                                    }

                                case "organizationid":
                                    {
                                        ht.Add("ORGANIZATIONID", xReader.ReadString());
                                        break;
                                    }

                                case "streetaddress1":
                                    {
                                        ht.Add("STREETADDRESS1", xReader.ReadString());
                                        break;
                                    }

                                case "streetaddress2":
                                    {
                                        ht.Add("STREETADDRESS2", xReader.ReadString());
                                        break;
                                    }

                                case "streetaddress3":
                                    {
                                        ht.Add("STREETADDRESS3", xReader.ReadString());
                                        break;
                                    }

                                case "postalcodelocalityid":
                                    {
                                        ht.Add("POSTALCODELOCALITYID", xReader.ReadString());
                                        break;
                                    }

                                case "postalcode":
                                    {
                                        ht.Add("POSTALCODE", xReader.ReadString());
                                        break;
                                    }

                                case "locality":
                                    {
                                        ht.Add("LOCALITY", xReader.ReadString());
                                        break;
                                    }

                                case "stateorprovinceid":
                                    {
                                        ht.Add("STATEORPROVINCEID", xReader.ReadString());
                                        break;
                                    }

                                case "stateorprovincename":
                                    {
                                        ht.Add("STATEORPROVINCENAME", xReader.ReadString());
                                        break;
                                    }

                                case "countryid":
                                    {
                                        ht.Add("COUNTRYID", xReader.ReadString());
                                        break;
                                    }

                                case "countryname":
                                    {
                                        ht.Add("COUNTRYNAME", xReader.ReadString());
                                        break;
                                    }

                                case "countrycode":
                                    {
                                        ht.Add("COUNTRYCODE", xReader.ReadString());
                                        break;
                                    }

                                case "nationality":
                                    {
                                        ht.Add("NATIONALITY", xReader.ReadString());
                                        break;
                                    }

                                case "timedifferenceinhours":
                                    {
                                        ht.Add("TIMEDIFFERENCEINHOURS", xReader.ReadString());
                                        break;
                                    }

                                case "statecode":
                                    {
                                        ht.Add("STATECODE", xReader.ReadString());
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

        #region Insert Address(18.1.1)
        public Status InsertAddress(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                InsertAddressSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("FriendlyName", Utilities.Utilities.HashtableEnumerator(htvalue, "FRIENDLYNAME")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "18.1.1.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void InsertAddressSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Address_spi]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {

                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("Address_spi", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@FriendlyName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "FRIENDLYNAME");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@OrganizationId", OleDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ORGANIZATIONID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StreetAddress1", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "STREETADDRESS1");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StreetAddress2", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "STREETADDRESS2");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StreetAddress3", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "STREETADDRESS3");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@PostalCodeLocalityId", OleDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "POSTALCODELOCALITYID");
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
                    InResult.StatusCode = "18.1.1.98";
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

        #region Select Address(18.1.2)
        public Status SelectAddress(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectAddressSP(htvalue, ref res);
                //res.Payload.Add(XmlMethods.CreateXMLElement("ADDRESSID", Utilities.HashtableEnumerator(htvalue,"ADDRESSID")));
                res.Payload.Add(XmlMethods.CreateXMLElement("RECORDS", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "18.1.2.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void SelectAddressSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Address_sps]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("Address_sps", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@AddressName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ADDRESSNAME");

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

                    DataSet ds = new DataSet("AddressSelectRecords");
                    da.Fill(ds, "AddressRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//AddressSelectRecords", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "18.1.2.98";
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

        #region Update Address(18.1.3)
        public Status UpdateAddress(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                UpdateAddressSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("ADDRESSID", Utilities.Utilities.HashtableEnumerator(htvalue, "ADDRESSID")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "18.1.3.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void UpdateAddressSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Address_spu]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {

                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("Address_spu", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@AddressId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ADDRESSID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@FriendlyName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "FRIENDLYNAME");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@OrganizationId", OleDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ORGANIZATIONID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StreetAddress1", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "STREETADDRESS1");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StreetAddress2", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "STREETADDRESS2");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StreetAddress3", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "STREETADDRESS3");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@PostalCodeLocalityId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "POSTALCODELOCALITYID");
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
                    InResult.StatusCode = "18.1.3.98";
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

        #region Select All Address(18.1.7)
        public Status SelectAllAddress(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectAllAddressSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("RECORDS", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "18.1.7.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void SelectAllAddressSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Address_sps_All]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {

                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("Address_sps_All", conn);
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


                    DataSet ds = new DataSet("AddressSelectRecords");
                    da.Fill(ds, "AddressRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//AddressSelectRecords", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "18.1.7.98";
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

        #region Insert Country(18.19.1)
        public Status InsertCountry(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                InsertCountrySP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("CountryName", Utilities.Utilities.HashtableEnumerator(htvalue, "COUNTRYNAME")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "18.19.1.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void InsertCountrySP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Country_spi]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {

                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("Country_spi", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@CountryName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "COUNTRYNAME");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@CounrtyCode", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "COUNTRYCODE");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@Nationality", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "NATIONALITY");
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
                    InResult.StatusCode = "18.19.1.98";
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

        #region Select Country(18.19.2)
        public Status SelectCountry(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectCountrySP(htvalue, ref res);
                //res.Payload.Add(XmlMethods.CreateXMLElement("COUNTRYID", Utilities.HashtableEnumerator(htvalue,"COUNTRYID")));
                res.Payload.Add(XmlMethods.CreateXMLElement("RECORDS", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "18.19.2.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void SelectCountrySP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Country_sps]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("Country_sps", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@CountryName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "COUNTRYNAME");

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

                    DataSet ds = new DataSet("CountrySelectRecords");
                    da.Fill(ds, "AddressRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//CountrySelectRecords", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "18.19.2.98";
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

        #region Update Country(18.19.3)
        public Status UpdateCountry(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                UpdateCountrySP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("COUNTRYID", Utilities.Utilities.HashtableEnumerator(htvalue, "COUNTRYID")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "18.19.3.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void UpdateCountrySP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Country_spu]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {

                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("Country_spu", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@CountryId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "COUNTRYID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@CountryName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "COUNTRYNAME");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@CounrtyCode", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "COUNTRYCODE");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@Nationality", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "NATIONALITY");
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
                    InResult.StatusCode = "18.19.3.98";
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

        #region Select All Country(18.19.7)
        public Status SelectAllCountry(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectAllCountrySP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("RECORDS", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "18.19.7.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void SelectAllCountrySP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[Country_sps_All]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {

                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("Country_sps_All", conn);
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


                    DataSet ds = new DataSet("CountrySelectRecords");
                    da.Fill(ds, "AddressRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//CountrySelectRecords", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "18.19.7.98";
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

        #region Insert PostalCodeLocality(18.58.1)
        public Status InsertPostalCodeLocality(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                InsertPostalCodeLocalitySP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("PostalCode", Utilities.Utilities.HashtableEnumerator(htvalue, "POSTALCODE")));
                res.Payload.Add(XmlMethods.CreateXMLElement("Locality", Utilities.Utilities.HashtableEnumerator(htvalue, "LOCALITY")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "18.58.1.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void InsertPostalCodeLocalitySP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[PostalCodeLocality_spi]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {

                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("PostalCodeLocality_spi", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@PostalCode", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "POSTALCODE");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@Locality", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "LOCALITY");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StateOrProvinceId", OleDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "STATEORPROVINCEID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@TimeDifferenceInHours", OleDbType.Decimal);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "TIMEDIFFERENCEINHOURS");
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
                    InResult.StatusCode = "18.58.1.98";
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

        #region Select PostalCodeLocality(18.58.2)
        public Status SelectPostalCodeLocality(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectPostalCodeLocalitySP(htvalue, ref res);
                //res.Payload.Add(XmlMethods.CreateXMLElement("POSTALCODELOCALITYID", Utilities.HashtableEnumerator(htvalue,"POSTALCODELOCALITYID")));
                res.Payload.Add(XmlMethods.CreateXMLElement("RECORDS", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "18.58.2.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void SelectPostalCodeLocalitySP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[PostalCodeLocality_sps]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("PostalCodeLocality_sps", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@PostalCodeLocality", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "POSTALCODELOCALITYID");

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

                    DataSet ds = new DataSet("PostalCodeLocalitySelectRecords");
                    da.Fill(ds, "AddressRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//PostalCodeLocalitySelectRecords", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "18.58.2.98";
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

        #region Update PostalCodeLocality(18.58.3)
        public Status UpdatePostalCodeLocality(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                UpdatePostalCodeLocalitySP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("POSTALCODELOCALITYID", Utilities.Utilities.HashtableEnumerator(htvalue, "POSTALCODELOCALITYID")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "18.58.3.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void UpdatePostalCodeLocalitySP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[PostalCodeLocality_spu]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {

                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("PostalCodeLocality_spu", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@PostalCodeLocalityId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "POSTALCODELOCALITYID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@PostalCode", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "POSTALCODE");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@Locality", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "LOCALITY");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StateOrProvinceId", OleDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "STATEORPROVINCEID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@TimeDifferenceInHours", OleDbType.Decimal);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "TIMEDIFFERENCEINHOURS");
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
                    InResult.StatusCode = "18.58.3.98";
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

        #region Select All PostalCodeLocality(18.58.7)
        public Status SelectAllPostalCodeLocality(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectAllPostalCodeLocalitySP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("RECORDS", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "18.58.7.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void SelectAllPostalCodeLocalitySP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[PostalCodeLocality_sps_All]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {

                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("PostalCodeLocality_sps_All", conn);
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


                    DataSet ds = new DataSet("PostalCodeLocalitySelectRecords");
                    da.Fill(ds, "AddressRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//PostalCodeLocalitySelectRecords", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "18.58.7.98";
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

        #region Insert StateOrProvince(18.61.1)
        public Status InsertStateOrProvince(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                InsertStateOrProvinceSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("STATEORPROVINCENAME", Utilities.Utilities.HashtableEnumerator(htvalue, "STATEORPROVINCENAME")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "18.61.1.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void InsertStateOrProvinceSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[StateOrProvince_spi]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {

                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("StateOrProvince_spi", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@StateOrProvinceName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "STATEORPROVINCENAME");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StateCode", OleDbType.VarChar, 3);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "STATECODE");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@CountryId", OleDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "COUNTRYID");
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
                    InResult.StatusCode = "18.61.1.98";
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

        #region Select StateOrProvince(18.61.2)
        public Status SelectStateOrProvince(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectStateOrProvinceSP(htvalue, ref res);
                //res.Payload.Add(XmlMethods.CreateXMLElement("STATEORPROVINCEID", Utilities.HashtableEnumerator(htvalue,"STATEORPROVINCEID")));
                res.Payload.Add(XmlMethods.CreateXMLElement("RECORDS", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "18.61.2.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void SelectStateOrProvinceSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[StateOrProvince_sps]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {
                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("StateOrProvince_sps", conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@StateOrProvinceName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "STATEORPROVINCENAME");

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

                    DataSet ds = new DataSet("StateOrProvinceSelectRecords");
                    da.Fill(ds, "AddressRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//StateOrProvinceSelectRecords", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "18.61.2.98";
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

        #region Update StateOrProvince(18.61.3)
        public Status UpdateStateOrProvince(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                UpdateStateOrProvinceSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("STATEORPROVINCEID", Utilities.Utilities.HashtableEnumerator(htvalue, "STATEORPROVINCEID")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "18.61.3.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void UpdateStateOrProvinceSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[StateOrProvince_spu]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {

                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("StateOrProvince_spu", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    OleDbParameter param;

                    param = new OleDbParameter("@StateOrProvinceId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "STATEORPROVINCEID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StateOrProvinceName", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "STATEORPROVINCENAME");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@StateCode", OleDbType.VarChar, 3);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "STATECODE");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@CountryId", OleDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "COUNTRYID");
                    cmd.Parameters.Add(param);

                    param = new OleDbParameter("@Obsolete", OleDbType.BigInt);
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
                    InResult.StatusCode = "18.61.3.98";
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

        #region Select All StateOrProvince(18.61.7)
        public Status SelectAllStateOrProvince(byte[] postXML, Status res)
        {
            Hashtable htvalue = new Hashtable();

            try
            {
                ParseXml(postXML, ref htvalue, ref res);
                SelectAllStateOrProvinceSP(htvalue, ref res);
                res.Payload.Add(XmlMethods.CreateXMLElement("RECORDS", Utilities.Utilities.HashtableEnumerator(htvalue, "RECORDS")));
                return res;
            }
            catch (Exception err)
            {
                res.StatusCode = "18.61.7.99";
                res.StatusMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE]" + " - " + res.StatusMessage);
                }
                return res;
            }
        }

        public void SelectAllStateOrProvinceSP(Hashtable ht, ref Status InResult)
        {
            if (InResult.StatusCode == "0")
            {
                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace("[TRACE] Invoke DB Stored Procedure " + "[StateOrProvince_sps_All]");
                }

                OleDbConnection conn = new OleDbConnection(Globals.m_sConnString);
                try
                {

                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = new OleDbCommand("StateOrProvince_sps_All", conn);
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


                    DataSet ds = new DataSet("StateOrProvinceSelectRecords");
                    da.Fill(ds, "AddressRecord");
                    ht.Add("RECORDS", XmlMethods.GetElementValue("//StateOrProvinceSelectRecords", Encoding.UTF8.GetBytes(ds.GetXml())));

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
                    InResult.StatusCode = "18.61.7.98";
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
