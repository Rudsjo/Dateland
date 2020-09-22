namespace Dateland.Controllers
{
    // Required namespaces
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Dateland.Core;
    using System.Linq;

    /// <summary>
    /// Our home controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class HomeController : Controller
    {
        #region Private Members

        /// <summary>
        /// The instance of the <see cref="ILogger"/>
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// The instance of the repository
        /// </summary>
        private readonly IRepository _repo;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="repo">The repo.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        public HomeController( ILogger<HomeController> logger, IRepository repo) 
        {
            // Set instances
            _logger = logger;
            _repo   = repo;
        }

        #endregion

        #region Action Results

        /// <summary>
        /// Returns the index page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            // If user is Authenticated...
            if (User.Identity.IsAuthenticated)

                // Redirect the user to the logged in page
                return RedirectToAction("Index", "Account");

            // Else just show the user the homepage...
            else return View();
        }

        /// <summary>
        /// Returns the privacy view
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Returns the error view
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } 

        #endregion
    }
}
