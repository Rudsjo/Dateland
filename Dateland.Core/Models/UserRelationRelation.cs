using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dateland.Core
{
    /// <summary>
    /// Class used to set up the relation between User and Relationships between outher users
    /// </summary>
    public class UserRelationRelation
    {
        /// <summary>
        /// Gets or sets the user relation ID
        /// </summary>
        [Key]
        public int UserRelationID { get; set; }

        /// <summary>
        /// Gets or sets the first users ID
        /// </summary>
        [ForeignKey("Id")]
        public User _FirstUser { get; set; }

        /// <summary>
        /// Gets or sets the first users ID
        /// </summary>
        [ForeignKey("Id")]
        public User _SecondUser { get; set; }

        /// <summary>
        /// Gets or sets the users relation
        /// </summary>
        [ForeignKey("RelationID")]
        public Relation _Relation { get; set; }
    }
}