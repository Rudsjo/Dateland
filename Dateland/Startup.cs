namespace Dateland
{
    // Required namespaces
    using Dateland.Core;
    using Dateland.Core.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Security;

    /// <summary>
    /// Startup class
    /// </summary>
    public partial class Startup
    {
        #region Private Properties

        /// <summary>
        /// Set to true if the real email service should be used
        /// </summary>
        private bool UseEmailService => true;

        /// <summary>
        /// Gets the current connection to use.
        /// </summary>
        private string CurrentConnection { get => "SmarterConnection"; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            // Set the configurator
            Configuration = configuration;
        }

        #endregion

        #region Configuration

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add AppDbContext
            services.AddDbContextPool<AppDbContext>(
                o => o.UseSqlServer(Configuration.GetConnectionString(CurrentConnection),
                a => a.MigrationsAssembly("Dateland")).UseLazyLoadingProxies());

            // Add identity to the project
            services.AddIdentity<User, IdentityRole>(req =>
            {
                // Set the password options here
                req.Password.RequireNonAlphanumeric = false;
                req.Password.RequireUppercase = false;

                req.SignIn.RequireConfirmedEmail = true;

            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders().AddRoles<IdentityRole>();

            // Map our IReposirory to our GlobalReposirory class
            services.AddScoped<IRepository, GlobalRepository>();

            // If the mail credentials file exists
            if (File.Exists("mailcredentials.json") && UseEmailService)
            {
                // Create dictionary to hold all json properties
                Dictionary<string, string> fields = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("mailcredentials.json"));

                // Create a secure string to hold the email password
                SecureString password = new SecureString();

                // Loop through each characters in the password
                for (int i = 0; i < fields["password"].Length; i++)
                    // Append char to the seucre string
                    password.AppendChar(fields["password"][i]);

                // Map our IEmailService with our StandardEmailService
                services.AddSingleton<IEmailService>(mailService =>
                    new StandardEmailService(
                    new NetworkCredential()
                    {
                        UserName = fields["username"],
                        SecurePassword = password
                    }));
            }
            // else...
            else
            {
                // use the mock email service
                services.AddSingleton<IEmailService, MockEmailService>();
            }

            // Add Controllers
            services.AddControllersWithViews();

            // Add view models
            services.AddSingleton<ProfileViewModel>();

        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        } 

        #endregion
    }
}
