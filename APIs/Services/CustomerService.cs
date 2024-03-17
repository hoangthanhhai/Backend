using APIs.Configurations;
using ApplicationCore.Entities;
using Infrastructure.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace APIs.Services
{
    public class CustomerService : ICustomerService//MongoDbRepository<Customer>, ICustomerService
    {
        private readonly IMongoCollection<Customer> _customer;
        private readonly DeveloperDatabaseConfiguration _settings;

        public CustomerService(IOptions<DeveloperDatabaseConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _customer = database.GetCollection<Customer>(_settings.CustomerCollectionName);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _customer.Find(c => true).ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(string id)
        {
            return await _customer.Find<Customer>(c => c.Id == null).FirstOrDefaultAsync();
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            await _customer.InsertOneAsync(customer);
            return customer;
        }

        public async Task UpdateAsync(string id, Customer customer)
        {
            await _customer.ReplaceOneAsync(c => c.Id == null, customer);
        }

        public async Task DeleteAsync(string id)
        {
            await _customer.DeleteOneAsync(c => c.Id == null);
        }
    }
}