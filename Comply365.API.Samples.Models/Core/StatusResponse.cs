namespace Comply365.API.Samples.Models.Core
{
    /// <summary>
    /// Represents a status response in Comply365
    /// </summary>
    public class StatusResponse
    {
        /// <summary>
        /// Boolean which tells if the request was successful
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// An error code which is useful for logging purposes.  Only populated when IsSuccess = false
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// A detailed error message with insight beyond what the error code provides.  Only populated when IsSuccess = false.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}