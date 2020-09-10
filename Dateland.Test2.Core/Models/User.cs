using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dateland.Test2.Core
{
    /// <summary>
    /// Class that represents a user
    /// </summary>
    public class User
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

    }
}
