namespace DocumentAndLookupManagement.DataType
{
    public class RequestDataTypeIUDAppReason
    {
        private string permissionCodeField;

        private string actionDescriptionField;

        private string sessionKeyField;

        private string enrolLocationNameField;

        private int appReasonField;

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
        public int AppReason
        {
            get
            {
                return this.appReasonField;
            }
            set
            {
                this.appReasonField = value;
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
