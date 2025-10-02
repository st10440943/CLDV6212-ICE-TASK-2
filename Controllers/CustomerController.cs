using AzureTableMVCApp.Models;
using AzureTableMVCApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzureTableMVCApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly TableStorageService _tableService;

        public CustomerController(TableStorageService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerEntity customer)
        {
            customer.PartitionKey = "Customer";
            customer.RowKey = Guid.NewGuid().ToString();
            _tableService.AddCustomer(customer);
            ViewBag.Message = "Customer added successfully!";
            return View();
        }
    }
}
