using Dateland.Test2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dateland.Test2
{
    /// <summary>
    /// The view model holding information for the whole application
    /// </summary>
    public class ApplicationViewModel
    {
        #region Public Properties

        /// <summary>
        /// A list holding all users
        /// </summary>
        public List<UserViewModel> AllUsers { get; set; } 

        #endregion
    }
}
