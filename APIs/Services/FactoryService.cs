using ApplicationCore.DTOs.Request;
using ApplicationCore.Entities;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;


namespace APIs.Services
{
    public class FactoryService : SqlServerRepositoryProxy<Factory>, IFactoryService
    {

        public FactoryService(SqlServerRepository<Factory> sqlServerRepository) :base(sqlServerRepository)
        {
        }

        public async Task<List<Factory>> GetAllAsync()
        {
            return await _sqlServerRepository.Table.ToListAsync();
        }

        public async Task<Factory> GetByIdAsync(string id)
        {
            return await _sqlServerRepository.Table.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Factory> CreateAsync(FactoryDTO Factory)
        {
            var entity = await CreateAsync(new Factory { Id = Factory.Id, Name = Factory.Name });
            return entity;
        }

        public async Task UpdateAsync(string id, FactoryDTO Factory)
        {
            var entity = await GetByIdAsync(id);
            entity.Name = Factory.Name;
            await UpdateAsync(id, entity);
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            await DeleteAsync(id);
        }
    }
}