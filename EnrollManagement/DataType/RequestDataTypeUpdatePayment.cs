namespace EnrollManagement.DataType
{
    public class RequestDataTypeUpdatePayment
    {
        private string permissionCodeField;

        private string actionDescriptionField;

        private string sessionKeyField;

        private string applicationIDField;

        private string EnrolLocationNameField;

        private System.Nullable<int> paymentMethodField;

        private System.Nullable<int> paymentAmtField;

        private string receiptNoField;

        private string cardNoField;

        private string paymentRemarkField;

        private string otherPaymentMethodField;

        private string feeTypeField;

        private string amountChangedByField;

        public RequestDataTypeUpdatePayment()
        {

        }

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
        public string EnrolLocationName
        {
            get
            {
                return this.EnrolLocationNameField;
            }
            set
            {
                this.EnrolLocationNameField = value;
            }
        }

        /// <remarks/>
        public System.Nullable<int> PaymentMethod
        {
            get
            {
                return this.paymentMethodField;
            }
            set
            {
                this.paymentMethodField = value;
            }
        }


        /// <remarks/>
        public System.Nullable<int> PaymentAmt
        {
            get
            {
                return this.paymentAmtField;
            }
            set
            {
                this.paymentAmtField = value;
            }
        }

        /// <remarks/>
        public string ReceiptNo
        {
            get
            {
                return this.receiptNoField;
            }
            set
            {
                this.receiptNoField = value;
            }
        }

        /// <remarks/>
        public string CardNo
        {
            get
            {
                return this.cardNoField;
            }
            set
            {
                this.cardNoField = value;
            }
        }

        /// <remarks/>
        public string PaymentRemark
        {
            get
            {
                return this.paymentRemarkField;
            }
            set
            {
                this.paymentRemarkField = value;
            }
        }

        /// <remarks/>
        public string OtherPaymentMethod
        {
            get
            {
                return this.otherPaymentMethodField;
            }
            set
            {
                this.otherPaymentMethodField = value;
            }
        }

        /// <remarks/>
        public string FeeType
        {
            get
            {
                return this.feeTypeField;
            }
            set
            {
                this.feeTypeField = value;
            }
        }

        /// <remarks/>
        public string AmountChangedBy
        {
            get
            {
                return this.amountChangedByField;
            }
            set
            {
                this.amountChangedByField = value;
            }
        }
    }
}

