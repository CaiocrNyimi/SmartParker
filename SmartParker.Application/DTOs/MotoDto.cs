namespace SmartParker.Application.DTOs
{
    public class MotoDto
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Fabricante { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;
        public string QRCode { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public long UsuarioId { get; set; }
    }
}
