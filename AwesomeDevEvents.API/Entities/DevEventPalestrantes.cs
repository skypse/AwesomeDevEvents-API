namespace AwesomeDevEvents.API.Entities
{
    public class DevEventPalestrantes
    {
        // Propriedades dos Palestrantes
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? TituloPalestra { get; set; }
        public string? DescricaoPalestra { get; set; }
        public string? LinkedInProfile { get; set; }
        // Foreign Key
        public Guid DevEventId { get; set; }
    }
}