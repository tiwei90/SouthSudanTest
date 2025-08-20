namespace DocumentAndLookupManagement.DataType
{
    public class ResponseDataTypeIUD
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
