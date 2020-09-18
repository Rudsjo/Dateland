namespace Dateland.Core.Models
{
    // Required namespaces
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// All user relationships
    /// </summary>
    public class UserRelations
    {
        /// <summary>
        /// Gets or sets the relation identifier.
        /// </summary>
        /// <value>
        /// The relation identifier.
        /// </value>
        [Key]
        public int RelationID { get; set; }

        /// <summary>
        /// Gets or sets the relation between the 2 users.
        /// </summary>
        public virtual Relation Relation { get; set; }

        /// <summary>
        /// Gets or sets user 1.
        /// </summary>
        public virtual User User1 { get; set; }

        /// <summary>
        /// Gets or sets user 2.
        /// </summary>
        public virtual User User2 { get; set; }

    }
}
