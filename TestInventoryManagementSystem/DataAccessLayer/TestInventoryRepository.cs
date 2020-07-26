using DataAccessLayer.Repository;
using Moq;
using NUnit.Framework;
using IDbConnection = DataAccessLayer.IDbConnection;
using Inventory.Data.Model;

namespace TestInventoryManagementSystem.DataAccessLayer
{
    [TestFixture]
    public class TestInventoryRepository
    {
        private Mock<IDbConnection> _dbConnectionMock;
        private IInventoryRepository _repository;

        [SetUp]
        public void CreateApplicantEducationRepository()
        {
            _dbConnectionMock = new Mock<IDbConnection>();
            _repository = new InventoryRepository(_dbConnectionMock.Object);

    }
        [Test]
        public void TestGetById()
        {
            var inventoryModelTest = new InventoryModel()
            {
                Id = 1,
                Tag = "abc",
                Category = "CRM",
                Name = "Slack",
                Twitter = "SlackHq"
            };

            const int idToFind = 3;

            var inventoryModel = _repository.GetById(idToFind);

            Assert.NotNull(inventoryModel);
            Assert.AreEqual(inventoryModelTest, inventoryModel);
        }

        [Test]
        public void TestGetByIdReturnsNullIfNoResultsFound()
        {
            const int idToFind = 199;

            var inventoryModel =  _repository.GetById(idToFind);

            Assert.Null(inventoryModel);
        }
    }
}
