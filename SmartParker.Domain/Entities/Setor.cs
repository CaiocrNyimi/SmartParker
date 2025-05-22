namespace SmartParker.Domain.Entities
{
    public class Setor
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public long PatioId { get; set; }
    }
}