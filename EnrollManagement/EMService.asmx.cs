using EnrollManagement.DataType;
using System.ComponentModel;
using System.Web.Services;

namespace EnrollManagement
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://acme.com/", Description = "ACME Company. (M) Web Services . Copyright 2016")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class EMService : System.Web.Services.WebService
    {
        #region BCMS
        [WebMethod]
        public ResponseDataTypeBCMSCheck BCMSVisaCheck(RequestDataTypeBCMSCheck requestdatatype)
        {
            return EMController.BCMSCheck(requestdatatype);
        }
        #endregion

        [WebMethod]
        public ResponseDataTypeGetApplicationID GetApplicationID(RequestDataTypeGetApplicationID requestdatatype)
        {
            return EMController.GetApplicationID(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeGetDetails GetDetails(RequestDataTypeGetDetails requestdatatype)
        {
            return EMController.GetDetails(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeGetDetailsByPermission GetDetailsByPermission(RequestDataTypeGetDetailsByPermission requestdatatype)
        {
            return EMController.GetDetailsByPermission(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeGetPermission GetPermission(RequestDataTypeGetPermission requestdatatype)
        {
            return EMController.GetPermission(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeSelectCountry GetCountryList(RequestDataTypeSelectCountry requestdatatype)
        {
            return EMController.GetCountryList(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeGetPlace SelectPlaceList(RequestDataTypeGetPlace requestdatatype)
        {
            return EMController.SelectPlaceList(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeGetBranchName GetBranchName(RequestDataTypeGetBranchName requestdatatype)
        {
            return EMController.GetBranchName(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeUpdateStageCode UpdateStageCode(RequestDataTypeUpdateStageCode requestdatatype)
        {
            return EMController.UpdateStageCode(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeGetActiveDoc GetActiveDoc(RequestDataTypeGetActiveDoc requestdatatype)
        {
            return EMController.GetActiveDoc(requestdatatype);
        }

        #region  Query
        [WebMethod]
        public ResponseDataTypeQueryByBranch QueryByBranch(RequestDataTypeQueryByBranch requestdatatype)
        {
            return EMController.QueryByBranch(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeQueryByBranchWithPermission QueryByBranchWithPermission(RequestDataTypeQueryByBranchWithPermission requestdatatype)
        {
            return EMController.QueryByBranchWithPermission(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeQueryByName QueryByName(RequestDataTypeQueryByName requestdatatype)
        {
            return EMController.QueryByName(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeQueryByNameWithPermission QueryByNameWithPermission(RequestDataTypeQueryByNameWithPermission requestdatatype)
        {
            return EMController.QueryByNameWithPermission(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeQueryByIDPerson QueryByIDPerson(RequestDataTypeQueryByIDPerson requestdatatype)
        {
            return EMController.QueryByIDPerson(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeQueryByPassport QueryByPassport(RequestDataTypeQueryByPassport requestdatatype)
        {
            return EMController.QueryByPassport(requestdatatype);
        }

        #endregion

        #region Approval
        [WebMethod]
        public ResponseDataTypeApproval Approve(RequestDataTypeApproval requestdatatype)
        {
            return EMController.Approve(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeSelectApprovalHistory SelectApprovalHistoryList(RequestDataTypeSelectApprovalHistory requestdatatype)
        {
            return EMController.SelectApprovalHistory(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeSelectApproval01List SelectApproval01List(RequestdataTypeSelectApproval01List requestdatatype)
        {
            return EMController.SelectApproval01List(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeSelectApproval02List SelectApproval02List(RequestdataTypeSelectApproval02List requestdatatype)
        {
            return EMController.SelectApproval02List(requestdatatype);
        }
        #endregion

        #region Enrollment
        [WebMethod]
        public ResponseDataTypePartialEnrol PartialEnrol(RequestDataTypePartialEnrol requestdatatype)
        {
            return EMController.PartialEnrol(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypePartialEnrol UpdateProfileEnrol(RequestDataTypePartialEnrol requestdatatype)
        {
            return EMController.UpdateProfileEnrol(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeSelectReprintColSlip SelectReprintColSlipList(RequestDataTypeSelectReprintColSlip requestdatatype)
        {
            return EMController.SelectReprintColSlipList(requestdatatype);
        }

        #endregion

        #region Data Entry
        [WebMethod]
        public ResponseDataTypeDataEntry CompleteEnrol(RequestDataTypeDataEntry requestdatatype)
        {
            return EMController.CompleteEnrol(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeDataEntry UpdateProfileDataEntry(RequestDataTypeDataEntry requestdatatype)
        {
            return EMController.UpdateProfileDataEntry(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeSelectDataEntryList SelectDataEntryList(RequestDataTypeSelectDataEntryList requestdatatype)
        {
            return EMController.SelectDataEntryList(requestdatatype);
        }
        #endregion

        #region Payment
        [WebMethod]
        public ResponseDataTypeUpdatePayment UpdatePayment(RequestDataTypeUpdatePayment requestdatatype)
        {
            return EMController.UpdatePayment(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeSelectPaymentHistory SelectPaymentHistory(RequestDataTypeSelectPaymentHistory requestdatatype)
        {
            return EMController.GetPaymentHistory(requestdatatype);
        }
        #endregion

        #region Issuance
        [WebMethod]
        public ResponseDataTypeIssuance Issue(RequestDataTypeIssuance requestdatatype)
        {
            return EMController.Issue(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeThirdPartyIssuance ThirdPartyIssue(RequestDataTypeThirdPartyIssuance requestdatatype)
        {
            return EMController.ThirdPartyIssue(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeSelectIssuanceList SelectIssuanceList(RequestdataTypeSelectIssuanceList requestdatatype)
        {
            return EMController.SelectIssuanceList(requestdatatype);
        }
        #endregion

        #region Scanned Document
        [WebMethod]
        public ResponseDataTypeInsertScannedDoc EnrolScannedDoc(RequestDataTypeInsertScannedDoc requestdatatype)
        {
            return EMController.EnrolScannedDoc(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeDeleteScannedDoc DeleteScannedDoc(RequestDataTypeDeleteScannedDoc requestdatatype)
        {
            return EMController.DeleteScannedDoc(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeSelectScannedDoc GetScannedDocList(RequestDataTypeSelectScannedDoc requestdatatype)
        {
            return EMController.GetScannedDoc(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeSelectScannedDoc GetScannedDocByImageID(RequestDataTypeSelectScannedDoc requestdatatype)
        {
            return EMController.GetScannedDocByImageID(requestdatatype);
        }
        #endregion

        [WebMethod]
        public ResponseDataTypeDeleteJob DeleteJob(RequestDataTypeDeleteJob requestdatatype)
        {
            return EMController.DeleteJob(requestdatatype);
        }
    }
}
