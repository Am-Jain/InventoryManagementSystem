using System;
using AutoMapper;
using NUnit.Framework;
using Inventory.Data.Model;

namespace TestInventoryManagementSystem.Inventory.Data
{
    [TestFixture]
    public class TestInventoryDataModel
    {
            protected readonly Type InventoryModelType = typeof(InventoryModel);
            private readonly IMapper _mapper;

            [Test]
            public virtual void ValidateInventoryModelStructure()
            {
                Assert.That(InventoryModelType.GetProperties(), Has.Length.EqualTo(5));

                Assert.That(InventoryModelType.HasPropertyOfType<int>(nameof(InventoryModel.Id)));
                Assert.That(InventoryModelType.HasPropertyOfType<string>(nameof(InventoryModel.Name)));
                Assert.That(InventoryModelType.HasPropertyOfType<string>(nameof(InventoryModel.Category)));
                Assert.That(InventoryModelType.HasPropertyOfType<string>(nameof(InventoryModel.Twitter)));
                Assert.That(InventoryModelType.HasPropertyOfType<string>(nameof(InventoryModel.Tag)));
            }

            [Test]
            public void TestNullInventoryModelIsMappedToNull()
            {
                //Arrange
                InventoryModel InventoryModel = null;

                //Act
                var InventoryModelDataModel = _mapper.Map<InventoryModel>(InventoryModel);

                //Act
                Assert.IsNull(InventoryModelDataModel);
            }


}
}
