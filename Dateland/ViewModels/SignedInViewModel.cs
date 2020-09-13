namespace Dateland
{
    // Required namespaces
    using Dateland.Core;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    /// <summary>
    /// The view model for the SignedIn view
    /// </summary>
    public class SignedInViewModel : ApplicationViewModel
    {
        #region Public Properties

        /// <summary>
        /// A list of of the matched users
        /// </summary>
        public List<User> MatchedUsers { get; set; }

        /// <summary>
        /// The user selected to be shown
        /// </summary>
        public int SelectedUser { get; set; } = 0;

        #endregion

    }
}
