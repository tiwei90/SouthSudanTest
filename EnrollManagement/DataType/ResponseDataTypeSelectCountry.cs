using System.Data;

namespace EnrollManagement.DataType
{
    public class ResponseDataTypeSelectCountry
    {
        private DataSet resultListField;

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
