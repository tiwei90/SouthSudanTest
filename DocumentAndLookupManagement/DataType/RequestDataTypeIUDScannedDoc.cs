namespace DocumentAndLookupManagement.DataType
{
    public class RequestDataTypeIUDScannedDoc
    {
        private string permissionCodeField;

        private string actionDescriptionField;

        private string sessionKeyField;

        private string enrolLocationNameField;

        private string scannedDocField;

        private string descField;

        private int idField;


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
        public string ScannedDoc
        {
            get
            {
                return this.scannedDocField;
            }
            set
            {
                this.scannedDocField = value;
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

        /// <remarks/>
        public int ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }
}

