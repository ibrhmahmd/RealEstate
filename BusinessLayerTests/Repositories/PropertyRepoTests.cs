using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.DTOModels;

namespace DataAccessLayer.Repositories.Tests
{
    [TestClass]
    public class PropertyRepoTests
    {
        private MyDbContext _context;
        private PropertyRepo _repo;
        private IMapper _mapper;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "PropertyDatabase")
                .Options;

            _context = new MyDbContext(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Property, PropertyDTO>().ReverseMap();
            });
            _mapper = config.CreateMapper();

            _repo = new PropertyRepo(_context, _mapper);
        }







        [TestMethod]
        public async Task InsertAsync_ShouldAddProperty_WhenValidPropertyDTO()
        {
            var propertyDTO = new PropertyDTO
            {
                ID = Guid.NewGuid(),
                Name = "Test Property",
                Type = "Apartment",
                Area = 100.5m,
                Price = 250000m,
                IsAvailable = true,
                IsOccupied = false
            };
            await _repo.InsertAsync(propertyDTO);
            var propertyInDb = await _repo.GetByIdAsync(propertyDTO.ID);

            Assert.IsNotNull(propertyInDb);
            Assert.AreEqual(propertyDTO.Name, propertyInDb.Name);
            Assert.AreEqual(propertyDTO.Type, propertyInDb.Type);
            Assert.AreEqual(propertyDTO.Area, propertyInDb.Area);
            Assert.AreEqual(propertyDTO.Price, propertyInDb.Price);
            Assert.AreEqual(propertyDTO.IsAvailable, propertyInDb.IsAvailable);
            Assert.AreEqual(propertyDTO.IsOccupied, propertyInDb.IsOccupied);
        }




        [TestMethod]
        public async Task UpdateAsync_ShouldModifyProperty_WhenValidPropertyDTO()
        {
            var propertyDTO = new PropertyDTO
            {
                ID = Guid.NewGuid(),
                Name = "Test Property",
                Type = "Apartment",
                Area = 100.5m,
                Price = 250000m,
                IsAvailable = true,
                IsOccupied = false
            };

            await _repo.InsertAsync(propertyDTO);

            // Update the property
            propertyDTO.Name = "Updated Property";
            propertyDTO.Price = 300000m;

            await _repo.UpdateAsync(propertyDTO);
            var updatedProperty = await _repo.GetByIdAsync(propertyDTO.ID);

            Assert.IsNotNull(updatedProperty);
            Assert.AreEqual("Updated Property", updatedProperty.Name);
            Assert.AreEqual(300000m, updatedProperty.Price);
        }






        [TestMethod]
        public async Task GetByIdAsync_ShouldReturnNull_WhenPropertyDoesNotExist()
        {
            var nonExistentId = Guid.NewGuid();
            var property = await _repo.GetByIdAsync(nonExistentId);
            Assert.IsNull(property);
        }





        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
