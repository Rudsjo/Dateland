namespace Dateland.ViewModels
{
    // Required namespaces
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ViewModel for the login view
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// The user's email address
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// The user password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Determines if the users should be kept logged in
        /// </summary>
        /// <value>
        ///   <c>true</c> if yes; otherwise, <c>false</c>.
        /// </value>
        public bool RememberMe { get; set; } = false;
    }
}
