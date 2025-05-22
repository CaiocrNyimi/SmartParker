namespace SmartParker.Domain.Entities
{
    public class LocalizacaoMoto
    {
        public long Id { get; set; }
        public long MotoId { get; set; }
        public long SetorId { get; set; }
        public DateTime DataHora { get; set; }
    }
}