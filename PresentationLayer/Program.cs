using BusinessLayer.DTOModels;
using BusinessLayer.MappingProfiles;
using BusinessLayer.Services;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Register DbContext
        builder.Services.AddDbContext<MyDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Register Identity services using the default IdentityUser and IdentityRole
        builder.Services.AddIdentity<User, IdentityRole<Guid>>() // Use IdentityRole with Guid
            .AddEntityFrameworkStores<MyDbContext>() // Ensure it uses your ApplicationUser and IdentityRole
            .AddDefaultTokenProviders();

        // Add authentication services
        builder.Services.AddAuthentication("CookieScheme")
            .AddCookie("CookieScheme", options =>
            {
                options.LoginPath = "/Account/Login"; // Redirect to Login if not authenticated
                options.AccessDeniedPath = "/Account/AccessDenied"; // Set your access denied path
                options.ExpireTimeSpan = TimeSpan.FromDays(14); // Set expiration time for the cookie
                options.SlidingExpiration = true; // Reset the cookie expiration time on each request
            });

        // Register the UnitOfWork and services
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<PropertyService>();
        builder.Services.AddScoped<ContractService>();
        builder.Services.AddScoped<PaymentService>();
        builder.Services.AddScoped<AddressService>();

        // Add AutoMapper and mapping profile
        builder.Services.AddAutoMapper(typeof(MappingProfile));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        // Use Authentication and Authorization
        app.UseAuthentication(); // Add this line
        app.UseAuthorization(); // Add this line

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
