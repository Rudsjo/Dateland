using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
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
