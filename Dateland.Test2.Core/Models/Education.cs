using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
    /// <summary>
    /// Represents an education object
    /// </summary>
    public class Education
    {
        /// <summary>
        /// Gets or sets the Education ID
        /// </summary>
        [Key]
        public int EducationID { get; set; }

        /// <summary>
        /// Gets or sets the name of the education
        /// </summary>
        [Required]
        [StringLength(50)]
        public string EducationName { get; set; }
    }
}
