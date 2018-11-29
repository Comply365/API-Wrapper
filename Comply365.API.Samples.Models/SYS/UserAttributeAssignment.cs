using System;

namespace Comply365.API.Samples.Models.SYS
{
    /// <summary>
    /// A model that represents the user attribute set on a user profile
    /// </summary>
    public class UserAttributeAssignment
    {
        /// <summary>
        /// The unique identifier of the user attribute
        /// </summary>
        public Guid AttributeUid { get; set; }
        /// <summary>
        /// The value set for this user's attribute
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Determines if the attribute is managed externally or not.
        /// </summary>
        public bool IsLinked { get; set; }
    }
}