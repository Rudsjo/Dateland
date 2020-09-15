using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dateland.Core
{
    /// <summary>
    /// Class used to set up the relation between User and Profession
    /// </summary>
    public class UserProfessionRelation
    {
        /// <summary>
        /// Gets or sets the user profession ID
        /// </summary>
        [Key]
        public int UserProfessionID { get; set; }

        /// <summary>
        /// Gets or sets the users ID
        /// </summary>
        [ForeignKey("Id")]
        public string _User { get; set; }

        /// <summary>
        /// Gets or sets the users profession
        /// </summary>
        [ForeignKey("ProfessionID")]
        public int _Profession { get; set; }
    }
}
