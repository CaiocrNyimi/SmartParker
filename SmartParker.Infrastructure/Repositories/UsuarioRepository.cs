using Microsoft.EntityFrameworkCore;
using SmartParker.Domain.Entities;
using SmartParker.Domain.Interfaces;
using SmartParker.Infrastructure.Data;

namespace SmartParker.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SmartParkerDbContext _context;

        public UsuarioRepository(SmartParkerDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AddAsync(Usuario entity)
        {
            _context.Usuarios.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _context.Usuarios.FindAsync(id);
            if (entity == null) return false;

            _context.Usuarios.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(long id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Usuario entity)
        {
            var exists = await _context.Usuarios.AnyAsync(e => e.Id == entity.Id);
            if (!exists) return false;

            _context.Usuarios.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}