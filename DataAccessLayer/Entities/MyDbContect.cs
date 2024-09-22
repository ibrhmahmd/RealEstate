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
   

    // Define DbSets here
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Resident> Residents { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Address> Addresse { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Admin>().ToTable("Admins");
        modelBuilder.Entity<Resident>().ToTable("Residents");
    }
 //delete
}
