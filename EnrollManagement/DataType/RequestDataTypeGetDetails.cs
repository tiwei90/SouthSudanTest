namespace EnrollManagement.DataType
{
    public class RequestDataTypeGetDetails
    {
        private string permissionCodeField;

        private string actionDescriptionField;

        private string sessionKeyField;

        private string applicationIDField;

        private string enrolLocationNameField;

        private string searchTypeField;

        private string passportNoField;

        private string passportCOIField;

        private string docNoField;

        public RequestDataTypeGetDetails()
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


        // ylchin - Search Record By
        public string SearchType
        {
            get
            {
                return this.searchTypeField;
            }
            set
            {
                this.searchTypeField = value;
            }
        }

        public string PassportNo
        {
            get
            {
                return this.passportNoField;
            }
            set
            {
                this.passportNoField = value;
            }
        }

        public string PassportCOI
        {
            get
            {
                return this.passportCOIField;
            }
            set
            {
                this.passportCOIField = value;
            }
        }

        public string DocNo
        {
            get
            {
                return this.docNoField;
            }
            set
            {
                this.docNoField = value;
            }
        }

        //--
    }
}
