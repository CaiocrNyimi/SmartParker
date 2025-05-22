using SmartParker.Application.DTOs;

namespace SmartParker.Application.Services
{
    public interface IMotoService
    {
        Task<List<MotoDto>> GetAllAsync();
        Task<MotoDto?> GetByIdAsync(long id);
        Task<MotoDto> CreateAsync(MotoDto moto);
        Task<bool> UpdateAsync(MotoDto moto);
        Task<bool> DeleteAsync(long id);
    }
}