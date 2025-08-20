namespace EnrollManagement.DataType
{
    public class RequestDataTypeIssuance
    {
        private string permissionCodeField;

        private string actionDescriptionField;

        private string sessionKeyField;

        private string applicationIDField;

        private string enrolLocationNameField;

        private string stageCodeField;

        private string rejectedByField;

        private string rejectReasonField;

        private string remarkField;

        private char isCertField;

        public RequestDataTypeIssuance()
        {

        }

        /// <remarks/>
        public string PermissionCode
        {
            get
            {
                return this.permissionCodeField;
            }
            set
            {
                this.permissionCodeField = value;
            }
        }

        /// <remarks/>
        public string ActionDescription
        {
            get
            {
                return this.actionDescriptionField;
            }
            set
            {
                this.actionDescriptionField = value;
            }
        }

        /// <remarks/>
        public string SessionKey
        {
            get
            {
                return this.sessionKeyField;
            }
            set
            {
                this.sessionKeyField = value;
            }
        }

        /// <remarks/>
        public string ApplicationID
        {
            get
            {
                return this.applicationIDField;
            }
            set
            {
                this.applicationIDField = value;
            }
        }

        /// <remarks/>
        public string EnrolLocationName
        {
            get
            {
                return this.enrolLocationNameField;
            }
            set
            {
                this.enrolLocationNameField = value;
            }
        }

        /// <remarks/>
        public string StageCode
        {
            get
            {
                return this.stageCodeField;
            }
            set
            {
                this.stageCodeField = value;
            }
        }

        /// <remarks/>
        public string RejectedBy
        {
            get
            {
                return this.rejectedByField;
            }
            set
            {
                this.rejectedByField = value;
            }
        }

        /// <remarks/>
        public string RejectReason
        {
            get
            {
                return this.rejectReasonField;
            }
            set
            {
                this.rejectReasonField = value;
            }
        }

        /// <remarks/>
        public string Remark
        {
            get
            {
                return this.remarkField;
            }
            set
            {
                this.remarkField = value;
            }
        }

        /// <remarks/>
        public char IsCert
        {
            get
            {
                return this.isCertField;
            }
            set
            {
                this.isCertField = value;
            }
        }

    }
}

