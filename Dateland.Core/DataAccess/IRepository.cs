namespace Dateland.Core
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
        /// Gets the potential matches count.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        abstract int GetPotentialMatchesCount(string userId);

        /// <summary>
        /// Gets the matching users.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        abstract Task<IDictionary<User, List<string>>> GetMatchingUsers(string userId, List<string> usersToSkip);

        /// <summary>
        /// Gets the pending requests.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        abstract Task<IEnumerable<User>> GetPendingRequests(string userId);

        #region Generic Add,Update and delete

        /// <summary>
        /// Generic function to create a new entity
        /// </summary>
        /// <typeparam name="T">The class to base the object from</typeparam>
        /// <param name="entity">the name of the entity</param>
        /// <returns></returns>
        abstract Task<T> Create<T>(T entity)
            where T : class;

        /// <summary>
        /// Generic function to update a new entity
        /// </summary>
        /// <typeparam name="T">the class of object to update</typeparam>
        /// <param name="entity">the object</param>
        /// <returns></returns>
        abstract Task<T> Update<T>(T entity)
            where T : class;

        /// <summary>
        /// Generic function to deleta an entity
        /// </summary>
        /// <typeparam name="T">the class of object to delete</typeparam>
        /// <param name="entity">the object</param>
        /// <returns></returns>
        abstract Task<T> Delete<T>(T entity)
            where T : class;

        /// <summary>
        /// Generic function to get all objects of a specified type
        /// </summary>
        /// <typeparam name="T">the class of object to get</typeparam>
        /// <returns></returns>
        abstract Task<ICollection<T>> GetAll<T>()
            where T : class;

        /// <summary>
        /// Generic function to get a single object of a desired type
        /// </summary>
        /// <typeparam name="T">the class of object to return</typeparam>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        abstract Task<T> GetByID<T>(int id)
            where T : class;

        /// <summary>
        /// Generic function to get a users relation of a specified type
        /// </summary>
        /// <typeparam name="T">the class of relation</typeparam>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        abstract Task<ICollection<T>> GetRelation<T>(string id)
            where T : class;

        /// <summary>
        /// Generic function to create a relation of a specified type
        /// </summary>
        /// <typeparam name="T">the class of relation</typeparam>
        /// <param name="relation">the relation object</param>
        /// <returns></returns>
        abstract Task<T> CreateRelation<T>(T relation)
            where T : class;

        /// <summary>
        /// Generic function to remove a relation of a specified type
        /// </summary>
        /// <typeparam name="T">the class of relation</typeparam>
        /// <param name="relation">the relation object</param>
        /// <returns></returns>
        abstract Task<T> RemoveRelation<T>(T relation)
            where T : class;

        #endregion
    }
}
