using System;

namespace Comply365.API.Samples.Models.SYS
{
    /// <summary>
    /// Represents a user attribute in the system
    /// </summary>
    public class UserAbsence
    {
        /// <summary>
        /// The unique identifier for this absence
        /// </summary>
        public Guid Uid { get; set; }
        /// <summary>
        /// The start date of a user absence in UTC
        /// </summary>
        public DateTime StartDateUtc { get; set; }
        /// <summary>
        /// The end date of a user absence in UTC
        /// </summary>
        public DateTime? EndDateUtc { get; set; }
        /// <summary>
        /// The reason for the absence
        /// </summary>
        public string Reason { get; set; }
    }
}