using Microsoft.EntityFrameworkCore;
using SmartParker.Domain.Entities;
using SmartParker.Domain.Interfaces;
using SmartParker.Infrastructure.Data;

namespace SmartParker.Infrastructure.Repositories
{
    public class PatioRepository : IPatioRepository
    {
        private readonly SmartParkerDbContext _context;

        public PatioRepository(SmartParkerDbContext context)
        {
            _context = context;
        }

        public async Task<Patio> AddAsync(Patio entity)
        {
            _context.Patios.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.Patios.FindAsync(id);
            if (entity == null) return false;

            _context.Patios.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Patio>> GetAllAsync()
        {
            return await _context.Patios.ToListAsync();
        }

        public async Task<Patio?> GetByIdAsync(long id)
        {
            return await _context.Patios.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Patio entity)
        {
            var exists = await _context.Patios.AnyAsync(e => e.Id == entity.Id);
            if (!exists) return false;

            _context.Patios.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}