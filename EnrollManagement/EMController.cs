using EnrollManagement.Common;
using EnrollManagement.DataType;
using EnrollManagement.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace EnrollManagement
{
    public class EMController
    {
        #region BCMS
        public static ResponseDataTypeBCMSCheck BCMSCheck(RequestDataTypeBCMSCheck requestdatatype)
        {
            ResponseDataTypeBCMSCheck responsedatatype = new ResponseDataTypeBCMSCheck();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Get Scanned Document");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  22.124.1");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [DocStatus_sps]");
            }

            SqlConnection connbhswpis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[DocStatus_sps]", connbhswpis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            try
            {
                connbhswpis.Open();

                param = new SqlParameter("@in_PassportNo", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportNo;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [PASSPORT NO] " + requestdatatype.PassportNo);
                }

                param = new SqlParameter("@in_PassportCOI", SqlDbType.VarChar, 3);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportCOI;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [PASSPORT ISSUE COUNTRY] " + requestdatatype.PassportCOI);
                }

                param = new SqlParameter("@in_DocType", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DocType;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [DOC TYPE] " + requestdatatype.DocType);
                }

                param = new SqlParameter("@RecCount", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                //cmd.ExecuteNonQuery();

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);


                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();

                responsedatatype.RecCount = Convert.ToInt16(cmd.Parameters["@reccount"].Value);

                responsedatatype.ResultList = DS;

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhswpis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }
        #endregion

        public static ResponseDataTypeGetApplicationID GetApplicationID(RequestDataTypeGetApplicationID requestdatatype)
        {
            ResponseDataTypeGetApplicationID responsedatatype = new ResponseDataTypeGetApplicationID();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] GetNewFormNo");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.1");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [GetNewFormNo]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("GetNewFormNo", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();



                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@out_newformno", SqlDbType.VarChar, 7);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();



                responsedatatype.NewApplicationID = Settings.Default._FormNoPrefix + cmd.Parameters["@out_newformno"].Value.ToString();
                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();


                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] New Application ID : " + responsedatatype.NewApplicationID);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }
            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }

        public static ResponseDataTypeGetPermission GetPermission(RequestDataTypeGetPermission requestdatatype)
        {
            ResponseDataTypeGetPermission responsedatatype = new ResponseDataTypeGetPermission();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Get Permission");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [GetPermission]");
            }

            SqlConnection connbhswpis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[GetPermission]", connbhswpis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            try
            {
                connbhswpis.Open();

                param = new SqlParameter("@sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@PermissionCode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PermissionCode;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [PERMISSION CODE] " + requestdatatype.PermissionCode);
                }

                param = new SqlParameter("@result", SqlDbType.Bit);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                responsedatatype.Result = cmd.Parameters["@result"].Value.ToString();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Result : " + responsedatatype.Result);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.Result = "-1";

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhswpis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }

        public static ResponseDataTypeUpdateStageCode UpdateStageCode(RequestDataTypeUpdateStageCode requestdatatype)
        {
            ResponseDataTypeUpdateStageCode responsedatatype = new ResponseDataTypeUpdateStageCode();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] UpdateStageCode");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.24");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordUpateStageCode_sps]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordUpateStageCode_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ApplicationID", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ApplicationID;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APPLICATION ID] " + requestdatatype.ApplicationID);
                }

                param = new SqlParameter("@in_StageCode", SqlDbType.VarChar, 6);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.StageCode;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [STAGE CODE] " + requestdatatype.StageCode);
                }

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();


                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();



                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;
            
        }

        public static ResponseDataTypeGetPlace SelectPlaceList(RequestDataTypeGetPlace requestdatatype)
        {
            ResponseDataTypeGetPlace responsedatatype = new ResponseDataTypeGetPlace();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Place List");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.25");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordGetPlace_sps]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordGetPlace_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_CountryCode", SqlDbType.VarChar, 3);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.CountryCode;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [COUNTRY CODE] " + requestdatatype.CountryCode);
                }

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.ResultList = DS;


                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();



                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }

        public static ResponseDataTypeGetBranchName GetBranchName(RequestDataTypeGetBranchName requestdatatype)
        {
            ResponseDataTypeGetBranchName responsedatatype = new ResponseDataTypeGetBranchName();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Get Branch Name");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.26");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordGetBranch_sps]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordGetBranch_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [LOCATION NAME] " + requestdatatype.EnrolLocationName);
                }

                param = new SqlParameter("@out_BranchName", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@out_ProcessDays", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();


                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }

                responsedatatype.BranchName = cmd.Parameters["@out_BranchName"].Value.ToString();
                responsedatatype.ProcessDays = Convert.ToInt32(cmd.Parameters["@out_ProcessDays"].Value);
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }

        public static ResponseDataTypeSelectCountry GetCountryList(RequestDataTypeSelectCountry requestdatatype)
        {
            ResponseDataTypeSelectCountry responsedatatype = new ResponseDataTypeSelectCountry();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] GetCountryList");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE] 12.23.28");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordForCountry_sps]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordForCountry_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_SortBy", SqlDbType.Char);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SortBy;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.ResultList = DS;


                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();


                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }

        public static ResponseDataTypeGetDetails GetDetails(RequestDataTypeGetDetails requestdatatype)
        {
            ResponseDataTypeGetDetails responsedatatype = new ResponseDataTypeGetDetails();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] GetDetails");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.4");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordDetails_sps]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordDetails_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                //ylchin - Search By different criteria
                // 1 = Application ID
                // 2 = Passport No
                // 3 = Document No
                param = new SqlParameter("@in_SearchType", SqlDbType.VarChar, 1);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SearchType;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [SEARCH TYPE] " + requestdatatype.SearchType);
                }

                param = new SqlParameter("@in_ApplicationID", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ApplicationID;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APPLICATION ID] " + requestdatatype.ApplicationID);
                }

                param = new SqlParameter("@in_PassportNo", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportNo;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [PASSPORT NO] " + requestdatatype.PassportNo);
                }

                param = new SqlParameter("@in_PassportCOI", SqlDbType.VarChar, 3);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportCOI;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [PASSPORT COI] " + requestdatatype.PassportCOI);
                }

                param = new SqlParameter("@in_DocNo", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DocNo;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [DOC NUMBER] " + requestdatatype.DocNo);
                }


                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();


                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }

                if (responsedatatype.StatusCode == "0")
                {
                    foreach (DataRow dr in DS.Tables[0].Rows)
                    {
                        foreach (DataColumn dc in DS.Tables[0].Columns)
                        {
                            responsedatatype.ApplicationID = dr["FORMNO"].ToString().ToUpper();
                            responsedatatype.IDPerson = DataConvertor.ToInt32(dr["IDPERSON"]);
                            responsedatatype.AppReason = dr["APPREASON"].ToString().ToUpper();
                            responsedatatype.DocType = dr["DOCTYPE"].ToString().ToUpper();
                            responsedatatype.EntryType = dr["ENTRYTYPE"].ToString().ToUpper();
                            responsedatatype.Priority = DataConvertor.ToInt32(dr["PRIORITY"]);
                            responsedatatype.DocNo = dr["DOCNO"].ToString().ToUpper();
                            responsedatatype.DocExpiryDate = DataConvertor.ToDateTime(dr["DOCEXPIRYDATE"]);
                            responsedatatype.DocIssueDate = DataConvertor.ToDateTime(dr["DOCISSUEDATE"]);
                            responsedatatype.StageCode = dr["STAGECODE"].ToString().ToUpper();
                            responsedatatype.IssueBy = dr["ISSUEBY"].ToString().ToUpper();
                            responsedatatype.IssueTime = DataConvertor.ToDateTime(dr["ISSUETIME"]);
                            responsedatatype.IssueLocation = dr["ISSUELOCATION"].ToString().ToUpper();
                            responsedatatype.DataEntryBy = dr["DATAENTRYBY"].ToString().ToUpper();
                            responsedatatype.DataEntryTime = DataConvertor.ToDateTime(dr["DATAENTRYTIME"]);
                            responsedatatype.DataEntryLocation = dr["DATAENTRYLOCATION"].ToString().ToUpper();
                            responsedatatype.EnrolBy = dr["ENROLBY"].ToString().ToUpper();
                            responsedatatype.EnrolTime = DataConvertor.ToDateTime(dr["ENROLTIME"]);
                            responsedatatype.EnrolLocation = dr["ENROLLOCATION"].ToString().ToUpper();
                            responsedatatype.CollectionDate = DataConvertor.ToDateTime(dr["COLLECTIONDATE"]);
                            responsedatatype.BirthDate = DataConvertor.ToDateTime(dr["BIRTHDATE"]);
                            responsedatatype.BirthPlace = dr["BIRTHPLACE"].ToString().ToUpper();
                            responsedatatype.BirthCountry = dr["BIRTHCOUNTRY"].ToString().ToUpper();
                            responsedatatype.Nationality = dr["NATIONALITY"].ToString().ToUpper();
                            responsedatatype.FatherNationality = dr["FATHERNATIONALITY"].ToString().ToUpper();
                            responsedatatype.MotherNationality = dr["MOTHERNATIONALITY"].ToString().ToUpper();
                            responsedatatype.FatherResidentialStatus = dr["FATHERRESIDENTIALSTATUS"].ToString().ToUpper();
                            responsedatatype.MotherResidentialStatus = dr["MOTHERRESIDENTIALSTATUS"].ToString().ToUpper();
                            responsedatatype.SpouseResidentialStatus = dr["SPOUSERESIDENTIALSTATUS"].ToString().ToUpper();
                            responsedatatype.SiblingResidentialStatus = dr["SIBLINGRESIDENTIALSTATUS"].ToString().ToUpper();
                            responsedatatype.ChildrenResidentialStatus = dr["CHILDRENRESIDENTIALSTATUS"].ToString().ToUpper();
                            responsedatatype.Surname = dr["SURNAME"].ToString().ToUpper();
                            responsedatatype.FirstName = dr["FIRSTNAME"].ToString().ToUpper();
                            responsedatatype.MiddleName = dr["MIDDLENAME"].ToString().ToUpper();
                            responsedatatype.PassportNo = dr["PASSPORTNO"].ToString().ToUpper();
                            responsedatatype.PassportCOI = dr["PASSPORTCOI"].ToString().ToUpper();
                            responsedatatype.PassportPOI = dr["PASSPORTPOI"].ToString().ToUpper();
                            responsedatatype.PassportDOE = DataConvertor.ToDateTime(dr["PASSPORTDOE"]);
                            responsedatatype.PassportDOI = DataConvertor.ToDateTime(dr["PASSPORTDOI"]);
                            responsedatatype.Sex = dr["SEX"].ToString().ToUpper();
                            responsedatatype.Title = dr["TITLE"].ToString().ToUpper();
                            responsedatatype.MaritalStatus = dr["MARITALSTATUS"].ToString().ToUpper();
                            responsedatatype.NationalIDNo = dr["NATIONALIDNO"].ToString().ToUpper();

                            responsedatatype.FaceImage = DataConvertor.ToByteArray(dr["FACEIMAGE"]);
                            responsedatatype.FaceImageJ2K = DataConvertor.ToByteArray(dr["FACEIMAGEJ2K"]);
                            responsedatatype.FaceEntryTime = DataConvertor.ToDateTime(dr["FACEENTRYTIME"]);

                            responsedatatype.PresentAddress = dr["PRESENTADDRESS"].ToString().ToUpper();
                            responsedatatype.PermanentAddress = dr["PERMANENTADDRESS"].ToString().ToUpper();
                            responsedatatype.PhoneHome = dr["PHONEHOME"].ToString().ToUpper();
                            responsedatatype.PhoneWork = dr["PHONEWORK"].ToString().ToUpper();
                            responsedatatype.Mobile = dr["MOBILE"].ToString().ToUpper();
                            responsedatatype.Email = dr["EMAIL"].ToString().ToUpper();
                            responsedatatype.Fax = dr["FAX"].ToString().ToUpper();

                            responsedatatype.Occupation = dr["OCCUPATION"].ToString().ToUpper();
                            responsedatatype.EmployerName = dr["EMPLOYERNAME"].ToString().ToUpper();
                            responsedatatype.EmployerAddress = dr["EMPLOYERADDRESS"].ToString().ToUpper();
                            responsedatatype.EmployerPhone = dr["EMPLOYERPHONE"].ToString().ToUpper();
                            responsedatatype.YearsEmployed = dr["YEARSEMPLOYED"].ToString().ToUpper();

                            responsedatatype.FormerOccupation = dr["FORMEROCCUPATION"].ToString().ToUpper();
                            responsedatatype.FormerEmployerName = dr["FORMEREMPLOYERNAME"].ToString().ToUpper();
                            responsedatatype.FormerEmployerAddress = dr["FORMEREMPLOYERADDRESS"].ToString().ToUpper();
                            responsedatatype.FormerEmployerPhone = dr["FORMEREMPLOYERPHONE"].ToString().ToUpper();
                            responsedatatype.FormerYearsEmployed = dr["FORMERYEARSEMPLOYED"].ToString().ToUpper();

                            responsedatatype.FatherFirstName = dr["FATHERFIRSTNAME"].ToString().ToUpper();
                            responsedatatype.FatherMiddleName = dr["FATHERMiddleNAME"].ToString().ToUpper();
                            responsedatatype.FatherLastName = dr["FATHERLASTNAME"].ToString().ToUpper();
                            responsedatatype.MotherFirstName = dr["MOTHERFIRSTNAME"].ToString().ToUpper();
                            responsedatatype.MotherMiddleName = dr["MOTHERMiddleNAME"].ToString().ToUpper();
                            responsedatatype.MotherLastName = dr["MOTHERLASTNAME"].ToString().ToUpper();
                            responsedatatype.SpouseFirstName = dr["SPOUSEFIRSTNAME"].ToString().ToUpper();
                            responsedatatype.SpouseMiddleName = dr["SPOUSEMiddleNAME"].ToString().ToUpper();
                            responsedatatype.SpouseLastName = dr["SPOUSELASTNAME"].ToString().ToUpper();
                            responsedatatype.SpouseMaidenName = dr["SPOUSEMAIDENNAME"].ToString().ToUpper();
                            responsedatatype.SpouseDOB = DataConvertor.ToDateTime(dr["SPOUSEDOB"]);
                            responsedatatype.HasChildInd = dr["HASCHILDIND"].ToString().ToUpper();

                            responsedatatype.DependantName1 = dr["DEPENDANTNAME1"].ToString().ToUpper();
                            responsedatatype.Relationship1 = dr["RELATIONSHIP1"].ToString().ToUpper();
                            responsedatatype.DependantName2 = dr["DEPENDANTNAME2"].ToString().ToUpper();
                            responsedatatype.Relationship2 = dr["RELATIONSHIP2"].ToString().ToUpper();
                            responsedatatype.DependantName3 = dr["DEPENDANTNAME3"].ToString().ToUpper();
                            responsedatatype.Relationship3 = dr["RELATIONSHIP3"].ToString().ToUpper();
                            responsedatatype.DependantName4 = dr["DEPENDANTNAME4"].ToString().ToUpper();
                            responsedatatype.Relationship4 = dr["RELATIONSHIP4"].ToString().ToUpper();
                            responsedatatype.DependantName5 = dr["DEPENDANTNAME5"].ToString().ToUpper();
                            responsedatatype.Relationship5 = dr["RELATIONSHIP5"].ToString().ToUpper();

                            responsedatatype.TravelWithSpouseInd = dr["TRAVELWITHSPOUSEIND"].ToString().ToUpper();
                            responsedatatype.TravelWithDependantInd = dr["TRAVELWITHDEPENDANTIND"].ToString().ToUpper();

                            responsedatatype.VisitPurpose = dr["VISITPURPOSE"].ToString().ToUpper();
                            responsedatatype.OtherVisitPurpose = dr["OTHERVISITPURPOSE"].ToString().ToUpper();
                            responsedatatype.LengthOfStay = dr["LENGTHOFSTAY"].ToString().ToUpper();

                            responsedatatype.ArrivalDate = DataConvertor.ToDateTime(dr["ARRIVALDATE"]);

                            responsedatatype.HotelName = dr["HOTELNAME"].ToString().ToUpper();
                            responsedatatype.HotelAddress = dr["HOTELADDRESS"].ToString().ToUpper();
                            responsedatatype.HotelPhone = dr["HOTELPHONE"].ToString().ToUpper();

                            responsedatatype.TripSponsorBy = dr["TRIPSPONSORBY"].ToString().ToUpper();
                            responsedatatype.TripMoney = dr["TRIPMONEY"].ToString().ToUpper();

                            responsedatatype.CriminalConvictionInd = dr["CRIMINALCONVICTIONIND"].ToString().ToUpper();
                            responsedatatype.Offence1 = dr["OFFENCE1"].ToString().ToUpper();
                            responsedatatype.OffenceDate1 = DataConvertor.ToDateTime(dr["OFFENCEDATE1"].ToString());
                            responsedatatype.OffencePlace1 = dr["OFFENCEPLACE1"].ToString().ToUpper();
                            responsedatatype.OffencePenalty1 = dr["OFFENCEPENALTY1"].ToString().ToUpper();

                            responsedatatype.Offence2 = dr["OFFENCE2"].ToString().ToUpper();
                            responsedatatype.OffenceDate2 = DataConvertor.ToDateTime(dr["OFFENCEDATE2"].ToString());
                            responsedatatype.OffencePlace2 = dr["OFFENCEPLACE2"].ToString().ToUpper();
                            responsedatatype.OffencePenalty2 = dr["OFFENCEPENALTY2"].ToString().ToUpper();

                            responsedatatype.Offence3 = dr["OFFENCE3"].ToString().ToUpper();
                            responsedatatype.OffenceDate3 = DataConvertor.ToDateTime(dr["OFFENCEDATE3"].ToString());
                            responsedatatype.OffencePlace3 = dr["OFFENCEPLACE3"].ToString().ToUpper();
                            responsedatatype.OffencePenalty3 = dr["OFFENCEPENALTY3"].ToString().ToUpper();

                            responsedatatype.Offence4 = dr["OFFENCE4"].ToString().ToUpper();
                            responsedatatype.OffenceDate4 = DataConvertor.ToDateTime(dr["OFFENCEDATE4"].ToString());
                            responsedatatype.OffencePlace4 = dr["OFFENCEPLACE4"].ToString().ToUpper();
                            responsedatatype.OffencePenalty4 = dr["OFFENCEPENALTY4"].ToString().ToUpper();

                            responsedatatype.Offence5 = dr["OFFENCE5"].ToString().ToUpper();
                            responsedatatype.OffenceDate5 = DataConvertor.ToDateTime(dr["OFFENCEDATE5"].ToString());
                            responsedatatype.OffencePlace5 = dr["OFFENCEPLACE5"].ToString().ToUpper();
                            responsedatatype.OffencePenalty5 = dr["OFFENCEPENALTY5"].ToString().ToUpper();

                            responsedatatype.TerrorismInd = dr["TERRORISMIND"].ToString().ToUpper();
                            responsedatatype.TerrorismDesc = dr["TERRORISMDESC"].ToString().ToUpper();

                            responsedatatype.FatherInBHSInd = dr["FATHERINBHSIND"].ToString().ToUpper();
                            responsedatatype.MotherInBHSInd = dr["MOTHERINBHSIND"].ToString().ToUpper();
                            responsedatatype.SpouseInBHSInd = dr["SPOUSEINBHSIND"].ToString().ToUpper();
                            responsedatatype.SiblingInBHSInd = dr["SIBLINGINBHSIND"].ToString().ToUpper();
                            responsedatatype.ChildrenInBHSInd = dr["CHILDRENINBHSIND"].ToString().ToUpper();

                            responsedatatype.VisitedBhsInd = dr["VISITEDBHSIND"].ToString().ToUpper();
                            responsedatatype.LastVisitDate = DataConvertor.ToDateTime(dr["LASTVISITDATE"]);

                            responsedatatype.AppliedVisaInd = dr["APPLIEDVISAIND"].ToString().ToUpper();

                            responsedatatype.AppliedVisaDate = DataConvertor.ToDateTime(dr["APPLIEDVISADATE"]);
                            responsedatatype.AppliedVisaPlace = dr["APPLIEDVISAPLACE"].ToString().ToUpper();
                            responsedatatype.VisaOutCome = dr["VISAOUTCOME"].ToString().ToUpper();
                            responsedatatype.DeportedInd = dr["DEPORTEDIND"].ToString().ToUpper();

                            responsedatatype.DocIssPlace = dr["DOCISSPLACE"].ToString().ToUpper();

                            responsedatatype.EGContactName = dr["EGCONTACTNAME"].ToString().ToUpper();
                            responsedatatype.EGContactRelationship = dr["EGCONTACTRELATIONSHIP"].ToString().ToUpper();
                            responsedatatype.EGContactAddress = dr["EGCONTACTADDRESS"].ToString().ToUpper();
                            responsedatatype.EGContactPhone = dr["EGCONTACTPHONE"].ToString().ToUpper();

                            responsedatatype.ApprovedDocType = dr["ApprovedDocType"].ToString().ToUpper();
                            responsedatatype.ApprovedEntryType = dr["ApprovedEntryType"].ToString().ToUpper();

                            responsedatatype.TP_Name = dr["TP_Name"].ToString().ToUpper();
                            responsedatatype.TP_Phone = dr["TP_Phone"].ToString().ToUpper();
                            responsedatatype.TP_Remarks = dr["TP_Remarks"].ToString().ToUpper();
                            responsedatatype.TP_DocNo = dr["TP_DocNo"].ToString().ToUpper();


                            break;
                        }

                    }
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }

        public static ResponseDataTypeGetDetailsByPermission GetDetailsByPermission(RequestDataTypeGetDetailsByPermission requestdatatype)
        {
            ResponseDataTypeGetDetailsByPermission responsedatatype = new ResponseDataTypeGetDetailsByPermission();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] GetDetailsByPermission");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.8/9");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordDetailsByPermission_sps]");



            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordDetailsByPermission_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                //ylchin - Search By different criteria
                // 1 = Application ID
                // 2 = Passport No
                // 3 = Document No
                param = new SqlParameter("@in_SearchType", SqlDbType.VarChar, 1);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SearchType;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [SEARCH TYPE] " + requestdatatype.SearchType);
                }

                param = new SqlParameter("@in_ApplicationID", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ApplicationID;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APPLICATION ID] " + requestdatatype.ApplicationID);
                }

                param = new SqlParameter("@in_PassportNo", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportNo;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [PASSPORT NO] " + requestdatatype.PassportNo);
                }

                param = new SqlParameter("@in_PassportCOI", SqlDbType.VarChar, 3);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportCOI;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [PASSPORT COI] " + requestdatatype.PassportCOI);
                }

                param = new SqlParameter("@in_DocNo", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DocNo;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [DOC NUMBER] " + requestdatatype.DocNo);
                }

                param = new SqlParameter("@in_PermissionLevel", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PermissionLevel;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [Permission Level] " + requestdatatype.PermissionLevel);
                }


                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();


                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }

                if (responsedatatype.StatusCode == "0")
                {
                    foreach (DataRow dr in DS.Tables[0].Rows)
                    {
                        foreach (DataColumn dc in DS.Tables[0].Columns)
                        {
                            responsedatatype.ApplicationID = dr["FORMNO"].ToString().ToUpper();
                            responsedatatype.IDPerson = DataConvertor.ToInt32(dr["IDPERSON"]);
                            responsedatatype.AppReason = dr["APPREASON"].ToString().ToUpper();
                            responsedatatype.DocType = dr["DOCTYPE"].ToString().ToUpper();
                            responsedatatype.EntryType = dr["ENTRYTYPE"].ToString().ToUpper();
                            responsedatatype.Priority = DataConvertor.ToInt32(dr["PRIORITY"]);
                            responsedatatype.DocNo = dr["DOCNO"].ToString().ToUpper();
                            responsedatatype.DocExpiryDate = DataConvertor.ToDateTime(dr["DOCEXPIRYDATE"]);
                            responsedatatype.DocIssueDate = DataConvertor.ToDateTime(dr["DOCISSUEDATE"]);
                            responsedatatype.StageCode = dr["STAGECODE"].ToString().ToUpper();
                            responsedatatype.IssueBy = dr["ISSUEBY"].ToString().ToUpper();
                            responsedatatype.IssueTime = DataConvertor.ToDateTime(dr["ISSUETIME"]);
                            responsedatatype.IssueLocation = dr["ISSUELOCATION"].ToString().ToUpper();
                            responsedatatype.DataEntryBy = dr["DATAENTRYBY"].ToString().ToUpper();
                            responsedatatype.DataEntryTime = DataConvertor.ToDateTime(dr["DATAENTRYTIME"]);
                            responsedatatype.DataEntryLocation = dr["DATAENTRYLOCATION"].ToString().ToUpper();
                            responsedatatype.EnrolBy = dr["ENROLBY"].ToString().ToUpper();
                            responsedatatype.EnrolTime = DataConvertor.ToDateTime(dr["ENROLTIME"]);
                            responsedatatype.EnrolLocation = dr["ENROLLOCATION"].ToString().ToUpper();
                            responsedatatype.CollectionDate = DataConvertor.ToDateTime(dr["COLLECTIONDATE"]);
                            responsedatatype.BirthDate = DataConvertor.ToDateTime(dr["BIRTHDATE"]);
                            responsedatatype.BirthPlace = dr["BIRTHPLACE"].ToString().ToUpper();
                            responsedatatype.BirthCountry = dr["BIRTHCOUNTRY"].ToString().ToUpper();
                            responsedatatype.Nationality = dr["NATIONALITY"].ToString().ToUpper();
                            responsedatatype.FatherNationality = dr["FATHERNATIONALITY"].ToString().ToUpper();
                            responsedatatype.MotherNationality = dr["MOTHERNATIONALITY"].ToString().ToUpper();
                            responsedatatype.FatherResidentialStatus = dr["FATHERRESIDENTIALSTATUS"].ToString().ToUpper();
                            responsedatatype.MotherResidentialStatus = dr["MOTHERRESIDENTIALSTATUS"].ToString().ToUpper();
                            responsedatatype.SpouseResidentialStatus = dr["SPOUSERESIDENTIALSTATUS"].ToString().ToUpper();
                            responsedatatype.SiblingResidentialStatus = dr["SIBLINGRESIDENTIALSTATUS"].ToString().ToUpper();
                            responsedatatype.ChildrenResidentialStatus = dr["CHILDRENRESIDENTIALSTATUS"].ToString().ToUpper();
                            responsedatatype.Surname = dr["SURNAME"].ToString().ToUpper();
                            responsedatatype.FirstName = dr["FIRSTNAME"].ToString().ToUpper();
                            responsedatatype.MiddleName = dr["MIDDLENAME"].ToString().ToUpper();
                            responsedatatype.PassportNo = dr["PASSPORTNO"].ToString().ToUpper();
                            responsedatatype.PassportCOI = dr["PASSPORTCOI"].ToString().ToUpper();
                            responsedatatype.PassportPOI = dr["PASSPORTPOI"].ToString().ToUpper();
                            responsedatatype.PassportDOE = DataConvertor.ToDateTime(dr["PASSPORTDOE"]);
                            responsedatatype.PassportDOI = DataConvertor.ToDateTime(dr["PASSPORTDOI"]);
                            responsedatatype.Sex = dr["SEX"].ToString().ToUpper();
                            responsedatatype.Title = dr["TITLE"].ToString().ToUpper();
                            responsedatatype.MaritalStatus = dr["MARITALSTATUS"].ToString().ToUpper();
                            responsedatatype.NationalIDNo = dr["NATIONALIDNO"].ToString().ToUpper();

                            responsedatatype.FaceImage = DataConvertor.ToByteArray(dr["FACEIMAGE"]);
                            responsedatatype.FaceImageJ2K = DataConvertor.ToByteArray(dr["FACEIMAGEJ2K"]);
                            responsedatatype.FaceEntryTime = DataConvertor.ToDateTime(dr["FACEENTRYTIME"]);

                            responsedatatype.PresentAddress = dr["PRESENTADDRESS"].ToString().ToUpper();
                            responsedatatype.PermanentAddress = dr["PERMANENTADDRESS"].ToString().ToUpper();
                            responsedatatype.PhoneHome = dr["PHONEHOME"].ToString().ToUpper();
                            responsedatatype.PhoneWork = dr["PHONEWORK"].ToString().ToUpper();
                            responsedatatype.Mobile = dr["MOBILE"].ToString().ToUpper();
                            responsedatatype.Email = dr["EMAIL"].ToString().ToUpper();
                            responsedatatype.Fax = dr["FAX"].ToString().ToUpper();

                            responsedatatype.Occupation = dr["OCCUPATION"].ToString().ToUpper();
                            responsedatatype.EmployerName = dr["EMPLOYERNAME"].ToString().ToUpper();
                            responsedatatype.EmployerAddress = dr["EMPLOYERADDRESS"].ToString().ToUpper();
                            responsedatatype.EmployerPhone = dr["EMPLOYERPHONE"].ToString().ToUpper();
                            responsedatatype.YearsEmployed = dr["YEARSEMPLOYED"].ToString().ToUpper();

                            responsedatatype.FormerOccupation = dr["FORMEROCCUPATION"].ToString().ToUpper();
                            responsedatatype.FormerEmployerName = dr["FORMEREMPLOYERNAME"].ToString().ToUpper();
                            responsedatatype.FormerEmployerAddress = dr["FORMEREMPLOYERADDRESS"].ToString().ToUpper();
                            responsedatatype.FormerEmployerPhone = dr["FORMEREMPLOYERPHONE"].ToString().ToUpper();
                            responsedatatype.FormerYearsEmployed = dr["FORMERYEARSEMPLOYED"].ToString().ToUpper();

                            responsedatatype.FatherFirstName = dr["FATHERFIRSTNAME"].ToString().ToUpper();
                            responsedatatype.FatherMiddleName = dr["FATHERMiddleNAME"].ToString().ToUpper();
                            responsedatatype.FatherLastName = dr["FATHERLASTNAME"].ToString().ToUpper();
                            responsedatatype.MotherFirstName = dr["MOTHERFIRSTNAME"].ToString().ToUpper();
                            responsedatatype.MotherMiddleName = dr["MOTHERMiddleNAME"].ToString().ToUpper();
                            responsedatatype.MotherLastName = dr["MOTHERLASTNAME"].ToString().ToUpper();
                            responsedatatype.SpouseFirstName = dr["SPOUSEFIRSTNAME"].ToString().ToUpper();
                            responsedatatype.SpouseMiddleName = dr["SPOUSEMiddleNAME"].ToString().ToUpper();
                            responsedatatype.SpouseLastName = dr["SPOUSELASTNAME"].ToString().ToUpper();
                            responsedatatype.SpouseMaidenName = dr["SPOUSEMAIDENNAME"].ToString().ToUpper();
                            responsedatatype.SpouseDOB = DataConvertor.ToDateTime(dr["SPOUSEDOB"]);
                            responsedatatype.HasChildInd = dr["HASCHILDIND"].ToString().ToUpper();

                            responsedatatype.DependantName1 = dr["DEPENDANTNAME1"].ToString().ToUpper();
                            responsedatatype.Relationship1 = dr["RELATIONSHIP1"].ToString().ToUpper();
                            responsedatatype.DependantName2 = dr["DEPENDANTNAME2"].ToString().ToUpper();
                            responsedatatype.Relationship2 = dr["RELATIONSHIP2"].ToString().ToUpper();
                            responsedatatype.DependantName3 = dr["DEPENDANTNAME3"].ToString().ToUpper();
                            responsedatatype.Relationship3 = dr["RELATIONSHIP3"].ToString().ToUpper();
                            responsedatatype.DependantName4 = dr["DEPENDANTNAME4"].ToString().ToUpper();
                            responsedatatype.Relationship4 = dr["RELATIONSHIP4"].ToString().ToUpper();
                            responsedatatype.DependantName5 = dr["DEPENDANTNAME5"].ToString().ToUpper();
                            responsedatatype.Relationship5 = dr["RELATIONSHIP5"].ToString().ToUpper();

                            responsedatatype.TravelWithSpouseInd = dr["TRAVELWITHSPOUSEIND"].ToString().ToUpper();
                            responsedatatype.TravelWithDependantInd = dr["TRAVELWITHDEPENDANTIND"].ToString().ToUpper();

                            responsedatatype.VisitPurpose = dr["VISITPURPOSE"].ToString().ToUpper();
                            responsedatatype.OtherVisitPurpose = dr["OTHERVISITPURPOSE"].ToString().ToUpper();
                            responsedatatype.LengthOfStay = dr["LENGTHOFSTAY"].ToString().ToUpper();

                            responsedatatype.ArrivalDate = DataConvertor.ToDateTime(dr["ARRIVALDATE"]);

                            responsedatatype.HotelName = dr["HOTELNAME"].ToString().ToUpper();
                            responsedatatype.HotelAddress = dr["HOTELADDRESS"].ToString().ToUpper();
                            responsedatatype.HotelPhone = dr["HOTELPHONE"].ToString().ToUpper();

                            responsedatatype.TripSponsorBy = dr["TRIPSPONSORBY"].ToString().ToUpper();
                            responsedatatype.TripMoney = dr["TRIPMONEY"].ToString().ToUpper();

                            responsedatatype.CriminalConvictionInd = dr["CRIMINALCONVICTIONIND"].ToString().ToUpper();
                            responsedatatype.Offence1 = dr["OFFENCE1"].ToString().ToUpper();
                            responsedatatype.OffenceDate1 = DataConvertor.ToDateTime(dr["OFFENCEDATE1"].ToString());
                            responsedatatype.OffencePlace1 = dr["OFFENCEPLACE1"].ToString().ToUpper();
                            responsedatatype.OffencePenalty1 = dr["OFFENCEPENALTY1"].ToString().ToUpper();

                            responsedatatype.Offence2 = dr["OFFENCE2"].ToString().ToUpper();
                            responsedatatype.OffenceDate2 = DataConvertor.ToDateTime(dr["OFFENCEDATE2"].ToString());
                            responsedatatype.OffencePlace2 = dr["OFFENCEPLACE2"].ToString().ToUpper();
                            responsedatatype.OffencePenalty2 = dr["OFFENCEPENALTY2"].ToString().ToUpper();

                            responsedatatype.Offence3 = dr["OFFENCE3"].ToString().ToUpper();
                            responsedatatype.OffenceDate3 = DataConvertor.ToDateTime(dr["OFFENCEDATE3"].ToString());
                            responsedatatype.OffencePlace3 = dr["OFFENCEPLACE3"].ToString().ToUpper();
                            responsedatatype.OffencePenalty3 = dr["OFFENCEPENALTY3"].ToString().ToUpper();

                            responsedatatype.Offence4 = dr["OFFENCE4"].ToString().ToUpper();
                            responsedatatype.OffenceDate4 = DataConvertor.ToDateTime(dr["OFFENCEDATE4"].ToString());
                            responsedatatype.OffencePlace4 = dr["OFFENCEPLACE4"].ToString().ToUpper();
                            responsedatatype.OffencePenalty4 = dr["OFFENCEPENALTY4"].ToString().ToUpper();

                            responsedatatype.Offence5 = dr["OFFENCE5"].ToString().ToUpper();
                            responsedatatype.OffenceDate5 = DataConvertor.ToDateTime(dr["OFFENCEDATE5"].ToString());
                            responsedatatype.OffencePlace5 = dr["OFFENCEPLACE5"].ToString().ToUpper();
                            responsedatatype.OffencePenalty5 = dr["OFFENCEPENALTY5"].ToString().ToUpper();

                            responsedatatype.TerrorismInd = dr["TERRORISMIND"].ToString().ToUpper();
                            responsedatatype.TerrorismDesc = dr["TERRORISMDESC"].ToString().ToUpper();

                            responsedatatype.FatherInBHSInd = dr["FATHERINBHSIND"].ToString().ToUpper();
                            responsedatatype.MotherInBHSInd = dr["MOTHERINBHSIND"].ToString().ToUpper();
                            responsedatatype.SpouseInBHSInd = dr["SPOUSEINBHSIND"].ToString().ToUpper();
                            responsedatatype.SiblingInBHSInd = dr["SIBLINGINBHSIND"].ToString().ToUpper();
                            responsedatatype.ChildrenInBHSInd = dr["CHILDRENINBHSIND"].ToString().ToUpper();

                            responsedatatype.VisitedBhsInd = dr["VISITEDBHSIND"].ToString().ToUpper();
                            responsedatatype.LastVisitDate = DataConvertor.ToDateTime(dr["LASTVISITDATE"]);

                            responsedatatype.AppliedVisaInd = dr["APPLIEDVISAIND"].ToString().ToUpper();

                            responsedatatype.AppliedVisaDate = DataConvertor.ToDateTime(dr["APPLIEDVISADATE"]);
                            responsedatatype.AppliedVisaPlace = dr["APPLIEDVISAPLACE"].ToString().ToUpper();
                            responsedatatype.VisaOutCome = dr["VISAOUTCOME"].ToString().ToUpper();
                            responsedatatype.DeportedInd = dr["DEPORTEDIND"].ToString().ToUpper();

                            responsedatatype.DocIssPlace = dr["DOCISSPLACE"].ToString().ToUpper();

                            responsedatatype.EGContactName = dr["EGCONTACTNAME"].ToString().ToUpper();
                            responsedatatype.EGContactRelationship = dr["EGCONTACTRELATIONSHIP"].ToString().ToUpper();
                            responsedatatype.EGContactAddress = dr["EGCONTACTADDRESS"].ToString().ToUpper();
                            responsedatatype.EGContactPhone = dr["EGCONTACTPHONE"].ToString().ToUpper();

                            responsedatatype.ApprovedDocType = dr["ApprovedDocType"].ToString().ToUpper();
                            responsedatatype.ApprovedEntryType = dr["ApprovedEntryType"].ToString().ToUpper();

                            responsedatatype.TP_Name = dr["TP_Name"].ToString().ToUpper();
                            responsedatatype.TP_Phone = dr["TP_Phone"].ToString().ToUpper();
                            responsedatatype.TP_Remarks = dr["TP_Remarks"].ToString().ToUpper();
                            responsedatatype.TP_DocNo = dr["TP_DocNo"].ToString().ToUpper();


                            break;
                        }

                    }
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }


        public static ResponseDataTypeGetActiveDoc GetActiveDoc(RequestDataTypeGetActiveDoc requestdatatype)
        {
            ResponseDataTypeGetActiveDoc responsedatatype = new ResponseDataTypeGetActiveDoc();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] GetActiveDoc");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE] ");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordForActiveDoc_sps]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordForActiveDoc_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            try
            {
                connbhspis.Open();


                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@in_IDPerson", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.IDPerson;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@out_RecCount", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.ResultList = DS;

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();

                responsedatatype.RecCount = Convert.ToInt16(cmd.Parameters["@out_RecCount"].Value);

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }

        #region Query
        public static ResponseDataTypeQueryByBranch QueryByBranch(RequestDataTypeQueryByBranch requestdatatype)
        {
            ResponseDataTypeQueryByBranch responsedatatype = new ResponseDataTypeQueryByBranch();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] QueryByBranch");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.30");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordForQueryByBranch_sps]");

            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordForQueryByBranch_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.LocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_BranchCode", SqlDbType.VarChar, 5);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.BranchCode;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [BRANCHCODE] " + requestdatatype.BranchCode);
                }


                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.ResultList = DS;

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }

        public static ResponseDataTypeQueryByBranchWithPermission QueryByBranchWithPermission(RequestDataTypeQueryByBranchWithPermission requestdatatype)
        {
            ResponseDataTypeQueryByBranchWithPermission responsedatatype = new ResponseDataTypeQueryByBranchWithPermission();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] QueryByBranchWithPermission");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordForQueryByBranchWithPermission_sps]");

            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordForQueryByBranchWithPermission_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.LocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_BranchCode", SqlDbType.VarChar, 5);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.BranchCode;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [BRANCHCODE] " + requestdatatype.BranchCode);
                }

                param = new SqlParameter("@in_PermissionLevel", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PermissionLevel;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [Permission Level] " + requestdatatype.PermissionLevel);
                }

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.ResultList = DS;

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }

        public static ResponseDataTypeQueryByName QueryByName(RequestDataTypeQueryByName requestdatatype)
        {
            ResponseDataTypeQueryByName responsedatatype = new ResponseDataTypeQueryByName();

            CultureInfo MyCultureInfo = new CultureInfo("en-GB");

            DateTime dtResult = new DateTime();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] QueryByName");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.17");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordForQueryByName_sps]");

            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordForQueryByName_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.LocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Surname", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Surname;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [SURNAME] " + requestdatatype.Surname);
                }

                param = new SqlParameter("@in_FirstName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FirstName;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [FIRST NAME] " + requestdatatype.FirstName);
                }

                param = new SqlParameter("@in_MiddleName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MiddleName;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [MIDDLE NAME] " + requestdatatype.MiddleName);
                }

                param = new SqlParameter("@in_BirthDate", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.BirthDate, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [DOB] " + requestdatatype.BirthDate);
                }

                param = new SqlParameter("@in_BirthCountry", SqlDbType.VarChar, 3);
                param.Direction = ParameterDirection.Input;
                if (string.IsNullOrEmpty(requestdatatype.BirthCountry))
                    param.Value = DBNull.Value;
                else
                    param.Value = requestdatatype.BirthCountry;

                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [BIRTH COUNTRY] " + requestdatatype.BirthCountry);
                }

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.ResultList = DS;

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();



                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }

        public static ResponseDataTypeQueryByNameWithPermission QueryByNameWithPermission(RequestDataTypeQueryByNameWithPermission requestdatatype)
        {
            ResponseDataTypeQueryByNameWithPermission responsedatatype = new ResponseDataTypeQueryByNameWithPermission();

            CultureInfo MyCultureInfo = new CultureInfo("en-GB");

            DateTime dtResult = new DateTime();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] QueryByNameWithPermisssion");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordForQueryByNameWithPermisssion_sps]");

            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordForQueryByNameWithPermission_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.LocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Surname", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Surname;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [SURNAME] " + requestdatatype.Surname);
                }

                param = new SqlParameter("@in_FirstName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FirstName;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [FIRST NAME] " + requestdatatype.FirstName);
                }

                param = new SqlParameter("@in_MiddleName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MiddleName;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [MIDDLE NAME] " + requestdatatype.MiddleName);
                }

                param = new SqlParameter("@in_BirthDate", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.BirthDate, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [DOB] " + requestdatatype.BirthDate);
                }

                param = new SqlParameter("@in_BirthCountry", SqlDbType.VarChar, 3);
                param.Direction = ParameterDirection.Input;
                if (string.IsNullOrEmpty(requestdatatype.BirthCountry))
                    param.Value = DBNull.Value;
                else
                    param.Value = requestdatatype.BirthCountry;

                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [BIRTH COUNTRY] " + requestdatatype.BirthCountry);
                }

                param = new SqlParameter("@in_PermissionLevel", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PermissionLevel;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [Permission Level] " + requestdatatype.PermissionLevel);
                }

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.ResultList = DS;

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();



                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }

        public static ResponseDataTypeQueryByIDPerson QueryByIDPerson(RequestDataTypeQueryByIDPerson requestdatatype)
        {
            ResponseDataTypeQueryByIDPerson responsedatatype = new ResponseDataTypeQueryByIDPerson();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] QueryByIDPerson");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE] ");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordForQueryByIDPerson_sps]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordForQueryByIDPerson_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            try
            {
                connbhspis.Open();


                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@in_IDPerson", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.IDPerson;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();


                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }

                if (responsedatatype.StatusCode == "0")
                {
                    foreach (DataRow dr in DS.Tables[0].Rows)
                    {
                        foreach (DataColumn dc in DS.Tables[0].Columns)
                        {
                            responsedatatype.ApplicationID = dr["FORMNO"].ToString().ToUpper();
                            responsedatatype.IDPerson = DataConvertor.ToInt32(dr["IDPERSON"]);
                            responsedatatype.AppReason = dr["APPREASON"].ToString().ToUpper();
                            responsedatatype.DocType = dr["DOCTYPE"].ToString().ToUpper();
                            responsedatatype.Priority = DataConvertor.ToInt32(dr["PRIORITY"]);
                            responsedatatype.DocNo = dr["DOCNO"].ToString().ToUpper();
                            responsedatatype.DocExpiryDate = DataConvertor.ToDateTime(dr["DOCEXPIRYDATE"]);
                            responsedatatype.DocIssueDate = DataConvertor.ToDateTime(dr["DOCISSUEDATE"]);
                            responsedatatype.StageCode = dr["STAGECODE"].ToString().ToUpper();
                            responsedatatype.EnrolTime = DataConvertor.ToDateTime(dr["ENROLTIME"]);
                            responsedatatype.IssueBy = dr["ISSUEBY"].ToString().ToUpper();
                            responsedatatype.IssueTime = DataConvertor.ToDateTime(dr["ISSUETIME"]);
                            responsedatatype.CollectionDate = DataConvertor.ToDateTime(dr["COLLECTIONDATE"]);
                            responsedatatype.BirthDate = DataConvertor.ToDateTime(dr["BIRTHDATE"]);
                            responsedatatype.BirthPlace = dr["BIRTHPLACE"].ToString().ToUpper();
                            responsedatatype.BirthCountry = dr["BIRTHCOUNTRY"].ToString().ToUpper();
                            responsedatatype.Nationality = dr["NATIONALITY"].ToString().ToUpper();
                            responsedatatype.FatherNationality = dr["FATHERNATIONALITY"].ToString().ToUpper();
                            responsedatatype.MotherNationality = dr["MOTHERNATIONALITY"].ToString().ToUpper();
                            responsedatatype.FatherResidentialStatus = dr["FATHERRESIDENTIALSTATUS"].ToString().ToUpper();
                            responsedatatype.MotherResidentialStatus = dr["MOTHERRESIDENTIALSTATUS"].ToString().ToUpper();
                            responsedatatype.SpouseResidentialStatus = dr["SPOUSERESIDENTIALSTATUS"].ToString().ToUpper();
                            responsedatatype.SiblingResidentialStatus = dr["SIBLINGRESIDENTIALSTATUS"].ToString().ToUpper();
                            responsedatatype.ChildrenResidentialStatus = dr["CHILDRENRESIDENTIALSTATUS"].ToString().ToUpper();
                            responsedatatype.Surname = dr["SURNAME"].ToString().ToUpper();
                            responsedatatype.FirstName = dr["FIRSTNAME"].ToString().ToUpper();
                            responsedatatype.MiddleName = dr["MIDDLENAME"].ToString().ToUpper();
                            responsedatatype.PassportNo = dr["PASSPORTNO"].ToString().ToUpper();
                            responsedatatype.PassportCOI = dr["PASSPORTCOI"].ToString().ToUpper();
                            responsedatatype.PassportPOI = dr["PASSPORTPOI"].ToString().ToUpper();
                            responsedatatype.PassportDOE = DataConvertor.ToDateTime(dr["PASSPORTDOE"]);
                            responsedatatype.Sex = dr["SEX"].ToString().ToUpper();
                            responsedatatype.Title = dr["TITLE"].ToString().ToUpper();
                            responsedatatype.MaritalStatus = dr["MARITALSTATUS"].ToString().ToUpper();
                            responsedatatype.NationalIDNo = dr["NATIONALIDNO"].ToString().ToUpper();

                            responsedatatype.FaceImage = DataConvertor.ToByteArray(dr["FACEIMAGE"]);
                            responsedatatype.FaceImageJ2K = DataConvertor.ToByteArray(dr["FACEIMAGEJ2K"]);
                            responsedatatype.FaceEntryTime = DataConvertor.ToDateTime(dr["FACEENTRYTIME"]);

                            responsedatatype.PresentAddress = dr["PRESENTADDRESS"].ToString().ToUpper();
                            responsedatatype.PermanentAddress = dr["PERMANENTADDRESS"].ToString().ToUpper();
                            responsedatatype.PhoneHome = dr["PHONEHOME"].ToString().ToUpper();
                            responsedatatype.PhoneWork = dr["PHONEWORK"].ToString().ToUpper();
                            responsedatatype.Mobile = dr["MOBILE"].ToString().ToUpper();
                            responsedatatype.Email = dr["EMAIL"].ToString().ToUpper();
                            responsedatatype.Fax = dr["FAX"].ToString().ToUpper();

                            responsedatatype.Occupation = dr["OCCUPATION"].ToString().ToUpper();
                            responsedatatype.EmployerName = dr["EMPLOYERNAME"].ToString().ToUpper();
                            responsedatatype.EmployerAddress = dr["EMPLOYERADDRESS"].ToString().ToUpper();
                            responsedatatype.EmployerPhone = dr["EMPLOYERPHONE"].ToString().ToUpper();
                            responsedatatype.YearsEmployed = dr["YEARSEMPLOYED"].ToString().ToUpper();

                            responsedatatype.FormerOccupation = dr["FORMEROCCUPATION"].ToString().ToUpper();
                            responsedatatype.FormerEmployerName = dr["FORMEREMPLOYERNAME"].ToString().ToUpper();
                            responsedatatype.FormerEmployerAddress = dr["FORMEREMPLOYERADDRESS"].ToString().ToUpper();
                            responsedatatype.FormerEmployerPhone = dr["FORMEREMPLOYERPHONE"].ToString().ToUpper();
                            responsedatatype.FormerYearsEmployed = dr["FORMERYEARSEMPLOYED"].ToString().ToUpper();

                            responsedatatype.FatherFirstName = dr["FATHERFIRSTNAME"].ToString().ToUpper();
                            responsedatatype.FatherMiddleName = dr["FATHERMiddleNAME"].ToString().ToUpper();
                            responsedatatype.FatherLastName = dr["FATHERLASTNAME"].ToString().ToUpper();
                            responsedatatype.MotherFirstName = dr["MOTHERFIRSTNAME"].ToString().ToUpper();
                            responsedatatype.MotherMiddleName = dr["MOTHERMiddleNAME"].ToString().ToUpper();
                            responsedatatype.MotherLastName = dr["MOTHERLASTNAME"].ToString().ToUpper();
                            responsedatatype.SpouseFirstName = dr["SPOUSEFIRSTNAME"].ToString().ToUpper();
                            responsedatatype.SpouseMiddleName = dr["SPOUSEMiddleNAME"].ToString().ToUpper();
                            responsedatatype.SpouseLastName = dr["SPOUSELASTNAME"].ToString().ToUpper();
                            responsedatatype.SpouseDOB = DataConvertor.ToDateTime(dr["SPOUSEDOB"]);
                            responsedatatype.HasChildInd = dr["HASCHILDIND"].ToString().ToUpper();

                            responsedatatype.DependantName1 = dr["DEPENDANTNAME1"].ToString().ToUpper();
                            responsedatatype.Relationship1 = dr["RELATIONSHIP1"].ToString().ToUpper();
                            responsedatatype.DependantName2 = dr["DEPENDANTNAME2"].ToString().ToUpper();
                            responsedatatype.Relationship2 = dr["RELATIONSHIP2"].ToString().ToUpper();
                            responsedatatype.DependantName3 = dr["DEPENDANTNAME3"].ToString().ToUpper();
                            responsedatatype.Relationship3 = dr["RELATIONSHIP3"].ToString().ToUpper();
                            responsedatatype.DependantName4 = dr["DEPENDANTNAME4"].ToString().ToUpper();
                            responsedatatype.Relationship4 = dr["RELATIONSHIP4"].ToString().ToUpper();
                            responsedatatype.DependantName5 = dr["DEPENDANTNAME5"].ToString().ToUpper();
                            responsedatatype.Relationship5 = dr["RELATIONSHIP5"].ToString().ToUpper();

                            responsedatatype.TravelWithSpouseInd = dr["TRAVELWITHSPOUSEIND"].ToString().ToUpper();
                            responsedatatype.TravelWithDependantInd = dr["TRAVELWITHDEPENDANTIND"].ToString().ToUpper();

                            responsedatatype.VisitPurpose = dr["VISITPURPOSE"].ToString().ToUpper();
                            responsedatatype.OtherVisitPurpose = dr["OTHERVISITPURPOSE"].ToString().ToUpper();
                            responsedatatype.LengthOfStay = dr["LENGTHOFSTAY"].ToString().ToUpper();

                            responsedatatype.ArrivalDate = DataConvertor.ToDateTime(dr["ARRIVALDATE"]);

                            responsedatatype.HotelName = dr["HOTELNAME"].ToString().ToUpper();
                            responsedatatype.HotelAddress = dr["HOTELADDRESS"].ToString().ToUpper();
                            responsedatatype.HotelPhone = dr["HOTELPHONE"].ToString().ToUpper();

                            responsedatatype.TripSponsorBy = dr["TRIPSPONSORBY"].ToString().ToUpper();
                            responsedatatype.TripMoney = dr["TRIPMONEY"].ToString().ToUpper();

                            responsedatatype.CriminalConvictionInd = dr["CRIMINALCONVICTIONIND"].ToString().ToUpper();
                            responsedatatype.Offence1 = dr["OFFENCE1"].ToString().ToUpper();
                            responsedatatype.OffenceDate1 = DataConvertor.ToDateTime(dr["OFFENCEDATE1"].ToString());
                            responsedatatype.OffencePlace1 = dr["OFFENCEPLACE1"].ToString().ToUpper();
                            responsedatatype.OffencePenalty1 = dr["OFFENCEPENALTY1"].ToString().ToUpper();

                            responsedatatype.Offence2 = dr["OFFENCE2"].ToString().ToUpper();
                            responsedatatype.OffenceDate2 = DataConvertor.ToDateTime(dr["OFFENCEDATE2"].ToString());
                            responsedatatype.OffencePlace2 = dr["OFFENCEPLACE2"].ToString().ToUpper();
                            responsedatatype.OffencePenalty2 = dr["OFFENCEPENALTY2"].ToString().ToUpper();

                            responsedatatype.Offence3 = dr["OFFENCE3"].ToString().ToUpper();
                            responsedatatype.OffenceDate3 = DataConvertor.ToDateTime(dr["OFFENCEDATE3"].ToString());
                            responsedatatype.OffencePlace3 = dr["OFFENCEPLACE3"].ToString().ToUpper();
                            responsedatatype.OffencePenalty3 = dr["OFFENCEPENALTY3"].ToString().ToUpper();

                            responsedatatype.Offence4 = dr["OFFENCE4"].ToString().ToUpper();
                            responsedatatype.OffenceDate4 = DataConvertor.ToDateTime(dr["OFFENCEDATE4"].ToString());
                            responsedatatype.OffencePlace4 = dr["OFFENCEPLACE4"].ToString().ToUpper();
                            responsedatatype.OffencePenalty4 = dr["OFFENCEPENALTY4"].ToString().ToUpper();

                            responsedatatype.Offence5 = dr["OFFENCE5"].ToString().ToUpper();
                            responsedatatype.OffenceDate5 = DataConvertor.ToDateTime(dr["OFFENCEDATE5"].ToString());
                            responsedatatype.OffencePlace5 = dr["OFFENCEPLACE5"].ToString().ToUpper();
                            responsedatatype.OffencePenalty5 = dr["OFFENCEPENALTY5"].ToString().ToUpper();

                            responsedatatype.TerrorismInd = dr["TERRORISMIND"].ToString().ToUpper();
                            responsedatatype.TerrorismDesc = dr["TERRORISMDESC"].ToString().ToUpper();

                            responsedatatype.FatherInBHSInd = dr["FATHERINBHSIND"].ToString().ToUpper();
                            responsedatatype.MotherInBHSInd = dr["MOTHERINBHSIND"].ToString().ToUpper();
                            responsedatatype.SpouseInBHSInd = dr["SPOUSEINBHSIND"].ToString().ToUpper();
                            responsedatatype.SiblingInBHSInd = dr["SIBLINGINBHSIND"].ToString().ToUpper();
                            responsedatatype.ChildrenInBHSInd = dr["CHILDRENINBHSIND"].ToString().ToUpper();

                            responsedatatype.VisitedBhsInd = dr["VISITEDBHSIND"].ToString().ToUpper();
                            responsedatatype.LastVisitDate = DataConvertor.ToDateTime(dr["LASTVISITDATE"]);

                            responsedatatype.AppliedVisaInd = dr["APPLIEDVISAIND"].ToString().ToUpper();

                            responsedatatype.AppliedVisaDate = DataConvertor.ToDateTime(dr["APPLIEDVISADATE"]);
                            responsedatatype.AppliedVisaPlace = dr["APPLIEDVISAPLACE"].ToString().ToUpper();
                            responsedatatype.VisaOutCome = dr["VISAOUTCOME"].ToString().ToUpper();
                            responsedatatype.DeportedInd = dr["DEPORTEDIND"].ToString().ToUpper();

                            responsedatatype.DocIssPlace = dr["DOCISSPLACE"].ToString().ToUpper();

                            responsedatatype.EGContactName = dr["EGCONTACTNAME"].ToString().ToUpper();
                            responsedatatype.EGContactRelationship = dr["EGCONTACTRELATIONSHIP"].ToString().ToUpper();
                            responsedatatype.EGContactAddress = dr["EGCONTACTADDRESS"].ToString().ToUpper();
                            responsedatatype.EGContactPhone = dr["EGCONTACTPHONE"].ToString().ToUpper();

                            break;
                        }
                    }
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }

        public static ResponseDataTypeQueryByPassport QueryByPassport(RequestDataTypeQueryByPassport requestdatatype)
        {
            ResponseDataTypeQueryByPassport responsedatatype = new ResponseDataTypeQueryByPassport();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] QueryByFileNo");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.38");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordForQueryByPassport_sps]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordForQueryByPassport_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.LocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportNo", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportNo;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [PASSPORTNO] " + requestdatatype.PassportNo);
                }

                param = new SqlParameter("@in_PassportCOI", SqlDbType.VarChar, 3);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportCOI;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [PASSPORTCOI] " + requestdatatype.PassportCOI);
                }

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();


                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();



                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }

                //if (responsedatatype.StatusCode == "0")
                //{
                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.ResultList = DS;

                //}
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }

        #endregion

        #region Approval
        public static ResponseDataTypeApproval Approve(RequestDataTypeApproval requestdatatype)
        {
            ResponseDataTypeApproval responsedatatype = new ResponseDataTypeApproval();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Approve Application");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.6");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordApprove_spi]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordApprove_spi]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ApplicationID", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ApplicationID;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APPLICATION ID] " + requestdatatype.ApplicationID);
                }

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ApprovalLevel", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ApprovalLevel;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APPROVAL LEVEL] " + requestdatatype.ApprovalLevel);
                }

                param = new SqlParameter("@in_RejectReason", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.RejectReason;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_InterviewNote", SqlDbType.VarChar, 1024);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.InterviewNote;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Remark", SqlDbType.VarChar, 1024);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Remark;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Annotation", SqlDbType.VarChar, 1024);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Annotation;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ValidWeek", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ValidWeek;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ValidMonth", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ValidMonth;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ValidYear", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ValidYear;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_DocType", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DocType;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_VisaClass1", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.VisaClass1;
                if (param.Value == null)
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_VisaClass2", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.VisaClass2;
                if (param.Value == null)
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_VisaClass3", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.VisaClass3;
                if (param.Value == null)
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_VisaClass4", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.VisaClass4;
                if (param.Value == null)
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_VisaClass5", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.VisaClass5;
                if (param.Value == null)
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EntryType", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EntryType;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_StageCode", SqlDbType.VarChar, 6);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.StageCode;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [STAGE CODE] " + requestdatatype.StageCode);
                }

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();


                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();


                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }
        public static ResponseDataTypeSelectApprovalHistory SelectApprovalHistory(RequestDataTypeSelectApprovalHistory requestdatatype)
        {
            ResponseDataTypeSelectApprovalHistory responsedatatype = new ResponseDataTypeSelectApprovalHistory();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] SelectApprovalHistory");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.7");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordApprove_sps]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordApprove_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ApplicationID", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ApplicationID;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APPLICATION ID] " + requestdatatype.ApplicationID);
                }

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.ResultList = DS;

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }
        public static ResponseDataTypeSelectApproval01List SelectApproval01List(RequestdataTypeSelectApproval01List requestdatatype)
        {
            ResponseDataTypeSelectApproval01List responsedatatype = new ResponseDataTypeSelectApproval01List();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Approval01List");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.8");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordForApproval01_sps]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordForApproval01_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.ResultList = DS;

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();



                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }
        public static ResponseDataTypeSelectApproval02List SelectApproval02List(RequestdataTypeSelectApproval02List requestdatatype)
        {
            ResponseDataTypeSelectApproval02List responsedatatype = new ResponseDataTypeSelectApproval02List();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Approval02List");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.9");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordForApproval02_sps]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordForApproval02_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.ResultList = DS;
                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }
        #endregion

        #region Enrollment
        public static ResponseDataTypePartialEnrol PartialEnrol(RequestDataTypePartialEnrol requestdatatype)
        {
            CultureInfo MyCultureInfo = new CultureInfo("en-GB");

            DateTime dtResult = new DateTime();

            ResponseDataTypePartialEnrol responsedatatype = new ResponseDataTypePartialEnrol();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] PartialEnrol");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.2");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordPartial_spi]");

            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("RecordPartial_spi", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;

            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ApplicationID", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ApplicationID;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APPLICATION ID] " + requestdatatype.ApplicationID);
                }

                param = new SqlParameter("@in_IDPerson", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.IDPerson;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [ID PERSON] " + requestdatatype.IDPerson);
                }

                param = new SqlParameter("@in_AppReason", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = DataConvertor.ToInt32(requestdatatype.AppReason);
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APP REASON] " + requestdatatype.AppReason);
                }

                param = new SqlParameter("@in_DocType", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DocType;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [DOC TYPE] " + requestdatatype.DocType);
                }

                param = new SqlParameter("@in_EntryType", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EntryType;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [ENTRY TYPE] " + requestdatatype.EntryType);
                }

                param = new SqlParameter("@in_EnrolBy", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolBy;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Priority", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = DataConvertor.ToInt32(requestdatatype.Priority);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_SurName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Surname;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FirstName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FirstName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_MiddleName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MiddleName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_BirthCountry", SqlDbType.VarChar, 3);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.BirthCountry;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_BirthPlace", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.BirthPlace;
                if (requestdatatype.BirthPlace.Length == 0)
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_BirthDate", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.BirthDate, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);


                param = new SqlParameter("@in_Nationality", SqlDbType.VarChar, 3);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Nationality;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportNo", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportNo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportDOI", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.PassportDOI, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportCOI", SqlDbType.VarChar, 3);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportCOI;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportPOI", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportPOI;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportDOE", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.PassportDOE, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Sex ", SqlDbType.VarChar, 1);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Sex;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Title", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Title;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_NationalIDNo", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                if (requestdatatype.NationalIDNo.Length == 0)
                    param.Value = DBNull.Value;
                else
                    param.Value = requestdatatype.NationalIDNo;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@in_CollectionDate", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.CollectionDate, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }
        public static ResponseDataTypePartialEnrol UpdateProfileEnrol(RequestDataTypePartialEnrol requestdatatype)
        {
            CultureInfo MyCultureInfo = new CultureInfo("en-GB");

            DateTime dtResult = new DateTime();

            ResponseDataTypePartialEnrol responsedatatype = new ResponseDataTypePartialEnrol();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] PartialEnrol");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.31");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordPartial_spu]");

            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("RecordPartial_spu", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;

            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ApplicationID", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ApplicationID;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APPLICATION ID] " + requestdatatype.ApplicationID);
                }

                param = new SqlParameter("@in_IDPerson", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.IDPerson;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [ID PERSON] " + requestdatatype.IDPerson);
                }

                param = new SqlParameter("@in_AppReason", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = DataConvertor.ToInt32(requestdatatype.AppReason);
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APP REASON] " + requestdatatype.AppReason);
                }

                param = new SqlParameter("@in_DocType", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DocType;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [DOC TYPE] " + requestdatatype.DocType);
                }

                param = new SqlParameter("@in_EntryType", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EntryType;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [ENTRY TYPE] " + requestdatatype.EntryType);
                }

                param = new SqlParameter("@in_EnrolBy", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolBy;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Priority", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = DataConvertor.ToInt32(requestdatatype.Priority);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_SurName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Surname;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FirstName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FirstName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_MiddleName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MiddleName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_BirthCountry", SqlDbType.VarChar, 25);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.BirthCountry;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_BirthPlace", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.BirthPlace;
                if (requestdatatype.BirthPlace.Length == 0)
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_BirthDate", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.BirthDate, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Nationality", SqlDbType.VarChar, 3);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Nationality;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportNo", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportNo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportDOI", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.PassportDOI, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportCOI", SqlDbType.VarChar, 3);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportCOI;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportPOI", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportPOI;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportDOE", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.PassportDOE, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Sex ", SqlDbType.VarChar, 1);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Sex;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Title", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Title;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_NationalIDNo", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                if (requestdatatype.NationalIDNo.Length == 0)
                    param.Value = DBNull.Value;
                else
                    param.Value = requestdatatype.NationalIDNo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_CollectionDate", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.CollectionDate, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }
        public static ResponseDataTypeSelectReprintColSlip SelectReprintColSlipList(RequestDataTypeSelectReprintColSlip requestdatatype)
        {
            ResponseDataTypeSelectReprintColSlip responsedatatype = new ResponseDataTypeSelectReprintColSlip();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] SelectReprintColSlipList");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.21");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordForReprintColSlip_sps]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordForReprintColSlip_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();



                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.ResultList = DS;

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();


                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }
        #endregion

        #region Data Entry
        public static ResponseDataTypeDataEntry CompleteEnrol(RequestDataTypeDataEntry requestdatatype)
        {
            CultureInfo MyCultureInfo = new CultureInfo("en-GB");

            DateTime dtResult = new DateTime();

            ResponseDataTypeDataEntry responsedatatype = new ResponseDataTypeDataEntry();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] CompleteEnrol");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.3");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordComplete_spi]");

            }

            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordComplete_spi]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ApplicationID", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ApplicationID;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APPLICATION ID] " + requestdatatype.ApplicationID);
                }

                param = new SqlParameter("@in_AppReason", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = DataConvertor.ToInt32(requestdatatype.AppReason);
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APP REASON] " + requestdatatype.AppReason);
                }

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_DocType", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DocType;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolCompletedBy", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolCompletedBy;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Priority", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = DataConvertor.ToInt32(requestdatatype.Priority);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_SurName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Surname;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FirstName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FirstName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_MiddleName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MiddleName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_BirthCountry", SqlDbType.VarChar, 25);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.BirthCountry;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_BirthPlace", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.BirthPlace;
                if (requestdatatype.BirthPlace.Length == 0)
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_BirthDate", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.BirthDate, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);


                param = new SqlParameter("@in_Nationality", SqlDbType.VarChar, 3);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Nationality;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportNo", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportNo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportDOI", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.PassportDOI, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportCOI", SqlDbType.VarChar, 3);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportCOI;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportPOI", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportPOI;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportDOE", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.PassportDOE, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_MaritalStatus", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MaritalStatus;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Sex", SqlDbType.VarChar, 1);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Sex;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Title", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Title;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_NationalIDNo", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                if (requestdatatype.NationalIDNo.Length == 0)
                    param.Value = DBNull.Value;
                else
                    param.Value = requestdatatype.NationalIDNo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FaceImage", SqlDbType.Image);
                param.Direction = ParameterDirection.Input;
                param.Value = DataConvertor.ToByteArray(requestdatatype.FaceImage);
                if (param.Value == null)
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FaceImageJ2K", SqlDbType.Image);
                param.Direction = ParameterDirection.Input;
                param.Value = DataConvertor.ToByteArray(requestdatatype.FaceImageJ2K);
                if (param.Value == null)
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PresentAddress", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PresentAddress;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PermanentAddress", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PermanentAddress;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PhoneHome", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PhoneHome;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PhoneWork", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PhoneWork;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Mobile", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Mobile;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Email", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Email;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Fax", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Fax;
                cmd.Parameters.Add(param);

                #region Employment Details
                param = new SqlParameter("@in_Occupation", SqlDbType.VarChar, 25);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Occupation;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EmployerName", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EmployerName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EmployerAddress", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EmployerAddress;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EmployerPhone", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EmployerPhone;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_YearsEmployed", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.YearsEmployed;
                cmd.Parameters.Add(param);
                #endregion

                #region Former Employment Details
                param = new SqlParameter("@in_FormerOccupation", SqlDbType.VarChar, 25);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FormerOccupation;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FormerEmployerName", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FormerEmployerName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FormerEmployerAddress", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FormerEmployerAddress;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FormerEmployerPhone", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FormerEmployerPhone;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FormerYearsEmployed", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FormerYearsEmployed;
                cmd.Parameters.Add(param);
                #endregion

                #region Father details
                param = new SqlParameter("@in_FatherFirstName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FatherFirstName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FatherMiddleName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FatherMiddleName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FatherLastName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FatherLastName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FatherNationality", SqlDbType.VarChar, 25);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FatherNationality;
                cmd.Parameters.Add(param);
                #endregion

                #region Mother Details
                param = new SqlParameter("@in_MotherFirstName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MotherFirstName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_MotherMiddleName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MotherMiddleName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_MotherLastName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MotherLastName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_MotherNationality", SqlDbType.VarChar, 25);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MotherNationality;
                cmd.Parameters.Add(param);
                #endregion

                #region Spouse Details
                param = new SqlParameter("@in_SpouseFirstName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SpouseFirstName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_SpouseMiddleName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SpouseMiddleName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_SpouseLastName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SpouseLastName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_SpouseMaidenName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SpouseMaidenName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_SpouseDOB", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.SpouseDOB, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                #endregion

                param = new SqlParameter("@in_HasChildInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.HasChildInd;
                cmd.Parameters.Add(param);

                #region Dependant Details
                param = new SqlParameter("@in_DependantName1", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DependantName1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Relationship1", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Relationship1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_DependantName2", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DependantName2;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Relationship2", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Relationship2;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_DependantName3", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DependantName3;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Relationship3", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Relationship3;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_DependantName4", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DependantName4;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Relationship4", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Relationship4;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_DependantName5", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DependantName5;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Relationship5", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Relationship5;
                cmd.Parameters.Add(param);
                #endregion

                param = new SqlParameter("@in_TravelWithSpouseInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.TravelWithSpouseInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_TravelWithDependantInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.TravelWithDependantInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_VisitPurpose", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.VisitPurpose;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OtherVisitPurpose", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OtherVisitPurpose;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_LengthOfStay", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.LengthOfStay;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ArrivalDate", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.ArrivalDate, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                #region Hotel Details
                param = new SqlParameter("@in_HotelName", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.HotelName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_HotelAddress", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.HotelAddress;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_HotelPhone", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.HotelPhone;
                cmd.Parameters.Add(param);

                #endregion

                param = new SqlParameter("@in_TripSponsorBy", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.TripSponsorBy;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_TripMoney", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.TripMoney;
                cmd.Parameters.Add(param);

                #region Criminal Details
                param = new SqlParameter("@in_CriminalConvictionInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.CriminalConvictionInd;
                cmd.Parameters.Add(param);

                #region
                param = new SqlParameter("@in_Offence1", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Offence1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffenceDate1", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.OffenceDate1, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePlace1", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePlace1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePenalty1", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePenalty1;
                cmd.Parameters.Add(param);
                #endregion

                #region
                param = new SqlParameter("@in_Offence2", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Offence2;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffenceDate2", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.OffenceDate2, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePlace2", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePlace2;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePenalty2", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePenalty2;
                cmd.Parameters.Add(param);
                #endregion

                #region
                param = new SqlParameter("@in_Offence3", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Offence3;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffenceDate3", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.OffenceDate3, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePlace3", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePlace3;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePenalty3", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePenalty3;
                cmd.Parameters.Add(param);
                #endregion

                #region
                param = new SqlParameter("@in_Offence4", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Offence4;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffenceDate4", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.OffenceDate4, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePlace4", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePlace4;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePenalty4", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePenalty4;
                cmd.Parameters.Add(param);
                #endregion

                #region
                param = new SqlParameter("@in_Offence5", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Offence5;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffenceDate5", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.OffenceDate5, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePlace5", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePlace5;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePenalty5", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePenalty5;
                cmd.Parameters.Add(param);
                #endregion
                #endregion

                param = new SqlParameter("@in_TerrorismInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.TerrorismInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_TerrorismDesc", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.TerrorismDesc;
                cmd.Parameters.Add(param);

                #region
                param = new SqlParameter("@in_FatherInBhsInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FatherInBhsInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FatherResidentialStatus", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FatherResidentialStatus;
                cmd.Parameters.Add(param);
                #endregion

                #region
                param = new SqlParameter("@in_MotherInBhsInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MotherInBhsInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_MotherResidentialStatus", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MotherResidentialStatus;
                cmd.Parameters.Add(param);
                #endregion
                #region
                param = new SqlParameter("@in_SpouseInBhsInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SpouseInBhsInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_SpouseResidentialStatus", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SpouseResidentialStatus;
                cmd.Parameters.Add(param);
                #endregion

                #region
                param = new SqlParameter("@in_SiblingInBhsInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SiblingInBhsInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_SiblingResidentialStatus", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SiblingResidentialStatus;
                cmd.Parameters.Add(param);
                #endregion

                #region
                param = new SqlParameter("@in_ChildrenInBhsInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ChildrenInBhsInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ChildrenResidentialStatus", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ChildrenResidentialStatus;
                cmd.Parameters.Add(param);
                #endregion

                param = new SqlParameter("@in_VisitedBhsInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.VisitedBhsInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_LastVisitDate", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.LastVisitDate, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_AppliedVisaInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.AppliedVisaInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_AppliedVisaDate", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.AppliedVisaDate, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_AppliedVisaPlace", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.AppliedVisaPlace;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_VisaOutcome", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.VisaOutcome;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_DeportedInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DeportedInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EGContactName", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EGContactName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EGContactRelationship", SqlDbType.VarChar, 25);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EGContactRelationship;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EGContactAddress", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EGContactAddress;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EGContactPhone", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EGContactPhone;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();


                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }

            }
            return responsedatatype;

        }
        public static ResponseDataTypeDataEntry UpdateProfileDataEntry(RequestDataTypeDataEntry requestdatatype)
        {
            CultureInfo MyCultureInfo = new CultureInfo("en-GB");

            DateTime dtResult = new DateTime();

            ResponseDataTypeDataEntry responsedatatype = new ResponseDataTypeDataEntry();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] CompleteEnrol");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.32");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordComplete_spu]");

            }

            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordComplete_spu]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ApplicationID", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ApplicationID;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APPLICATION ID] " + requestdatatype.ApplicationID);
                }

                param = new SqlParameter("@in_AppReason", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = DataConvertor.ToInt32(requestdatatype.AppReason);
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APP REASON] " + requestdatatype.AppReason);
                }

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_DocType", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DocType;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolCompletedBy", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolCompletedBy;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Priority", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = DataConvertor.ToInt32(requestdatatype.Priority);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_SurName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Surname;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FirstName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FirstName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_MiddleName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MiddleName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_BirthCountry", SqlDbType.VarChar, 25);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.BirthCountry;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_BirthPlace", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.BirthPlace;
                if (requestdatatype.BirthPlace.Length == 0)
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_BirthDate", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.BirthDate, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);


                param = new SqlParameter("@in_Nationality", SqlDbType.VarChar, 3);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Nationality;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportNo", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportNo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportDOI", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.PassportDOI, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportCOI", SqlDbType.VarChar, 3);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportCOI;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportPOI", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportPOI;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportDOE", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.PassportDOE, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_MaritalStatus", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MaritalStatus;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Sex ", SqlDbType.VarChar, 1);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Sex;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Title", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Title;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_NationalIDNo", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                if (requestdatatype.NationalIDNo.Length == 0)
                    param.Value = DBNull.Value;
                else
                    param.Value = requestdatatype.NationalIDNo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FaceImage", SqlDbType.Image);
                param.Direction = ParameterDirection.Input;
                param.Value = DataConvertor.ToByteArray(requestdatatype.FaceImage);
                if (param.Value == null)
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FaceImageJ2K", SqlDbType.Image);
                param.Direction = ParameterDirection.Input;
                param.Value = DataConvertor.ToByteArray(requestdatatype.FaceImageJ2K);
                if (param.Value == null)
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PresentAddress", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PresentAddress;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PermanentAddress", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PermanentAddress;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PhoneHome", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PhoneHome;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PhoneWork", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PhoneWork;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Mobile", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Mobile;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Email", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Email;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Fax", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Fax;
                cmd.Parameters.Add(param);

                #region Employment Details
                param = new SqlParameter("@in_Occupation", SqlDbType.VarChar, 25);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Occupation;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EmployerName", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EmployerName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EmployerAddress", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EmployerAddress;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EmployerPhone", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EmployerPhone;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_YearsEmployed", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.YearsEmployed;
                cmd.Parameters.Add(param);
                #endregion

                #region Former Employment Details
                param = new SqlParameter("@in_FormerOccupation", SqlDbType.VarChar, 25);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FormerOccupation;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FormerEmployerName", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FormerEmployerName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FormerEmployerAddress", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FormerEmployerAddress;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FormerEmployerPhone", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FormerEmployerPhone;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FormerYearsEmployed", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FormerYearsEmployed;
                cmd.Parameters.Add(param);
                #endregion

                #region Father details
                param = new SqlParameter("@in_FatherFirstName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FatherFirstName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FatherMiddleName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FatherMiddleName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FatherLastName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FatherLastName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FatherNationality", SqlDbType.VarChar, 25);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FatherNationality;
                cmd.Parameters.Add(param);
                #endregion

                #region Mother Details
                param = new SqlParameter("@in_MotherFirstName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MotherFirstName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_MotherMiddleName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MotherMiddleName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_MotherLastName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MotherLastName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_MotherNationality", SqlDbType.VarChar, 25);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MotherNationality;
                cmd.Parameters.Add(param);
                #endregion

                #region Spouse Details
                param = new SqlParameter("@in_SpouseFirstName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SpouseFirstName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_SpouseMiddleName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SpouseMiddleName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_SpouseLastName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SpouseLastName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_SpouseMaidenName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SpouseMaidenName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_SpouseDOB", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.SpouseDOB, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                #endregion

                param = new SqlParameter("@in_HasChildInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.HasChildInd;
                cmd.Parameters.Add(param);

                #region Dependant Details
                param = new SqlParameter("@in_DependantName1", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DependantName1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Relationship1", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Relationship1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_DependantName2", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DependantName2;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Relationship2", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Relationship2;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_DependantName3", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DependantName3;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Relationship3", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Relationship3;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_DependantName4", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DependantName4;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Relationship4", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Relationship4;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_DependantName5", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DependantName5;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Relationship5", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Relationship5;
                cmd.Parameters.Add(param);
                #endregion

                param = new SqlParameter("@in_TravelWithSpouseInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.TravelWithSpouseInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_TravelWithDependantInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.TravelWithDependantInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_VisitPurpose", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.VisitPurpose;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OtherVisitPurpose", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OtherVisitPurpose;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_LengthOfStay", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.LengthOfStay;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ArrivalDate", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.ArrivalDate, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                #region Hotel Details
                param = new SqlParameter("@in_HotelName", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.HotelName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_HotelAddress", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.HotelAddress;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_HotelPhone", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.HotelPhone;
                cmd.Parameters.Add(param);

                #endregion

                param = new SqlParameter("@in_TripSponsorBy", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.TripSponsorBy;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_TripMoney", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.TripMoney;
                cmd.Parameters.Add(param);

                #region Criminal Details
                param = new SqlParameter("@in_CriminalConvictionInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.CriminalConvictionInd;
                cmd.Parameters.Add(param);

                #region
                param = new SqlParameter("@in_Offence1", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Offence1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffenceDate1", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.OffenceDate1, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePlace1", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePlace1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePenalty1", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePenalty1;
                cmd.Parameters.Add(param);
                #endregion

                #region
                param = new SqlParameter("@in_Offence2", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Offence2;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffenceDate2", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.OffenceDate2, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePlace2", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePlace2;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePenalty2", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePenalty2;
                cmd.Parameters.Add(param);
                #endregion

                #region
                param = new SqlParameter("@in_Offence3", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Offence3;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffenceDate3", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.OffenceDate3, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePlace3", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePlace3;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePenalty3", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePenalty3;
                cmd.Parameters.Add(param);
                #endregion

                #region
                param = new SqlParameter("@in_Offence4", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Offence4;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffenceDate4", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.OffenceDate4, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePlace4", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePlace4;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePenalty4", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePenalty4;
                cmd.Parameters.Add(param);
                #endregion

                #region
                param = new SqlParameter("@in_Offence5", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Offence5;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffenceDate5", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.OffenceDate5, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePlace5", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePlace5;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OffencePenalty5", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OffencePenalty5;
                cmd.Parameters.Add(param);
                #endregion
                #endregion

                param = new SqlParameter("@in_TerrorismInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.TerrorismInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_TerrorismDesc", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.TerrorismDesc;
                cmd.Parameters.Add(param);

                #region
                param = new SqlParameter("@in_FatherInBhsInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FatherInBhsInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FatherResidentialStatus", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FatherResidentialStatus;
                cmd.Parameters.Add(param);
                #endregion

                #region
                param = new SqlParameter("@in_MotherInBhsInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MotherInBhsInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_MotherResidentialStatus", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MotherResidentialStatus;
                cmd.Parameters.Add(param);
                #endregion
                #region
                param = new SqlParameter("@in_SpouseInBhsInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SpouseInBhsInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_SpouseResidentialStatus", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SpouseResidentialStatus;
                cmd.Parameters.Add(param);
                #endregion

                #region
                param = new SqlParameter("@in_SiblingInBhsInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SiblingInBhsInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_SiblingResidentialStatus", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SiblingResidentialStatus;
                cmd.Parameters.Add(param);
                #endregion

                #region
                param = new SqlParameter("@in_ChildrenInBhsInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ChildrenInBhsInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ChildrenResidentialStatus", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ChildrenResidentialStatus;
                cmd.Parameters.Add(param);
                #endregion

                param = new SqlParameter("@in_VisitedBhsInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.VisitedBhsInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_LastVisitDate", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.LastVisitDate, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_AppliedVisaInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.AppliedVisaInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_AppliedVisaDate", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.AppliedVisaDate, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_AppliedVisaPlace", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.AppliedVisaPlace;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_VisaOutcome", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.VisaOutcome;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_DeportedInd", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DeportedInd;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EGContactName", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EGContactName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EGContactRelationship", SqlDbType.VarChar, 25);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EGContactRelationship;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EGContactAddress", SqlDbType.VarChar, 200);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EGContactAddress;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EGContactPhone", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EGContactPhone;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();


                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();


                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }

            }
            return responsedatatype;

        }
        public static ResponseDataTypeSelectDataEntryList SelectDataEntryList(RequestDataTypeSelectDataEntryList requestdatatype)
        {
            ResponseDataTypeSelectDataEntryList responsedatatype = new ResponseDataTypeSelectDataEntryList();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] SelectDataEntryList");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.16");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordForDataEntry_sps]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordForDataEntry_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.ResultList = DS;

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }
        #endregion

        #region Payment
        public static ResponseDataTypeUpdatePayment UpdatePayment(RequestDataTypeUpdatePayment requestdatatype)
        {
            ResponseDataTypeUpdatePayment responsedatatype = new ResponseDataTypeUpdatePayment();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] UpdatePayment");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.5");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [PaymentHistory_spi]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[PaymentHistory_spi]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();



                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ApplicationID", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ApplicationID;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APPLICATION ID] " + requestdatatype.ApplicationID);
                }

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PaymentMethod", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PaymentMethod;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PaymentAmt", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PaymentAmt;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ReceiptNo", SqlDbType.VarChar, 15);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ReceiptNo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_CardNo", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.CardNo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PaymentRemark", SqlDbType.VarChar, 1024);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PaymentRemark;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_OtherPaymentMethod", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.OtherPaymentMethod;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FeeType", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FeeType;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_AmountChangedBy", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.AmountChangedBy;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@out_ResultStageCode", SqlDbType.VarChar, 6);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();


                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();
                responsedatatype.ResultStageCode = cmd.Parameters["@out_ResultStageCode"].Value.ToString();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }
        public static ResponseDataTypeSelectPaymentHistory GetPaymentHistory(RequestDataTypeSelectPaymentHistory requestdatatype)
        {
            ResponseDataTypeSelectPaymentHistory responsedatatype = new ResponseDataTypeSelectPaymentHistory();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] GetPaymentHistory");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [PaymentHistory_sps]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[PaymentHistory_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ApplicationID", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ApplicationID;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APPLICATION ID] " + requestdatatype.ApplicationID);
                }

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.ResultList = DS;

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();


                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }

            }

            return responsedatatype;

        }
        #endregion

        #region Issuance
        public static ResponseDataTypeIssuance Issue(RequestDataTypeIssuance requestdatatype)
        {
            ResponseDataTypeIssuance responsedatatype = new ResponseDataTypeIssuance();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Issue");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.12");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordIssue_spi]");
            }

            SqlConnection connbhswpis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordIssue_spi]", connbhswpis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            try
            {
                connbhswpis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ApplicationID", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ApplicationID;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APPLICATION ID] " + requestdatatype.ApplicationID);
                }

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_StageCode", SqlDbType.VarChar, 6);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.StageCode;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_RejectedBy", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.RejectedBy;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_RejectReason", SqlDbType.VarChar, 6);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.RejectReason;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Remark", SqlDbType.VarChar, 1024);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Remark;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_IsCert", SqlDbType.Char, 1);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.IsCert;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();


                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();


                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhswpis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }
        public static ResponseDataTypeThirdPartyIssuance ThirdPartyIssue(RequestDataTypeThirdPartyIssuance requestdatatype)
        {
            ResponseDataTypeThirdPartyIssuance responsedatatype = new ResponseDataTypeThirdPartyIssuance();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] ThirdPartyIssue");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.13");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordThirdPartyIssue_spi]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordThirdPartyIssue_spi]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ApplicationID", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ApplicationID;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APPLICATION ID] " + requestdatatype.ApplicationID);
                }

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_StageCode", SqlDbType.VarChar, 6);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.StageCode;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_TP_Name", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.TP_Name;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_TP_Phone", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.TP_Phone;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_TP_Remarks", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.TP_Remarks;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_TP_DocNo", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.TP_DocNo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();


                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();


                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }

            }

            return responsedatatype;

        }
        public static ResponseDataTypeSelectIssuanceList SelectIssuanceList(RequestdataTypeSelectIssuanceList requestdatatype)
        {
            ResponseDataTypeSelectIssuanceList responsedatatype = new ResponseDataTypeSelectIssuanceList();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] IssuanceList");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.11");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordForIssuance_sps]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[RecordForIssuance_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.ResultList = DS;
                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }
        #endregion

        #region Scanned Document
        public static ResponseDataTypeInsertScannedDoc EnrolScannedDoc(RequestDataTypeInsertScannedDoc requestdatatype)
        {

            ResponseDataTypeInsertScannedDoc responsedatatype = new ResponseDataTypeInsertScannedDoc();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] EnrolScannedDoc");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.106.1");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [ScannedDoc_spi]");

            }

            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[ScannedDoc_spi]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ApplicationID", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ApplicationID;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APPLICATION ID] " + requestdatatype.ApplicationID);
                }

                param = new SqlParameter("@in_ScannedImage", SqlDbType.Image);
                param.Direction = ParameterDirection.Input;
                param.Value = DataConvertor.ToByteArray(requestdatatype.ScannedImage);
                if (param.Value == null)
                    param.Value = DBNull.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ScannedDoc", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ScannedDoc;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PageNo", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PageNo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ImageDesc", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ImageDesc;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();


                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }


            }
            return responsedatatype;

        }
        public static ResponseDataTypeDeleteScannedDoc DeleteScannedDoc(RequestDataTypeDeleteScannedDoc requestdatatype)
        {
            ResponseDataTypeDeleteScannedDoc responsedatatype = new ResponseDataTypeDeleteScannedDoc();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] DeleteScannedDoc");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.106.4");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [ScannedDoc_spd]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[ScannedDoc_spd]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();



                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ImageID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ImageID;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [IMAGE ID] " + requestdatatype.ImageID);
                }

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();


                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();


                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }

            }

            return responsedatatype;

        }
        public static ResponseDataTypeSelectScannedDoc GetScannedDoc(RequestDataTypeSelectScannedDoc requestdatatype)
        {
            ResponseDataTypeSelectScannedDoc responsedatatype = new ResponseDataTypeSelectScannedDoc();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] GetScannedDoc");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.106.2");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [ScannedDoc_sps]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[ScannedDoc_sps]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.LocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ApplicationID", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ApplicationID;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APPLICATION ID] " + requestdatatype.ApplicationID);
                }

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.ResultList = DS;

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }
        public static ResponseDataTypeSelectScannedDoc GetScannedDocByImageID(RequestDataTypeSelectScannedDoc requestdatatype)
        {
            ResponseDataTypeSelectScannedDoc responsedatatype = new ResponseDataTypeSelectScannedDoc();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] GetScannedDoc");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.106.5");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [ScannedDoc_sps_ByImageID]");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[ScannedDoc_sps_ByImageID]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.LocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ImageID;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [IMAGW ID] " + requestdatatype.ImageID);
                }

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();
                responsedatatype.ResultList = DS;


                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }
        #endregion

        public static ResponseDataTypeDeleteJob DeleteJob(RequestDataTypeDeleteJob requestdatatype)
        {
            CultureInfo MyCultureInfo = new CultureInfo("en-GB");

            DateTime dtResult = new DateTime();

            ResponseDataTypeDeleteJob responsedatatype = new ResponseDataTypeDeleteJob();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] PartialEnrol");
                Logger.WriteTrace("[TRACE] [PERMMISION CODE]  12.23.39");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [RecordDeleteJob_spd]");

            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("RecordDeleteJob_spd", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;

            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ApplicationID", SqlDbType.VarChar, 12);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ApplicationID;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APPLICATION ID] " + requestdatatype.ApplicationID);
                }

                param = new SqlParameter("@in_IDPerson", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.IDPerson;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [ID PERSON] " + requestdatatype.IDPerson);
                }

                param = new SqlParameter("@in_AppReason", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = DataConvertor.ToInt32(requestdatatype.AppReason);
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [APP REASON] " + requestdatatype.AppReason);
                }

                param = new SqlParameter("@in_DocType", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DocType;
                cmd.Parameters.Add(param);
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [DOC TYPE] " + requestdatatype.DocType);
                }

                param = new SqlParameter("@in_EntryType", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EntryType;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_DeleteBy", SqlDbType.VarChar, 20);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DeleteBy;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_SurName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Surname;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_FirstName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.FirstName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_MiddleName", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.MiddleName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Nationality", SqlDbType.VarChar, 3);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Nationality;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_BirthCountry", SqlDbType.VarChar, 3);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.BirthCountry;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_StageCode", SqlDbType.VarChar, 6);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.StageCode;
                cmd.Parameters.Add(param);


                param = new SqlParameter("@in_BirthDate", SqlDbType.DateTime);
                param.Direction = ParameterDirection.Input;
                if (DateTime.TryParseExact(requestdatatype.BirthDate, "ddMMyyyy", MyCultureInfo, DateTimeStyles.None, out dtResult))
                { param.Value = dtResult; }
                else
                { param.Value = DBNull.Value; }
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportNo", SqlDbType.VarChar, 30);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportNo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PassportCOI", SqlDbType.VarChar, 3);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PassportCOI;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Remarks", SqlDbType.VarChar, 300);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Remarks;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@exception", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();



                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();



                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] Status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] [" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }
    }
}

