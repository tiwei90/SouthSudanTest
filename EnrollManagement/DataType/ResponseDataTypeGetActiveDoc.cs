using System.Data;

namespace EnrollManagement.DataType
{
    public class ResponseDataTypeGetActiveDoc
    {
        private int recCount;

        private string statusCode;

        private string statusMessage;

        private DataSet resultListField;

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

        public int RecCount
        {
            get
            {
                return this.recCount;
            }
            set
            {
                this.recCount = value;
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
