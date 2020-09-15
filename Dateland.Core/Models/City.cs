using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Dateland.Core
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
