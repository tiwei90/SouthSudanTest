namespace EnrollManagement.DataType
{
    public class RequestDataTypeQueryByBranchWithPermission
    {
        private string permissionCodeField;

        private string actionDescriptionField;

        private string sessionKeyField;

        private string locationNameField;

        private string branchCodeField;

        private int PermissionLevelField;


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

        public string BranchCode
        {
            get
            {
                return this.branchCodeField;
            }
            set
            {
                this.branchCodeField = value;
            }
        }

        public int PermissionLevel
        {
            get
            {
                return this.PermissionLevelField;
            }
            set
            {
                this.PermissionLevelField = value;
            }
        }

    }
}

