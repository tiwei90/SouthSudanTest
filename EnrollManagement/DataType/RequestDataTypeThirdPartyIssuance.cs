namespace EnrollManagement.DataType
{
    public class RequestDataTypeThirdPartyIssuance
    {
        private string permissionCodeField;

        private string actionDescriptionField;

        private string sessionKeyField;

        private string applicationIDField;

        private string enrolLocationNameField;

        private string tp_NameField;

        private string tp_PhoneField;

        private string tp_RemarksField;

        private string tp_DocNoField;

        private string stageCodeField;

        public RequestDataTypeThirdPartyIssuance()
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
        public string TP_Name
        {
            get
            {
                return this.tp_NameField;
            }
            set
            {
                this.tp_NameField = value;
            }
        }


        /// <remarks/>
        public string TP_Phone
        {
            get
            {
                return this.tp_PhoneField;
            }
            set
            {
                this.tp_PhoneField = value;
            }
        }


        /// <remarks/>
        public string TP_Remarks
        {
            get
            {
                return this.tp_RemarksField;
            }
            set
            {
                this.tp_RemarksField = value;
            }
        }

        /// <remarks/>
        public string TP_DocNo
        {
            get
            {
                return this.tp_DocNoField;
            }
            set
            {
                this.tp_DocNoField = value;
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

    }
}
