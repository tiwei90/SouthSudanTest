namespace EnrollManagement.DataType
{
    public class RequestDataTypePartialEnrol
    {
        private string permissionCodeField;

        private string actionDescriptionField;

        private string sessionKeyField;

        private string enrolLocationNameField;

        private string applicationIDField;

        private int IDPersonField;

        private int appReasonField;

        private string docTypeField;

        private string entryTypeField;

        private string enrolByField;

        private int priorityField;

        private string surnameField;

        private string firstNameField;

        private string middleNameField;

        private string birthCountryField;

        private string birthPlaceField;

        private string birthDateField;

        private string birthCtryField;

        private string nationalityField;

        private string passportNoField;

        private string passportDOIField;

        private string passportCOIField;

        private string passportPOIField;

        private string passportDOEField;

        private string sexField;

        private string titleField;

        private string nationalIDNoField;

        private string collectionDateField;

        public RequestDataTypePartialEnrol()
        {
            this.priorityField = 0;
        }

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

        public int IDPerson
        {
            get
            {
                return this.IDPersonField;
            }
            set
            {
                this.IDPersonField = value;
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

        public string EnrolBy
        {
            get
            {
                return this.enrolByField;
            }
            set
            {
                this.enrolByField = value;
            }
        }

        public int Priority
        {
            get
            {
                return this.priorityField;
            }
            set
            {
                this.priorityField = value;
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

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
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

        public string BirthPlace
        {
            get
            {
                return this.birthPlaceField;
            }
            set
            {
                this.birthPlaceField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
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

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
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

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string BirthCtry
        {
            get
            {
                return this.birthCtryField;
            }
            set
            {
                this.birthCtryField = value;
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

        public string PassportDOI
        {
            get
            {
                return this.passportDOIField;
            }
            set
            {
                this.passportDOIField = value;
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

        public string PassportPOI
        {
            get
            {
                return this.passportPOIField;
            }
            set
            {
                this.passportPOIField = value;
            }
        }

        public string PassportDOE
        {
            get
            {
                return this.passportDOEField;
            }
            set
            {
                this.passportDOEField = value;
            }
        }

        public string Sex
        {
            get
            {
                return this.sexField;
            }
            set
            {
                this.sexField = value;
            }
        }

        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        public string NationalIDNo
        {
            get
            {
                return this.nationalIDNoField;
            }
            set
            {
                this.nationalIDNoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string CollectionDate
        {
            get
            {
                return this.collectionDateField;
            }
            set
            {
                this.collectionDateField = value;
            }
        }

    }
}
