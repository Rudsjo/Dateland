using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
    /// <summary>
    /// Represents a favorite food object
    /// </summary>
    public class Food
    {
        /// <summary>
        /// Gets or sets the foods ID
        /// </summary>
        [Key]
        public int FoodID { get; set; }

        /// <summary>
        /// Gets or sets the name of the food
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FoodName { get; set; }
    }
}
