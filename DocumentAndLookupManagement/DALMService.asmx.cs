using DocumentAndLookupManagement.DataType;
using System.ComponentModel;
using System.Web.Services;

namespace DocumentAndLookupManagement
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://acme.com/", Description = "ACME Company. (M) Web Services . Copyright 2025")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class DALMService : System.Web.Services.WebService
    {
        #region Application Reason 
        [WebMethod]
        public ResponseDataTypeSelectAppReason SelectAppReasonList(RequestDataTypeSelectAppReason requestdatatype)
        {
            return DALMController.SelectLookupAppReasonList(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeIUD InsertAppReason(RequestDataTypeIUDAppReason requestdatatype)
        {
            return DALMController.IUDLookupAppReason(requestdatatype, 'I');
        }

        [WebMethod]
        public ResponseDataTypeIUD UpdateAppReason(RequestDataTypeIUDAppReason requestdatatype)
        {
            return DALMController.IUDLookupAppReason(requestdatatype, 'U');
        }

        [WebMethod]
        public ResponseDataTypeIUD DeleteAppReason(RequestDataTypeIUDAppReason requestdatatype)
        {
            return DALMController.IUDLookupAppReason(requestdatatype, 'D');
        }
        #endregion        

        #region Document Type
        [WebMethod]
        public ResponseDataTypeSelectDocType SelectDocTypeList(RequestDataTypeSelectDocType requestdatatype)
        {
            return DALMController.SelectLookupDocTypeList(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeIUD InsertDocType(RequestDataTypeIUDLookupDocType requestdatatype)
        {
            return DALMController.IUDLookupDocType(requestdatatype, 'I');
        }

        [WebMethod]
        public ResponseDataTypeIUD UpdateDocType(RequestDataTypeIUDLookupDocType requestdatatype)
        {
            return DALMController.IUDLookupDocType(requestdatatype, 'U');
        }

        [WebMethod]
        public ResponseDataTypeIUD DeleteDocType(RequestDataTypeIUDLookupDocType requestdatatype)
        {
            return DALMController.IUDLookupDocType(requestdatatype, 'D');
        }
        #endregion

        #region Branch
        [WebMethod]
        public ResponseDataTypeSelectAll SelectBranch(RequestDataTypeSelectAll requestdatatype)
        {
            return DALMController.SelectBranch(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeIUD InsertBranch(RequestDataTypeIUDBranch requestdatatype)
        {
            return DALMController.IUDBranch(requestdatatype, 'I');
        }

        [WebMethod]
        public ResponseDataTypeIUD UpdateBranch(RequestDataTypeIUDBranch requestdatatype)
        {
            return DALMController.IUDBranch(requestdatatype, 'U');
        }

        [WebMethod]
        public ResponseDataTypeIUD DeleteBranch(RequestDataTypeIUDBranch requestdatatype)
        {
            return DALMController.IUDBranch(requestdatatype, 'D');
        }
        #endregion

        #region Payment Method
        [WebMethod]
        public ResponseDataTypeSelectPaymentMethod SelectPaymentMethodList(RequestDataTypeSelectPaymentMethod requestdatatype)
        {
            return DALMController.SelectLookupPaymentMethodList(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeIUD InsertPaymentMethod(RequestDataTypeIUDPaymentMethod requestdatatype)
        {
            return DALMController.IUDLookupPaymentMethod(requestdatatype, 'I');
        }

        [WebMethod]
        public ResponseDataTypeIUD UpdatePaymentMethod(RequestDataTypeIUDPaymentMethod requestdatatype)
        {
            return DALMController.IUDLookupPaymentMethod(requestdatatype, 'U');
        }

        [WebMethod]
        public ResponseDataTypeIUD DeletePaymentMethod(RequestDataTypeIUDPaymentMethod requestdatatype)
        {
            return DALMController.IUDLookupPaymentMethod(requestdatatype, 'D');
        }
        #endregion        

        #region ScannedDoc
        [WebMethod]
        public ResponseDataTypeSelectScannedDoc SelectScannedDocList(RequestDataTypeSelectScannedDoc requestdatatype)
        {
            return DALMController.SelectLookupScannedDocList(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeIUD InsertScannedDoc(RequestDataTypeIUDScannedDoc requestdatatype)
        {
            return DALMController.IUDLookupScannedDoc(requestdatatype, 'I');
        }

        [WebMethod]
        public ResponseDataTypeIUD UpdateScannedDoc(RequestDataTypeIUDScannedDoc requestdatatype)
        {
            return DALMController.IUDLookupScannedDoc(requestdatatype, 'U');
        }

        [WebMethod]
        public ResponseDataTypeIUD DeleteScannedDoc(RequestDataTypeIUDScannedDoc requestdatatype)
        {
            return DALMController.IUDLookupScannedDoc(requestdatatype, 'D');
        }
        #endregion        

        #region Fees
        [WebMethod]
        public ResponseDataTypeSelectFees SelectFeesList(RequestDataTypeSelectFees requestdatatype)
        {
            return DALMController.SelectLookupFeesList(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeSelectFees SelectFee(RequestDataTypeSelectFees requestdatatype)
        {
            return DALMController.SelectLookupFee(requestdatatype);
        }


        [WebMethod]
        public ResponseDataTypeIUD InsertFees(RequestDataTypeIUDLookupFees requestdatatype)
        {
            return DALMController.IUDLookupFees(requestdatatype, 'I');
        }

        [WebMethod]
        public ResponseDataTypeIUD UpdateFees(RequestDataTypeIUDLookupFees requestdatatype)
        {
            return DALMController.IUDLookupFees(requestdatatype, 'U');
        }

        [WebMethod]
        public ResponseDataTypeIUD DeleteFees(RequestDataTypeIUDLookupFees requestdatatype)
        {
            return DALMController.IUDLookupFees(requestdatatype, 'D');
        }
        #endregion       

        #region Reject Reason
        [WebMethod]
        public ResponseDataTypeSelectRejectReason SelectRejectReason(RequestDataTypeSelectRejectReason requestdatatype)
        {
            return DALMController.SelectLookupRejectReasonList(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeIUD InsertRejectReason(RequestDataTypeIUDRejectReason requestdatatype)
        {
            return DALMController.IUDLookupRejectReason(requestdatatype, 'I');
        }

        [WebMethod]
        public ResponseDataTypeIUD UpdateRejectReason(RequestDataTypeIUDRejectReason requestdatatype)
        {
            return DALMController.IUDLookupRejectReason(requestdatatype, 'U');
        }

        [WebMethod]
        public ResponseDataTypeIUD DeleteRejectReason(RequestDataTypeIUDRejectReason requestdatatype)
        {
            return DALMController.IUDLookupRejectReason(requestdatatype, 'D');
        }
        #endregion

        [WebMethod]
        public ResponseDataTypeSelectLayoutID SelectLayoutID(RequestDataTypeSelectLayoutID requestdatatype)
        {
            return DALMController.SelectLayoutIDList(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeSelectPoliceStation SelectPoliceStation(RequestDataTypeSelectPoliceStation requestdatatype)
        {
            return DALMController.SelectPoliceStationList(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeIUD InsertPoliceStation(RequestDataTypeIUDPoliceStation requestdatatype)
        {
            return DALMController.IUDLookupPoliceStation(requestdatatype, 'I');
        }

        [WebMethod]
        public ResponseDataTypeIUD UpdatePoliceStation(RequestDataTypeIUDPoliceStation requestdatatype)
        {
            return DALMController.IUDLookupPoliceStation(requestdatatype, 'U');
        }

        [WebMethod]
        public ResponseDataTypeIUD DeletePoliceStation(RequestDataTypeIUDPoliceStation requestdatatype)
        {
            return DALMController.IUDLookupPoliceStation(requestdatatype, 'D');
        }

        [WebMethod]
        public ResponseDataTypeSelectBranch SelectBranchList(RequestDataTypeSelectBranch requestdatatype)
        {
            return DALMController.SelectBranchList(requestdatatype);
        }

        #region Issuance Reject Reason
        [WebMethod]
        public ResponseDataTypeSelectIssRejectReason SelectIssRejectReason(RequestDataTypeSelectIssRejectReason requestdatatype)
        {
            return DALMController.SelectIssRejectReason(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeIUD InsertIssRejectReason(RequestDataTypeIUDIssRejectReason requestdatatype)
        {
            return DALMController.IUDLookupIssRejectReason(requestdatatype, 'I');
        }

        [WebMethod]
        public ResponseDataTypeIUD UpdateIssRejectReason(RequestDataTypeIUDIssRejectReason requestdatatype)
        {
            return DALMController.IUDLookupIssRejectReason(requestdatatype, 'U');
        }

        [WebMethod]
        public ResponseDataTypeIUD DeleteIssRejectReason(RequestDataTypeIUDIssRejectReason requestdatatype)
        {
            return DALMController.IUDLookupIssRejectReason(requestdatatype, 'D');
        }

        #endregion

        #region Location
        [WebMethod]
        public ResponseDataTypeSelectLocation SelectLocationList(RequestDataTypeSelectLocation requestdatatype)
        {
            return DALMController.SelectLocationList(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeIUD InsertLocation(RequestDataTypeIUDLocation requestdatatype)
        {
            return DALMController.IUDLocation(requestdatatype, 'I');
        }

        [WebMethod]
        public ResponseDataTypeIUD UpdateLocation(RequestDataTypeIUDLocation requestdatatype)
        {
            return DALMController.IUDLocation(requestdatatype, 'U');
        }
        #endregion

        #region Entry Type
        [WebMethod]
        public ResponseDataTypeSelectEntryType SelectLookupEntryTypeList(RequestDataTypeSelectEntryType requestdatatype)
        {
            return DALMController.SelectLookupEntryTypeList(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeIUD InsertEntryType(RequestDataTypeIUDEntryType requestdatatype)
        {
            return DALMController.IUDLookupEntryType(requestdatatype, 'I');
        }

        [WebMethod]
        public ResponseDataTypeIUD UpdateEntryType(RequestDataTypeIUDEntryType requestdatatype)
        {
            return DALMController.IUDLookupEntryType(requestdatatype, 'U');
        }

        [WebMethod]
        public ResponseDataTypeIUD DeleteEntryType(RequestDataTypeIUDEntryType requestdatatype)
        {
            return DALMController.IUDLookupEntryType(requestdatatype, 'D');
        }

        #endregion

        #region Residential Status
        [WebMethod]
        public ResponseDataTypeSelectResidentialStatus SelectLookupResidentialStatusList(RequestDataTypeSelectResidentialStatus requestdatatype)
        {
            return DALMController.SelectLookupResidentialStatusList(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeIUD InsertResidentialStatus(RequestDataTypeIUDResidentialStatus requestdatatype)
        {
            return DALMController.IUDLookupResidentialStatus(requestdatatype, 'I');
        }

        [WebMethod]
        public ResponseDataTypeIUD UpdateResidentialStatus(RequestDataTypeIUDResidentialStatus requestdatatype)
        {
            return DALMController.IUDLookupResidentialStatus(requestdatatype, 'U');
        }

        [WebMethod]
        public ResponseDataTypeIUD DeleteResidentialStatus(RequestDataTypeIUDResidentialStatus requestdatatype)
        {
            return DALMController.IUDLookupResidentialStatus(requestdatatype, 'D');
        }

        #endregion

        #region Visa Class

        [WebMethod]
        public ResponseDataTypeSelectVisaClass SelectVisaClass(RequestDataTypeSelectVisaClass requestdatatype)
        {
            return DALMController.SelectVisaClass(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeSelectVisaClass SelectLookupVisaClassList(RequestDataTypeSelectVisaClass requestdatatype)
        {
            return DALMController.SelectLookupVisaClassList(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeIUD InsertVisaClass(RequestDataTypeIUDVisaClass requestdatatype)
        {
            return DALMController.IUDLookupVisaClass(requestdatatype, 'I');
        }

        [WebMethod]
        public ResponseDataTypeIUD UpdateVisaClass(RequestDataTypeIUDVisaClass requestdatatype)
        {
            return DALMController.IUDLookupVisaClass(requestdatatype, 'U');
        }

        [WebMethod]
        public ResponseDataTypeIUD DeleteVisaClass(RequestDataTypeIUDVisaClass requestdatatype)
        {
            return DALMController.IUDLookupVisaClass(requestdatatype, 'D');
        }

        #endregion

        #region Visit Purpose
        [WebMethod]
        public ResponseDataTypeSelectVisitPurpose SelectLookupVisitPurposeList(RequestDataTypeSelectVisitPurpose requestdatatype)
        {
            return DALMController.SelectLookupVisitPurposeList(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeIUD InsertVisitPurpose(RequestDataTypeIUDVisitPurpose requestdatatype)
        {
            return DALMController.IUDLookupVisitPurpose(requestdatatype, 'I');
        }

        [WebMethod]
        public ResponseDataTypeIUD UpdateVisitPurpose(RequestDataTypeIUDVisitPurpose requestdatatype)
        {
            return DALMController.IUDLookupVisitPurpose(requestdatatype, 'U');
        }

        [WebMethod]
        public ResponseDataTypeIUD DeleteVisitPurpose(RequestDataTypeIUDVisitPurpose requestdatatype)
        {
            return DALMController.IUDLookupVisitPurpose(requestdatatype, 'D');
        }

        #endregion

        #region ConfigLocation
        [WebMethod]
        public ResponseDataTypeSelectAll SelectConfigLocation(RequestDataTypeSelectConfigLocation requestdatatype)
        {
            return DALMController.SelectConfigLocation(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeSelectAll SelectAllConfigLocation(RequestDataTypeSelectConfigLocation requestdatatype)
        {
            return DALMController.SelectAllConfigLocation(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeIUD InsertConfigLocation(RequestDataTypeIUDConfigLocation requestdatatype)
        {
            return DALMController.IUDConfigLocation(requestdatatype, 'I');
        }

        [WebMethod]
        public ResponseDataTypeIUD UpdateConfigLocation(RequestDataTypeIUDConfigLocation requestdatatype)
        {
            return DALMController.IUDConfigLocation(requestdatatype, 'U');
        }

        [WebMethod]
        public ResponseDataTypeIUD DeleteConfigLocation(RequestDataTypeIUDConfigLocation requestdatatype)
        {
            return DALMController.IUDConfigLocation(requestdatatype, 'D');
        }
        #endregion

        #region Perso Mapping
        [WebMethod]
        public ResponseDataTypeSelectAll SelectPersoMappingList(RequestDataTypeSelectAll requestdatatype)
        {
            return DALMController.SelectPersoMappingList(requestdatatype);
        }

        [WebMethod]
        public ResponseDataTypeIUD InsertPersoMapping(RequestDataTypeIUDPersoMapping requestdatatype)
        {
            return DALMController.IUDLookupPersoMapping(requestdatatype, 'I');
        }

        [WebMethod]
        public ResponseDataTypeIUD UpdatePersoMapping(RequestDataTypeIUDPersoMapping requestdatatype)
        {
            return DALMController.IUDLookupPersoMapping(requestdatatype, 'U');
        }

        #endregion
    }
}
