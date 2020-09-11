using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dateland.Test2.Core
{
    /// <summary>
    /// Represents the preferred gender object
    /// </summary>
    public class GenderPreferation
    {
        /// <summary>
        /// Gets or sets the preferred gender to match with
        /// </summary>
        [Key]
        public int GenderPreferationID { get; set; }

        /// <summary>
        /// Gets or sets the type of the gender
        /// </summary>
        [Required]
        [StringLength(50)]
        public string GenderPreferationType { get; set; }

    }
}
