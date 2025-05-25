using SmartParker.Application.DTOs;
using SmartParker.Domain.Interfaces;
using SmartParker.Domain.Entities;

namespace SmartParker.Application.Services
{
    public class MotoService : IMotoService
    {
        private readonly IMotoRepository _motoRepository;

        public MotoService(IMotoRepository motoRepository)
        {
            _motoRepository = motoRepository;
        }

        public async Task<List<MotoDto>> GetAllAsync()
        {
            var motos = await _motoRepository.GetAllAsync();
            return motos.Select(m => new MotoDto
            {
                Id = m.Id,
                Nome = m.Nome,
                Fabricante = m.Fabricante,
                Placa = m.Placa,
                QRCode = m.QRCode,
                Status = m.Status,
                UsuarioId = m.UsuarioId
            }).ToList();
        }

        public async Task<MotoDto?> GetByIdAsync(long id)
        {
            var m = await _motoRepository.GetByIdAsync(id);
            return m is null ? null : new MotoDto
            {
                Id = m.Id,
                Nome = m.Nome,
                Fabricante = m.Fabricante,
                Placa = m.Placa,
                QRCode = m.QRCode,
                Status = m.Status,
                UsuarioId = m.UsuarioId
            };
        }

        public async Task<IEnumerable<MotoDto>> SearchByNomeAsync(string nome)
        {
            var motos = await _motoRepository.SearchByNomeAsync(nome);
            return motos.Select(m => new MotoDto
            {
                Id = m.Id,
                Nome = m.Nome,
                Fabricante = m.Fabricante,
                Placa = m.Placa,
                QRCode = m.QRCode,
                Status = m.Status,
                UsuarioId = m.UsuarioId
            });
        }

        public async Task<MotoDto> CreateAsync(MotoDto dto)
        {
            var moto = new Moto
            {
                Nome = dto.Nome,
                Fabricante = dto.Fabricante,
                Placa = dto.Placa,
                QRCode = dto.QRCode,
                Status = dto.Status,
                UsuarioId = dto.UsuarioId
            };
            await _motoRepository.AddAsync(moto);
            dto.Id = moto.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(long id, MotoUpdateDto dto)
        {
            var existing = await _motoRepository.GetByIdAsync(id);
            if (existing == null) return false;

            existing.Nome = dto.Nome;
            existing.Fabricante = dto.Fabricante;
            existing.Placa = dto.Placa;
            existing.QRCode = dto.QRCode;
            existing.Status = dto.Status;
            existing.UsuarioId = dto.UsuarioId;

            return await _motoRepository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var existing = await _motoRepository.GetByIdAsync(id);
            if (existing == null) return false;
            return await _motoRepository.DeleteAsync(id);
        }
    }
}