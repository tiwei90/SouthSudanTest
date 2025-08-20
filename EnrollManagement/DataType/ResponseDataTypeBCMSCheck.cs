using System.Data;

namespace EnrollManagement.DataType
{
    public class ResponseDataTypeBCMSCheck
    {
        private DataSet resultListField;

        private string statusCode;

        private int reccount;

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

        public int RecCount
        {
            get
            {
                return this.reccount;
            }
            set
            {
                this.reccount = value;
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

