using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IEventoService
{
    Task<List<EventoAD>> ObtenerEventosDelMesAsync(DateTime inicio, DateTime fin);
    Task<EventoAD> CrearEventoAsync(EventoAD evento);
    Task<bool> EditarEventoAsync(EventoAD evento);
    Task<bool> EliminarEventoAsync(int id);
}
