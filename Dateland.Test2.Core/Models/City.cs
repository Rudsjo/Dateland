using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
    /// <summary>
    /// Represents a city obejct
    /// </summary>
    public class City
    {
        /// <summary>
        /// Gets or sets the City ID
        /// </summary>
        [Key]
        public int CityID { get; set; }

        /// <summary>
        /// Gets or sets the name of the city
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CityName { get; set; }
    }
}
