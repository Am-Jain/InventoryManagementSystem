using BusinessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestInventoryManagementSystem
{
    public class TestInventoryService
    {
        private Mock<IInventoryRepository> _inventoryRepositoryMock;
        private Mock<IFileReader> _fileReaderMock;
        private Mock<IInventoryDatabaseSettings> _inventoryDatabaseSettingsMock;

        private IInventoryService _service;

        [SetUp]
        public void SetupService()
        {
            _inventoryRepositoryMock = new Mock<IInventoryRepository>();
            _fileReaderMock = new Mock<IFileReader>();
            _inventoryDatabaseSettingsMock = new Mock<IInventoryDatabaseSettings>();
            _service = new InventoryService(_inventoryRepositoryMock.Object, _inventoryDatabaseSettingsMock.Object, _fileReaderMock.Object);
        }


        [Test]
        public void TestGetDataFromFilePathReturnsOneRecordIfNoFileFoundOnFilePath()
        {
            //Arrange
            string filePath = "";
            string provider = "";

            //Act
            List<string> list = _service.GetDataFromFilePath(filePath, provider);

            //Assert
            Assert.AreEqual(list.Count, 1);
        }

        [Test]

        public void TestGetDataFromFilePathReturnsNoFileFoundStringIfNoFileFoundOnFilePath()
        {
            //Arrange
            string filePath = "C:\\Users\\amit.jain2\\Downloads\\software engineer\\software engineer\\coding\\feed-products";
            string provider = "abc";
            string resultString = "No file found in the directory";

            //Act
            List<string> list = _service.GetDataFromFilePath(filePath, provider);

            //Assert
            Assert.AreEqual(list.Count, 1);
            Assert.AreEqual(list[0], resultString);
        }

        [Test]
        public void TestGetDataFromFilePathReturnsNoDataFoundInFileStringIfNoDataFoundInFile()
        {
            //Arrange
            string filePath = "C:\\Users\\amit.jain2\\Downloads\\software engineer\\software engineer\\coding\\feed-products";
            string provider = "abc";
            string resultString = "No Data found in the file";

            //Act
            List<string> list = _service.GetDataFromFilePath(filePath, provider);

            //Assert
            Assert.AreEqual(list.Count, 1);
            Assert.AreEqual(list[0], resultString);
        }
    }
}
