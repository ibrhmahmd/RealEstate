using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

public class MyDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public DbSet<Property> Properties { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<DeveloperCompany> DeveloperCompanies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Identity User table to use "Users" instead of the default "AspNetUsers"
        modelBuilder.Entity<User>().ToTable("Users");

        // Explicitly configure the relationship between Contract and User for UserID and AgentID
        modelBuilder.Entity<Contract>()
            .HasOne(c => c.Occupant)
            .WithMany()
            .HasForeignKey(c => c.OccupantId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes if needed

        modelBuilder.Entity<Contract>()
            .HasOne(c => c.Agent)
            .WithMany()
            .HasForeignKey(c => c.AgentId)
            .OnDelete(DeleteBehavior.Restrict);

        Guid systemUserId = Guid.NewGuid();  // Replace with actual system user ID

        modelBuilder.Entity<Address>().HasData(
            new Address { Id = Guid.NewGuid(), City = "Cairo", State = "Cairo", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Alexandria", State = "Alexandria", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Giza", State = "Giza", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Benha", State = "Qalyubia", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Mansoura", State = "Dakahlia", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Damietta", State = "Damietta", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Port Said", State = "Port Said", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Ismailia", State = "Ismailia", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Zagazig", State = "Sharqia", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Kafr El Sheikh", State = "Kafr El Sheikh", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Tanta", State = "Gharbia", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Shibin El Kom", State = "Monufia", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Beni Suef", State = "Beni Suef", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Fayoum", State = "Fayoum", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Asyut", State = "Asyut", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Sohag", State = "Sohag", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Qena", State = "Qena", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Luxor", State = "Luxor", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Aswan", State = "Aswan", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Hurghada", State = "Red Sea", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Sharm El Sheikh", State = "South Sinai", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Arish", State = "North Sinai", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Marsa Matruh", State = "Matrouh", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Kharga", State = "New Valley", CreatedBy = systemUserId },
            new Address { Id = Guid.NewGuid(), City = "Suez", State = "Suez", CreatedBy = systemUserId }
            );
    }



}
