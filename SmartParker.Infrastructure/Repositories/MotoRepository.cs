using SmartParker.Domain.Entities;
using SmartParker.Domain.Interfaces;
using SmartParker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SmartParker.Infrastructure.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        private readonly SmartParkerDbContext _context;

        public MotoRepository(SmartParkerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Moto>> GetAllAsync()
        {
            return await _context.Motos.ToListAsync();
        }

        public async Task<Moto?> GetByIdAsync(long id)
        {
            return await _context.Motos.FindAsync(id);
        }

        public async Task<IEnumerable<Moto>> SearchByNomeAsync(string nome)
        {
            return await _context.Motos
                .Where(m => m.Nome.ToLower().Contains(nome.ToLower()))
                .ToListAsync();
        }

        public async Task<Moto> AddAsync(Moto entity)
        {
            _context.Motos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(Moto entity)
        {
            _context.Motos.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null) return false;
            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}