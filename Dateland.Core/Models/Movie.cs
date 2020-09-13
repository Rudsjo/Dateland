using System.ComponentModel.DataAnnotations;

namespace Dateland.Core
{
    /// <summary>
    /// Represents a movie object
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Gets or sets the movie ID
        /// </summary>
        [Key]
        public int MovieID { get; set; }

        /// <summary>
        /// Gets or sets the name of the movie
        /// </summary>
        [Required]
        [StringLength(50)]
        public string MovieName { get; set; }
    }
}
