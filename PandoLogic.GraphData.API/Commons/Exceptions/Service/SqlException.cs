namespace Commons.Exceptions.Service
{
    public class SqlException : BaseExceptionAbstract
    {
        public string StoredProcedureName { get; set; }
        public dynamic StoredProcedureRequest { get; set; }

        public SqlException(string errorMessage) : base(errorMessage) { }

        public SqlException(string storedProcedureName, dynamic storedProcedureRequest) :
            base($"Stored procedure {storedProcedureName} has failed to execute properly")
        {
            StoredProcedureName = storedProcedureName;
            StoredProcedureRequest = storedProcedureRequest;
        }
    }
}
