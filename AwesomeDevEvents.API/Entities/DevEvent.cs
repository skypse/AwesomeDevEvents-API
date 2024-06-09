namespace AwesomeDevEvents.API.Entities
{
    public class DevEvent
    {
        public DevEvent()
        {
            Palestrantes = new List<DevEventPalestrantes>();
            IsDeleted = false;
        }
        // Propriedades dos Eventos
        public Guid Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public List<DevEventPalestrantes> Palestrantes { get; set; }
        public bool IsDeleted { get; set; }

        // Método atualização
        // Setando quais informações posso atualizar?
        public void Update(string titulo, string descricao, DateTime dataInicio, DateTime dataFinal)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFinal = dataFinal;
        }

        // Método Delete
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
