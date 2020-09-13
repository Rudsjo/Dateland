using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dateland.Core
{
    /// <summary>
    /// Class used to set up the relation between User and GenderPreferation
    /// </summary>
    public class UserGenderPreferationRelation
    {
        /// <summary>
        /// Gets or sets the user genderpreferation ID
        /// </summary>
        [Key]
        public int UserGenderPreferationID { get; set; }

        /// <summary>
        /// Gets or sets the users ID
        /// </summary>
        [ForeignKey("UserID")]
        public User _User { get; set; }

        /// <summary>
        /// Gets or sets the users perferred gender
        /// </summary>
        [ForeignKey("GenderPreferationID")]
        public GenderPreferation _GenderPreferation { get; set; }
    }
}
