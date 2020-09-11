using Dateland.Test2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
    /// <summary>
    /// Class used to set up the relation between User and City
    /// </summary>
    public class UserCityRelation
    {
        /// <summary>
        /// Gets or sets the UserCity ID
        /// </summary>
        [Key]
        public int UserCityID { get; set; }

        /// <summary>
        /// Gets or sets the users id
        /// </summary>
        [ForeignKey("UserID")]
        public User _User { get; set; }

        /// <summary>
        /// Gets or sets the users city
        /// </summary>
        [ForeignKey("CityID")]
        public City _City { get; set; }
    }
}
