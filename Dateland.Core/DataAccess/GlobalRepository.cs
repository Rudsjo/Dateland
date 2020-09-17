namespace Dateland.Core
{
    // Required namespaces
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;
    using System;

    /// <summary>
    /// The global repository implementation
    /// </summary>
    /// <seealso cref="Dateland.Test2.Core.IRepository" />
    public class GlobalRepository : IRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly AppDbContext Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GlobalRepository(AppDbContext context)
        {
            // Set the context
            this.Context = context;
        }

        /// <summary>
        /// Gets the matching users.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetMatchingUsers(string userId)
        {
            // Create the result object
            List<User> result = new List<User>();

            // Get the current user
            var currentUser = Context.Users.FirstOrDefault(u => u.Id.Equals(userId));

            // If the user does'nt exist...
            if (currentUser == null)
                // return an empty list
                return result;

            // Keeps track of all matches so far
            int matches = 0;

            // Get all user identifiers
            var useridentifiers = Context.Users.Select(u => u.Id).ToList();

            // Loop through all users in the database
            for(int i = 0; i < useridentifiers.Count(); i++)
            {
                // Get the user with the current id
                var user = await Context.Users.FirstOrDefaultAsync(u => u.Id.Equals(useridentifiers[i]));

                // If the user is'nt null
                if(user != null)
                {
                    // x: Check music
                    // x: Check food
                    // x: Check movies
                    // x: Check Interest
                    // x: Check education
                    // x: My gender preferation must be their gender, and their gender preferation must be my gender

                    // We both must prefer each others genders
                    if (user.GenderPreferation.Equals(currentUser.Gender) && currentUser.GenderPreferation.Equals(user.GenderPreferation))
                    {
                        // Keeps track of how many interests they have in common
                        int interestsCount = 0;

                        // Check if we both like the same music
                        if (user.Music.Equals(currentUser.Music))         interestsCount++;
                        // Check if we both like the same food
                        if (user.Food.Equals(currentUser.Food))           interestsCount++;
                        // Check if we both like the same movie
                        if (user.Movie.Equals(currentUser.Movie))         interestsCount++;
                        // Check if we both like the same music
                        if (user.Interest.Equals(currentUser.Interest))   interestsCount++;
                        // Check if we both have the same education
                        if (user.Education.Equals(currentUser.Education)) interestsCount++;

                        if (interestsCount >= 3)
                            // Add the user to the result
                            result.Add(user);

                        // If 6 matches has been made
                        if (matches.Equals(6))
                            // Break out of the loop
                            break;
                    }
                }
            }

            // Return the result
            return result;
        }

        /// <summary>
        /// Gets all interests  from the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Interest>> GetAllInterests()
            =>
            await Context.Interests.ToListAsync();

        /// <summary>
        /// Gets all users from the database.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<IEnumerable<User>> GetUsers()
            =>
            await Context.Users.ToListAsync();

        /// <summary>
        /// Gets the users intrest.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<IEnumerable<UserInterestRelation>> GetUsersInterest(int id)
            =>
            await Context.UserIntrests.Where(u => u._User.Id.Equals(id)).ToListAsync();

        #region Added by marcus

        #region GetAll
        /// <summary>
        /// Gets all the cities from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<City>> GetAllCities()
            =>
            await Context.Cities.ToListAsync();

        /// <summary>
        /// Gets all the educations from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Education>> GetAllEducations()
            =>
            await Context.Educations.ToListAsync();

        /// <summary>
        /// Gets all the foods from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Food>> GetAllFoods()
            =>
            await Context.Foods.ToListAsync();

        /// <summary>
        /// Gets all the genders from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Gender>> GetAllGenders()
            =>
            await Context.Genders.ToListAsync();

        /// <summary>
        /// Gets all the gender preferations from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GenderPreferation>> GetAllGenderPreferations()
            =>
            await Context.GenderPreferations.ToListAsync();

        /// <summary>
        /// Gets all the movies from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Movie>> GetAllMovies()
            =>
            await Context.Movies.ToListAsync();

        /// <summary>
        /// Gets all the musicGenres from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Music>> GetAllMusic()
            =>
            await Context.Music.ToListAsync();

        /// <summary>
        /// Gets all the professions from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Profession>> GetAllProfessions()
            =>
            await Context.Professions.ToListAsync();

        /// <summary>
        /// Gets all the types of relations from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Relation>> GetAllRelationTypes()
            =>
            await Context.Relations.ToListAsync();
        #endregion

        #region Get Relationships

        /// <summary>
        /// Gets the users cities of interest
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserCityRelation>> GetUserCities(int id)
            =>
            await Context.UserCityRelations.Where(u => u._User.Id.Equals(id)).ToListAsync();

        /// <summary>
        /// Gets the users educations
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserEducationRelation>> GetUserEducations(int id)
            =>
            await Context.UserEducationRelations.Where(u => u._User.Id.Equals(id)).ToListAsync();

        /// <summary>
        /// Gets the users preferred datinggender
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserGenderPreferationRelation>> GetUserGenderPreferations(int id)
            =>
            await Context.UserGenderPreferationRelations.Where(u => u._User.Id.Equals(id)).ToListAsync();

        /// <summary>
        /// Gets the users professions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserProfessionRelation>> GetUserProfessions(int id)
            =>
            await Context.UserProfessionRelations.Where(u => u._User.Id.Equals(id)).ToListAsync();

        /// <summary>
        /// Gets the users relationships with other users
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserRelationRelation>> GetUserRelations(int id)
            =>
            await Context.UserRelationRelations.Where(u => u._FirstUserID.Id.Equals(id)).ToListAsync();

        #endregion

        

        public async Task AddCity(string name)
        {
            var newCity = new City();
            newCity.CityName = name;
            await Context.Cities.AddAsync(newCity);
        }
            

        public async Task AddEducation(string name)
        {
            var newEducation = new Education();
            newEducation.EducationName = name;
            await Context.Educations.AddAsync(newEducation);
        }

        public Task AddFood(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task AddGender(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task AddGenderPreferation(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task AddInterest(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task AddMovie(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task AddMusic(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task AddProfession(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task AddRelation(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task AddUserCity(int userID, int cityID)
        {
            throw new System.NotImplementedException();
        }

        public Task AddUserEducation(int userID, int educationID)
        {
            throw new System.NotImplementedException();
        }

        public Task AddUserGenderPreferation(int userID, int genderpreferationID)
        {
            throw new System.NotImplementedException();
        }

        public Task AddUserInterest(int userID, int interestID)
        {
            throw new System.NotImplementedException();
        }

        public Task AddUserProfession(int userID, int professionID)
        {
            throw new System.NotImplementedException();
        }

        public Task AddUserRelation(int userID, int relationID)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateCity(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateEducation(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateFood(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateGender(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateGenderPreferation(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateInterest(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateMovie(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateMusic(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateProfession(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateRelation(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteCity(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteEducation(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteFood(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteGender(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteGenderPreferation(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteInterest(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteMovie(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteMusic(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteProfession(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteRelation(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveUserCityRelation(int userID, int cityID)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveUserEducationRelation(int userID, int educationID)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveUserGenderPreferationRelation(int userID, int genderPreferationID)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveUserInterestRelation(int userID, int interestID)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveUserProfessionRelation(int userID, int professionID)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveUserRelationRelation(int userID, int relationID)
        {
            throw new System.NotImplementedException();
        }

        #endregion

    }
}
