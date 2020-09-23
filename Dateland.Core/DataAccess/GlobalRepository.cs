namespace Dateland.Core
{
    // Required namespaces
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;
    using System;
    using Dateland.Core.Models;
    using System.Security.Cryptography.X509Certificates;
    using System.Runtime.CompilerServices;

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
        public async Task<IDictionary<User, List<string>>> GetMatchingUsers(string userId, List<string> usersToSkip)
        {
            // Create the result object
            Dictionary<User, List<string>> result = new Dictionary<User, List<string>>();

            // Get the current user
            var currentUser = Context.Users.FirstOrDefault(u => u.Id.Equals(userId));

            // If the user does'nt exist...
            if (currentUser == null)
                // return an empty list
                return result;

            // Get all user identifiers
            var useridentifiers = Context.Users.Select(u => u.Id).Where(i => !usersToSkip.Contains(i)).ToList();

            // The minimum required matches
            int RequiredMatches = 3;

            // Loop through until enough matches has been made
            while(RequiredMatches >= 0)
            {
                // Loop through all users in the database
                for (int i = 0; i < useridentifiers.Count(); i++)
                {
                    // Get the user with the current id
                    var user = await Context.Users.FirstOrDefaultAsync(u => u.Id.Equals(useridentifiers[i]));

                    // If the user is'nt null and is'nt me
                    if (user != null && user.Id.CompareTo(currentUser.Id) != 0)
                    {
                        // We both must prefer each others genders
                        if (user.GenderPreferation.Equals(currentUser.Gender) && currentUser.GenderPreferation.Equals(user.Gender))
                        {
                            // Create a new list that will hold the matched parameters
                            List<string> matchedParameters = new List<string>();

                            // If the required matches is 0...
                            if (RequiredMatches.Equals(0))
                            {
                                // Remove the current user from the list of identifiers
                                useridentifiers.Remove(user.Id);
                                // Add the user to the result
                                result.Add(user, matchedParameters);
                                // Skip the rest
                                continue;
                            }

                            // Check if we both like the same music
                            if (user.Music.MusicID.Equals(currentUser.Music.MusicID)) matchedParameters.Add(currentUser.Music.MusicGenre); 
                            // Check if we both like the same food
                            if (user.Food.FoodID.Equals(currentUser.Food.FoodID))     matchedParameters.Add(currentUser.Food.FoodName);
                            // Check if we both like the same movie
                            if (user.Movie.MovieID.Equals(currentUser.Movie.MovieID)) matchedParameters.Add(currentUser.Movie.MovieName);
                            // Check if we both have the same education
                            if (user.Education.EducationID.Equals(currentUser.Education.EducationID)) matchedParameters.Add(currentUser.Education.EducationName);

                            // Check if we have any same interests
                            foreach (var interest in currentUser.UserInterests)
                                // If the other user have the same interest as me...
                                if (user.UserInterests.Contains(interest))
                                    // Add the interest to the matched parameters
                                    matchedParameters.Add(interest.Interest.InterestName);

                            // If user is a match
                            if (matchedParameters.Count >= RequiredMatches)
                            {
                                // Remove the current user from the list of identifiers
                                useridentifiers.Remove(user.Id);
                                // Add the user to the result
                                result.Add(user, matchedParameters);
                            }


                            // If 6 matches has been made
                            if (result.Count == 6)
                                // Break out of the loop
                                return result;
                        }
                    }
                }
                // If not enough matches was found, decreased the minimum required match set
                RequiredMatches--;
            }

            // Return the result
            return result;
        }

        public async Task<IEnumerable<User>> GetPendingRequests(string userId)
        {
            // Create the result object
            List<User> result = new List<User>();

            // If the user does'nt exist...
            if (userId == null)
                // return an empty list
                return result;

            // Gets the pending relations for the user
            var userRelations = (await Context.Set<UserRelations>().ToListAsync()).Where(x => x.RelationID1.Equals(2) && x.User2Id.Equals(userId)).Select(x => x.User1Id);

            // Loop through the pending relations and get the user
            foreach (var user in userRelations)
            {
                // Add the user to a list
                result.Add(await Context.FindAsync<User>(user));
            }

            // Return the list of users
            return result;
        }

        #region Generic Add, Update, Delete

        /// <summary>
        /// Generic function to create a new entity
        /// </summary>
        /// <typeparam name="T">The class to base the object from</typeparam>
        /// <param name="entity">the name of the entity</param>
        /// <returns></returns>
        public async Task<T> Create<T>(T entity)
            where T : class
        {

            await Context.Set<T>().AddAsync(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Generic function to update a new entity
        /// </summary>
        /// <typeparam name="T">the class of object to update</typeparam>
        /// <param name="entity">the object</param>
        /// <returns></returns>
        public async Task<T> Update<T>(T entity)
            where T : class
        {
            Context.Set<T>().Update(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Generic function to deleta an entity
        /// </summary>
        /// <typeparam name="T">the class of object to delete</typeparam>
        /// <param name="entity">the object</param>
        /// <returns></returns>
        public async Task<T> Delete<T>(T entity)
             where T : class
        {
            Context.Set<T>().Remove(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Generic function to get all objects of a specified type
        /// </summary>
        /// <typeparam name="T">the class of object to get</typeparam>
        /// <returns></returns>
        public async Task<ICollection<T>> GetAll<T>()
            where T : class
        {
            return await Context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Generic function to get a single object of a desired type
        /// </summary>
        /// <typeparam name="T">the class of object to return</typeparam>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        public async Task<T> GetByID<T>(int id)
            where T : class
        {
            return await Context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Generic function to get a users relation of a specified type
        /// </summary>
        /// <typeparam name="T">the class of relation</typeparam>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        public async Task<ICollection<T>> GetRelation<T>(string id)
            where T : class
        {
            return await Context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Generic function to create a relation of a specified type
        /// </summary>
        /// <typeparam name="T">the class of relation</typeparam>
        /// <param name="relation">the relation object</param>
        /// <returns></returns>
        public async Task<T> CreateRelation<T>(T relation)
            where T : class
        {
            await Context.Set<T>().AddAsync(relation);

            await Context.SaveChangesAsync();

            return relation;
        }

        /// <summary>
        /// Generic function to remove a relation of a specified type
        /// </summary>
        /// <typeparam name="T">the class of relation</typeparam>
        /// <param name="relation">the relation object</param>
        /// <returns></returns>
        public async Task<T> RemoveRelation<T>(T relation)
            where T : class
        {
            Context.Set<T>().Remove(relation);

            await Context.SaveChangesAsync();

            return relation;
        }

        #endregion

    }
}
