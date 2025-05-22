namespace SmartParker.Domain.Entities
{
    public class Patio
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Localizacao { get; set; } = string.Empty;
    }
}