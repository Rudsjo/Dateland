namespace Dateland.Test2.Core
{
    // Required namespaces
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the intrests.
        /// </summary>
        public DbSet<Interest> Interests { get; set; }

        /// <summary>
        /// Gets or sets the user intrests.
        /// </summary>
        public DbSet<UserInterestRelation> UserIntrests { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public AppDbContext(DbContextOptions options) : base(options) { }

    }
}
