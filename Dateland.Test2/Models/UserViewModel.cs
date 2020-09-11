﻿using Core.Model;
using Dateland.Test2.Core;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dateland.Test2
{
    /// <summary>
    /// Class that represents a user as a view model
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [Key]
        public int UserID { get; set; }

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
        /// Gets or sets the email.
        /// </summary>
        [Required]
        [EmailAddress]
        [DataType("NVARCHAR(MAX)")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the email confirmed.
        /// </summary>
        [Required]
        [DataType("BIT")]
        public int EmailConfirmed { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is email confirmed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is email confirmed; otherwise, <c>false</c>.
        /// </value>
        [NotMapped]
        public bool IsEmailConfirmed { get => EmailConfirmed != 0; }

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        /// <value>
        /// The password hash.
        /// </value>
        [Required]
        [DataType("NVARCHAR(MAX)")]
        public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the salt.
        /// </summary>
        [Required]
        [DataType("NVARCHAR(MAX)")]
        public string Salt { get; set; }

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
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string DateOfBirth { get; set; }

        /// <summary>
        /// Property to get or set the description of the user
        /// </summary>
        [StringLength(1000)]
        public string Description { get; set; }

        #region Properties with no relations, User can only have one

        /// <summary>
        /// Property to get or set the user gender
        /// </summary>
        public int GenderID { get; set; }

        /// <summary>
        /// Property used to set the foreign key to the user <see cref="Model.Gender"/>
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Property to get or set the users favorite food 
        /// </summary>
        public int FoodID { get; set; }

        /// <summary>
        /// Property used to set the foreign key to the user <see cref="Model.Food"/>
        /// </summary>
        public Food Food { get; set; }

        /// <summary>
        /// Property to get or set the users favorite movie
        /// </summary>
        public int MovieID { get; set; }

        /// <summary>
        /// Property used to set the foreign key to the user <see cref="Model.Movie"/>
        /// </summary>
        public Movie Movie { get; set; }

        /// <summary>
        /// Property to get or set the users favorite music genre
        /// </summary>
        public int MusicID { get; set; }

        /// <summary>
        /// Property used to set the foreign key to the user <see cref="Model.Music"/>
        /// </summary>
        public Music Music { get; set; }

        #endregion


        #region Properties with relations

        /// <summary>
        /// Property to get or set the users education
        /// </summary>
        public int EducationID { get; set; }

        /// <summary>
        /// Property for Education ID used in relationship table <see cref="UserEducationRelation"/>
        /// </summary>
        public Education Education { get; set; }

        /// <summary>
        /// Property to get or set the users intrests
        /// </summary>
        public int InterestID { get; set; }

        /// <summary>
        /// Property for Intrest ID used in relationship table <see cref="UserInterestRelation"/>
        /// </summary>
        public Interest Interest { get; set; }

        /// <summary>
        /// Property to get or set the users city of origin aswell as city of intrest
        /// </summary>
        public int CityID { get; set; }

        /// <summary>
        /// Property for City ID used in relationship table <see cref="UserCityRelation"/>
        /// </summary>
        public City City { get; set; }

        /// <summary>
        /// Property to get or set the users preferred gender to date
        /// </summary>
        public int GenderPreferationID { get; set; }

        /// <summary>
        /// Property for GenderPref ID used in relationship table <see cref="UserGenderPreferationRelation"/>
        /// </summary>
        public GenderPreferation GenderPreferation { get; set; }

        /// <summary>
        /// Property to get or set the users current relations
        /// </summary>
        public int RelationID { get; set; }

        /// <summary>
        /// Property for Relation ID used in relationship table <see cref="UserRelationRelation"/>
        /// </summary>
        public Relation Relation { get; set; }

        /// <summary>
        /// Property to get or set the users profession
        /// </summary>
        public int ProfessionID { get; set; }
        /// <summary>
        /// Property for Profession ID used in relationship table <see cref="UserProfessionRelation"/>
        /// </summary>
        public Profession Profession { get; set; }

        #endregion

        #endregion

        #region Added properties
        
        /// <summary>
        /// The confirmed email put in by the user
        /// </summary>
        [Compare(nameof(Email))]
        public string ConfirmedEmail { get; set; }

        #endregion

    }
}
