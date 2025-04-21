using Microsoft.EntityFrameworkCore;
using Moq;
using MyWallet.Domain.Interfaces;
using MyWallet.Infrastructure.Context;
using MyWallet.Infrastructure.Repositories;

namespace MyWallet.Test
{
    public class BaseRepositoryTests
    {
        private readonly Mock<BaseDbContext> _mockContext;
        private readonly Mock<DbSet<TestEntity>> _mockDbSet;
        private readonly IBaseRepository<TestEntity> _repository;

        public BaseRepositoryTests()
        {
            _mockContext = new Mock<BaseDbContext>();
            _mockDbSet = new Mock<DbSet<TestEntity>>();

            _mockContext.Setup(c => c.Set<TestEntity>()).Returns(_mockDbSet.Object);

            _repository = new BaseRepository<TestEntity>(_mockContext.Object);
        }

        [Fact]
        public async Task AddEntity()
        {
            // Arrange
            var entity = new TestEntity { Id = 1,Name ="Jonatan" };

            // Act
            var result = await _repository.Add(entity);

            // Assert
            _mockDbSet.Verify(m => m.Add(entity), Times.Once);
            Assert.Equal(entity, result);
        }
    }
}