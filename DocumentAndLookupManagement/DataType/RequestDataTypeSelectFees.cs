namespace DocumentAndLookupManagement.DataType
{
    public class RequestDataTypeSelectFees
    {
        private string permissionCodeField;

        private string actionDescriptionField;

        private string sessionKeyField;

        private string entryTypeField;

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

        public string EntryType
        {
            get
            {
                return this.entryTypeField;
            }
            set
            {
                this.entryTypeField = value;
            }
        }

    }
}
