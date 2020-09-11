using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dateland.Test2.Core
{
    /// <summary>
    /// Represents a gender object
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Gets or sets the gender ID
        /// </summary>
        [Key]
        public int GenderID { get; set; }

        /// <summary>
        /// Gets or sets the gender type
        /// </summary>
        [Required]
        [StringLength(50)]
        public string GenderType { get; set; }
    }
}
