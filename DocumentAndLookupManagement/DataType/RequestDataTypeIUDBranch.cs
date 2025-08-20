namespace DocumentAndLookupManagement.DataType
{
    public class RequestDataTypeIUDBranch
    {
        private string permissionCodeField;

        private string actionDescriptionField;

        private string sessionKeyField;

        private string enrolLocationNameField;

        private string stateField;

        private string branchCodeField;

        private string branchNameField;

        private int processDaysField;

        private string countryCodeField;

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
        public string StateCode
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <remarks/>
        public string BranchCode
        {
            get
            {
                return this.branchCodeField;
            }
            set
            {
                this.branchCodeField = value;
            }
        }

        /// <remarks/>
        public string BranchName
        {
            get
            {
                return this.branchNameField;
            }
            set
            {
                this.branchNameField = value;
            }
        }

        public int ProcessDays
        {
            get
            {
                return this.processDaysField;
            }
            set
            {
                this.processDaysField = value;
            }
        }

        public string CountryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }
    }
}
