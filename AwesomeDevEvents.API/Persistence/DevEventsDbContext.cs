using AwesomeDevEvents.API.Entities;

namespace AwesomeDevEvents.API.Persistence
{
    public class DevEventsDbContext
    {
        // Objeto que vai armazenar o estado do nosso banco de dados
        public List<DevEvent>? DevEvents { get; set; }

        public DevEventsDbContext()
        {
            DevEvents = new List<DevEvent>();
        }
    }
}
