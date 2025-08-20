namespace EnrollManagement.DataType
{
    public class RequestDataTypeSelectScannedDoc
    {
        private string permissionCodeField;

        private string actionDescriptionField;

        private string sessionKeyField;

        private string locationNameField;

        private string applicationIDField;

        private int imageIDField;

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
        public string LocationName
        {
            get
            {
                return this.locationNameField;
            }
            set
            {
                this.locationNameField = value;
            }
        }

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
        public int ImageID
        {
            get
            {
                return this.imageIDField;
            }
            set
            {
                this.imageIDField = value;
            }
        }

    }
}
