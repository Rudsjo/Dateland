namespace Dateland.Core
{
    // Required namespaces
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Dateland.Core.Models;

    public class AppDbContext : IdentityDbContext<User>
    {
        /// <summary>
        /// Gets or sets the intrests.
        /// </summary>
        public DbSet<Interest> Interests { get; set; }

        #region Added by Marcus

        /// <summary>
        /// Gets or sets the cities.
        /// </summary>
        public DbSet<City> Cities { get; set; }

        /// <summary>
        /// Gets or sets the educations.
        /// </summary>
        public DbSet<Education> Educations { get; set; }

        /// <summary>
        /// Gets or sets the Foods.
        /// </summary>
        public DbSet<Food> Foods { get; set; }

        /// <summary>
        /// Gets or sets the genders.
        /// </summary>
        public DbSet<Gender> Genders { get; set; }

        /// <summary>
        /// Gets or sets the Movies.
        /// </summary>
        public DbSet<Movie> Movies { get; set; }

        /// <summary>
        /// Gets or sets the Music.
        /// </summary>
        public DbSet<Music> Music { get; set; }

        /// <summary>
        /// Gets or sets the professions.
        /// </summary>
        public DbSet<Profession> Professions { get; set; }

        /// <summary>
        /// Gets or sets the relations.
        /// </summary>
        public DbSet<Relation> Relations { get; set; }

        public DbSet<UserInterest> UserInterests { get; set; }

        public DbSet<UserRelations> UserRelations { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public AppDbContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Configures the schema needed for the identity framework.
        /// </summary>
        /// <param name="builder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Call the base class
            base.OnModelCreating(builder);

            // Sets the primary keys for the user intrests table
            builder.Entity<UserInterest>().HasKey(x => new { x.UserID, x.InterestID });

            // Change the default name of the users table to "Users"
            builder.Entity<User>()
                        .ToTable("Users", "dbo");

            #region UserInterests

            builder.Entity<UserInterest>()
                .HasOne<User>  (x => x.User)
                .WithMany      (x => x.UserInterests)
                .HasForeignKey (x => x.UserID);

            builder.Entity<UserInterest>()
                .HasOne<Interest> (x => x.Interest)
                .WithMany         (x => x.UserInterests)
                .HasForeignKey    (x => x.InterestID);

            #endregion
        }
    }
}
