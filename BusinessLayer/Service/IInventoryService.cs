using Inventory.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IInventoryService
    {
        void CapterraDataProvider();
        void SoftwareAdviceDataProvider();

        //void NewClientDataProvider();

        List<string> GetDataFromFilePath(string FilePath, string Provider);

    }
}
