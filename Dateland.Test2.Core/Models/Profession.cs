using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
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
