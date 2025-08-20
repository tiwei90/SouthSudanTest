using DocumentAndLookupManagement.Common;
using DocumentAndLookupManagement.DataType;
using DocumentAndLookupManagement.Properties;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DocumentAndLookupManagement
{
    public class DALMController
    {
        public static ResponseDataTypeSelectAppReason SelectLookupAppReasonList(RequestDataTypeSelectAppReason requestdatatype)
        {
            ResponseDataTypeSelectAppReason responsedatatype = new ResponseDataTypeSelectAppReason();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Application Reason List");
            }

            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[LookupAppReason_sps_All]", connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
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
                    Logger.WriteTrace("[TRACE] SelectAppReason status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] SelectAppReason status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;
        }

        public static ResponseDataTypeIUD IUDLookupAppReason(RequestDataTypeIUDAppReason requestdatatype, char option)
        {
            ResponseDataTypeIUD responsedatatype = new ResponseDataTypeIUD();

            if (Settings.Default._debugmode == 1)
            {
                if (option == 'I')
                {
                    Logger.WriteTrace("[TRACE] Insert Application Reason");
                }
                else if (option == 'U')
                {
                    Logger.WriteTrace("[TRACE] Update Application Reason");
                }
                else if (option == 'D')
                {
                    Logger.WriteTrace("[TRACE] Delete Application Reason");
                }
            }

            string StoredProc = string.Empty;

            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);

            if (option == 'I')
            {
                StoredProc = "[LookupAppReason_spi]";
            }
            else if (option == 'U')
            {
                StoredProc = "[LookupAppReason_spu]";
            }
            else if (option == 'D')
            {
                StoredProc = "[LookupAppReason_spd]";
            }

            SqlCommand cmd = new SqlCommand(StoredProc, connbhsvis);
            
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_AppReason", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.AppReason;
                cmd.Parameters.Add(param);

                if (option != 'D')
                {
                    param = new SqlParameter("@in_Description", SqlDbType.VarChar, 1024);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.Desc;
                    cmd.Parameters.Add(param);
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
                    if (option == 'I')
                    {
                        Logger.WriteTrace("[TRACE] InsertAppReason status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] InsertAppReason status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'U')
                    {
                        Logger.WriteTrace("[TRACE] UpdateAppReason status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] UpdateAppReason status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'D')
                    {
                        Logger.WriteTrace("[TRACE] DeleteAppReason status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] DeleteAppReason status Message : " + responsedatatype.StatusMessage);
                    }
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;
        }

        public static ResponseDataTypeSelectDocType SelectLookupDocTypeList(RequestDataTypeSelectDocType requestdatatype)
        {
            ResponseDataTypeSelectDocType responsedatatype = new ResponseDataTypeSelectDocType();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Document Type List");
            }

            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[LookupDocType_sps_All]", connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
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
                    Logger.WriteTrace("[TRACE] SelectDocType status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] SelectDocType status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }
            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;
        }

        public static ResponseDataTypeIUD IUDLookupDocType(RequestDataTypeIUDLookupDocType requestdatatype, char option)
        {
            ResponseDataTypeIUD responsedatatype = new ResponseDataTypeIUD();

            if (Settings.Default._debugmode == 1)
            {
                if (option == 'I')
                {
                    Logger.WriteTrace("[TRACE] Insert Doc type");
                }
                else if (option == 'U')
                {
                    Logger.WriteTrace("[TRACE] Update Doc type");
                }
                else if (option == 'D')
                {
                    Logger.WriteTrace("[TRACE] Delete Doc type");
                }
            }

            string StoredProc = string.Empty;

            if (option == 'I')
            {
                StoredProc = "[LookupDocType_spi]";
            }
            else if (option == 'U')
            {
                StoredProc = "[LookupDocType_spu]";
            }
            else if (option == 'D')
            {
                StoredProc = "[LookupDocType_spd]";
            }

            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand(StoredProc, connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_DocType", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DocType;
                cmd.Parameters.Add(param);

                if (option != 'D')
                {
                    param = new SqlParameter("@in_Description", SqlDbType.VarChar, 1024);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.Desc;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_LayoutID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.LayoutID;
                    cmd.Parameters.Add(param);
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
                    if (option == 'I')
                    {
                        Logger.WriteTrace("[TRACE] InsertDocType status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] InsertDocType status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'U')
                    {
                        Logger.WriteTrace("[TRACE] UpdateDocType status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] UpdateDocType status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'D')
                    {
                        Logger.WriteTrace("[TRACE] DeleteDocType status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] DeleteDocType status Message : " + responsedatatype.StatusMessage);
                    }
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }
            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;
        }

        public static ResponseDataTypeSelectPaymentMethod SelectLookupPaymentMethodList(RequestDataTypeSelectPaymentMethod requestdatatype)
        {
            ResponseDataTypeSelectPaymentMethod responsedatatype = new ResponseDataTypeSelectPaymentMethod();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Payment Method List");
            }

            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[LookupPaymentMethod_sps_All]", connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
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
                    Logger.WriteTrace("[TRACE] SelectPaymentMethod status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] SelectPaymentMethod status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }
            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;
        }

        public static ResponseDataTypeIUD IUDLookupPaymentMethod(RequestDataTypeIUDPaymentMethod requestdatatype, char option)
        {
            ResponseDataTypeIUD responsedatatype = new ResponseDataTypeIUD();

            if (Settings.Default._debugmode == 1)
            {
                if (option == 'I')
                    Logger.WriteTrace("[TRACE] Insert Payment Method");
                else if (option == 'U')
                    Logger.WriteTrace("[TRACE] Update Payment Method");
                else if (option == 'D')
                    Logger.WriteTrace("[TRACE] Delete Payment Method");
            }

            string StoredProc = string.Empty;

            if (option == 'I')
                StoredProc = "[LookupPaymentMethod_spi]";
            else if (option == 'U')
                StoredProc = "[LookupPaymentMethod_spu]";
            else if (option == 'D')
                StoredProc = "[LookupPaymentMethod_spd]";

            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand(StoredProc, connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_PaymentMethod", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PaymentMethod;
                cmd.Parameters.Add(param);

                if (option != 'D')
                {
                    param = new SqlParameter("@in_Description", SqlDbType.VarChar, 1024);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.Desc;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_ID", SqlDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.ID;
                    cmd.Parameters.Add(param);

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
                    if (option == 'I')
                    {
                        Logger.WriteTrace("[TRACE] InsertPaymentMethod status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] InsertPaymentMethod status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'U')
                    {
                        Logger.WriteTrace("[TRACE] UpdatePaymentMethod status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] UpdatePaymentMethod status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'D')
                    {
                        Logger.WriteTrace("[TRACE] DeletePaymentMethod status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] DeletePaymentMethod status Message : " + responsedatatype.StatusMessage);
                    }
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }

        public static ResponseDataTypeSelectScannedDoc SelectLookupScannedDocList(RequestDataTypeSelectScannedDoc requestdatatype)
        {
            ResponseDataTypeSelectScannedDoc responsedatatype = new ResponseDataTypeSelectScannedDoc();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Scanned Document List");
            }
            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[LookupScannedDoc_sps_All]", connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
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
                    Logger.WriteTrace("[TRACE] SelectScannedDoc status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] SelectScannedDoc status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }
        public static ResponseDataTypeIUD IUDLookupScannedDoc(RequestDataTypeIUDScannedDoc requestdatatype, char option)
        {
            ResponseDataTypeIUD responsedatatype = new ResponseDataTypeIUD();

            if (Settings.Default._debugmode == 1)
            {
                if (option == 'I')
                    Logger.WriteTrace("[TRACE] Insert Scanned Doc");
                else if (option == 'U')
                    Logger.WriteTrace("[TRACE] Update Scanned Doc");
                else if (option == 'D')
                    Logger.WriteTrace("[TRACE] Delete Scanned Doc");
            }
            string StoredProc = string.Empty;

            if (option == 'I')
                StoredProc = "[LookupScannedDoc_spi]";
            else if (option == 'U')
                StoredProc = "[LookupScannedDoc_spu]";
            else if (option == 'D')
                StoredProc = "[LookupScannedDoc_spd]";

            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand(StoredProc, connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ScannedDoc", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ScannedDoc;
                cmd.Parameters.Add(param);

                if (option != 'D')
                {
                    param = new SqlParameter("@in_Description", SqlDbType.VarChar, 1024);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.Desc;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_ID", SqlDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.ID;
                    cmd.Parameters.Add(param);

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
                    if (option == 'I')
                    {
                        Logger.WriteTrace("[TRACE] InsertScannedDoc status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] InsertScannedDoc status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'U')
                    {
                        Logger.WriteTrace("[TRACE] UpdateScannedDoc status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] UpdateScannedDoc status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'D')
                    {
                        Logger.WriteTrace("[TRACE] DeleteScannedDoc status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] DeleteScannedDoc status Message : " + responsedatatype.StatusMessage);
                    }
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }

        public static ResponseDataTypeSelectFees SelectLookupFeesList(RequestDataTypeSelectFees requestdatatype)
        {
            ResponseDataTypeSelectFees responsedatatype = new ResponseDataTypeSelectFees();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Fees List");
            }
            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[LookupFees_sps_All]", connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
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
                    Logger.WriteTrace("[TRACE] SelectFees status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] SelectFees status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }
        public static ResponseDataTypeSelectFees SelectLookupFee(RequestDataTypeSelectFees requestdatatype)
        {
            ResponseDataTypeSelectFees responsedatatype = new ResponseDataTypeSelectFees();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Fees List");
            }
            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[LookupFees_sps]", connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EntryType", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EntryType;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@out_Fee", SqlDbType.Int);
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

                responsedatatype.Fee = cmd.Parameters["@out_Fee"].Value.ToString();

                responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] SelectFees status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] SelectFees status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }
        public static ResponseDataTypeIUD IUDLookupFees(RequestDataTypeIUDLookupFees requestdatatype, char option)
        {
            ResponseDataTypeIUD responsedatatype = new ResponseDataTypeIUD();

            if (Settings.Default._debugmode == 1)
            {
                if (option == 'I')
                    Logger.WriteTrace("[TRACE] Insert Fees");
                else if (option == 'U')
                    Logger.WriteTrace("[TRACE] Update Fees");
                else if (option == 'D')
                    Logger.WriteTrace("[TRACE] Delete Fees");

            }
            string StoredProc = string.Empty;

            if (option == 'I')
                StoredProc = "[LookupFees_spi]";
            else if (option == 'U')
                StoredProc = "[LookupFees_spu]";
            else if (option == 'D')
                StoredProc = "[LookupFees_spd]";

            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand(StoredProc, connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                if (option == 'I')
                {
                    param = new SqlParameter("@in_EntryType", SqlDbType.VarChar, 2);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.EntryType;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_Fee", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.Fee;
                    cmd.Parameters.Add(param);
                }
                else if (option == 'D')
                {
                    param = new SqlParameter("@in_ID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.ID;
                    cmd.Parameters.Add(param);
                }
                else if (option == 'U')
                {
                    param = new SqlParameter("@in_ID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.ID;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_Fee", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.Fee;
                    cmd.Parameters.Add(param);
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
                    if (option == 'I')
                    {
                        Logger.WriteTrace("[TRACE] InsertFees status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] InsertFees status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'U')
                    {
                        Logger.WriteTrace("[TRACE] UpdateFees status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] UpdateFees status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'D')
                    {
                        Logger.WriteTrace("[TRACE] DeleteFees status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] DeleteFees status Message : " + responsedatatype.StatusMessage);
                    }
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }

        public static ResponseDataTypeSelectRejectReason SelectLookupRejectReasonList(RequestDataTypeSelectRejectReason requestdatatype)
        {
            ResponseDataTypeSelectRejectReason responsedatatype = new ResponseDataTypeSelectRejectReason();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Reject Reason List");
            }
            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[LookupRejectReason_sps_All]", connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
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
                    Logger.WriteTrace("[TRACE] SelectRejectReason status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] SelectRejectReason status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }
        public static ResponseDataTypeIUD IUDLookupRejectReason(RequestDataTypeIUDRejectReason requestdatatype, char option)
        {
            ResponseDataTypeIUD responsedatatype = new ResponseDataTypeIUD();

            if (Settings.Default._debugmode == 1)
            {
                if (option == 'I')
                    Logger.WriteTrace("[TRACE] Insert Reject Reason");
                else if (option == 'U')
                    Logger.WriteTrace("[TRACE] Update Reject Reason");
                else if (option == 'D')
                    Logger.WriteTrace("[TRACE] Delete Reject Reason");
            }
            string StoredProc = string.Empty;

            if (option == 'I')
                StoredProc = "[LookupRejectReason_spi]";
            else if (option == 'U')
                StoredProc = "[LookupRejectReason_spu]";
            else if (option == 'D')
                StoredProc = "[LookupRejectReason_spd]";

            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand(StoredProc, connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_RejectReasonCode", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.RejectReasonCode;
                cmd.Parameters.Add(param);

                if (option != 'D')
                {
                    param = new SqlParameter("@in_Description", SqlDbType.VarChar, 1024);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.Desc;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_ID", SqlDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.ID;
                    cmd.Parameters.Add(param);

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
                    if (option == 'I')
                    {
                        Logger.WriteTrace("[TRACE] InsertRejectReason status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] InsertRejectReason status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'U')
                    {
                        Logger.WriteTrace("[TRACE] UpdateRejectReason status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] UpdateRejectReason status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'D')
                    {
                        Logger.WriteTrace("[TRACE] DeleteRejectReason status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] DeleteRejectReason status Message : " + responsedatatype.StatusMessage);
                    }
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }

        public static ResponseDataTypeSelectLayoutID SelectLayoutIDList(RequestDataTypeSelectLayoutID requestdatatype)
        {
            ResponseDataTypeSelectLayoutID responsedatatype = new ResponseDataTypeSelectLayoutID();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Layout ID List");
            }
            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[Layout_sps_SelectAll]", connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statuscode", SqlDbType.VarChar, 16);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@statusmessage", SqlDbType.VarChar, 1152);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                DataSet DS = new DataSet();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(DS);

                responsedatatype.ResultList = DS; responsedatatype.StatusCode = cmd.Parameters["@statuscode"].Value.ToString();
                responsedatatype.StatusMessage = cmd.Parameters["@statusmessage"].Value.ToString();

                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE] SelectLayoutID status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] SelectLayoutID status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }

        public static ResponseDataTypeSelectPoliceStation SelectPoliceStationList(RequestDataTypeSelectPoliceStation requestdatatype)
        {
            ResponseDataTypeSelectPoliceStation responsedatatype = new ResponseDataTypeSelectPoliceStation();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Police Station List");
            }
            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[LookupPoliceStation_sps_All]", connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_SessionKey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
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
                    Logger.WriteTrace("[TRACE] SelectPoliceStation status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] SelectPoliceStation status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }
        public static ResponseDataTypeIUD IUDLookupPoliceStation(RequestDataTypeIUDPoliceStation requestdatatype, char option)
        {
            ResponseDataTypeIUD responsedatatype = new ResponseDataTypeIUD();

            if (Settings.Default._debugmode == 1)
            {
                if (option == 'I')
                    Logger.WriteTrace("[TRACE] Insert Police Station");
                else if (option == 'U')
                    Logger.WriteTrace("[TRACE] Update Police Station");
                else if (option == 'D')
                    Logger.WriteTrace("[TRACE] Delete Police Station");
            }
            string StoredProc = string.Empty;

            if (option == 'I')
                StoredProc = "[LookupPoliceStation_spi]";
            else if (option == 'U')
                StoredProc = "[LookupPoliceStation_spu]";
            else if (option == 'D')
                StoredProc = "[LookupPoliceStation_spd]";

            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand(StoredProc, connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_StationCode", SqlDbType.VarChar, 8);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.StationCode;
                cmd.Parameters.Add(param);

                if (option != 'D')
                {
                    param = new SqlParameter("@in_StationName", SqlDbType.VarChar, 50);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.StationName;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_StateCode", SqlDbType.VarChar, 3);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.StateCode;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_ID", SqlDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.ID;
                    cmd.Parameters.Add(param);

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
                    if (option == 'I')
                    {
                        Logger.WriteTrace("[TRACE] InsertPoliceStation status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] InsertPoliceStation status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'U')
                    {
                        Logger.WriteTrace("[TRACE] UpdatePoliceStation status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] UpdatePoliceStation status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'D')
                    {
                        Logger.WriteTrace("[TRACE] DeletePoliceStation status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] DeletePoliceStation status Message : " + responsedatatype.StatusMessage);
                    }
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }

        #region Branch
        public static ResponseDataTypeSelectBranch SelectBranchList(RequestDataTypeSelectBranch requestdatatype)
        {
            ResponseDataTypeSelectBranch responsedatatype = new ResponseDataTypeSelectBranch();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] GetBranchList");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [Branch_sps]");
            }
            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[Branch_sps_All]", connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
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
                connbhsvis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }

        public static ResponseDataTypeSelectAll SelectBranch(RequestDataTypeSelectAll requestdatatype)
        {
            ResponseDataTypeSelectAll responsedatatype = new ResponseDataTypeSelectAll();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Branch List");
            }
            SqlConnection connbhswpis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[Branch_sps]", connbhswpis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhswpis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
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
                    Logger.WriteTrace("[TRACE] Select Branch status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Select Branch status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhswpis.Close();
            }

            return responsedatatype;

        }
        public static ResponseDataTypeIUD IUDBranch(RequestDataTypeIUDBranch requestdatatype, char option)
        {
            ResponseDataTypeIUD responsedatatype = new ResponseDataTypeIUD();

            if (Settings.Default._debugmode == 1)
            {
                if (option == 'I')
                    Logger.WriteTrace("[TRACE] Insert Branch");
                else if (option == 'U')
                    Logger.WriteTrace("[TRACE] Update Branch");
                else if (option == 'D')
                    Logger.WriteTrace("[TRACE] Delete Branch");
            }
            string StoredProc = string.Empty;

            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            if (option == 'I')
                StoredProc = "[Branch_spi]";
            else if (option == 'U')
                StoredProc = "[Branch_spu]";
            else if (option == 'D')
                StoredProc = "[Branch_spd]";

            SqlCommand cmd = new SqlCommand(StoredProc, connbhspis);

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

                if (option == 'D')
                {
                    param = new SqlParameter("@in_BranchCode", SqlDbType.VarChar, 5);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.BranchCode;
                    cmd.Parameters.Add(param);
                }


                if (option == 'I')
                {
                    param = new SqlParameter("@in_StateCode", SqlDbType.VarChar, 3);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.StateCode;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_BranchCode", SqlDbType.VarChar, 5);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.BranchCode;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_BranchName", SqlDbType.VarChar, 50);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.BranchName;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_ProcessDays", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.ProcessDays;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_CountryCode", SqlDbType.VarChar, 3);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.CountryCode;
                    cmd.Parameters.Add(param);
                }

                if (option == 'U')
                {
                    param = new SqlParameter("@in_BranchCode", SqlDbType.VarChar, 5);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.BranchCode;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_BranchName", SqlDbType.VarChar, 50);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.BranchName;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_ProcessDays", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.ProcessDays;
                    cmd.Parameters.Add(param);
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
                    if (option == 'I')
                    {
                        Logger.WriteTrace("[TRACE] InsertBranch status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] InsertBranch status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'U')
                    {
                        Logger.WriteTrace("[TRACE] UpdateBranch status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] UpdateBranch status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'D')
                    {
                        Logger.WriteTrace("[TRACE] DeleteBranch status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] DeleteBranch status Message : " + responsedatatype.StatusMessage);
                    }
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
            }

            return responsedatatype;

        }

        #endregion

        public static ResponseDataTypeSelectIssRejectReason SelectIssRejectReason(RequestDataTypeSelectIssRejectReason requestdatatype)
        {
            ResponseDataTypeSelectIssRejectReason responsedatatype = new ResponseDataTypeSelectIssRejectReason();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Issuance Reject Reason");
                Logger.WriteTrace("[TRACE] Invoke DB Stored Procedure [LookupIssRejectReason_sps_All]");
            }
            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[LookupIssRejectReason_sps_All]", connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
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
                connbhsvis.Close();
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("*****************************************************************");
                }
            }

            return responsedatatype;

        }
        public static ResponseDataTypeIUD IUDLookupIssRejectReason(RequestDataTypeIUDIssRejectReason requestdatatype, char option)
        {
            ResponseDataTypeIUD responsedatatype = new ResponseDataTypeIUD();

            if (Settings.Default._debugmode == 1)
            {
                if (option == 'I')
                    Logger.WriteTrace("[TRACE] Insert Issuance Reject Reason");
                else if (option == 'U')
                    Logger.WriteTrace("[TRACE] Update Issuance Reject Reason");
                else if (option == 'D')
                    Logger.WriteTrace("[TRACE] Delete Issuance Reject Reason");
            }
            string StoredProc = string.Empty;

            if (option == 'I')
                StoredProc = "[LookupIssRejectReason_spi]";
            else if (option == 'U')
                StoredProc = "[LookupIssRejectReason_spu]";
            else if (option == 'D')
                StoredProc = "[LookupIssRejectReason_spd]";

            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand(StoredProc, connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_RejectCode", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.RejectCode;
                cmd.Parameters.Add(param);

                if (option != 'D')
                {
                    param = new SqlParameter("@in_Description", SqlDbType.VarChar, 1024);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.Desc;
                    cmd.Parameters.Add(param);
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
                    if (option == 'I')
                    {
                        Logger.WriteTrace("[TRACE] InsertIssRejectCode status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] InsertIssRejectCode status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'U')
                    {
                        Logger.WriteTrace("[TRACE] UpdateIssRejectCode status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] UpdateIssRejectCode status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'D')
                    {
                        Logger.WriteTrace("[TRACE] DeleteIssRejectCode status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] DeleteIssRejectCode status Message : " + responsedatatype.StatusMessage);
                    }
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }

        public static ResponseDataTypeSelectLocation SelectLocationList(RequestDataTypeSelectLocation requestdatatype)
        {
            ResponseDataTypeSelectLocation responsedatatype = new ResponseDataTypeSelectLocation();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Location List");
            }
            SqlConnection connbhswpis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[Location_sps_All]", connbhswpis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhswpis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
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
                    Logger.WriteTrace("[TRACE] Select Location status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] Select Location status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhswpis.Close();
            }

            return responsedatatype;

        }
        public static ResponseDataTypeIUD IUDLocation(RequestDataTypeIUDLocation requestdatatype, char option)
        {
            ResponseDataTypeIUD responsedatatype = new ResponseDataTypeIUD();

            if (Settings.Default._debugmode == 1)
            {
                if (option == 'I')
                    Logger.WriteTrace("[TRACE] Insert Location");
                else if (option == 'U')
                    Logger.WriteTrace("[TRACE] Update Location");
            }
            string StoredProc = string.Empty;

            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            if (option == 'I')
                StoredProc = "[Location_spi]";
            else if (option == 'U')
                StoredProc = "[Location_spu]";

            SqlCommand cmd = new SqlCommand(StoredProc, connbhsvis);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                if (option == 'U')
                {
                    param = new SqlParameter("@in_ID", SqlDbType.BigInt);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.ID;
                    cmd.Parameters.Add(param);
                }

                param = new SqlParameter("@in_Name", SqlDbType.NVarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Name;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_LocationType", SqlDbType.NVarChar, 16);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.LocationType;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_BranchCode", SqlDbType.VarChar, 5);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.BranchCode;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Obsolete", SqlDbType.Bit);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Obsolete;
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
                    if (option == 'I')
                    {
                        Logger.WriteTrace("[TRACE] Insert Location status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] Insert Location status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'U')
                    {
                        Logger.WriteTrace("[TRACE] Update Location status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] Update Location status Message : " + responsedatatype.StatusMessage);
                    }
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }

        public static ResponseDataTypeSelectEntryType SelectLookupEntryTypeList(RequestDataTypeSelectEntryType requestdatatype)
        {
            ResponseDataTypeSelectEntryType responsedatatype = new ResponseDataTypeSelectEntryType();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Entry Type List");
            }
            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[LookupEntryType_sps_All]", connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
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
                    Logger.WriteTrace("[TRACE] SelectEntryType status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] SelectEntryType status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }
        public static ResponseDataTypeIUD IUDLookupEntryType(RequestDataTypeIUDEntryType requestdatatype, char option)
        {
            ResponseDataTypeIUD responsedatatype = new ResponseDataTypeIUD();

            if (Settings.Default._debugmode == 1)
            {
                if (option == 'I')
                    Logger.WriteTrace("[TRACE] Insert Entry Type");
                else if (option == 'U')
                    Logger.WriteTrace("[TRACE] Update Entry Type");
                else if (option == 'D')
                    Logger.WriteTrace("[TRACE] Delete Entry Type");
            }
            string StoredProc = string.Empty;

            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            if (option == 'I')
                StoredProc = "[LookupEntryType_spi]";
            else if (option == 'U')
                StoredProc = "[LookupEntryType_spu]";
            else if (option == 'D')
                StoredProc = "[LookupEntryType_spd]";

            SqlCommand cmd = new SqlCommand(StoredProc, connbhsvis);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EntryType", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EntryType;
                cmd.Parameters.Add(param);

                if (option != 'D')
                {
                    param = new SqlParameter("@in_Description", SqlDbType.VarChar, 50);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.Desc;
                    cmd.Parameters.Add(param);
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
                    if (option == 'I')
                    {
                        Logger.WriteTrace("[TRACE] InsertEntryType status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] InsertEntryType status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'U')
                    {
                        Logger.WriteTrace("[TRACE] UpdateEntryType status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] UpdateEntryType status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'D')
                    {
                        Logger.WriteTrace("[TRACE] DeleteEntryTypen status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] DeleteEntryType status Message : " + responsedatatype.StatusMessage);
                    }
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }

        public static ResponseDataTypeSelectResidentialStatus SelectLookupResidentialStatusList(RequestDataTypeSelectResidentialStatus requestdatatype)
        {
            ResponseDataTypeSelectResidentialStatus responsedatatype = new ResponseDataTypeSelectResidentialStatus();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Residential Status List");
            }
            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[LookupResidentialStatus_sps_All]", connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
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
                    Logger.WriteTrace("[TRACE] SelectResidentialStatus status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] SelectResidentialStatus status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }
        public static ResponseDataTypeIUD IUDLookupResidentialStatus(RequestDataTypeIUDResidentialStatus requestdatatype, char option)
        {
            ResponseDataTypeIUD responsedatatype = new ResponseDataTypeIUD();

            if (Settings.Default._debugmode == 1)
            {
                if (option == 'I')
                    Logger.WriteTrace("[TRACE] Insert Residential Status");
                else if (option == 'U')
                    Logger.WriteTrace("[TRACE] Update Residential Status");
                else if (option == 'D')
                    Logger.WriteTrace("[TRACE] Delete Residential Status");
            }
            string StoredProc = string.Empty;

            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            if (option == 'I')
                StoredProc = "[LookupResidentialStatus_spi]";
            else if (option == 'U')
                StoredProc = "[LookupResidentialStatus_spu]";
            else if (option == 'D')
                StoredProc = "[LookupResidentialStatus_spd]";

            SqlCommand cmd = new SqlCommand(StoredProc, connbhsvis);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_ResidentialStatus", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.ResidentialStatus;
                cmd.Parameters.Add(param);

                if (option != 'D')
                {
                    param = new SqlParameter("@in_Description", SqlDbType.VarChar, 100);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.Desc;
                    cmd.Parameters.Add(param);
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
                    if (option == 'I')
                    {
                        Logger.WriteTrace("[TRACE] InsertResidentialStatus status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] InsertResidentialStatus status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'U')
                    {
                        Logger.WriteTrace("[TRACE] UpdateResidentialStatus status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] UpdateResidentialStatus status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'D')
                    {
                        Logger.WriteTrace("[TRACE] DeleteResidentialStatus status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] DeleteResidentialStatus status Message : " + responsedatatype.StatusMessage);
                    }
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }

        public static ResponseDataTypeSelectVisaClass SelectLookupVisaClassList(RequestDataTypeSelectVisaClass requestdatatype)
        {
            ResponseDataTypeSelectVisaClass responsedatatype = new ResponseDataTypeSelectVisaClass();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Visa Class List");
            }
            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[LookupVisaClass_sps_All]", connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
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
                    Logger.WriteTrace("[TRACE] SelectVisaClasss status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] SelectVisaClass status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }
        public static ResponseDataTypeSelectVisaClass SelectVisaClass(RequestDataTypeSelectVisaClass requestdatatype)
        {
            ResponseDataTypeSelectVisaClass responsedatatype = new ResponseDataTypeSelectVisaClass();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Visa Class List");
            }
            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[LookupVisaClass_sps]", connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_DocType", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DocType;
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
                    Logger.WriteTrace("[TRACE] SelectVisaClasss status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] SelectVisaClass status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }
        public static ResponseDataTypeIUD IUDLookupVisaClass(RequestDataTypeIUDVisaClass requestdatatype, char option)
        {
            ResponseDataTypeIUD responsedatatype = new ResponseDataTypeIUD();

            if (Settings.Default._debugmode == 1)
            {
                if (option == 'I')
                    Logger.WriteTrace("[TRACE] Insert Visa Class");
                else if (option == 'D')
                    Logger.WriteTrace("[TRACE] Delete Visa Class");
                else if (option == 'U')
                    Logger.WriteTrace("[TRACE] Update Visa Class");
            }
            string StoredProc = string.Empty;

            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            if (option == 'I')
                StoredProc = "[LookupVisaClass_spi]";
            else if (option == 'D')
                StoredProc = "[LookupVisaClass_spd]";
            else if (option == 'U')
                StoredProc = "[LookupVisaClass_spu]";

            SqlCommand cmd = new SqlCommand(StoredProc, connbhsvis);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_DocType", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.DocType;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_Class", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.Class;
                cmd.Parameters.Add(param);

                if (option != 'D')
                {
                    param = new SqlParameter("@in_Desc", SqlDbType.VarChar, 100);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.Desc;
                    cmd.Parameters.Add(param);
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
                    if (option == 'I')
                    {
                        Logger.WriteTrace("[TRACE] InsertVisaClass status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] InsertVisaClass status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'U')
                    {
                        Logger.WriteTrace("[TRACE] UpdateVisaClass status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] UpdateVisaClass status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'D')
                    {
                        Logger.WriteTrace("[TRACE] DeleteVisaClass status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] DeleteVisaClass status Message : " + responsedatatype.StatusMessage);
                    }
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }

        public static ResponseDataTypeSelectVisitPurpose SelectLookupVisitPurposeList(RequestDataTypeSelectVisitPurpose requestdatatype)
        {
            ResponseDataTypeSelectVisitPurpose responsedatatype = new ResponseDataTypeSelectVisitPurpose();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Visit Purpose List");
            }
            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[LookupVisitPurpose_sps_All]", connbhsvis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
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
                    Logger.WriteTrace("[TRACE] SelectVisitPurpose status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] SelectVisitPurpose status Message : " + responsedatatype.StatusMessage);
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }
        public static ResponseDataTypeIUD IUDLookupVisitPurpose(RequestDataTypeIUDVisitPurpose requestdatatype, char option)
        {
            ResponseDataTypeIUD responsedatatype = new ResponseDataTypeIUD();

            if (Settings.Default._debugmode == 1)
            {
                if (option == 'I')
                    Logger.WriteTrace("[TRACE] Insert Visit Purpose");
                else if (option == 'U')
                    Logger.WriteTrace("[TRACE] Update Visit Purposes");
                else if (option == 'D')
                    Logger.WriteTrace("[TRACE] Delete Visit Purpose");
            }
            string StoredProc = string.Empty;

            SqlConnection connbhsvis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            if (option == 'I')
                StoredProc = "[LookupVisitPurpose_spi]";
            else if (option == 'U')
                StoredProc = "[LookupVisitPurpose_spu]";
            else if (option == 'D')
                StoredProc = "[LookupVisitPurpose_spd]";

            SqlCommand cmd = new SqlCommand(StoredProc, connbhsvis);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhsvis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_EnrolLocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.EnrolLocationName;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_VisitPurpose", SqlDbType.VarChar, 2);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.VisitPurpose;
                cmd.Parameters.Add(param);

                if (option != 'D')
                {
                    param = new SqlParameter("@in_Description", SqlDbType.VarChar, 100);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.Desc;
                    cmd.Parameters.Add(param);
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
                    if (option == 'I')
                    {
                        Logger.WriteTrace("[TRACE] InsertVisitPurpose status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] InsertVisitPurpose status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'U')
                    {
                        Logger.WriteTrace("[TRACE] UpdateVisitPurpose status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] UpdateVisitPurpose status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'D')
                    {
                        Logger.WriteTrace("[TRACE] DeleteVisitPurpose status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] DeleteVisitPurpose status Message : " + responsedatatype.StatusMessage);
                    }
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhsvis.Close();
            }

            return responsedatatype;

        }

        #region ConfigLocation
        public static ResponseDataTypeSelectAll SelectConfigLocation(RequestDataTypeSelectConfigLocation requestdatatype)
        {
            ResponseDataTypeSelectAll responsedatatype = new ResponseDataTypeSelectAll();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Location Configuration List");
            }
            SqlConnection connbhswpis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[ConfigLocation_sps]", connbhswpis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhswpis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_LocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.LocationName;
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
                    Logger.WriteTrace("[TRACE] SelectFeeType status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] SelectFeeType status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhswpis.Close();
            }

            return responsedatatype;

        }
        public static ResponseDataTypeSelectAll SelectAllConfigLocation(RequestDataTypeSelectConfigLocation requestdatatype)
        {
            ResponseDataTypeSelectAll responsedatatype = new ResponseDataTypeSelectAll();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Location Configuration List");
            }
            SqlConnection connbhswpis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[ConfigLocation_sps_All]", connbhswpis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhswpis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@in_LocationName", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.LocationName;
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
                    Logger.WriteTrace("[TRACE] SelectFeeType status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] SelectFeeType status Message : " + responsedatatype.StatusMessage);
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhswpis.Close();
            }

            return responsedatatype;

        }
        public static ResponseDataTypeIUD IUDConfigLocation(RequestDataTypeIUDConfigLocation requestdatatype, char option)
        {
            ResponseDataTypeIUD responsedatatype = new ResponseDataTypeIUD();

            if (Settings.Default._debugmode == 1)
            {
                if (option == 'I')
                    Logger.WriteTrace("[TRACE] Insert Config Location");
                else if (option == 'U')
                    Logger.WriteTrace("[TRACE] Update Config Location");
                else if (option == 'D')
                    Logger.WriteTrace("[TRACE] Delete Config Location");
            }
            string StoredProc = string.Empty;

            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            if (option == 'I')
                StoredProc = "[ConfigLocation_spi]";
            else if (option == 'U')
                StoredProc = "[ConfigLocation_spu]";
            else if (option == 'D')
                StoredProc = "[ConfigLocation_spd]";

            SqlCommand cmd = new SqlCommand(StoredProc, connbhspis);

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

                param = new SqlParameter("@in_LocationID", SqlDbType.BigInt);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.LocationID;
                cmd.Parameters.Add(param);


                if (option != 'D')
                {
                    param = new SqlParameter("@in_IsEnrollment", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.IsEnrollment;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_IsPayment", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.IsPayment;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_IsApproval", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.IsApproval;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_IsIssuance", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.IsIssuance;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_OtherCounter1", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.OtherCounter1;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_OtherCounter2", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.OtherCounter2;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_OtherCounter3", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.OtherCounter3;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_OtherCounter4", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.OtherCounter4;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@in_OtherCounter5", SqlDbType.Bit);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.OtherCounter5;
                    cmd.Parameters.Add(param);

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
                    if (option == 'I')
                    {
                        Logger.WriteTrace("[TRACE] InsertConfigLocation status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] InsertConfigLocation status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'U')
                    {
                        Logger.WriteTrace("[TRACE] UpdateConfigLocation status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] UpdateConfigLocation status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'D')
                    {
                        Logger.WriteTrace("[TRACE] DeleteConfigLocation status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] DeleteConfigLocation status Message : " + responsedatatype.StatusMessage);
                    }
                }
            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
            }

            return responsedatatype;

        }

        #endregion

        #region perso mapping
        public static ResponseDataTypeSelectAll SelectPersoMappingList(RequestDataTypeSelectAll requestdatatype)
        {
            ResponseDataTypeSelectAll responsedatatype = new ResponseDataTypeSelectAll();

            if (Settings.Default._debugmode == 1)
            {
                Logger.WriteTrace("[TRACE] Select Perso Mapping List");
            }
            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand("[LookupPersoMapping_sps_All]", connbhspis);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            try
            {
                connbhspis.Open();

                param = new SqlParameter("@in_sessionkey", SqlDbType.VarChar, 32);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.SessionKey;
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
                    Logger.WriteTrace("[TRACE] SelectPersoMapping status code : " + responsedatatype.StatusCode);
                    Logger.WriteTrace("[TRACE] SelectPersoMapping status Message : " + responsedatatype.StatusMessage);
                }


            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
            }

            return responsedatatype;

        }
        public static ResponseDataTypeIUD IUDLookupPersoMapping(RequestDataTypeIUDPersoMapping requestdatatype, char option)
        {
            ResponseDataTypeIUD responsedatatype = new ResponseDataTypeIUD();

            if (Settings.Default._debugmode == 1)
            {
                if (option == 'I')
                    Logger.WriteTrace("[TRACE] Insert Perso Mapping");
                else if (option == 'U')
                    Logger.WriteTrace("[TRACE] Update Perso Mapping");
            }

            string StoredProc = string.Empty;

            if (option == 'I')
                StoredProc = "[LookupPersoMapping_spi]";
            else if (option == 'U')
                StoredProc = "[LookupPersoMapping_spu]";

            SqlConnection connbhspis = new SqlConnection(Settings.Default._bhsvisconnectionstring);
            SqlCommand cmd = new SqlCommand(StoredProc, connbhspis);
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

                param = new SqlParameter("@in_PersoBranch", SqlDbType.VarChar, 5);
                param.Direction = ParameterDirection.Input;
                param.Value = requestdatatype.PersoBranch;
                cmd.Parameters.Add(param);

                if (option == 'I')
                {
                    param = new SqlParameter("@in_EnrollBranch", SqlDbType.VarChar, 5);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.EnrollBranch;
                    cmd.Parameters.Add(param);
                }

                if (option == 'U')
                {
                    param = new SqlParameter("@in_ID", SqlDbType.Int);
                    param.Direction = ParameterDirection.Input;
                    param.Value = requestdatatype.ID;
                    cmd.Parameters.Add(param);
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
                    if (option == 'I')
                    {
                        Logger.WriteTrace("[TRACE] InsertCitizenMode status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] InsertCitizenMode status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'U')
                    {
                        Logger.WriteTrace("[TRACE] UpdateCitizenMode status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] UpdateCitizenMode status Message : " + responsedatatype.StatusMessage);
                    }
                    else if (option == 'D')
                    {
                        Logger.WriteTrace("[TRACE] DeleteCitizenMode status code : " + responsedatatype.StatusCode);
                        Logger.WriteTrace("[TRACE] DeleteCitizenMode status Message : " + responsedatatype.StatusMessage);
                    }
                }

            }
            catch (Exception exception2)
            {
                responsedatatype.StatusCode = "-1";
                responsedatatype.StatusMessage = exception2.GetType().ToString() + ", " + exception2.Message;
                if (Settings.Default._debugmode == 1)
                {
                    Logger.WriteTrace("[TRACE][" + exception2.GetType().ToString() + "] [" + exception2.Message + "]");
                }
            }

            finally
            {
                connbhspis.Close();
            }

            return responsedatatype;

        }
        #endregion
    }
}