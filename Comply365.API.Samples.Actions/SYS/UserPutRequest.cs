using System;

namespace Comply365.API.Samples.Actions.SYS
{
    /// <summary>
    /// Represents a request to put a user onto the Comply365 system
    /// </summary>
    public class UserPutRequest
    {
        /// <summary>
        /// A unique identifier for this user which can be used to lookup other information about them.
        /// </summary>
        public Guid? Uid { get; set; }
        /// <summary>
        /// The user's username.  This can be whatever you like
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// This field is used to relate a user to a 3rd party system.  It is a unique identifier that is not used for anything other than looking up users for software integrations.
        /// </summary>
        public string LinkedId { get; set; }
        /// <summary>
        /// The employee id of the user
        /// </summary>
        public string EmployeeId { get; set; }
        /// <summary>
        /// The user's first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The user's last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The users email address.  Email addresses are required and must be valid, but do not have to be unique.  If you do not have an email address, we recommend passing a generic inbox such as comply365@yourcompanydomain.com
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// The user's phone number
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// The user's cell phone
        /// </summary>
        public string CellPhone { get; set; }
        /// <summary>
        /// The user's start date.  If you enter this in the future, they will not have access to the application until after their start date.
        /// </summary>
        public DateTime StartDateTimeUtc { get; set; }
        /// <summary>
        /// A user's EndDate can be a past or future date.  If it's a future date, the user will remain active until that date.
        /// </summary>
        public DateTime? EndDateTimeUtc { get; set; }
    }
}