using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        // Seed roles
        string adminRole = "Admin";
        if (!await roleManager.RoleExistsAsync(adminRole))
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>(adminRole));
        }

        // Seed admin user
        var adminUser = new User
        {
            Email = "admin",
            UserName = "admin@a.com",
            // You can add additional properties if needed
        };

        var passwordHasher = new PasswordHasher<User>();
        var hashedPassword = passwordHasher.HashPassword(adminUser, "Admin123");

        // Assign the hashed password to the user
        adminUser.PasswordHash = hashedPassword;

        // Check if the user already exists
        var existingUser = await userManager.FindByEmailAsync(adminUser.Email);
        if (existingUser == null)
        {
            await userManager.CreateAsync(adminUser);
            await userManager.AddToRoleAsync(adminUser, adminRole);
        }
    }
}
