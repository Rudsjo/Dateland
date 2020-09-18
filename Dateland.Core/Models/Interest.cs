namespace Dateland.Core
{
    // Required namespace
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Dateland.Core.Models;

    /// <summary>
    /// Repsresents an intrest object
    /// </summary>
    public class Interest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Interest"/> class.
        /// </summary>
        public Interest()
        {
            // Create the new list
            UserInterests = new List<UserInterest>();
        }

        /// <summary>
        /// Gets or sets the intrest identifier.
        /// </summary>
        [Key]
        public int InterestID { get; set; }

        /// <summary>
        /// Gets or sets the name of the intrest.
        /// </summary>
        /// <value>
        /// The name of the intrest.
        /// </value>
        [Required]
        [DataType("NVARCHAR(MAX)")]
        public string InterestName { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public virtual IList<UserInterest> UserInterests { get; set; }
    }
}
