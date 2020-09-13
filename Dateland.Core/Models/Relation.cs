using System.ComponentModel.DataAnnotations;

namespace Dateland.Core
{
    /// <summary>
    /// Represents a user relation type object
    /// </summary>
    public class Relation
    {
        /// <summary>
        /// Gets or sets the relation ID
        /// </summary>
        [Key]
        public int RelationID { get; set; }

        /// <summary>
        /// Gets or sets the type of relation
        /// </summary>
        [Required]
        [StringLength(50)]
        public string RelationType { get; set; }

    }
}
