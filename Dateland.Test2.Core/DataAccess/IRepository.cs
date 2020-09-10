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
    }
}
