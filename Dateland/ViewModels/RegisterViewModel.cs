namespace Dateland
{
    // Required namespaces
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Class that represents a user as a view model
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [Required] [DataType("NVARCHAR(MAX)")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [Required] [DataType("NVARCHAR(MAX)")]
        public string LastName { get; set; }

        /// <summary>
        /// The user's email address
        /// </summary>
        [Required] [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the users date of birth
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The user password
        /// </summary>
        [Required] [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// The user password
        /// </summary>
        [Required] [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
