namespace DocumentAndLookupManagement.DataType
{
    public class RequestDataTypeIUDVisitPurpose
    {
        private string permissionCodeField;

        private string actionDescriptionField;

        private string sessionKeyField;

        private string enrolLocationNameField;

        private string visitPurposeField;

        private string descField;


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
        public string VisitPurpose
        {
            get
            {
                return this.visitPurposeField;
            }
            set
            {
                this.visitPurposeField = value;
            }
        }

        /// <remarks/>
        public string Desc
        {
            get
            {
                return this.descField;
            }
            set
            {
                this.descField = value;
            }
        }
    }
}

