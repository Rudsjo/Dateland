namespace Dateland.Core
{
    // Required namespaces
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Contains all user intrest relations
    /// </summary>
    [Table("UserInterestRelations")]
    public class UserInterestRelation
    {
        /// <summary>
        /// Gets or sets the user intrest identifier.
        /// </summary>
        [Key]
        public int UserInterestID { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        [ForeignKey("UserID")]
        public User _User { get; set; }

        /// <summary>
        /// Gets or sets the intrest.
        /// </summary>
        [ForeignKey("InterestID")]
        public Interest _Interest { get; set; }
    }
}
