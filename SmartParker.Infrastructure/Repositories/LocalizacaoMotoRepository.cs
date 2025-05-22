using Microsoft.EntityFrameworkCore;
using SmartParker.Domain.Entities;
using SmartParker.Domain.Interfaces;
using SmartParker.Infrastructure.Data;

namespace SmartParker.Infrastructure.Repositories
{
    public class LocalizacaoMotoRepository : ILocalizacaoMotoRepository
    {
        private readonly SmartParkerDbContext _context;

        public LocalizacaoMotoRepository(SmartParkerDbContext context)
        {
            _context = context;
        }

        public async Task<LocalizacaoMoto> AddAsync(LocalizacaoMoto entity)
        {
            _context.Localizacoes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.Localizacoes.FindAsync(id);
            if (entity == null) return false;

            _context.Localizacoes.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<LocalizacaoMoto>> GetAllAsync()
        {
            return await _context.Localizacoes.ToListAsync();
        }

        public async Task<LocalizacaoMoto?> GetByIdAsync(long id)
        {
            return await _context.Localizacoes.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(LocalizacaoMoto entity)
        {
            var exists = await _context.Localizacoes.AnyAsync(e => e.Id == entity.Id);
            if (!exists) return false;

            _context.Localizacoes.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
