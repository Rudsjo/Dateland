namespace Dateland.Core
{
    // Required namespaces
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using System.IO.Compression;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System.Reflection.Metadata.Ecma335;
    using System.Xml.Schema;
    using System.Runtime.CompilerServices;
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


        ///// <summary>
        ///// Gets all interests  from the database.
        ///// </summary>
        ///// <returns></returns>
        //public async Task<IEnumerable<Interest>> GetAllInterests()
        //    =>
        //    await Context.Interests.ToListAsync();

        ///// <summary>
        ///// Gets all users from the database.
        ///// </summary>
        ///// <returns></returns>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public async Task<IEnumerable<User>> GetUsers()
        //    =>
        //    await Context.Users.ToListAsync();

        ///// <summary>
        ///// Gets the users intrest.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <returns></returns>
        ///// <exception cref="System.NotImplementedException"></exception>
        //public async Task<IEnumerable<UserInterestRelation>> GetUsersInterest(int id)
        //    =>
        //    await Context.UserIntrestsRelation.Where(u => u._User.Id.Equals(id)).ToListAsync();

        #region Added by marcus

        #region Generic Add, Update, Delete

        public async Task<T> Create<T>(T entity)
            where T : class
        {

            await Context.Set<T>().AddAsync(entity);          

            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Update<T>(T entity)
            where T : class
        {
            Context.Set<T>().Update(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Delete<T>(T entity)
             where T : class
        {
            Context.Set<T>().Remove(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<ICollection<T>> GetAll<T>()
            where T : class
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByID<T>(int id)
            where T : class
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<ICollection<T>> GetRelation<T>(int id)
            where T : class
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<T> CreateRelation<T>(T relation)
            where T : class
        {
            await Context.Set<T>().AddAsync(relation);

            await Context.SaveChangesAsync();

            return relation;
        }

        public async Task<T> RemoveRelation<T>(T relation)
            where T : class
        {
            Context.Set<T>().Remove(relation);

            await Context.SaveChangesAsync();

            return relation;
        }
        #endregion

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

        #region GetByID

        /// <summary>
        /// Gets a single city by id
        /// </summary>
        /// <param name="cityID">the identifier</param>
        /// <returns></returns>
        public async Task<City> GetCityByID(int cityID)
            =>
            await Context.Cities.Where(c => c.CityID.Equals(cityID)).FirstOrDefaultAsync();

        /// <summary>
        /// Gets a single education by id
        /// </summary>
        /// <param name="educationID">the identifier</param>
        /// <returns></returns>
        public async Task<Education> GetEducationByID(int educationID)
            =>
            await Context.Educations.Where(e => e.EducationID.Equals(educationID)).FirstOrDefaultAsync();

        /// <summary>
        /// Gets a single food by id
        /// </summary>
        /// <param name="foodID">the identifier</param>
        /// <returns></returns>
        public async Task<Food> GetFoodByID(int foodID)
            =>
            await Context.Foods.Where(f => f.FoodID.Equals(foodID)).FirstOrDefaultAsync();

        /// <summary>
        /// Gets a single gender by id
        /// </summary>
        /// <param name="genderID">the identifier</param>
        /// <returns></returns>
        public async Task<Gender> GetGenderByID(int genderID)
            =>
            await Context.Genders.Where(g => g.GenderID.Equals(genderID)).FirstOrDefaultAsync();

        /// <summary>
        /// Gets a single gender preferation by id
        /// </summary>
        /// <param name="genderPreferationID">the identifier</param>
        /// <returns></returns>
        public async Task<GenderPreferation> GetGenderPreferationByID(int genderPreferationID)
            =>
            await Context.GenderPreferations.Where(g => g.GenderPreferationID.Equals(genderPreferationID)).FirstOrDefaultAsync();

        /// <summary>
        /// Gets a single interest by id
        /// </summary>
        /// <param name="interestID">the identifier</param>
        /// <returns></returns>
        public async Task<Interest> GetInterestByID(int interestID)
            =>
            await Context.Interests.Where(i => i.InterestID.Equals(interestID)).FirstOrDefaultAsync();

        /// <summary>
        /// Gets a single movie by id
        /// </summary>
        /// <param name="movieID">the identifier</param>
        /// <returns></returns>
        public async Task<Movie> GetMovieByID(int movieID)
            =>
            await Context.Movies.Where(m => m.MovieID.Equals(movieID)).FirstOrDefaultAsync();

        /// <summary>
        /// Gets a single music genre by id
        /// </summary>
        /// <param name="musicID">the identifier</param>
        /// <returns></returns>
        public async Task<Music> GetMusicGenreByID(int musicID)
            =>
            await Context.Music.Where(m => m.MusicID.Equals(musicID)).FirstOrDefaultAsync();

        /// <summary>
        /// Gets a single profession by id
        /// </summary>
        /// <param name="professionID">the identifier</param>
        /// <returns></returns>
        public async Task<Profession> GetProfessionByID(int professionID)
            =>
            await Context.Professions.Where(p => p.ProfessionID.Equals(professionID)).FirstOrDefaultAsync();

        /// <summary>
        /// Gets a single relationtype by id
        /// </summary>
        /// <param name="relationID">the identifier</param>
        /// <returns></returns>
        public async Task<Relation> GetRelationByID(int relationID)
            =>
            await Context.Relations.Where(r => r.RelationID.Equals(relationID)).FirstOrDefaultAsync();
        #endregion

        //#region Get Relationships MAY NOT BE USED IF THE GENERIC METHODS WORK

        ///// <summary>
        ///// Gets the users cities of interest
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<UserCityRelation>> GetUserCities(int id)
        //    =>
        //    await Context.UserCityRelations.Where(u => u._User.Id.Equals(id)).ToListAsync();

        ///// <summary>
        ///// Gets the users educations
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<UserEducationRelation>> GetUserEducations(int id)
        //    =>
        //    await Context.UserEducationRelations.Where(u => u._User.Id.Equals(id)).ToListAsync();

        ///// <summary>
        ///// Gets the users preferred datinggender
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<UserGenderPreferationRelation>> GetUserGenderPreferations(int id)
        //    =>
        //    await Context.UserGenderPreferationRelations.Where(u => u._User.Id.Equals(id)).ToListAsync();

        ///// <summary>
        ///// Gets the users professions
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<UserProfessionRelation>> GetUserProfessions(int id)
        //    =>
        //    await Context.UserProfessionRelations.Where(u => u._User.Id.Equals(id)).ToListAsync();

        ///// <summary>
        ///// Gets the users relationships with other users
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<UserRelationRelation>> GetUserRelations(int id)
        //    =>
        //    await Context.UserRelationRelations.Where(u => u._FirstUser.Id.Equals(id)).ToListAsync();

        //#endregion

        #region Add

        /// <summary>
        /// Adds a new city to the database
        /// </summary>
        /// <param name="name">the name of the ciy</param>
        /// <returns></returns>
        public async Task AddCity(string name)
        {
            await Context.Cities.AddAsync(new City() { CityName = name });
            await Context.SaveChangesAsync();
        }


        /// <summary>
        /// Adds a new education to the database
        /// </summary>
        /// <param name="name">the name of the education</param>
        /// <returns></returns>
        public async Task AddEducation(string name)
            =>
            await Context.Educations.AddAsync(new Education() { EducationName = name });

        /// <summary>
        /// Adds a new food to the database
        /// </summary>
        /// <param name="name">the type of food</param>
        /// <returns></returns>
        public async Task AddFood(string name)
            =>
            await Context.Foods.AddAsync(new Food() { FoodName = name });

        /// <summary>
        /// Adds a new gender to the databse
        /// </summary>
        /// <param name="name">the type of gender</param>
        /// <returns></returns>
        public async Task AddGender(string name)
            =>
            await Context.Genders.AddAsync(new Gender { GenderType = name });

        /// <summary>
        /// WE MIGHT NOT NEED THIS
        /// Adds a new genderpreferation to the database
        /// </summary>
        /// <param name="name">the type of gender preferation</param>
        /// <returns></returns>
        public async Task AddGenderPreferation(string name)
            =>
            await Context.GenderPreferations.AddAsync(new GenderPreferation { GenderPreferationType = name });

        /// <summary>
        /// Adds a new interest to the database
        /// </summary>
        /// <param name="name">the name of the interest</param>
        /// <returns></returns>
        public async Task AddInterest(string name)
            =>
            await Context.Interests.AddAsync(new Interest { InterestName = name });

        /// <summary>
        /// Adds a new movie to the database
        /// </summary>
        /// <param name="name">the name of the movie</param>
        /// <returns></returns>
        public async Task AddMovie(string name)
            =>
            await Context.Movies.AddAsync(new Movie { MovieName = name });

        /// <summary>
        /// Adds a new music genre to the database
        /// </summary>
        /// <param name="name">the name of the genre</param>
        /// <returns></returns>
        public async Task AddMusic(string name)
            =>
            await Context.Music.AddAsync(new Music { MusicGenre = name });

        /// <summary>
        /// Adds a new profession to the database
        /// </summary>
        /// <param name="name">the name of the profession</param>
        /// <returns></returns>
        public async Task AddProfession(string name)
            =>
            await Context.Professions.AddAsync(new Profession { ProfessionName = name });

        /// <summary>
        /// Adds a new type of relation to the database
        /// </summary>
        /// <param name="name">the type of relation</param>
        /// <returns></returns>
        public async Task AddRelation(string name)
            =>
            await Context.Relations.AddAsync(new Relation { RelationType = name });

        #endregion

        //#region AddRelation MAY NOT BE USED IF THE GENERIC METHODS WORK

        ///// <summary>
        ///// Adds a relation between a user and city
        ///// </summary>
        ///// <param name="user">the user object</param>
        ///// <param name="city">the city object</param>
        ///// <returns></returns>
        //public async Task AddUserCity(User user, City city)
        //    =>
        //    await Context.UserCityRelations.AddAsync(new UserCityRelation { _User = user, _City = city });

        ///// <summary>
        ///// Adds a relation between a user and an education
        ///// </summary>
        ///// <param name="user">the user object</param>
        ///// <param name="education">the education object</param>
        ///// <returns></returns>
        //public async Task AddUserEducation(User user, Education education)
        //    =>
        //    await Context.UserEducationRelations.AddAsync(new UserEducationRelation { _User = user, _Education = education });

        ///// <summary>
        ///// Adds a relation between a user and a gender preferation
        ///// </summary>
        ///// <param name="user">the user object</param>
        ///// <param name="genderPreferation">the gender preferation object</param>
        ///// <returns></returns>
        //public async Task AddUserGenderPreferation(User user, GenderPreferation genderPreferation)
        //    =>
        //    await Context.UserGenderPreferationRelations.AddAsync(new UserGenderPreferationRelation { _User = user, _GenderPreferation = genderPreferation });

        ///// <summary>
        ///// Adds a relation between a user and an interest
        ///// </summary>
        ///// <param name="user">the user object</param>
        ///// <param name="interest">the interest object</param>
        ///// <returns></returns>
        //public async Task AddUserInterest(User user, Interest interest)
        //    =>
        //    await Context.UserIntrestsRelation.AddAsync(new UserInterestRelation { _User = user, _Interest = interest });

        ///// <summary>
        ///// Adds a relation between a user and a profession
        ///// </summary>
        ///// <param name="user">the user object</param>
        ///// <param name="profession">the profession object</param>
        ///// <returns></returns>
        //public async Task AddUserProfession(User user, Profession profession)
        //    =>
        //    await Context.UserProfessionRelations.AddAsync(new UserProfessionRelation { _User = user, _Profession = profession });

        ///// <summary>
        ///// Adds a relationship between two users
        ///// </summary>
        ///// <param name="firstUser">the first user object</param>
        ///// <param name="secondUser">the second user object</param>
        ///// <param name="relation">the relation object</param>
        ///// <returns></returns>
        //public async Task AddUserRelation(User firstUser, User secondUser, Relation relation)
        //    =>
        //    await Context.UserRelationRelations.AddAsync(new UserRelationRelation { _FirstUser = firstUser, _SecondUser = secondUser, _Relation = relation });

        //#endregion

        #region Update    

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

        #endregion

        #region Delete

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

        #endregion

        #region RemoveRelation

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


        #endregion
    }
}
