using System;

namespace Comply365.API.Samples.Actions.SYS
{
    /// <summary>
    /// A response object to the request to put a user
    /// </summary>
    public class UserPutResponse
    {
        /// <summary>
        /// If the request to put a user was successful, the user's Uid will be returned
        /// </summary>
        public Guid? UserUid { get; set; }
        /// <summary>
        /// The user's username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// The user's linked id
        /// </summary>
        public string LinkedId { get; set; }
        /// <summary>
        /// The user's employee id
        /// </summary>
        public string EmployeeId { get; set; }
    }
}