using Azure.Data.Tables;
using AzureTableMVCApp.Models;

namespace AzureTableMVCApp.Services
{
    public class TableStorageService
    {
        private readonly TableClient _tableClient;

        public TableStorageService(IConfiguration configuration)
        {
            // Read connection string from appsettings.json
            string connectionString = configuration["StorageAccount:ConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString), "Azure Storage connection string is missing!");

            // Use the connection string here
            _tableClient = new TableClient(connectionString, "Customers");
            _tableClient.CreateIfNotExists();
        }

        public void AddCustomer(CustomerEntity customer)
        {
            _tableClient.AddEntity(customer);
        }
    }
}
