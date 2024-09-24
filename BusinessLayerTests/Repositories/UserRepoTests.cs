using AutoMapper;
using BusinessLayer.DTOModels;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Tests
{
    [TestClass]
    public class UserRepoTests
    {
        private MyDbContext _context;
        private IMapper _mapper;
        private UserRepo _userRepo;


        [TestInitialize]
        public void Setup()
        {
            // Set up DbContext with in-memory database
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new MyDbContext(options);

            // Set up the mapper configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
            });
            _mapper = config.CreateMapper();


            // Instantiate the repository with the real DbContext and mapper
            _userRepo = new UserRepo(_context, _mapper);
        }








        [TestMethod]
        public async Task InsertAsync_ShouldAddUserToDatabase()
        {
            // Arrange
            var userDto = new UserDTO { Id = Guid.NewGuid(), UserName = "newuser" };

            // Act
            await _userRepo.InsertAsync(userDto);

            // Assert
            var userInDb = await _context.Users.FindAsync(userDto.Id);
            Assert.IsNotNull(userInDb); // Verify user was added
            Assert.AreEqual("newuser", userInDb.UserName); // Verify username is correct
        }








        [TestMethod]
        public async Task GetAllAsync_ShouldReturnAllUsers()
        {
            // Arrange
            var users = new[]
            {
                new User { Id = Guid.NewGuid(), UserName = "user1", IsDeleted = false },
                new User { Id = Guid.NewGuid(), UserName = "user2", IsDeleted = false }
            };

            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();

            // Act
            var result = await _userRepo.GetAllAsync();

            // Assert
            Assert.AreEqual(2, result.Count()); // Ensure all users are returned
            Assert.AreEqual("user1", result.First().UserName); // Verify the first user
        }








        [TestMethod]
        public async Task GetByIdAsync_ShouldReturnUserById()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new User { Id = userId, UserName = "testuser", IsDeleted = false };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            // Act
            var result = await _userRepo.GetByIdAsync(userId);

            // Assert
            Assert.IsNotNull(result); // Ensure the user is found
            Assert.AreEqual("testuser", result.UserName); // Verify the username
        }





        [TestMethod]
        public async Task SoftDeleteAsync_ShouldMarkUserAsDeleted()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new User { Id = userId, UserName = "testuser", IsDeleted = false };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            // Act
            await _userRepo.SoftDeleteAsync(userId);

            // Assert
            var userInDb = await _context.Users.FindAsync(userId);
            Assert.IsTrue(userInDb.IsDeleted); // Verify the user is marked as deleted
        }






        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted(); // Clean up the database after each test
            _context.Dispose(); // Dispose of the context
        }
    }
}
