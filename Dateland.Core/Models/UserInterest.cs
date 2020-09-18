namespace Dateland.Core.Models
{
    // Required namespaces
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Relationtable for user interests
    /// </summary>
    public class UserInterest
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [Key]
        public string UserID { get; set; }

        /// <summary>
        /// Gets or sets the interest identifier.
        /// </summary>
        [Key]
        public int InterestID { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets the interest.
        /// </summary>
        public virtual Interest Interest { get; set; }
    }
}
