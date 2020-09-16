using Dateland.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dateland
{
    /// <summary>
    /// View model for the UserProfile page, including view specific information
    /// </summary>
    public class UserProfileViewModel
    {
        /// <summary>
        /// The selected user to show
        /// </summary>
        public User SelectedUser { get; set; } 
    }
}
