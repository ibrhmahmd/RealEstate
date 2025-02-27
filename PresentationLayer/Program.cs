using BusinessLayer.MappingProfiles;
using BusinessLayer.Services;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer;
using DataAccessLayer.UnitOfWork;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.Controllers;
using System.Security.Claims;

namespace PresentationLayer
{
    public class Program
    {
        public static async Task Main(string[] args) // Changed to async Task
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register DbContext
            builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Configure Identity to use our custom User class and IdentityRole
            builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
                options.ClaimsIdentity.RoleClaimType = ClaimTypes.Role;  // Ensure roles are correctly included
            })
            .AddEntityFrameworkStores<MyDbContext>()
            .AddDefaultTokenProviders();

            // Register the UnitOfWork and services
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped< UserService>();
            builder.Services.AddScoped<PropertyService>();
            builder.Services.AddScoped<ContractService>();
            builder.Services.AddScoped< PaymentService>();
            builder.Services.AddScoped< DeveloperCompanyService>();
            builder.Services.AddScoped< ProjectService>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));


            // Add AutoMapper and mapping profile
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Optional: Configure role manager service
            builder.Services.AddScoped<RoleManager<IdentityRole<Guid>>>();

            var app = builder.Build();

            // Seed the database
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    // Get the necessary services
                    var userService = services.GetRequiredService<UserService>();
                    var signInManager = services.GetRequiredService<SignInManager<User>>();
                    var web = services.GetRequiredService<IWebHostEnvironment>();
                    // Create the AccountController with the resolved services
                    var accountController = new AccountController(userService, signInManager,web);

                    // Call the method to seed the admin user
                    await accountController.SeedAdminUser();
         
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication(); // Ensure authentication is used
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
