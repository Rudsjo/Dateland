using System.Collections.Generic;
using System.Threading.Tasks;
using Dateland.Core;
using Microsoft.AspNetCore.Mvc;

namespace Dateland
{
    public class SignedInController : Controller
    {
        #region Private Members

        /// <summary>
        /// The instance of the repository
        /// </summary>
        private readonly IRepository _repo;

        /// <summary>
        /// The instance of the viewmodel of this controller
        /// </summary>
        private readonly SignedInViewModel _vm;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="repo">The repository to be injected</param>
        /// <param name="vm">The viemodel to be injected</param>
        public SignedInController(IRepository repo, SignedInViewModel vm)
        {
            // Inject
            _repo = repo;
            _vm = vm;
        }

        #endregion

        #region Action Results

        /// <summary>
        /// The action result to show the matched users for a logged in user
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            // Get the list of matched users for the logged in user
            _vm.MatchedUsers = new List<User>(await _repo.GetAll<User>());

            return View(_vm);
        }

        /// <summary>
        /// Sets the selected user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The SignedIn page</returns>
        public IActionResult UpdateSelectedUser(int id)
        {
            // Set the selected user
            _vm.SelectedUser = id;

            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
