using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dateland.Core
{
    /// <summary>
    /// Class used to set up the relation between User and Education
    /// </summary>
    public class UserEducationRelation
    {
        /// <summary>
        /// Gets or sets the User education ID
        /// </summary>
        [Key]
        public int UserEducationID { get; set; }

        /// <summary>
        /// Gets or sets the users ID
        /// </summary>
        [ForeignKey("Id")]
        public User _User { get; set; }

        /// <summary>
        /// Gets or sets the users education
        /// </summary>
        [ForeignKey("EducationID")]
        public Education _Education { get; set; }
    }
}
