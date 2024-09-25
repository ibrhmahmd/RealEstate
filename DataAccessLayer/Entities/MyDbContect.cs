using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;

public class MyDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }
   
    public DbSet<User> Users { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Address> Addresses { get; set; }
    


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().ToTable("Users");
    }
}
