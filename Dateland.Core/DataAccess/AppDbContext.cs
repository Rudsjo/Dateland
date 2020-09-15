namespace Dateland.Core
{
    // Required namespaces
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using System.Dynamic;

    public class AppDbContext : IdentityDbContext<User>
    {
        /// <summary>
        /// Gets or sets the intrests.
        /// </summary>
        public DbSet<Interest> Interests { get; set; }

        /// <summary>
        /// Gets or sets the user intrests.
        /// </summary>
        public DbSet<UserInterestRelation> UserIntrestsRelation { get; set; }

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
        /// Gets or sets the genderpreferations.
        /// </summary>
        public DbSet<GenderPreferation> GenderPreferations { get; set; }

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

        /// <summary>
        /// Gets or sets the user cities.
        /// </summary>
        public DbSet<UserCityRelation> UserCityRelations { get; set; }

        /// <summary>
        /// Gets or sets the user education.
        /// </summary>
        public DbSet<UserEducationRelation> UserEducationRelations { get; set; }

        /// <summary>
        /// Gets or sets the user gender preferation.
        /// </summary>
        public DbSet<UserGenderPreferationRelation> UserGenderPreferationRelations { get; set; }

        /// <summary>
        /// Gets or sets the user profession.
        /// </summary>
        public DbSet<UserProfessionRelation> UserProfessionRelations { get; set; }

        /// <summary>
        /// Gets or sets the user to user relationshit.
        /// </summary>
        public DbSet<UserRelationRelation> UserRelationRelations { get; set; }

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

            // Change the default name of the users table to "Users"
            builder.Entity<User>()
                        .ToTable("Users", "dbo");
        }
    }
}
