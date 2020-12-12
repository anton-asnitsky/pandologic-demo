using Newtonsoft.Json;

namespace Commons.Model.Outbound
{
    public class ErrorResponse
    {
        [JsonProperty("correlation_id")]
        public string CorrelationId { get; set; }

        [JsonProperty("error_id")]
        public int ErrorId { get; set; }

        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        public ErrorResponse(string correlationId, int errorId, string errorCode, string errorDescription)
        {
            CorrelationId = correlationId;
            ErrorId = errorId;
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
        }
    }
}
