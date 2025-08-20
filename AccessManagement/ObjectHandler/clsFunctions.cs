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
    public class Functions
    {
        public Functions()
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

                                case "permissioncode":
                                    {
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
                    TextLogFile.WriteLog(InResult.LogMessage);

                    if (Globals.m_sDebugMode == "1")
                    {
                        TextLogFile.WriteTrace(InResult.LogMessage);
                    }


                }
                finally
                {
                    if (xReader != null) xReader.Close();
                }
            }
        }
        #endregion

        #region Insert (16.30.1)
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
                res.StatusCode = "16.30.1.0";
                res.LogMessage = "[" + res.PermissionCode + "] " + "[" + res.StatusCode + "] " + err.Message;
                TextLogFile.WriteLog(res.LogMessage);

                if (Globals.m_sDebugMode == "1")
                {
                    TextLogFile.WriteTrace(res.LogMessage);
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

                    param = new OleDbParameter("@PasswordExpires", OleDbType.VarChar);
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

                    param = new OleDbParameter("@OrganizationUnitId", OleDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Value = Utilities.Utilities.HashtableEnumerator(ht, "ORGANIZATIONUNITID");
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

                    if (string.Equals(InResult.StatusCode, "0") == true)
                    {
                        ht.Add("DBTIMESTAMP", cmd.Parameters["@TimeStamp"].Value.ToString());
                        ht.Add("DBSESSIONKEY", cmd.Parameters["@SessionKey"].Value.ToString());
                    }
                    else
                    {
                        InResult.StatusMessage = cmd.Parameters["@StatusMessage"].Value.ToString();

                        //InResult.TransResult  = cmd.Parameters["@Exception"].Value.ToString();
                        InResult.TransResult = "[" + InResult.PermissionCode + "] [" + InResult.StatusCode + "] [" +
                            InResult.TransResult + "]";

                        TextLogFile.WriteLog(InResult.StatusMessage);
                        if (Globals.m_sDebugMode == "1")
                        {
                            TextLogFile.WriteLog(InResult.TransResult);
                        }
                    }
                }
                catch (Exception err)
                {
                    if (conn.State != 0)
                        conn.Close();

                    InResult.StatusCode = "13.86.11.3";
                    InResult.LogMessage = "[" + InResult.PermissionCode + "] " + "[" + InResult.StatusCode + "] " + err.Message;
                    TextLogFile.WriteLog(InResult.LogMessage);

                    if (Globals.m_sDebugMode == "1")
                    {
                        TextLogFile.WriteTrace(InResult.LogMessage);
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        #endregion
    }
}
