namespace Comply365.API.Samples.Models.Core
{
    /// <summary>
    /// A response object which will contain a success boolean, errors if relevant, as well as the items being requested if the request was a success
    /// </summary>
    public class PagedListWithStatusResponse<T> : StatusResponseWithData<T>
    {
        /// <summary>
        /// The number of items in the system.  This is used to know when to stop paging.
        /// </summary>
        public int TotalRecords { get; set; }
    }
}