namespace SmartParker.Domain.Entities
{
    public class Moto
    {
        public long Id { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Cor { get; set; } = string.Empty;
        public long UsuarioId { get; set; }
        public long? LocalizacaoId { get; set; }
    }
}
