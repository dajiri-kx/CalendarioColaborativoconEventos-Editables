using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

public class CalendarController : Controller
{
    private readonly IEventoService _eventoService;

    public CalendarController(IEventoService eventoService)
    {
        _eventoService = eventoService;
    }

    public IActionResult Index()
    {
        return View();
    }

	[HttpGet]
	public async Task<JsonResult> GetEvents(DateTime start, DateTime end)
	{
		var eventos = await _eventoService.ObtenerEventosDelMesAsync(start, end);

		var resultado = eventos.Select(e => new
		{
			id = e.Id,
			title = e.Titulo,
			description = e.Descripcion,
			start = e.FechaInicio.ToString("yyyy-MM-ddTHH:mm:ss"),
			end = e.FechaFin.ToString("yyyy-MM-ddTHH:mm:ss"),
			color = e.Color ?? "#3788d8"
		});

		return Json(resultado);
	}

	[HttpPost]
    public async Task<JsonResult> CreateEvent([FromBody] EventoAD evento)
    {
        if (!ModelState.IsValid)
            return Json(new { success = false, message = "Datos inválidos." });

        var creado = await _eventoService.CrearEventoAsync(evento);

        return Json(new
        {
            success = true,
            id = creado.Id,
            title = creado.Titulo,
            start = creado.FechaInicio.ToString("yyyy-MM-ddTHH:mm:ss"),
            end = creado.FechaFin.ToString("yyyy-MM-ddTHH:mm:ss"),
            color = creado.Color ?? "#3788d8"
        });
    }



}
