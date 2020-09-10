using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dateland.Test2.Models;
using Dateland.Test2.Core;

namespace Dateland.Test2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IRepository repo { get; private set; } = new MSSQL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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
                return RedirectToAction(nameof(SignedIn));
            }

            // Go back to the start page in case of failing
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult SignedIn()
        {
            return View();
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
    }
}
