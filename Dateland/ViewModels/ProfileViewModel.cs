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
        public IDictionary<User, List<string>> MatchedUsers { get; set; }

        /// <summary>
        /// The user selected to be shown
        /// </summary>
        public User SelectedUser { get; set; } = new User();

        /// <summary>
        /// To display the selected users city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The current users favorite movie
        /// </summary>
        public string FavMovie { get; set; }

        /// <summary>
        /// The current users favorite food
        /// </summary>
        public string FavFood { get; set; }

        /// <summary>
        /// The current users favorite music
        /// </summary>
        public string FavMusic { get; set; }

        public List<Interest> CurrentInterests { get; set; } = new List<Interest>();
    }
}
