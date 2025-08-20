namespace EnrollManagement.DataType
{
    public class RequestDataTypeBCMSCheck
    {
        private string permissionCodeField;

        private string actionDescriptionField;

        private string passportNoField;

        private string passportCOIField;

        private string docTypeField;

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

        /// <remarks/>
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

        /// <remarks/>
        public string DocType
        {
            get
            {
                return this.docTypeField;
            }
            set
            {
                this.docTypeField = value;
            }
        }

    }
}
