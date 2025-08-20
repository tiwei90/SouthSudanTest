namespace DocumentAndLookupManagement.DataType
{
    public class RequestDataTypeIUDPersoMapping
    {
        private string permissionCodeField;

        private string actionDescriptionField;

        private string sessionKeyField;

        private string enrolLocationNameField;

        private int idField;

        private string enrollBranchField;

        private string persoBranchField;


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

        /// <remarks/>
        public string PersoBranch
        {
            get
            {
                return this.persoBranchField;
            }
            set
            {
                this.persoBranchField = value;
            }
        }

        public string EnrollBranch
        {
            get
            {
                return this.enrollBranchField;
            }
            set
            {
                this.enrollBranchField = value;
            }
        }
    }
}
