namespace EnrollManagement.DataType
{
    public class ResponseDataTypeGetApplicationID
    {
        private string newApplicationID;

        private string statusCode;

        private string statusMessage;

        public string NewApplicationID
        {
            get
            {
                return this.newApplicationID;
            }
            set
            {
                this.newApplicationID = value;
            }
        }

        public string StatusCode
        {
            get
            {
                return this.statusCode;
            }
            set
            {
                this.statusCode = value;
            }
        }

        public string StatusMessage
        {
            get
            {
                return this.statusMessage; ;
            }
            set
            {
                this.statusMessage = value;
            }
        }
    }
}
