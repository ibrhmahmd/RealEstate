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
    public DbSet<Project> Projects{ get; set; }
    public DbSet<DeveloperCompany> DeveloperCompanies { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().ToTable("Users");

        // Explicitly configure the relationship between Contract and User for UserID and AgentID
        modelBuilder.Entity<Contract>()
            .HasOne(c => c.Occupant) // Relationship for UserID
            .WithMany()
            .HasForeignKey(c => c.OccupantId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes if needed

        modelBuilder.Entity<Contract>()
            .HasOne(c => c.Agent) // Relationship for AgentID
            .WithMany()
            .HasForeignKey(c => c.AgentId)
            .OnDelete(DeleteBehavior.Restrict); // Optional: Configure delete behavior
    }
}

