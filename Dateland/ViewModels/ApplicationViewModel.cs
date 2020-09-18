namespace Dateland
{
    // Required namespaces
    using Dateland.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The view model holding information for the whole application
    /// </summary>
    public class ApplicationViewModel
    {
        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        public User CurrentUser { get; set; }

        /// <summary>
        /// A list of friend requests
        /// </summary>
        public List<User> FriendRequests { get; set; } = new List<User>()
        {
            new User()
            {
                FirstName = "Ulla", LastName = "Red"
            }
        };
    }
}
