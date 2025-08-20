namespace EnrollManagement.DataType
{
    public class RequestDataTypeDeleteJob
    {
        private string permissionCodeField;

        private string actionDescriptionField;

        private string sessionKeyField;

        private string applicationIDField;

        private string enrolLocationNameField;

        private int idPersonField;

        private int appReasonField;

        private string docTypeField;

        private string entryTypeField;

        private string surnameField;

        private string firstNameField;

        private string middleNameField;

        private string birthDateField;

        private string nationalityField;

        private string birthCountryField;

        private string passportNoField;

        private string passportCOIField;

        private string remarkField;

        private string stageCodeField;

        private string deleteByField;

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
        public string Remarks
        {
            get
            {
                return this.remarkField;
            }
            set
            {
                this.remarkField = value;
            }
        }
        public string StageCode
        {
            get
            {
                return this.stageCodeField;
            }
            set
            {
                this.stageCodeField = value;
            }
        }

        public string DeleteBy
        {
            get
            {
                return this.deleteByField;
            }
            set
            {
                this.deleteByField = value;
            }
        }

        public int IDPerson
        {
            get
            {
                return this.idPersonField;
            }
            set
            {
                this.idPersonField = value;
            }
        }

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

        public string Surname
        {
            get
            {
                return this.surnameField;
            }
            set
            {
                this.surnameField = value;
            }
        }


        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleNameField;
            }
            set
            {
                this.middleNameField = value;
            }
        }

        public string BirthDate
        {
            get
            {
                return this.birthDateField;
            }
            set
            {
                this.birthDateField = value;
            }
        }

        public string BirthCountry
        {
            get
            {
                return this.birthCountryField;
            }
            set
            {
                this.birthCountryField = value;
            }
        }

        public string Nationality
        {
            get
            {
                return this.nationalityField;
            }
            set
            {
                this.nationalityField = value;
            }
        }

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
    }
}

