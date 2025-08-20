namespace EnrollManagement.DataType
{
    public class ResponseDataTypePartialEnrol
    {
        private string statusCode;

        private string statusMessage;

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
