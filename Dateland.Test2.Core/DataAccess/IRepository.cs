namespace Dateland.Test2.Core
{
    // Required namespaces
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Repository interface
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Gets all users from the database.
        /// </summary>
        /// <returns></returns>
        abstract Task<IEnumerable<User>> GetUsers();

        /// <summary>
        /// Gets the users intrest.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        abstract Task<IEnumerable<UserInterestRelation>> GetUsersInterest(int id);

        /// <summary>
        /// Gets all interests  from the database.
        /// </summary>
        /// <returns></returns>
        abstract Task<IEnumerable<Interest>> GetAllInterests();

        #region Added by marcus

        #region GetAll

        /// <summary>
        /// Gets all the cities from the database
        /// </summary>
        /// <returns></returns>
        abstract Task<IEnumerable<City>> GetAllCities();

        /// <summary>
        /// Gets all the educations from the database
        /// </summary>
        /// <returns></returns>
        abstract Task<IEnumerable<Education>> GetAllEducations();


        /// <summary>
        /// Gets all the food from the database
        /// </summary>
        /// <returns></returns>
        abstract Task<IEnumerable<Food>> GetAllFoods();

        /// <summary>
        /// Gets all the genders from the database
        /// </summary>
        /// <returns></returns>
        abstract Task<IEnumerable<Gender>> GetAllGenders();

        /// <summary>
        /// Gets all the genderpreferations from the database
        /// </summary>
        /// <returns></returns>
        abstract Task<IEnumerable<GenderPreferation>> GetAllGenderPreferations();

        /// <summary>
        /// Gets all the movies from the database
        /// </summary>
        /// <returns></returns>
        abstract Task<IEnumerable<Movie>> GetAllMovies();

        /// <summary>
        /// Gets all the musicgenres from the database
        /// </summary>
        /// <returns></returns>
        abstract Task<IEnumerable<Music>> GetAllMusic();

        /// <summary>
        /// Gets all the professions from the database
        /// </summary>
        /// <returns></returns>
        abstract Task<IEnumerable<Profession>> GetAllProfessions();

        /// <summary>
        /// Gets all the types of relations from the database
        /// </summary>
        /// <returns></returns>
        abstract Task<IEnumerable<Relation>> GetAllRelationTypes();

        #endregion

        #region GetRelationships

        /// <summary>
        /// Gets the users cities of interest
        /// </summary>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        abstract Task<IEnumerable<UserCityRelation>> GetUserCities(int id);

        /// <summary>
        /// Gets the users educations
        /// </summary>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        abstract Task<IEnumerable<UserEducationRelation>> GetUserEducations(int id);

        /// <summary>
        /// Gets the users preferred datinggender
        /// </summary>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        abstract Task<IEnumerable<UserGenderPreferationRelation>> GetUserGenderPreferations(int id);

        /// <summary>
        /// Gets the users professions
        /// </summary>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        abstract Task<IEnumerable<UserProfessionRelation>> GetUserProfessions(int id);

        /// <summary>
        /// Gets the users relationships with other users
        /// </summary>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        abstract Task<IEnumerable<UserRelationRelation>> GetUserRelations(int id);

        #endregion

        #region Add

        /// <summary>
        /// Adds a city to the database
        /// </summary>
        abstract Task AddCity(string name);

        /// <summary>
        /// Adds an education to the database
        /// </summary>
        /// <returns></returns>
        abstract Task AddEducation(string name);

        /// <summary>
        /// Adds a type of food to the database
        /// </summary>
        /// <returns></returns>
        abstract Task AddFood(string name);

        /// <summary>
        /// Adds a gender to the database
        /// </summary>
        /// <returns></returns>
        abstract Task AddGender(string name);

        /// <summary>
        /// Adds a genderpreferation to the database
        /// </summary>
        /// <returns></returns>
        abstract Task AddGenderPreferation(string name);

        /// <summary>
        /// Adds an interest to the database
        /// </summary>
        /// <returns></returns>
        abstract Task AddInterest(string name);

        /// <summary>
        /// Adds a movie to the database
        /// </summary>
        /// <returns></returns>
        abstract Task AddMovie(string name);

        /// <summary>
        /// Adds a music genre to the database
        /// </summary>
        /// <returns></returns>
        abstract Task AddMusic(string name);

        /// <summary>
        /// Adds a profession to the database
        /// </summary>
        /// <returns></returns>
        abstract Task AddProfession(string name);

        /// <summary>
        /// Adds a type of relation to the database
        /// </summary>
        /// <returns></returns>
        abstract Task AddRelation(string name);

        #endregion 

        #region AddRelations

        /// <summary>
        /// Adds a relation between user and city
        /// </summary>
        /// <returns></returns>
        abstract Task AddUserCity(int userID, int cityID);

        /// <summary>
        /// Adds a relation between user and education
        /// </summary>
        /// <returns></returns>
        abstract Task AddUserEducation(int userID, int educationID);

        /// <summary>
        /// Adds a relation between user and preferred datinggender
        /// </summary>
        /// <returns></returns>
        abstract Task AddUserGenderPreferation(int userID, int genderpreferationID);

        /// <summary>
        /// Adds a relation between user and interest
        /// </summary>
        /// <returns></returns>
        abstract Task AddUserInterest(int userID, int interestID);

        /// <summary>
        /// Adds a relation between user and profession
        /// </summary>
        /// <returns></returns>
        abstract Task AddUserProfession(int userID, int professionID);

        /// <summary>
        /// Adds a relation between two users
        /// </summary>
        /// <returns></returns>
        abstract Task AddUserRelation(int userID, int relationID);
        #endregion

        #region Update

        /// <summary>
        /// Updates the name of a city
        /// </summary>
        /// <param name="id">the indentifier</param>
        /// <returns></returns>
        abstract Task UpdateCity(int id, string name);

        /// <summary>
        /// Updates the name of an education
        /// </summary>
        /// <param name="id">the indentifier</param>
        /// <returns></returns>
        abstract Task UpdateEducation(int id, string name);

        /// <summary>
        /// Updates the name of a food
        /// </summary>
        /// <param name="id">the indentifier</param>
        /// <returns></returns>
        abstract Task UpdateFood(int id, string name);

        /// <summary>
        /// Updates the name of a Gender
        /// </summary>
        /// <param name="id">the indentifier</param>
        /// <returns></returns>
        abstract Task UpdateGender(int id, string name);

        /// <summary>
        /// Updates the name of a Genderpreferation
        /// </summary>
        /// <param name="id">the indentifier</param>
        /// <returns></returns>
        abstract Task UpdateGenderPreferation(int id, string name);

        /// <summary>
        /// Updates the name of an interest
        /// </summary>
        /// <param name="id">the indentifier</param>
        /// <returns></returns>
        abstract Task UpdateInterest(int id, string name);

        /// <summary>
        /// Updates the name of a movie
        /// </summary>
        /// <param name="id">the indentifier</param>
        /// <returns></returns>
        abstract Task UpdateMovie(int id, string name);

        /// <summary>
        /// Updates the name of a music genre
        /// </summary>
        /// <param name="id">the indentifier</param>
        /// <returns></returns>
        abstract Task UpdateMusic(int id, string name);

        /// <summary>
        /// Updates the name of a profession
        /// </summary>
        /// <param name="id">the indentifier</param>
        /// <returns></returns>
        abstract Task UpdateProfession(int id, string name);

        /// <summary>
        /// Updates the name of a relation
        /// </summary>
        /// <param name="id">the indentifier</param>
        /// <returns></returns>
        abstract Task UpdateRelation(int id, string name);
        #endregion

        #region Delete

        /// <summary>
        /// Deletes the city from the database
        /// </summary>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        abstract Task DeleteCity(int id);

        /// <summary>
        /// Deletes the education from the database
        /// </summary>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        abstract Task DeleteEducation(int id);

        /// <summary>
        /// Deletes the food from the database
        /// </summary>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        abstract Task DeleteFood(int id);

        /// <summary>
        /// Deletes the gender from the database
        /// </summary>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        abstract Task DeleteGender(int id);

        /// <summary>
        /// Deletes the genderpreferation from the database
        /// </summary>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        abstract Task DeleteGenderPreferation(int id);

        /// <summary>
        /// Deletes the interest from the database
        /// </summary>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        abstract Task DeleteInterest(int id);

        /// <summary>
        /// Deletes the movie from the database
        /// </summary>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        abstract Task DeleteMovie(int id);

        /// <summary>
        /// Deletes the music genre from the database
        /// </summary>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        abstract Task DeleteMusic(int id);

        /// <summary>
        /// Deletes the profession from the database
        /// </summary>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        abstract Task DeleteProfession(int id);

        /// <summary>
        /// Deletes the relation type from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        abstract Task DeleteRelation(int id);

        #endregion

        #region RemoveRelation

        /// <summary>
        /// Removes the user to city connection in the database
        /// </summary>
        /// <returns></returns>
        abstract Task RemoveUserCityRelation(int userID, int cityID);

        /// <summary>
        /// Removes the user to education connection in the database
        /// </summary>
        /// <returns></returns>
        abstract Task RemoveUserEducationRelation(int userID, int educationID);

        /// <summary>
        /// Removes the user to genderpreferation connection in the database
        /// </summary>
        /// <returns></returns>
        abstract Task RemoveUserGenderPreferationRelation(int userID, int genderPreferationID);

        /// <summary>
        /// Removes the user to interest connection in the database
        /// </summary>
        /// <returns></returns>
        abstract Task RemoveUserInterestRelation(int userID, int interestID);

        /// <summary>
        /// Removes the user to profession connection in the database
        /// </summary>
        /// <returns></returns>
        abstract Task RemoveUserProfessionRelation(int userID, int professionID);

        /// <summary>
        /// Removes the user to user connection in the database
        /// </summary>
        /// <returns></returns>
        abstract Task RemoveUserRelationRelation(int userID, int relationID);

        #endregion

        #endregion
    }
}
