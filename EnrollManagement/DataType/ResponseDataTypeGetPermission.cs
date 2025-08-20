namespace EnrollManagement.DataType
{
    public class ResponseDataTypeGetPermission
    {
        private string result;

        private string statusMessage;

        public string Result
        {
            get
            {
                return this.result;
            }
            set
            {
                this.result = value;
            }
        }
    }
}
