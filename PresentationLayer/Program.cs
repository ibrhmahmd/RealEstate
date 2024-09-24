using BusinessLayer.Services;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.GenericRepository;
using DataAccessLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace PresentationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Register PropertyService and UserService
            builder.Services.AddScoped<PropertyService>();  // Property service depends on IUnitOfWork and IMapper
            builder.Services.AddScoped<UserService>();      // User service depends on IUnitOfWork and IMapper

            // Register UnitOfWork and its implementation
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register the generic repository for different entities like User and Property
            builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            // Add DbContext (if you're using Entity Framework Core)
            builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
