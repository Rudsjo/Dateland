namespace Dateland
{
    using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
    using Dateland.Controllers;
    // Required namespaces
    using Dateland.Core;
    using Dateland.Core.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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
        public List<User> FriendRequests { get; set; }

    }
}
