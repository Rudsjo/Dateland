using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Dateland.Core;
namespace Dateland.Controllers
{
    using Dateland.Helpers;
    // Required namespaces
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Internal;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    [Authorize]
    public class AccountController : Controller
    {
        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<User> UserManager;

        /// <summary>
        /// The sign in manager
        /// </summary>
        private readonly SignInManager<User> SignInManager;

        /// <summary>
        /// Gets the email service.
        /// </summary>
        public IEmailService EmailService { get; }

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        public IRepository Repository { get; }

        public ProfileViewModel ProfileVm { get; set; } = new ProfileViewModel();

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        /// <param name="emailService">The email service.</param>
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailService emailService, IRepository repository)
        {
            // Set the user manager
            UserManager = userManager;
            // Set the sign in manager
            SignInManager = signInManager;
            // Set the repository
            Repository = repository;
            // Set the email service
            EmailService = emailService;
        }

        /// <summary>
        /// The index page.
        /// </summary>
        /// <param name="selectedUserId">The id of a user to be selected</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index(string selectedUserId)
        {
            // TEMPORARY UNTIL WE HAVE A MATCHING FUNCTION
            ProfileVm.MatchedUsers = new List<User>();
            ProfileVm.MatchedUsers.Add(await UserManager.FindByIdAsync("1380b9f5-e7cc-464b-950a-aedc285a6761"));
            ProfileVm.MatchedUsers.Add(await UserManager.FindByIdAsync("18217bae-9c0f-4e29-a657-9fb77c99294d"));
            ProfileVm.MatchedUsers.Add(await UserManager.FindByIdAsync("eebedef6-2889-44c6-980a-c62fc71809f5"));

            // Checks if any id is sent in and updates the selected user
            if (selectedUserId != null)
                ProfileVm.SelectedUser = await UserManager.FindByIdAsync(selectedUserId);

            return View(ProfileVm);
        }


        /// <summary>
        /// The page for the logged in users profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> MyProfile()
            => View(ProfileVm.CurrentUser = await UserManager.FindByEmailAsync(User.Identity.Name));
        
        /// <summary>
        /// Registers a user to the database if criterias are set in the register form
        /// </summary>
        /// <param name="vm">The identity user to add</param>
        /// <returns>The page to go to</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            // Check if all fields are filled correctly
            if (ModelState.IsValid)
            {
                // Create the new user
                User newUser = new User()
                {
                    UserName = vm.Email,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    Email = vm.Email,
                    DateOfBirth = vm.DateOfBirth
                };

                // Create the new user and capture the result
                var registrationResult = await UserManager.CreateAsync(newUser, vm.Password);

                // If registration was successful...
                if (registrationResult.Succeeded)
                {
                    // Generate an email confirmation token for the user
                    var token = await UserManager.GenerateEmailConfirmationTokenAsync(newUser);

                    // Create the confirmation link
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userid = newUser.Id, confirmationtoken = token }, Request.Scheme);

                    // Send the confirmation link and get result
                    var emailResult = await EmailService.SendEmail(vm.Email, "Confirmation", $"Click on the link to activate your account: {confirmationLink}");

                    // If email could be sent...
                    if (emailResult)
                    {
                        // Redirect to the Index in screen
                        return View(viewName: "ConfirmEmail");
                    }
                    // Else...
                    else
                    {
                        // Email does not exist (Probably...)
                        ModelState.AddModelError("", "Confirmation email could not be sent");
                    }
                }
                // Else...
                else foreach (var err in registrationResult.Errors) ModelState.AddModelError("", err.Description);
            }

            // Go back to the start page in case of failing
            return View(nameof(Index), vm);
        }

        /// <summary>
        /// Gets the prifle page of a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> UserProfile(string id)
        {
            ProfileVm.SelectedUser = await UserManager.FindByIdAsync(id);

            return View(ProfileVm);
        }

        /// <summary>
        /// Confirms the email.
        /// </summary>
        /// <param name="userid">The userid received by the link.</param>
        /// <param name="confirmationtoken">The confirm token received by the link.</param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userid, string confirmationtoken)
        {
            // If any of the received parameters are null...
            if (userid == null || confirmationtoken == null)
            {
                // Redirect the user back to the index page
                return RedirectToAction("Index");
            }

            // Find the user
            var user = await UserManager.FindByIdAsync(userid);

            // Confirm the user's email
            var confirmationResult = await UserManager.ConfirmEmailAsync(user, confirmationtoken);

            // If email could be confirmed
            if (confirmationResult.Succeeded)
            {
                // Return the email confirmed view
                return View("EmailConfirmed");
            }

            // Return the error page if the email could not be confirmed
            return View("Error");
        }

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            // Sign out the current user
            await SignInManager.SignOutAsync();

            // Return the home page
            return RedirectToAction("Index", controllerName: "Home");
        }

        /// <summary>
        /// Returns the login view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
            => View(new LoginViewModel());

        /// <summary>
        /// Attempts to login the user with the submitted credentials
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
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
                    return Redirect(nameof(Index));
                }
                else
                    // Show the user that the login failed
                    ModelState.AddModelError(string.Empty, "Login failed");
            }

            // Else redirect the user back to the login page with the same ViewModel instance
            return View(vm);
        }

        /// <summary>
        /// Post method for when a user saves changes to their profile
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SaveChanges(string id, ProfileViewModel vm)
        {
            // If everything is ok...
            if (ModelState.IsValid)
            {
                // Get the updated user
                var newUser = await UserManager.FindByIdAsync(id);

                // Update the user in relation to the updated model
                newUser.UpdateInRelationTo<User>(vm.CurrentUser);

                // Update the current user
                await UserManager.UpdateAsync(newUser);               

                // Redirect the user back to the profile page
                return RedirectToAction(nameof(MyProfile));
            }
            else
            {
                // Return the MyPage with the currently edited user
                return View("MyProfile", vm);
            }
            
        }
    }
}