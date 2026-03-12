using WebApplication1.Models;

namespace WebApplication1.Services;

public class EventoService : IEventoService
{
    private static readonly List<EventoAD> _eventos = [
        new() { Id = 1, Titulo = "Reunión de equipo",      Descripcion = "Revisión semanal del proyecto",    FechaInicio = new(2026, 3, 12,  9, 0, 0), FechaFin = new(2026, 3, 12, 10,  0, 0), Color = "#3788d8" },
        new() { Id = 2, Titulo = "Entrega Hackathon",      Descripcion = "Fecha límite de entrega",          FechaInicio = new(2026, 3, 15, 23, 59, 0), FechaFin = new(2026, 3, 16,  0,  0, 0), Color = "#e74c3c" },
        new() { Id = 3, Titulo = "Presentación final",     Descripcion = "Demo del calendario colaborativo", FechaInicio = new(2026, 3, 18, 14, 0, 0), FechaFin = new(2026, 3, 18, 15, 30, 0), Color = "#2ecc71" },
        new() { Id = 4, Titulo = "Sprint Planning",        Descripcion = "Planificación del sprint 4",       FechaInicio = new(2026, 3, 20,  8, 0, 0), FechaFin = new(2026, 3, 20,  9,  0, 0), Color = "#f39c12" },
        new() { Id = 5, Titulo = "Taller de ASP.NET Core", Descripcion = "Tópicos avanzados MVC + AJAX",     FechaInicio = new(2026, 3, 25, 10, 0, 0), FechaFin = new(2026, 3, 25, 12,  0, 0), Color = "#9b59b6" },
    ];

    private static int _nextId = 6;

    public Task<List<EventoAD>> ObtenerEventosDelMesAsync(DateTime inicio, DateTime fin)
    {
        var resultado = _eventos
            .Where(e => e.FechaInicio < fin && e.FechaFin >= inicio)
            .OrderBy(e => e.FechaInicio)
            .ToList();

        return Task.FromResult(resultado);
    }

    public Task<EventoAD> CrearEventoAsync(EventoAD evento)
    {
        evento.Id = _nextId++;
        _eventos.Add(evento);
        return Task.FromResult(evento);
    }
}
