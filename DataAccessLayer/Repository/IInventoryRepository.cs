using Inventory.Data.Model;
using System.Collections.Generic;

namespace DataAccessLayer.Repository
{
    public interface IInventoryRepository
    {
        void Insert(List<string> List);
        void Update();
        void Delete();
        InventoryModel Get();
        InventoryModel GetById(int Id);

    }
}
