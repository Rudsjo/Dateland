namespace Dateland.Test2.Core
{
    // Required namespaces
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Contains all user intrest relations
    /// </summary>
    [Table("UserIntrestRelations")]
    public class UserIntrestRelation
    {
        /// <summary>
        /// Gets or sets the user intrest identifier.
        /// </summary>
        [Key]
        public int UserIntrestID { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        [ForeignKey("UserID")]
        public User _User { get; set; }

        /// <summary>
        /// Gets or sets the intrest.
        /// </summary>
        [ForeignKey("IntrestID")]
        public Interest _Intrest { get; set; }
    }
}
