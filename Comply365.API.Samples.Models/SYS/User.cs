using System;
using System.Collections.Generic;

namespace Comply365.API.Samples.Models.SYS
{
    /// <summary>
    /// A model representing a user in the Comply365 system
    /// </summary>

    public class User
    {
        /// <summary>
        /// A unique identifier for this user which can be used to lookup other information about them.
        /// </summary>
        public Guid Uid { get; set; }
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
        /// The user's start date.  If you enter this in the future, they will not have access to the application until after their start date
        /// </summary>
        public DateTime StartDateTimeUtc { get; set; }
        /// <summary>
        /// A user's EndDate can be a past or future date.  If it's a future date, the user will remain active until that date.
        /// </summary>
        public DateTime? EndDateTimeUtc { get; set; }
        /// <summary>
        /// User absences do not disable a user.  They ensure that while a user is on leave, overdue notices and reports do not look at this user.
        /// </summary>
        public List<UserAbsence> Absences { get; set; }
        /// <summary>
        /// A collection of all of the user's non-null attribute values
        /// </summary>
        public List<UserAttributeAssignment> Attributes { get; set; }
        /// <summary>
        /// The unique identifiers for the managers this user reports to
        /// </summary>
        public List<Guid> ManagerUids { get; set; }
        /// <summary>
        /// A list of roles that a user is in
        /// </summary>
        public List<string> Roles { get; set; }
        /// <summary>
        /// A list of modules that a user is assigned to.
        /// </summary>
        public List<string> Modules { get; set; }
        /// <summary>
        /// The last time this user logged in.
        /// </summary>
        public DateTime? LastLoginDateUtc { get; set; }

    }
}