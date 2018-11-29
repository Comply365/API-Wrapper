namespace Comply365.API.Samples.Models.Core
{
    /// <summary>
    /// A response object used to respond to GET requests
    /// </summary>
    /// <typeparam name="T">The object being returned</typeparam>
    public class StatusResponseWithData<T> : StatusResponse
    {
        /// <summary>
        /// The object being returned
        /// </summary>
        public T Data { get; set; }
    }
}