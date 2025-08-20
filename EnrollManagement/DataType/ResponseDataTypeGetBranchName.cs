namespace EnrollManagement.DataType
{
    public class ResponseDataTypeGetBranchName
    {
        private string branchName;

        private string statusCode;

        private string statusMessage;

        private int processDays;

        public int ProcessDays
        {
            get
            {
                return this.processDays;
            }
            set
            {
                this.processDays = value;
            }
        }

        public string BranchName
        {
            get
            {
                return this.branchName;
            }
            set
            {
                this.branchName = value;
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