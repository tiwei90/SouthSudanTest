namespace EnrollManagement.DataType
{
    public class RequestDataTypeGetApplicationID
    {
        private string permissionCode;

        private string actionDescription;

        private string sessionKey;

        public string PermissionCode
        {
            get
            {
                return this.permissionCode;
            }
            set
            {
                this.permissionCode = value;
            }
        }

        public string ActionDescription
        {
            get
            {
                return this.actionDescription;
            }
            set
            {
                this.actionDescription = value;
            }
        }

        public string SessionKey
        {
            get
            {
                return this.sessionKey; ;
            }
            set
            {
                this.sessionKey = value;
            }
        }
    }
}

