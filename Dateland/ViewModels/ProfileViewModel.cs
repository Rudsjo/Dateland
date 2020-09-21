namespace Dateland
{
    // Required namespaces
    using Dateland.Core;
    using System.Collections.Generic;

    /// <summary>
    /// ViewModel for MyProfile
    /// </summary>
    public class ProfileViewModel : ApplicationViewModel
    {
        /// <summary>
        /// A list of of the matched users
        /// </summary>
        public List<User> MatchedUsers { get; set; }

        /// <summary>
        /// The user selected to be shown
        /// </summary>
        public User SelectedUser { get; set; } = new User();

        /// <summary>
        /// To display the selected users city
        /// </summary>
        public string City { get; set; }
    }
}
