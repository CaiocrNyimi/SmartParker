using SmartParker.Domain.Entities;

namespace SmartParker.Domain.Interfaces
{
    public interface IMotoRepository
    {
        Task<IEnumerable<Moto>> GetAllAsync();
        Task<Moto?> GetByIdAsync(long id);
        Task<IEnumerable<Moto>> SearchByNomeAsync(string nome);
        Task<Moto> AddAsync(Moto entity);
        Task<bool> UpdateAsync(Moto entity);
        Task<bool> DeleteAsync(long id);
    }
}