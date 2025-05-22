using Microsoft.EntityFrameworkCore;
using SmartParker.Domain.Entities;
using SmartParker.Domain.Interfaces;
using SmartParker.Infrastructure.Data;

namespace SmartParker.Infrastructure.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        private readonly SmartParkerDbContext _context;

        public MotoRepository(SmartParkerDbContext context)
        {
            _context = context;
        }

        public async Task<Moto> AddAsync(Moto entity)
        {
            _context.Motos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.Motos.FindAsync(id);
            if (entity == null) return false;

            _context.Motos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Moto>> GetAllAsync()
        {
            return await _context.Motos.ToListAsync();
        }

        public async Task<Moto?> GetByIdAsync(long id)
        {
            return await _context.Motos.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Moto entity)
        {
            var exists = await _context.Motos.AnyAsync(e => e.Id == entity.Id);
            if (!exists) return false;

            _context.Motos.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}