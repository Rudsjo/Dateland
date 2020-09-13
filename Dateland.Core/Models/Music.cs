using System.ComponentModel.DataAnnotations;

namespace Dateland.Core
{
    /// <summary>
    /// Represents a music genre object
    /// </summary>
    public class Music
    {
        /// <summary>
        /// Gets or sets the Music ID
        /// </summary>
        [Key]
        public int MusicID { get; set; }

        /// <summary>
        /// Gets or sets the name of the genre
        /// </summary>
        [Required]
        [StringLength(50)]
        public string MusicGenre { get; set; }
    }
}
