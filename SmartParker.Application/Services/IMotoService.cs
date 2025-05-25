using SmartParker.Application.DTOs;

namespace SmartParker.Application.Services
{
    public interface IMotoService
    {
        Task<List<MotoDto>> GetAllAsync();
        Task<MotoDto?> GetByIdAsync(long id);
        Task<IEnumerable<MotoDto>> SearchByNomeAsync(string nome);
        Task<MotoDto> CreateAsync(MotoDto moto);
        Task<bool> UpdateAsync(long id, MotoUpdateDto dto);
        Task<bool> DeleteAsync(long id);
    }
}