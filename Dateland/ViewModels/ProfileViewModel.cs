namespace Dateland
{
    // Required namespaces
    using Dateland.Core;
    using System.Collections.Generic;

    /// <summary>
    /// ViewModel for MyProfile
    /// </summary>
    public class ProfileViewModel
    {
        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        public User CurrentUser { get; set; }

        /// <summary>
        /// A list of of the matched users
        /// </summary>
        public List<User> MatchedUsers { get; set; }

        /// <summary>
        /// The user selected to be shown
        /// </summary>
        public User SelectedUser { get; set; } = new User();

    }
}
