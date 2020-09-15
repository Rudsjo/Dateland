using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dateland.Core
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
        [ForeignKey("Id")] // Måste denna heta bara Id
        public string _User { get; set; }

        /// <summary>
        /// Gets or sets the users city
        /// </summary>
        [ForeignKey("CityID")]
        public int _City { get; set; }
    }
}
