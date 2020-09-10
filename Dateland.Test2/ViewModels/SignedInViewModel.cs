using Dateland.Test2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dateland.Test2
{
    /// <summary>
    /// The view model for the SignedIn view
    /// </summary>
    public class SignedInViewModel : ApplicationViewModel
    {
        #region Public Properties

        /// <summary>
        /// A list of of the matched users
        /// </summary>
        public List<UserViewModel> MatchedUsers { get; set; }

        /// <summary>
        /// The user selected to be shown
        /// </summary>
        public int SelectedUser { get; set; } = 0;

        #endregion

    }
}
