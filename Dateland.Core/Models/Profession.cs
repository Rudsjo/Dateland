using System.ComponentModel.DataAnnotations;

namespace Dateland.Core
{
    /// <summary>
    /// Represents a profession ID
    /// </summary>
    public class Profession
    {
        /// <summary>
        /// Gets or sets the profession ID
        /// </summary>
        [Key]
        public int ProfessionID { get; set; }

        /// <summary>
        /// Gets or sets the name of the profession
        /// </summary>
        [Required]
        [StringLength(50)]
        public string ProfessionName { get; set; }
    }
}
