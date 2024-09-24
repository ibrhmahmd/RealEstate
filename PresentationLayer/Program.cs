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

            builder.Services.AddControllersWithViews();

            // Register AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




            builder.Services.AddScoped<PropertyService>();  
            builder.Services.AddScoped<UserService>();      

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



            // Register the generic repository for different entities like User and Property
            builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));





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
