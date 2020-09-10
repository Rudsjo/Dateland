namespace Dateland.Test2
{
    // Required namespaces
    using System.Linq;
    using Dateland.Test2.Core;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<UserIntrestRelation>> GetUsersInterest(int id)
            =>
            await Context.UserIntrests.Where(u => u._User.UserID.Equals(id)).ToListAsync();
    }
}
