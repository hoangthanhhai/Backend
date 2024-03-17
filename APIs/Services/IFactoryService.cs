using ApplicationCore.DTOs.Request;
using ApplicationCore.Entities;

namespace APIs.Services
{
    public interface IFactoryService
    {
        Task<List<Factory>> GetAllAsync();
        Task<Factory> GetByIdAsync(string id);
        Task<Factory> CreateAsync(FactoryDTO Factory);
        Task UpdateAsync(string id, FactoryDTO Factory);
        Task DeleteAsync(string id);
    }
}