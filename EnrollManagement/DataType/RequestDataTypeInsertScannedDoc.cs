namespace EnrollManagement.DataType
{
    public class RequestDataTypeInsertScannedDoc
    {
        private string permissionCodeField;

        private string actionDescriptionField;

        private string sessionKeyField;

        private string enrolLocationNameField;

        private string applicationIDField;

        private byte[] scannedImageField;

        private string scannedDocField;

        private int pageNoField;

        private string imageDescField;

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
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] ScannedImage
        {
            get
            {
                return this.scannedImageField;
            }
            set
            {
                this.scannedImageField = value;
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
        public int PageNo
        {
            get
            {
                return this.pageNoField;
            }
            set
            {
                this.pageNoField = value;
            }
        }

        /// <remarks/>
        public string ImageDesc
        {
            get
            {
                return this.imageDescField;
            }
            set
            {
                this.imageDescField = value;
            }
        }


    }
}
