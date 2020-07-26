using BusinessLayer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryManagementSystem
{
    public class InventoryController : Controller
    {
        private IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            _inventoryService.CapterraDataProvider();
            _inventoryService.SoftwareAdviceDataProvider();
            //_inventoryService.NewClientDataProvider();
            return View();
        }
        
    }
}

