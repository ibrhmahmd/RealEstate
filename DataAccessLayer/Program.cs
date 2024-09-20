using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace DataAccessLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Build configuration to read appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())  // Set the base path for appsettings.json
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)  // Load appsettings.json
                .Build();

            // Set up the service collection and configure the DbContext with the connection string
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);

            // Create a service provider to resolve services
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Example usage: Resolving DbContext and performing a database operation
            using (var context = serviceProvider.GetService<MyDbContext>())
            {
                Console.WriteLine("Database context configured successfully!");
                // Example: Query the database here
            }

            Console.ReadLine(); // Keep the console window open
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext with the connection string from appsettings.json
            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Add other services if needed
        }
    }
}
