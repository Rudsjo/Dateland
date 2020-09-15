namespace Dateland.Controllers
{
    // Required namespaces
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Dateland.Core;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Dateland.ViewModels;
    using System.Collections;
    using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<User> UserManager;

        /// <summary>
        /// The sign in manager
        /// </summary>
        private readonly SignInManager<User> SignInManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="repo">The repo.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        public HomeController(
            ILogger<HomeController> logger, 
            IRepository repo, 
            UserManager<User> userManager, 
            SignInManager<User> signInManager)
        {
            // Set instances
            _logger = logger;
            _repo   = repo;
            UserManager   = userManager;
            SignInManager = signInManager;
        }

        #endregion

        #region Action Results

        /// <summary>
        /// Returns the index page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
          => View();
       
           

        /// <summary>
        /// Registers a user to the database if criterias are set in the register form
        /// </summary>
        /// <param name="vm">The identity user to add</param>
        /// <returns>The page to go to</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {

            // Check if all fields are filled correctly
            if (ModelState.IsValid)
            {
                // Create the new user
                User newUser = new User()
                {
                    UserName    = vm.Email,
                    FirstName   = vm.FirstName,
                    LastName    = vm.LastName,
                    Email       = vm.Email,
                    DateOfBirth = vm.DateOfBirth
                };

                // Create the new user and capture the result
                var registrationResult = await UserManager.CreateAsync(newUser, vm.Password);

                // If registration was successful...
                if (registrationResult.Succeeded)
                {
                    // Sign in the new user
                    await SignInManager.SignInAsync(newUser, isPersistent: false);

                    // Redirect to the signed in screen
                    return RedirectToAction("Index", "SignedIn");
                }
                // Else...
                else foreach (var err in registrationResult.Errors) ModelState.AddModelError("", err.Description);
            }

            // Go back to the start page in case of failing
            return View(nameof(Index), vm);
        }

        /// <summary>
        /// Returns the login view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
            => View(new LoginViewModel());

        /// <summary>
        /// Attempts to login the user with the submitted credentials
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            // If the submit is valid...
            if (ModelState.IsValid)
            {
                // Attempt to login the user with the submited credentials
                var loginResult = await SignInManager.PasswordSignInAsync(
                    vm.Email, 
                    vm.Password, 
                    vm.RememberMe, 
                    false);

                // If login was successful
                if (loginResult.Succeeded)
                {
                    // Redirect the user to the logged in page
                    return RedirectToAction("Index", "SignedIn");
                }
                else
                    // Show the user that the login failed
                    ModelState.AddModelError(string.Empty, "Login failed");
            }

            // Else redirect the user back to the login page with the same ViewModel instance
            return View(vm);
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
