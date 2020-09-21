namespace Dateland.Core
{
    // Required namespaces
    using System;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using Dateland.Core.Models;

    /// <summary>
    /// Class that represents a user
    /// </summary>
    [Table("Users")]
    public class User : IdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <remarks>
        /// The Id property is initialized to form a new GUID string value.
        /// </remarks>
        public User()
        {
            // Create the new list
            UserInterests = new List<UserInterest>();
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [Required]
        [DataType("NVARCHAR(MAX)")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [Required]
        [DataType("NVARCHAR(MAX)")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the profile picture URL.
        /// </summary>
        /// <value>
        /// The profile picture URL.
        /// </value>
        [DataType("NVARCHAR(MAX)")]
        public string ProfilePictureUrl { get; set; }

        /// <summary>
        /// Gets or sets the users date of birth
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Property to get or set the description of the user
        /// </summary>
        [MaxLength(1000)]
        public string Description { get; set; }

        #region Foreign keys

        /// <summary>
        /// Property used to set the foreign key to the user <see cref="Model.Gender"/>
        /// </summary>
        [ForeignKey("GenderID")]
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets the gender preferation.
        /// </summary>
        [ForeignKey("PreferedGenderID")]
        public virtual Gender GenderPreferation { get; set; }

        /// <summary>
        /// Property used to set the foreign key to the user <see cref="Model.Food"/>
        /// </summary>
        public virtual Food Food { get; set; }

        /// <summary>
        /// Property used to set the foreign key to the user <see cref="Model.Movie"/>
        /// </summary>
        public virtual Movie Movie { get; set; }

        /// <summary>
        /// Property used to set the foreign key to the user <see cref="Model.Music"/>
        /// </summary>
        public virtual Music Music { get; set; }

        /// <summary>
        /// Property for Education ID used in relationship table <see cref="UserEducationRelation"/>
        /// </summary>
        public virtual Education Education { get; set; }

        /// <summary>
        /// Property for Intrest ID used in relationship table <see cref="UserInterestRelation"/>
        /// </summary>
        public virtual IList<UserInterest> UserInterests { get; set; }

        /// <summary>
        /// Property for City ID used in relationship table <see cref="UserCityRelation"/>
        /// </summary>
        public virtual City City { get; set; }

        /// <summary>
        /// Property for Profession ID used in relationship table <see cref="UserProfessionRelation"/>
        /// </summary>
        public virtual Profession Profession { get; set; }

        #endregion
    }
}
