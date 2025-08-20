using System.Data;
//test
namespace DocumentAndLookupManagement.DataType
{
    public class ResponseDataTypeSelectFees
    {
        private DataSet resultListField;

        private string feeField;

        private string statusCode;

        private string statusMessage;

        public DataSet ResultList
        {
            get
            {
                return this.resultListField;
            }
            set
            {
                this.resultListField = value;
            }
        }

        public string Fee
        {
            get
            {
                return this.feeField;
            }
            set
            {
                this.feeField = value;
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
