namespace EnrollManagement.DataType
{
    public class RequestDataTypeDataEntry
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

        private string enrolCompletedByField;

        private int priorityField;

        private string surnameField;

        private string firstNameField;

        private string middleNameField;

        private string birthCountryField;

        private string birthPlaceField;

        private string birthDateField;

        private string nationalityField;


        private string passportNoField;

        private string passportDOIField;

        private string passportCOIField;

        private string passportPOIField;

        private string passportDOEField;

        private int maritalStatusField;

        private string sexField;

        private string titleField;

        private string nationalIDNoField;

        private string egContactNameField;

        private string egContactRelationshipField;

        private string egContactAddressField;

        private string egContactPhoneField;


        #region Bio Profile
        private byte[] faceImageField;
        private byte[] faceImageJ2KField;
        #endregion

        #region Custom Profile
        private string presentAddressField;
        private string permanentAddressField;
        private string phoneHomeField;
        private string phoneWorkField;
        private string mobileField;
        private string emailField;
        private string faxField;
        private string occupationField;
        private string employerNameField;
        private string employerAddressField;
        private string employerPhoneField;
        private int yearsEmployedField;
        private string formerOccupationField;
        private string formerEmployerNameField;
        private string formerEmployerAddressField;
        private string formerEmployerPhoneField;
        private int formerYearsEmployedField;
        private string fatherFirstNameField;
        private string fatherMiddleNameField;
        private string fatherLastNameField;
        private string fatherNationalityField;
        private string motherFirstNameField;
        private string motherMiddleNameField;
        private string motherLastNameField;
        private string motherNationalityField;
        private string spouseFirstNameField;
        private string spouseMiddleNameField;
        private string spouseLastNameField;
        private string spouseMaidenNameField;
        private string spouseDOBField;
        private int hasChildIndField;
        private string dependantName1Field;
        private string relationship1Field;
        private string dependantName2Field;
        private string relationship2Field;
        private string dependantName3Field;
        private string relationship3Field;
        private string dependantName4Field;
        private string relationship4Field;
        private string dependantName5Field;
        private string relationship5Field;
        private int travelWithSpouseIndField;
        private int travelWithDependantIndField;
        private string visitPurposeField;
        private string otherVisitPurposeField;
        private string lengthOfStayField;
        private string arrivalDateField;
        private string hotelNameField;
        private string hotelAddressField;
        private string hotelPhoneField;
        private string tripSponsorByField;
        private string tripMoneyField;
        private int criminalConvictionIndField;
        private string offence1Field;
        private string offenceDate1Field;
        private string offencePlace1Field;
        private string offencePenalty1Field;
        private string offence2Field;
        private string offenceDate2Field;
        private string offencePlace2Field;
        private string offencePenalty2Field;
        private string offence3Field;
        private string offenceDate3Field;
        private string offencePlace3Field;
        private string offencePenalty3Field;
        private string offence4Field;
        private string offenceDate4Field;
        private string offencePlace4Field;
        private string offencePenalty4Field;
        private string offence5Field;
        private string offenceDate5Field;
        private string offencePlace5Field;
        private string offencePenalty5Field;
        private int terrorismIndField;
        private string terrorismDescField;
        private int fatherInBhsIndField;
        private string fatherResidentialStatusField;
        private int motherInBhsIndField;
        private string motherResidentialStatusField;
        private int spouseInBhsIndField;
        private string spouseResidentialStatusField;
        private int siblingInBhsIndField;
        private string siblingResidentialStatusField;
        private int childrenInBhsIndField;
        private string childrenResidentialStatusField;
        private int visitedBhsIndField;
        private string lastVisitDateField;
        private int appliedVisaIndField;
        private string appliedVisaDateField;
        private string appliedVisaPlaceField;
        private string visaOutcomeField;
        private int deportedIndField;
        #endregion


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

        public string EnrolCompletedBy
        {
            get
            {
                return this.enrolCompletedByField;
            }
            set
            {
                this.enrolCompletedByField = value;
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

        public int MaritalStatus
        {
            get
            {
                return this.maritalStatusField;
            }
            set
            {
                this.maritalStatusField = value;
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

        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] FaceImage
        {
            get
            {
                return this.faceImageField;
            }
            set
            {
                this.faceImageField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] FaceImageJ2K
        {
            get
            {
                return this.faceImageJ2KField;
            }
            set
            {
                this.faceImageJ2KField = value;
            }
        }

        #region Custom Profile
        public string PresentAddress
        {
            get
            {
                return this.presentAddressField;
            }
            set
            {
                this.presentAddressField = value;
            }
        }
        public string PermanentAddress
        {
            get
            {
                return this.permanentAddressField;
            }
            set
            {
                this.permanentAddressField = value;
            }
        }
        public string PhoneHome
        {
            get
            {
                return this.phoneHomeField;
            }
            set
            {
                this.phoneHomeField = value;
            }
        }
        public string PhoneWork
        {
            get
            {
                return this.phoneWorkField;
            }
            set
            {
                this.phoneWorkField = value;
            }
        }
        public string Mobile
        {
            get
            {
                return this.mobileField;
            }
            set
            {
                this.mobileField = value;
            }
        }
        public string Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }
        public string Fax
        {
            get
            {
                return this.faxField;
            }
            set
            {
                this.faxField = value;
            }
        }
        public string Occupation
        {
            get
            {
                return this.occupationField;
            }
            set
            {
                this.occupationField = value;
            }
        }
        public string EmployerName
        {
            get
            {
                return this.employerNameField;
            }
            set
            {
                this.employerNameField = value;
            }
        }
        public string EmployerAddress
        {
            get
            {
                return this.employerAddressField;
            }
            set
            {
                this.employerAddressField = value;
            }
        }
        public string EmployerPhone
        {
            get
            {
                return this.employerPhoneField;
            }
            set
            {
                this.employerPhoneField = value;
            }
        }
        public int YearsEmployed
        {
            get
            {
                return this.yearsEmployedField;
            }
            set
            {
                this.yearsEmployedField = value;
            }
        }
        public string FormerOccupation
        {
            get
            {
                return this.formerOccupationField;
            }
            set
            {
                this.formerOccupationField = value;
            }
        }
        public string FormerEmployerName
        {
            get
            {
                return this.formerEmployerNameField;
            }
            set
            {
                this.formerEmployerNameField = value;
            }
        }
        public string FormerEmployerAddress
        {
            get
            {
                return this.formerEmployerAddressField;
            }
            set
            {
                this.formerEmployerAddressField = value;
            }
        }
        public string FormerEmployerPhone
        {
            get
            {
                return this.formerEmployerPhoneField;
            }
            set
            {
                this.formerEmployerPhoneField = value;
            }
        }
        public int FormerYearsEmployed
        {
            get
            {
                return this.formerYearsEmployedField;
            }
            set
            {
                this.formerYearsEmployedField = value;
            }
        }
        public string FatherFirstName
        {
            get
            {
                return this.fatherFirstNameField;
            }
            set
            {
                this.fatherFirstNameField = value;
            }
        }
        public string FatherMiddleName
        {
            get
            {
                return this.fatherMiddleNameField;
            }
            set
            {
                this.fatherMiddleNameField = value;
            }
        }
        public string FatherLastName
        {
            get
            {
                return this.fatherLastNameField;
            }
            set
            {
                this.fatherLastNameField = value;
            }
        }
        public string FatherNationality
        {
            get
            {
                return this.fatherNationalityField;
            }
            set
            {
                this.fatherNationalityField = value;
            }
        }
        public string MotherFirstName
        {
            get
            {
                return this.motherFirstNameField;
            }
            set
            {
                this.motherFirstNameField = value;
            }
        }
        public string MotherMiddleName
        {
            get
            {
                return this.motherMiddleNameField;
            }
            set
            {
                this.motherMiddleNameField = value;
            }
        }
        public string MotherLastName
        {
            get
            {
                return this.motherLastNameField;
            }
            set
            {
                this.motherLastNameField = value;
            }
        }
        public string MotherNationality
        {
            get
            {
                return this.motherNationalityField;
            }
            set
            {
                this.motherNationalityField = value;
            }
        }
        public string SpouseFirstName
        {
            get
            {
                return this.spouseFirstNameField;
            }
            set
            {
                this.spouseFirstNameField = value;
            }
        }
        public string SpouseMiddleName
        {
            get
            {
                return this.spouseMiddleNameField;
            }
            set
            {
                this.spouseMiddleNameField = value;
            }
        }
        public string SpouseLastName
        {
            get
            {
                return this.spouseLastNameField;
            }
            set
            {
                this.spouseLastNameField = value;
            }
        }
        public string SpouseMaidenName
        {
            get
            {
                return this.spouseMaidenNameField;
            }
            set
            {
                this.spouseMaidenNameField = value;
            }
        }
        public string SpouseDOB
        {
            get
            {
                return this.spouseDOBField;
            }
            set
            {
                this.spouseDOBField = value;
            }
        }
        public int HasChildInd
        {
            get
            {
                return this.hasChildIndField;
            }
            set
            {
                this.hasChildIndField = value;
            }
        }
        public string DependantName1
        {
            get
            {
                return this.dependantName1Field;
            }
            set
            {
                this.dependantName1Field = value;
            }
        }
        public string Relationship1
        {
            get
            {
                return this.relationship1Field;
            }
            set
            {
                this.relationship1Field = value;
            }
        }
        public string DependantName2
        {
            get
            {
                return this.dependantName2Field;
            }
            set
            {
                this.dependantName2Field = value;
            }
        }
        public string Relationship2
        {
            get
            {
                return this.relationship2Field;
            }
            set
            {
                this.relationship2Field = value;
            }
        }
        public string DependantName3
        {
            get
            {
                return this.dependantName3Field;
            }
            set
            {
                this.dependantName3Field = value;
            }
        }
        public string Relationship3
        {
            get
            {
                return this.relationship3Field;
            }
            set
            {
                this.relationship3Field = value;
            }
        }
        public string DependantName4
        {
            get
            {
                return this.dependantName4Field;
            }
            set
            {
                this.dependantName4Field = value;
            }
        }
        public string Relationship4
        {
            get
            {
                return this.relationship4Field;
            }
            set
            {
                this.relationship4Field = value;
            }
        }
        public string DependantName5
        {
            get
            {
                return this.dependantName5Field;
            }
            set
            {
                this.dependantName5Field = value;
            }
        }
        public string Relationship5
        {
            get
            {
                return this.relationship5Field;
            }
            set
            {
                this.relationship5Field = value;
            }
        }
        public int TravelWithSpouseInd
        {
            get
            {
                return this.travelWithSpouseIndField;
            }
            set
            {
                this.travelWithSpouseIndField = value;
            }
        }
        public int TravelWithDependantInd
        {
            get
            {
                return this.travelWithDependantIndField;
            }
            set
            {
                this.travelWithDependantIndField = value;
            }
        }
        public string VisitPurpose
        {
            get
            {
                return this.visitPurposeField;
            }
            set
            {
                this.visitPurposeField = value;
            }
        }
        public string OtherVisitPurpose
        {
            get
            {
                return this.otherVisitPurposeField;
            }
            set
            {
                this.otherVisitPurposeField = value;
            }
        }
        public string LengthOfStay
        {
            get
            {
                return this.lengthOfStayField;
            }
            set
            {
                this.lengthOfStayField = value;
            }
        }
        public string ArrivalDate
        {
            get
            {
                return this.arrivalDateField;
            }
            set
            {
                this.arrivalDateField = value;
            }
        }
        public string HotelName
        {
            get
            {
                return this.hotelNameField;
            }
            set
            {
                this.hotelNameField = value;
            }
        }
        public string HotelAddress
        {
            get
            {
                return this.hotelAddressField;
            }
            set
            {
                this.hotelAddressField = value;
            }
        }
        public string HotelPhone
        {
            get
            {
                return this.hotelPhoneField;
            }
            set
            {
                this.hotelPhoneField = value;
            }
        }
        public string TripSponsorBy
        {
            get
            {
                return this.tripSponsorByField;
            }
            set
            {
                this.tripSponsorByField = value;
            }
        }
        public string TripMoney
        {
            get
            {
                return this.tripMoneyField;
            }
            set
            {
                this.tripMoneyField = value;
            }
        }
        public int CriminalConvictionInd
        {
            get
            {
                return this.criminalConvictionIndField;
            }
            set
            {
                this.criminalConvictionIndField = value;
            }
        }
        public string Offence1
        {
            get
            {
                return this.offence1Field;
            }
            set
            {
                this.offence1Field = value;
            }
        }
        public string OffenceDate1
        {
            get
            {
                return this.offenceDate1Field;
            }
            set
            {
                this.offenceDate1Field = value;
            }
        }
        public string OffencePlace1
        {
            get
            {
                return this.offencePlace1Field;
            }
            set
            {
                this.offencePlace1Field = value;
            }
        }
        public string OffencePenalty1
        {
            get
            {
                return this.offencePenalty1Field;
            }
            set
            {
                this.offencePenalty1Field = value;
            }
        }
        public string Offence2
        {
            get
            {
                return this.offence2Field;
            }
            set
            {
                this.offence2Field = value;
            }
        }
        public string OffenceDate2
        {
            get
            {
                return this.offenceDate2Field;
            }
            set
            {
                this.offenceDate2Field = value;
            }
        }
        public string OffencePlace2
        {
            get
            {
                return this.offencePlace2Field;
            }
            set
            {
                this.offencePlace2Field = value;
            }
        }
        public string OffencePenalty2
        {
            get
            {
                return this.offencePenalty2Field;
            }
            set
            {
                this.offencePenalty2Field = value;
            }
        }
        public string Offence3
        {
            get
            {
                return this.offence3Field;
            }
            set
            {
                this.offence3Field = value;
            }
        }
        public string OffenceDate3
        {
            get
            {
                return this.offenceDate3Field;
            }
            set
            {
                this.offenceDate3Field = value;
            }
        }
        public string OffencePlace3
        {
            get
            {
                return this.offencePlace3Field;
            }
            set
            {
                this.offencePlace3Field = value;
            }
        }
        public string OffencePenalty3
        {
            get
            {
                return this.offencePenalty3Field;
            }
            set
            {
                this.offencePenalty3Field = value;
            }
        }
        public string Offence4
        {
            get
            {
                return this.offence4Field;
            }
            set
            {
                this.offence4Field = value;
            }
        }
        public string OffenceDate4
        {
            get
            {
                return this.offenceDate4Field;
            }
            set
            {
                this.offenceDate4Field = value;
            }
        }
        public string OffencePlace4
        {
            get
            {
                return this.offencePlace4Field;
            }
            set
            {
                this.offencePlace4Field = value;
            }
        }
        public string OffencePenalty4
        {
            get
            {
                return this.offencePenalty4Field;
            }
            set
            {
                this.offencePenalty4Field = value;
            }
        }
        public string Offence5
        {
            get
            {
                return this.offence5Field;
            }
            set
            {
                this.offence5Field = value;
            }
        }
        public string OffenceDate5
        {
            get
            {
                return this.offenceDate5Field;
            }
            set
            {
                this.offenceDate5Field = value;
            }
        }
        public string OffencePlace5
        {
            get
            {
                return this.offencePlace5Field;
            }
            set
            {
                this.offencePlace5Field = value;
            }
        }
        public string OffencePenalty5
        {
            get
            {
                return this.offencePenalty5Field;
            }
            set
            {
                this.offencePenalty5Field = value;
            }
        }
        public int TerrorismInd
        {
            get
            {
                return this.terrorismIndField;
            }
            set
            {
                this.terrorismIndField = value;
            }
        }
        public string TerrorismDesc
        {
            get
            {
                return this.terrorismDescField;
            }
            set
            {
                this.terrorismDescField = value;
            }
        }
        public int FatherInBhsInd
        {
            get
            {
                return this.fatherInBhsIndField;
            }
            set
            {
                this.fatherInBhsIndField = value;
            }
        }
        public string FatherResidentialStatus
        {
            get
            {
                return this.fatherResidentialStatusField;
            }
            set
            {
                this.fatherResidentialStatusField = value;
            }
        }
        public int MotherInBhsInd
        {
            get
            {
                return this.motherInBhsIndField;
            }
            set
            {
                this.motherInBhsIndField = value;
            }
        }
        public string MotherResidentialStatus
        {
            get
            {
                return this.motherResidentialStatusField;
            }
            set
            {
                this.motherResidentialStatusField = value;
            }
        }
        public int SpouseInBhsInd
        {
            get
            {
                return this.spouseInBhsIndField;
            }
            set
            {
                this.spouseInBhsIndField = value;
            }
        }
        public string SpouseResidentialStatus
        {
            get
            {
                return this.spouseResidentialStatusField;
            }
            set
            {
                this.spouseResidentialStatusField = value;
            }
        }
        public int SiblingInBhsInd
        {
            get
            {
                return this.siblingInBhsIndField;
            }
            set
            {
                this.siblingInBhsIndField = value;
            }
        }
        public string SiblingResidentialStatus
        {
            get
            {
                return this.siblingResidentialStatusField;
            }
            set
            {
                this.siblingResidentialStatusField = value;
            }
        }
        public int ChildrenInBhsInd
        {
            get
            {
                return this.childrenInBhsIndField;
            }
            set
            {
                this.childrenInBhsIndField = value;
            }
        }
        public string ChildrenResidentialStatus
        {
            get
            {
                return this.childrenResidentialStatusField;
            }
            set
            {
                this.childrenResidentialStatusField = value;
            }
        }
        public int VisitedBhsInd
        {
            get
            {
                return this.visitedBhsIndField;
            }
            set
            {
                this.visitedBhsIndField = value;
            }
        }
        public string LastVisitDate
        {
            get
            {
                return this.lastVisitDateField;
            }
            set
            {
                this.lastVisitDateField = value;
            }
        }
        public int AppliedVisaInd
        {
            get
            {
                return this.appliedVisaIndField;
            }
            set
            {
                this.appliedVisaIndField = value;
            }
        }
        public string AppliedVisaDate
        {
            get
            {
                return this.appliedVisaDateField;
            }
            set
            {
                this.appliedVisaDateField = value;
            }
        }
        public string AppliedVisaPlace
        {
            get
            {
                return this.appliedVisaPlaceField;
            }
            set
            {
                this.appliedVisaPlaceField = value;
            }
        }
        public string VisaOutcome
        {
            get
            {
                return this.visaOutcomeField;
            }
            set
            {
                this.visaOutcomeField = value;
            }
        }
        public int DeportedInd
        {
            get
            {
                return this.deportedIndField;
            }
            set
            {
                this.deportedIndField = value;
            }
        }
        #endregion

        public string EGContactName
        {
            get
            {
                return this.egContactNameField;
            }
            set
            {
                this.egContactNameField = value;
            }
        }

        public string EGContactRelationship
        {
            get
            {
                return this.egContactRelationshipField;
            }
            set
            {
                this.egContactRelationshipField = value;
            }
        }

        public string EGContactAddress
        {
            get
            {
                return this.egContactAddressField;
            }
            set
            {
                this.egContactAddressField = value;
            }
        }

        public string EGContactPhone
        {
            get
            {
                return this.egContactPhoneField;
            }
            set
            {
                this.egContactPhoneField = value;
            }
        }

    }
}
