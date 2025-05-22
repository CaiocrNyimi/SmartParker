using Microsoft.EntityFrameworkCore;
using SmartParker.Domain.Entities;
using SmartParker.Domain.Interfaces;
using SmartParker.Infrastructure.Data;

namespace SmartParker.Infrastructure.Repositories
{
    public class SetorRepository : ISetorRepository
    {
        private readonly SmartParkerDbContext _context;

        public SetorRepository(SmartParkerDbContext context)
        {
            _context = context;
        }

        public async Task<Setor> AddAsync(Setor entity)
        {
            _context.Setores.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.Setores.FindAsync(id);
            if (entity == null) return false;

            _context.Setores.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Setor>> GetAllAsync()
        {
            return await _context.Setores.ToListAsync();
        }

        public async Task<Setor?> GetByIdAsync(long id)
        {
            return await _context.Setores.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Setor entity)
        {
            var exists = await _context.Setores.AnyAsync(e => e.Id == entity.Id);
            if (!exists) return false;

            _context.Setores.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
