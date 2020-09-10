using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dateland.Test2.Models;
using Dateland.Test2.Core;
using System.Data;

namespace Dateland.Test2.Controllers
{
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
        /// Default constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="vm"></param>
        public HomeController(ILogger<HomeController> logger, SignedInViewModel vm, IRepository repo)
        {
            // Set instances
            _logger = logger;
            _repo = repo;
        }

        #endregion

        #region Action Results

        /// <summary>
        /// Shows the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            // Returns the index view
            return View();
        }

        /// <summary>
        /// Registers a user to the database if criterias are set in the register form
        /// </summary>
        /// <param name="user">The user to add</param>
        /// <returns>The page to go to</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserViewModel user)
        {
            // Check if all fields are filled correctly
            if (ModelState.IsValid)
            {
                // Adds the user
                // await repo.AddUser(user.ToModel<IUser, User>());

                // Change the page
                return RedirectToAction();
            }

            // Go back to the start page in case of failing
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } 

        #endregion
    }
}
