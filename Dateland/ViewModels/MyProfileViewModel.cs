using Dateland.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dateland
{
    public class MyProfileViewModel
    {
        #region Private Members

        /// <summary>
        /// Private instance of the repository used within the class
        /// </summary>
        private IRepository _repo;

        #endregion

        #region Public Properties

        /// <summary>
        /// The list of Foods to be displayed
        /// </summary>
        public List<Food> Foods { get; set; }

        /// <summary>
        /// The list of Musics to be displayed
        /// </summary>
        public List<Music> Musics { get; set; }

        /// <summary>
        /// The list of Interests to be displayed
        /// </summary>
        public List<Interest> Interests { get; set; }

        /// <summary>
        /// The list of Movies to be displayed
        /// </summary>
        public List<Movie> Movies { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="repo">The repository to inject</param>
        public MyProfileViewModel(IRepository repo)
        {
            // Injecting the repo
            _repo = repo;
        } 

        #endregion

        /// <summary>
        /// Setting up all needed list for the MyProfile-page
        /// </summary>
        /// <returns></returns>
        public async Task SetupMyProfile()
        {
            // Setting up lists
            Foods = new List<Food>();
            Musics = new List<Music>();
            Interests = new List<Interest>();
            Movies = new List<Movie>();

            Foods = (await _repo.GetAll<Food>()).ToList();
            Musics = (await _repo.GetAll<Music>()).ToList();
            Interests = (await _repo.GetAll<Interest>()).ToList();
            Movies = (await _repo.GetAll<Movie>()).ToList();
        }
    }
}
