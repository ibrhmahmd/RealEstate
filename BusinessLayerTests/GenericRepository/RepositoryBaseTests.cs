using BusinessLayer.GenericRepository;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.RepositoryTests
{
    [TestClass]
    public class RepositoryBaseInMemoryTests
    {
        private MyDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
                          .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique in-memory DB for each test
                          .Options;

            var context = new MyDbContext(options);
            return context;
        }

        [TestMethod]
        public async Task InsertAsync_ValidProperty_AddsEntity()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            var repository = new RepositoryBase<Property>(context);

            var property = new Property
            {
                ID = Guid.NewGuid(),
                Name = "Property1",
                AddressID = Guid.NewGuid(), // Mock Address ID
                Type = "Apartment",
                Area = 100,
                Price = 200000,
                IsAvailable = true,
                IsOccupied = false,
                Contracts = new List<Contract>() // Assuming Contract is a valid entity
            };

            // Act
            await repository.InsertAsync(property);
            var result = await repository.GetAllAsync();

            // Assert
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Property1", result.First().Name);
        }





        [TestMethod]
        public async Task GetAllAsync_ReturnsAllEntities()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            var repository = new RepositoryBase<Property>(context);

            context.Properties.Add(new Property
            {
                ID = Guid.NewGuid(),
                Name = "Property1",
                AddressID = Guid.NewGuid(),
                Type = "Apartment",
                Area = 100,
                Price = 200000,
                IsAvailable = true,
                IsOccupied = false,
                Contracts = new List<Contract>()
            });
            context.Properties.Add(new Property
            {
                ID = Guid.NewGuid(),
                Name = "Property2",
                AddressID = Guid.NewGuid(),
                Type = "House",
                Area = 150,
                Price = 300000,
                IsAvailable = true,
                IsOccupied = false,
                Contracts = new List<Contract>()
            });
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.AreEqual(2, result.Count());
        }




        [TestMethod]
        public async Task GetByIdAsync_ReturnsCorrectEntity()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            var repository = new RepositoryBase<Property>(context);

            var id = Guid.NewGuid();
            context.Properties.Add(new Property
            {
                ID = id,
                Name = "Property1",
                AddressID = Guid.NewGuid(),
                Type = "Apartment",
                Area = 100,
                Price = 200000,
                IsAvailable = true,
                IsOccupied = false,
                Contracts = new List<Contract>()
            });
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetByIdAsync(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Property1", result.Name);
        }



        [TestMethod]
        public async Task HardDeleteAsync_RemovesEntity()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            var repository = new RepositoryBase<Property>(context);

            var id = Guid.NewGuid();
            var property = new Property
            {
                ID = id,
                Name = "Property1",
                AddressID = Guid.NewGuid(),
                Type = "Apartment",
                Area = 100,
                Price = 200000,
                IsAvailable = true,
                IsOccupied = false,
                Contracts = new List<Contract>()
            };
            context.Properties.Add(property);
            await context.SaveChangesAsync();

            // Act
            await repository.HardDeleteAsync(id);
            var result = await repository.GetAllAsync();

            // Assert
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public async Task SoftDeleteAsync_SetsIsAvailableToFalse()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            var repository = new RepositoryBase<Property>(context);

            var id = Guid.NewGuid();
            var property = new Property
            {
                ID = id,
                Name = "Property1",
                AddressID = Guid.NewGuid(),
                Type = "Apartment",
                Area = 100,
                Price = 200000,
                IsAvailable = true,
                IsOccupied = false,
                Contracts = new List<Contract>()
            };
            context.Properties.Add(property);
            await context.SaveChangesAsync();

            // Act
            await repository.SoftDeleteAsync(id);
            var result = await repository.GetByIdAsync(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsAvailable);
        }

        [TestMethod]
        public async Task UpdateAsync_UpdatesEntity()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            var repository = new RepositoryBase<Property>(context);

            var id = Guid.NewGuid();
            var property = new Property
            {
                ID = id,
                Name = "Property1",
                AddressID = Guid.NewGuid(),
                Type = "Apartment",
                Area = 100,
                Price = 200000,
                IsAvailable = true,
                IsOccupied = false,
                Contracts = new List<Contract>()
            };
            context.Properties.Add(property);
            await context.SaveChangesAsync();

            // Act
            property.Name = "UpdatedProperty";
            await repository.UpdateAsync(property);
            var result = await repository.GetByIdAsync(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("UpdatedProperty", result.Name);
        }

        [TestMethod]
        public async Task GetByNameAsync_ReturnsCorrectEntity()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            var repository = new RepositoryBase<Property>(context);

            context.Properties.Add(new Property
            {
                ID = Guid.NewGuid(),
                Name = "Property1",
                AddressID = Guid.NewGuid(),
                Type = "Apartment",
                Area = 100,
                Price = 200000,
                IsAvailable = true,
                IsOccupied = false,
                Contracts = new List<Contract>()
            });
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetByNameAsync("Property1");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Property1", result.First().Name);
        }
    }
}
