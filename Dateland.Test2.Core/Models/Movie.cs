using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dateland.Test2.Core
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
