namespace EnrollManagement.DataType
{
    public class ResponseDataTypeUpdatePayment
    {
        private string statusCode;

        private string statusMessage;

        private string resultStageCodeField;

        public string ResultStageCode
        {
            get
            {
                return this.resultStageCodeField;
            }
            set
            {
                this.resultStageCodeField = value;
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
