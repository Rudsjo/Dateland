namespace Dateland.Core
{
    // Required namespaces
    using System;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class that represents a user
    /// </summary>
    [Table("Users")]
    public class User : IdentityUser
    {
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

        #region Added by marcus

        /// <summary>
        /// Gets or sets the users date of birth
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Property to get or set the description of the user
        /// </summary>
        [StringLength(1000)]
        public string Description { get; set; }

        #region Properties with no relations, User can only have one

        /// <summary>
        /// Property to get or set the user gender
        /// </summary>
        public int? GenderID { get; set; }

        /// <summary>
        /// Property used to set the foreign key to the user <see cref="Model.Gender"/>
        /// </summary>
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// Property to get or set the users favorite food 
        /// </summary>
        public int? FoodID { get; set; }

        /// <summary>
        /// Property used to set the foreign key to the user <see cref="Model.Food"/>
        /// </summary>
        public virtual Food Food { get; set; }

        /// <summary>
        /// Property to get or set the users favorite movie
        /// </summary>
        public int? MovieID { get; set; }

        /// <summary>
        /// Property used to set the foreign key to the user <see cref="Model.Movie"/>
        /// </summary>
        public virtual Movie Movie { get; set; }

        /// <summary>
        /// Property to get or set the users favorite music genre
        /// </summary>
        public int? MusicID { get; set; }

        /// <summary>
        /// Property used to set the foreign key to the user <see cref="Model.Music"/>
        /// </summary>
        public virtual Music Music { get; set; }

        #endregion


        #region Properties with relations

        /// <summary>
        /// Property to get or set the users education
        /// </summary>
        public int? EducationID { get; set; }

        /// <summary>
        /// Property for Education ID used in relationship table <see cref="UserEducationRelation"/>
        /// </summary>
        public virtual Education Education { get; set; }

        /// <summary>
        /// Property to get or set the users intrests
        /// </summary>
        public int? InterestID { get; set; }

        /// <summary>
        /// Property for Intrest ID used in relationship table <see cref="UserInterestRelation"/>
        /// </summary>
        public virtual Interest Interest { get; set; }

        /// <summary>
        /// Property to get or set the users city of origin aswell as city of intrest
        /// </summary>
        public int? CityID { get; set; }

        /// <summary>
        /// Property for City ID used in relationship table <see cref="UserCityRelation"/>
        /// </summary>
        public virtual City City { get; set; }

        /// <summary>
        /// Property to get or set the users preferred gender to date
        /// </summary>
        public int? GenderPreferationID { get; set; }

        /// <summary>
        /// Property for GenderPref ID used in relationship table <see cref="UserGenderPreferationRelation"/>
        /// </summary>
        public virtual GenderPreferation GenderPreferation { get; set; }

        /// <summary>
        /// Property to get or set the users current relations
        /// </summary>
        public int? RelationID { get; set; }

        /// <summary>
        /// Property for Relation ID used in relationship table <see cref="UserRelationRelation"/>
        /// </summary>
        public virtual Relation Relation { get; set; }

        /// <summary>
        /// Property to get or set the users profession
        /// </summary>
        public int? ProfessionID { get; set; }

        /// <summary>
        /// Property for Profession ID used in relationship table <see cref="UserProfessionRelation"/>
        /// </summary>
        public virtual Profession Profession { get; set; }

        #endregion

        #endregion

    }
}
